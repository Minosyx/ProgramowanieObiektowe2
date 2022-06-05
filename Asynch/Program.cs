using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asynch
{
    class Program
    {
        static int x = 15;
        static object locker = new();
        //int initial = 0;
        //ReaderWriterLock rwl = new ReaderWriterLock();
        //public void myRead(object threadName)
        //{
        //    //Accquire Reader Lock.
        //    rwl.AcquireReaderLock(Timeout.Infinite);
        //    Console.WriteLine("Read start: Thread: " + threadName + " " + initial);
        //    if (threadName.ToString() == "Thread 1")
        //        //Irregular sleeps makes more chances of
        //        //Multiple threads trying to access it
        //        //at same time
        //        Thread.Sleep(10);
        //    else
        //        Thread.Sleep(250);
        //    Console.WriteLine("Read end  : Thread: " + threadName + " " + initial);
        //    rwl.ReleaseReaderLock();
        //    //Release Lock
        //}
        //public void myWrite()
        //{
        //    rwl.AcquireWriterLock(Timeout.Infinite);
        //    Console.WriteLine("\nWriter start: " + initial);
        //    initial++; //Writing
        //    Console.WriteLine("Writer End: " + initial);
        //    rwl.ReleaseWriterLock();
        //    Console.WriteLine();
        //}
        static async Task Main(string[] args)
        {
            try
            {
                //int[] tab = { 1, 5, 3, 6, 2, 0, -5, 6, 3 };
                //Thread t = new Thread(Counter);
                //Thread t1 = new Thread(Incrementer);
                //Thread t2 = new Thread(delegate ()
                //{
                //    Array.Sort(tab);
                //    foreach (var item in tab)
                //    {
                //        Console.Write($"tab: {item}");
                //    }
                //});
                //ParameterizedThreadStart p = delegate (object o)
                //{
                //    Console.WriteLine(o);
                //};
                //Thread t3 = new Thread(p);
                //t.Start(15);
                //t1.Start(20);
                //t2.Start();
                //t3.Start(2137);

                ////t.Join();
                //Console.ReadLine();

                //Thread t = new Thread(Incrementer); // locker pozwala na zakazanie dostepu do sekcji krytycznej
                //Thread t1 = new Thread(Counter); // musi by wczesniej zdefiniowany
                //t.Start(50);
                //t1.Start(20);

                //Program p = new();

                //for (int i = 0; i < 5; i++)
                //{
                //    Thread t1 = new Thread(p.myRead); //Reader Thread
                //    //Writer Thread
                //    Thread t2 = new Thread(new ThreadStart(p.myWrite));
                //    //Reader Again
                //    Thread t3 = new Thread(p.myRead);
                //    //Start all threads
                //    t1.Start("Thread 1");
                //    t2.Start();
                //    t3.Start("Thread 3");
                //    //Wait for them to finish execution
                //    t1.Join();
                //    t2.Join();
                //    t3.Join();
                //}
                //Console.Read();

                //ThreadPool.QueueUserWorkItem(ThreadProc);
                //Console.WriteLine("Main thread does some work, then sleeps.");
                //Thread.Sleep(1000);

                //Console.WriteLine("Main thread exits.");

                //Task t = Countdown(15);
                //Task t1 = Countdown(24);
                //Task.WaitAll(t, t1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        static async Task Countdown(int c)
        {
            while (c > 0)
            {
                Console.WriteLine(c);
                await Task.Delay(1000);
                c--;
            }
        }
        static void ThreadProc(Object stateInfo)
        {
            // No state object was passed to QueueUserWorkItem, so stateInfo is null.
            Console.WriteLine("Hello from the thread pool.");
        }
        public static void Incrementer(object c)
        {
            int i = 0;
            while (x < (int)c)
            {
                //lock (locker)
                //{
                Monitor.Enter(locker); // takie samo działanie jak locker
                    Console.WriteLine(x);
                    Thread.Sleep(500);
                    x++;
                Monitor.Exit(locker);
                //}
            }
        }
        public static void Counter(object c)
        {
            int i = (int)c;
            while (x > 0)
            {
                lock (locker)
                {
                    Console.WriteLine(x);
                    Thread.Sleep(1000);
                    x--;
                }
            }
        }
    }
}
