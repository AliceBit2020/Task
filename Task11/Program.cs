namespace Task11
{
    struct Context
    {
        public int a;
        public int b;
    }

    class Program
    {
        // Метод который будет возвращать результат.
        static int Sum(object arg)
        {
            int a = ((Context)arg).a;
            int b = ((Context)arg).b;

            Thread.Sleep(5000);

            return a + b;
        }
        static void Print(object arg)
        {
            int a = ((Context)arg).a;
            int b = ((Context)arg).b;

            Thread.Sleep(2000);

            Console.WriteLine(a + b);
        }


        static void PrintContin(Task<int> task)
        {
          

            Thread.Sleep(2000);

            Console.WriteLine($"Sum:  {task.Result}");
        }

        static int PrintContin2(Task<int> task, bool flag)
        {

            /*
            try catch
             * */
            Thread.Sleep(2000);

            Console.WriteLine($"Sum:  {task.Result}");
            return 0;
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            Context context;
            context.a = 2;
            context.b = 3;

            //Task<int> task;

            //// 1 вариант
            //task = new Task<int>(Sum, context);
            //task.Start();

            //// 2 вариант
            //TaskFactory<int> factory = new TaskFactory<int>();
            //task = factory.StartNew(Sum, context);

            //// 3 вариант
            //task = Task<int>.Factory.StartNew(Sum, context);

            //task.Wait();/////   thread.join()

            //Console.WriteLine("Результат выполнения задачи Sum = " + task.Result);//// ждем результат!!!!!!!!!!!!!

            //Console.WriteLine("Основной поток завершен.");



            //////  06.04  Lesson

            Task<int> taskInt = Task.Run<int>(() => Sum(context));

            Task task = Task.Run(() => Print(context));

            task.Wait();
            Console.WriteLine(taskInt.Result);

            ///  a)Continue

            var task1 = Task.Run<int>(() => Sum(context)).ContinueWith(PrintContin);

            task1.Wait();

            /////  b)Continue

            //Task.Run<int>(() => Sum(context)).ContinueWith(PrintContin).Wait(); 


            ///  1. ContinueWith<>  (PrintContin2)  получить код Метод continuation возвращает значение !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            ///  2. Как передать дополнительный параметр в  Метод continuation!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


            // Delay
            // Console.ReadKey();
        }
    }
}
