namespace Task14
{
    static class Program
    {
        static int MyTask()
        {
            int result = 255;

            checked // Убрать комментарий.
            {
                result += 1;
            }

            Thread.Sleep(3000);

            return result;
        }

        static  void  Main()
        {
            Task<int> task = new Task<int>(MyTask);


            ///1,
            //task.Start();

            /////task.Wait();   

            //int a = task.Result;//////   блокировка потока и ожидание результата
            //Console.WriteLine(a);

            /////2,

            Action<Task<int>> continuation;

            continuation = t => Console.WriteLine("Result from continuation : " + task.Result);
            task.ContinueWith(continuation, TaskContinuationOptions.OnlyOnRanToCompletion);

            //continuation = t => Console.WriteLine("Inner Exception : " + task.Exception.InnerException.Message);
            //task.ContinueWith(continuation, TaskContinuationOptions.OnlyOnFaulted);

             task.Start();

            // Delay

            Console.WriteLine("Main After Result");
          Console.ReadKey();
        }
    }
}
