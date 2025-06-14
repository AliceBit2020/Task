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
        static void ContinuationTask(Task task)/////   идея CallBack только в разных потоках
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
            Task taskContinuation = task.ContinueWith(continuation);

            // Выполнение последовательности задач.
            task.Start();

            // Delay.
            Console.ReadKey();
        }
    }
}
