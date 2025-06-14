namespace Task9
{
    class Program
    {       
        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            // Использование лямбда-оператора для определения задачи.
            Task task = Task.Factory.StartNew(new Action(() =>
                {
                    for (int i = 0; i < 80; i++)
                    {
                        Thread.Sleep(20);
                        Console.Write(".");
                    }
                }));

            // Ожидание завершения задачи.
            task.Wait();

            // Освобождение задачи. 
            task.Dispose();

            Console.WriteLine("Основной поток завершен.");

            // Delay
            Console.ReadKey();
        }
    }
}
