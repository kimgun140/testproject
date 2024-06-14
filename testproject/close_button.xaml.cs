using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testproject
{
    /// <summary>
    /// close_button.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class close_button : Page
    {
        signup signup = new signup();
        public close_button()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NetworkStream stream = signup.client.GetStream();
            byte[] data1;
            string send_msg = "Close_msg";
            data1 = null;
            data1 = new byte[256];

            data1 = Encoding.UTF8.GetBytes(send_msg);
            stream.Write(data1, 0, data1.Length);//전송할 데이터의 바이트 배열, 전송을 시작할 배열의 인덱스, 전송할 데이터의 길이.
            Thread.Sleep(100);


            data1 = null;
            data1 = new byte[256];
            int bytes = stream.Read(data1, 0, data1.Length);//받는 데이터의 바이트배열, 인덱스, 길이
            string responses = Encoding.UTF8.GetString(data1, 0, bytes); // 서버가 종료 시그널 받고 "종료"라고 보낼거임 
            if (responses == "종료\n")
            {
                stream.Close();
                signup.client.Close();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }
}
