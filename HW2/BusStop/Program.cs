int capacity = 30;
var buses = new Dictionary<int, int> { { 1, 15 }, { 2, 20}, { 3, 25 } };
var waitingPass = new Dictionary<int, int> { { 1, 0 }, { 2, 0 }, { 3, 0 } };
var locker = new object();

DateTime duration = DateTime.Now.AddMilliseconds(10000);

Random random = new Random();

Thread passengersThread = new Thread(() => {
    while (DateTime.Now < duration)
    {
        var newPass = random.Next(1, 10);

        for (int i = 0; i < newPass; i++)
        {
            var bus = random.Next(1, 4);
            lock (locker)
            {
                waitingPass[bus]++;
                Console.WriteLine($"new passanger for bus {bus}");
            }
        }

        Thread.Sleep(1000);
    }
});

Thread busesThread = new Thread(() => {
    while (DateTime.Now < duration)
    {
        var busNum = random.Next(1, 4);
        Console.WriteLine($"bus {busNum} came");

        while (buses[busNum] != capacity && waitingPass[busNum] != 0)
        {
            lock (locker)
            {
                waitingPass[busNum]--;
                buses[busNum]++;
                Console.WriteLine($"passanger for bus {busNum} borded");
            }
            Thread.Sleep(100);
        }

        Thread.Sleep(1000);
    }
});

passengersThread.Start();
busesThread.Start();

passengersThread.Join();
busesThread.Join();
