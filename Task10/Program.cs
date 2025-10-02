namespace Task10
{
    class Program
    {
        // Метод который будет выполнен как задача.
        static void MyTask()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(200);
                Console.Write("+");
            }
        }

        // Метод исполняемый как продолжение задачи.
        static void ContinuationTask(Task task)/////   идея CallBack 
        {

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(200);
                Console.Write("-");
            }
        }

        static void Main()
        {
            // Создание задачи.

            Task task = new Task(MyTask);//1

            // Создание продолжения задачи.
            Action<Task> continuation = new Action<Task>(ContinuationTask);//2  dif thread

            ////1.
            //Task taskContinuation1 = task.ContinueWith(continuation);

            ////2.

            //Task taskContinuation2 = task.ContinueWith(ContinuationTask);

            //3.

            Task taskContinuation3 = task.ContinueWith((task_MyTask) =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                for (int count = 0; count < 10; count++)
                {
                    Thread.Sleep(200);
                    Console.Write("-");
                }
            }
                
             );




            // Выполнение последовательности задач.
            task.Start(); ///MyTask

            taskContinuation3.Wait();


            // Delay.
            //  Console.ReadKey();
        }
    }
}
