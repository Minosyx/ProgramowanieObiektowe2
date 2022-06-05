using System;
using System.Threading;

namespace AsynchFramework
{
    public delegate string AsyncCaller(int callDuration, out int threadID);
    public class AsyncDemo
    {
        public string TestMethod(int callDuration, out int threadID)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadID = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration);
        }
    }
    class Program
    {
        static int threadID;
        static void Main(string[] args)
        {
            AsyncDemo ad = new AsyncDemo();
            AsyncCaller caller = new AsyncCaller(ad.TestMethod);
            IAsyncResult result = caller.BeginInvoke(3000, out threadID, new AsyncCallback(CallbackMethod), caller);
            Console.WriteLine("Press Enter to close application.");
            Console.ReadLine();
        }
        static void CallbackMethod(IAsyncResult ar)
        {
            AsyncCaller caller = (AsyncCaller)ar.AsyncState;
            string returnValue = caller.EndInvoke(out threadID, ar);
            Console.WriteLine("Thread {0}, return value \"{1}\".",
            threadID, returnValue);
        }
    }
}
