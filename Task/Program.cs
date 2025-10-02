

namespace Taskk
{
    class Program
    {
        // Метод который будет выполнен асинхронно.
        static void MyTask()//// void Action() 
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine("\nMyTask: запущен в потоке # {0}", threadId);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.Write("+ ");
            }

            Console.WriteLine("\nMyTask: завершен в потоке # {0}", threadId);
        }

        static void Main()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine("Main: запущен в потоке # {0}", threadId);

            Action action = new Action(MyTask);

            Task task = new Task(MyTask); // Создание экземпляра задачи.            
             task.Start();                 // Запуск задачи на выполнение асинхронно в пуле потоков

            Task tsk = Task.Run(MyTask);/////   асинхронно в пуле потоков
            Task tsk1 = Task.Run(MyTask);


            tsk.Wait();  ////  catch exeption !!!!!!!!    block
            tsk1.Wait();

            Task.WaitAll(tsk, tsk1);///блокування поки не виконаються всі
            Task.WaitAny(tsk, tsk1);/// блокування поки не виконається один з них

            //task.RunSynchronously();    // Запуск задачи на выполнение синхронно.
            //MyTask(); // Запуск задачи на выполнение синхронно.
            for (int i = 0; i < 10; i++)
            {
                Console.Write(". ");
                Thread.Sleep(200);
            }

            //Console.WriteLine("\nMain: завершен в потоке # {0}", threadId);

            // Delay
            Console.ReadKey();
        }
    }
}
