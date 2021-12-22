namespace ConsoleApp.Task2;

public class Server2
{
    private static int _count;

    /// <summary>
    ///     Блокировка.
    /// </summary>
    private static readonly object Locker = new();

    /// <summary>
    ///     Получить колечество
    /// </summary>
    /// <returns></returns>
    public static int GetCount()
    {
        lock (Locker)
        {
            return _count;
        }
    }

    /// <summary>
    ///     Добавить
    /// </summary>
    /// <param name="value">Количество</param>
    public static void AddToCount(int value)
    {
        lock (Locker)
        {
            _count += value;
        }
    }
}