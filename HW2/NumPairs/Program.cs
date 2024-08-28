using System.Threading;

using var pairsGenerationEvent = new AutoResetEvent(false);
using var sumCountEvent = new AutoResetEvent(false);


ThreadPool.QueueUserWorkItem( (p) =>
{
    Random rand = new Random();
    using (StreamWriter streamWriter = new StreamWriter("pairs.txt"))
    {
        int num1, num2;
        for(int i = 0; i < 5; i++)
        {
            num1 = rand.Next(100);
            num2 = rand.Next(100);
            streamWriter.WriteLine($"{num1} {num2}");
        }
    }

    Console.WriteLine("Pairs generated");
    pairsGenerationEvent.Set();
});


ThreadPool.QueueUserWorkItem((p) =>
{
    pairsGenerationEvent.WaitOne();

    using (StreamReader streamReader = new StreamReader("pairs.txt"))
    using (StreamWriter streamWriter = new StreamWriter("sum.txt"))
    {
        string line;
        int result;
        for (int i = 0; i < 5; i++)
        {
            line = streamReader.ReadLine();
            var pair = line.Split(' ');
            result = Convert.ToInt32(pair[0]) + Convert.ToInt32(pair[1]);
            streamWriter.WriteLine(result);
        }
    }

    Console.WriteLine("Sum counted");
    sumCountEvent.Set();
});



ThreadPool.QueueUserWorkItem((p) =>
{
    sumCountEvent.WaitOne();

    using (StreamReader streamReader = new StreamReader("pairs.txt"))
    using (StreamWriter streamWriter = new StreamWriter("product.txt"))
    {
        string line;
        int result;
        for (int i = 0; i < 5; i++)
        {
            line = streamReader.ReadLine();
            var pair = line.Split(' ');
            result = Convert.ToInt32(pair[0]) * Convert.ToInt32(pair[1]);
            streamWriter.WriteLine(result);
        }
    }

    Console.WriteLine("Product counted");
});

Thread.Sleep(1000);
Console.WriteLine("Done");