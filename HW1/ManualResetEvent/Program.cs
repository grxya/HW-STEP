using var manualResetEvent = new ManualResetEvent(false);

var mutex = new Mutex();

for (int i = 0; i < 5; i++)
{
    ThreadPool.QueueUserWorkItem(
    (p) =>
    {
        mutex.WaitOne();
        manualResetEvent.Set();

        Console.WriteLine($"Is ThreadPool Thread: {Thread.CurrentThread.IsThreadPoolThread}");
        Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");

        mutex.ReleaseMutex();
    });
}

Thread.Sleep(1000);
manualResetEvent.WaitOne();

Console.WriteLine("End of main");