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
            Console.WriteLine($"����� ����������, {userName}");
            StreamReader? Reader = null;
            StreamWriter? Writer = null;

            try
            {
                client.Connect(host, port); //����������� �������
                Reader = new StreamReader(client.GetStream());
                Writer = new StreamWriter(client.GetStream());
                if (Writer is null || Reader is null) return; // ����� ����� ���������� ������� ��� �� ������ ����� �������
                // ��������� ����� ����� ��� ��������� ������
                Task.Run(() => ReceiveMessageAsync(Reader));
                // ��������� ���� ���������
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
            // ������� ���������� ���
            await writer.WriteLineAsync(userName);
            await writer.FlushAsync();
            //Console.WriteLine("��� �������� ��������� ������� ��������� � ������� Enter");

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
                    // ��������� ����� � ���� ������
                    string? message = await reader.ReadLineAsync();
                    // ���� ������ �����, ������ �� ������� �� �������
                    if (string.IsNullOrEmpty(message)) continue;
                    Print(message);//����� ���������
                }
                catch
                {
                    break;
                }
            }
        }

        void Print(string message)
        {
            if (OperatingSystem.IsWindows())    // ���� �� Windows
            {
                var position = Console.GetCursorPosition(); // �������� ������� ������� �������
                int left = position.Left;   // �������� � �������� ������������ ������ ����
                int top = position.Top;     // �������� � ������� ������������ �����
                                            // �������� ����� ��������� ������� � ������ �� ��������� ������
                Console.MoveBufferArea(0, top, left, 1, 0, top + 1);
                // ������������� ������ � ������ ������� ������
                Console.SetCursorPosition(0, top);
                // � ������� ������ ������� ���������� ���������
                Console.WriteLine(message);
                // ��������� ������ �� ��������� ������
                // � ������������ ���������� ���� ��� �� ��������� ������
                Console.SetCursorPosition(left, top + 1);
            }
            else Console.WriteLine(message);
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
