namespace Task4
{
    class Program
    {
        static void MyTask()
        {
            // Thread.CurrentThread.IsBackground = false; // Снять комментарий.   сделать поток основным а не фоновым

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }
        }

        static void Main()
        {
            Task task = new Task(MyTask);
            task.Start();

            Thread.Sleep(500); // Время на запуск задачи.

            Console.WriteLine("\nMain завершен.");

            // Delay
            //Console.ReadKey();
        }
    }
}
