namespace Task2
{
    class Program
    {
        /// <summary>
        /// obj
        /// count
        /// </summary>
        static void MyTask()
        {
            int local=8;
            Console.WriteLine("MyTask: CurrentId {0} c ManagedThreadId {1} запущен.",
                Task.CurrentId, Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(2000);

            Console.WriteLine("MyTask: CurrentId " + Task.CurrentId + " завершен.");
        }

        static void Main()
        {
            Console.WriteLine("Main: Task.CurrentId = {0}",  // Main - задача?
                Task.CurrentId == null ? "null" : Task.CurrentId.ToString());

            Task task1 = new Task(MyTask);
            Task task2 = new Task(MyTask);

            task1.Start();
            task2.Start();

            Console.WriteLine("Id задачи task1: " + task1.Id);
            Console.WriteLine("Id задачи task2: " + task2.Id);

            // Delay
            Console.ReadKey();
        }
    }
}
