using System.Net.Sockets;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        private async void ShowList(ListBox listbox, List<object> items)
        {
            listbox.Items.Clear();
            foreach(var item in items)
            {
                listbox.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label2.Text = entername.Text;

            listBox.Visible = true;

            string host = "127.0.0.1";
            int port = 8888;
            using TcpClient client = new TcpClient();
            string? userName = entername.Text;//
            Console.WriteLine($"Добро пожаловать, {userName}");
            StreamReader? Reader = null;
            StreamWriter? Writer = null;

            try
            {
                client.Connect(host, port); //подключение клиента
                Reader = new StreamReader(client.GetStream());
                Writer = new StreamWriter(client.GetStream());
                if (Writer is null || Reader is null) return; // здесь нужно выкидывать ексепшн что не создан ридер врайтер
                // запускаем новый поток для получения данных
                Task.Run(() => ReceiveMessageAsync(Reader));
                // запускаем ввод сообщений
                await EnterUserAsync(Writer, userName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Writer?.Close();
            Reader?.Close();
        }

        async Task EnterUserAsync(StreamWriter writer, string userName)
        {
            // сначала отправляем имя
            await writer.WriteLineAsync(userName);
            await writer.FlushAsync();
            //Console.WriteLine("Для отправки сообщений введите сообщение и нажмите Enter");

            //while (true)
            //{
            //    string? message = Console.ReadLine();
            //    await writer.WriteLineAsync(message);
            //    await writer.FlushAsync();
            //}

        }



        async Task ReceiveMessageAsync(StreamReader reader)
        {
            while (true)
            {
                try
                {
                    // считываем ответ в виде строки
                    string? message = await reader.ReadLineAsync();
                    // если пустой ответ, ничего не выводим на консоль
                    if (string.IsNullOrEmpty(message)) continue;
                    Print(message);//вывод сообщения
                }
                catch
                {
                    break;
                }
            }
        }

        void Print(string message)
        {
            if (OperatingSystem.IsWindows())    // если ОС Windows
            {
                var position = Console.GetCursorPosition(); // получаем текущую позицию курсора
                int left = position.Left;   // смещение в символах относительно левого края
                int top = position.Top;     // смещение в строках относительно верха
                                            // копируем ранее введенные символы в строке на следующую строку
                Console.MoveBufferArea(0, top, left, 1, 0, top + 1);
                // устанавливаем курсор в начало текущей строки
                Console.SetCursorPosition(0, top);
                // в текущей строке выводит полученное сообщение
                Console.WriteLine(message);
                // переносим курсор на следующую строку
                // и пользователь продолжает ввод уже на следующей строке
                Console.SetCursorPosition(left, top + 1);
            }
            else Console.WriteLine(message);
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
