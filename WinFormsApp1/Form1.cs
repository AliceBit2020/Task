namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        SynchronizationContext sc;
        public Form1()
        {
            InitializeComponent();
            sc=new SynchronizationContext();
        }


         int MyTask(int count)
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(count);
                sum += i;
                if (i == 5)
                    throw new Exception();
            }
            MessageBox.Show("ok");
            return sum;
        }


        void Test()
        {

            Console.WriteLine("Test void");
        }
        // Метод исполняемый как продолжение задачи.
        void ContinuationTask(Task<int> task)/////   идея CallBack только в разных потоках
        {
            sc.Send(b=>label1.Text = task.Result.ToString(),null);//// ждет
            sc.Send(b=> button1.Enabled = true,null);
            ///child
        }


        //void ContinuationTest(Task task)/////   идея CallBack только в разных потоках
        //{
          
        //    ///child
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //1.
            Task task1 = Task.Run(() => MyTask(100)).ContinueWith(ContinuationTask);
             Task task2 = Task.Run(() => MyTask(1000)).ContinueWith(ContinuationTask);

            //2.

            // Task<int> task = Task.Run(() => MyTask(10));/////  return  Task<int>

            //string res = task.Result.ToString();

            // label1.Text=res;





            button1.Enabled = false;
           
        }///  
    }
}
