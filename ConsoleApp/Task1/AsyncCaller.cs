namespace ConsoleApp.Task1;

public partial class AsyncCaller
{
    /// <summary>
    /// Обработчик события
    /// </summary>
    private static EventHandler? _handler;

    /// <summary>
    /// Вызов
    /// </summary>
    public readonly Func<int, object, EventArgs, bool> Invoke = (t, s, a) =>
        Task.Factory.StartNew(() => _handler?.Invoke(s, a)).Wait(t);

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="handler">Обработчик события</param>
    public AsyncCaller(EventHandler? handler) => 
        _handler = handler;
}