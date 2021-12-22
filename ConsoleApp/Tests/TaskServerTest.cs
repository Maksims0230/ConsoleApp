using ConsoleApp.Task1;
using ConsoleApp.Task2;
using NUnit.Framework;

namespace ConsoleApp.Tests;

[TestFixture]
public class TaskServerTest
{
    [Test]
    [TestCase(300, null!, null, 300)]
    [TestCase(500, null, null, 200)]
    [TestCase(200, null, null, 500)]
    public void InvokeTest(int time, object sender, EventArgs args, int timeSleep = 0)
    {
        var result = new AsyncCaller((_, _) => Thread.Sleep(timeSleep))
            .Invoke(time, sender, args);
        
        Assert.AreEqual(timeSleep < time, result);
    }

    [Test]
    public void AddToCountTest()
    {
        var tasks = new List<Task>();
        foreach (var i in Enumerable.Range(0, 1000))
        {
            tasks.AddRange(Enumerable.Range(0, 10).Select(_ => Task.Factory.StartNew(Server.GetCount)));
            tasks.Add(Task.Factory.StartNew(() => Server.AddToCount(i)));
        }
        Task.WaitAll(tasks.ToArray());
        Assert.AreEqual(Enumerable.Range(0, 1000).Sum(), Server.GetCount());
    }
    
    [Test]
    public void AddToCountTest2()
    {
        var tasks = new List<Task>();
        foreach (var i in Enumerable.Range(0, 1000))
        {
            tasks.AddRange(Enumerable.Range(0, 10).Select(_ => Task.Factory.StartNew(Server2.GetCount)));
            tasks.Add(Task.Factory.StartNew(() => Server2.AddToCount(i)));
        }
        Task.WaitAll(tasks.ToArray());
        Assert.AreEqual(Enumerable.Range(0, 1000).Sum(), Server2.GetCount());
    }
}