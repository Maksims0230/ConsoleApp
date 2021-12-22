namespace ConsoleApp.Task2;

public static class Server
{
    private static int _count;

    /// <summary>
    /// Блокировка, используемая для управления доступом,
    /// которая позволяет нескольким потокам производить
    /// считывание или получать монопольный доступ на запись.
    /// </summary>
    private static readonly ReaderWriterLockSlim CountLock = new();

    /// <summary>
    /// Получить колечество
    /// </summary>
    /// <returns></returns>
    public static int GetCount()
    {
        try
        {
            CountLock.EnterReadLock();
            return _count;
        }
        finally
        {
            CountLock.ExitReadLock();
        }
    }
    
    /// <summary>
    /// Добавить
    /// </summary>
    /// <param name="value">Количество</param>
    public static void AddToCount(int value)
    {
        try
        {
            CountLock.EnterWriteLock();
            checked
            {
                _count += value;
            }
        }
        finally
        {
            CountLock.ExitWriteLock();
        }
    }
}