using var autoResetEvent = new AutoResetEvent(false);

var mutex = new Mutex();

for (int i = 0; i < 5; i++)
{
    ThreadPool.QueueUserWorkItem(
    (p) =>
    {
        mutex.WaitOne();
        autoResetEvent.Set();

        Console.WriteLine($"Is ThreadPool Thread: {Thread.CurrentThread.IsThreadPoolThread}");
        Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");

        mutex.ReleaseMutex();
    });
}

Thread.Sleep(1000);
autoResetEvent.WaitOne();

Console.WriteLine("End of main");