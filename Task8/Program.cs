namespace Task8
{
    class Program
    {
        static void MyTask()
        {
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }
        }

        static void Main()
        {
            // Вариант 1.
            Task task = Task.Factory.StartNew(MyTask);
            //При запуске задачи через TaskFactory, вызов метода Start() не требуется.
           //// task.Start();

            // Вариант 2.
            //TaskFactory factory = new TaskFactory();
            //Task task = factory.StartNew(MyTask);

           Task task1 = Task.Run(MyTask);//////   рекомендованный вариант

          //  task1.Wait();


            // Delay
           Console.ReadKey();
        }
    }
}
