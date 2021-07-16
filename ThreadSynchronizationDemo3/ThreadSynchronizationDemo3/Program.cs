using System;
using System.IO;
using System.Threading;

namespace ThreadSynchronizationDemo3
{
    class Program
    {
        static Mutex _mutex = new Mutex();
        static void Main(string[] args)
        {
            Console.Write("Enter steps: ");
            int step = int.Parse(Console.ReadLine());
            Thread evenSeries = new Thread(new ThreadStart
                    (delegate {
                        PrintNumbers("even", step);
                    })
                );

            Thread oddSeries = new Thread(new ThreadStart
                    (delegate {
                        PrintNumbers("odd", step);
                    })
                );

            Thread primeSeries = new Thread(new ThreadStart
                    (delegate {
                        PrintNumbers("prime", step);
                    })
                );
            evenSeries.Start();
            oddSeries.Start();
            primeSeries.Start();
        }
        static void PrintNumbers(string type, int step)
        {
            _mutex.WaitOne();
            FileStream outputFile = new FileStream(@"F:\C# Programming and Concepts\Threading\ThreadSynchronizationDemo3\output.txt",
                                            FileMode.Append,
                                            FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                int i;
                int count;
                writer.WriteLine();
                if (type == "odd")
                {
                    Console.WriteLine($"Event:{Thread.CurrentThread.ManagedThreadId} printing even series has started..");
                    i = 0;
                    count = 0;
                    while (count < step)
                    {
                        if (i % 2 != 0)
                        {
                            writer.Write($"{i} ");
                            count++;
                        }
                        i++;
                    }
                    Console.WriteLine($"Event:{Thread.CurrentThread.ManagedThreadId} printing even series has been completed.");
                }
                else if (type == "even")
                {
                    Console.WriteLine($"Event:{Thread.CurrentThread.ManagedThreadId} printing odd series has started..");
                    i = 0;
                    count = 0;
                    while (count < step)
                    {
                        if (i % 2 == 0)
                        {
                            writer.Write($"{i} ");
                            count++;
                        }
                        i++;
                    }
                    Console.WriteLine($"Event:{Thread.CurrentThread.ManagedThreadId} printing odd series has been completed.");
                }
                else
                {
                    Console.WriteLine($"Event:{Thread.CurrentThread.ManagedThreadId} printing prime series has started..");
                    i = 2;
                    count = 0;
                    while (count < step)
                    {
                        if (i == 2 || CheckPrime(i))
                        {
                            writer.Write($"{i} ");
                            count++;
                        }
                        i++;
                    }
                    Console.WriteLine($"Event:{Thread.CurrentThread.ManagedThreadId} printing prime series has been completed.");
                }
            }
            _mutex.ReleaseMutex();
        }
        static bool CheckPrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
