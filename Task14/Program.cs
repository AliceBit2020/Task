namespace Task14
{
    static class Program
    {
        static int MyTask()
        {
            byte result = 255;//0..255

            checked // Убрать комментарий. при переповнені буде Exeption
            {
                result += 1;//256 --->0
            }

            Thread.Sleep(3000);

            return Convert.ToInt32(result);
        }

        static  void  Main()
        {
            Task<int> task = new Task<int>(MyTask);


            ///1,
            //task.Start();

            ///////task.Wait();   

            //int a = task.Result;//////   блокировка потока и ожидание результата
            //Console.WriteLine(a);

            /////2,

           

            /// task.Status  RanToCompletion 5 The task completed execution successfully.
                        
            
            task.ContinueWith(t => Console.WriteLine("Result from continuation : " + t.Result), TaskContinuationOptions.OnlyOnRanToCompletion);


            /// task.Status  Faulted	7	The task completed due to an unhandled exception.

            Action<Task<int>> continuation;

            continuation = t => Console.WriteLine("Inner Exception : " + t.Exception.InnerException.Message);

            task.ContinueWith(continuation, TaskContinuationOptions.OnlyOnFaulted);

            task.Start();

            // Delay

            Console.WriteLine("Main After Result");
          Console.ReadKey();
        }
    }
}
