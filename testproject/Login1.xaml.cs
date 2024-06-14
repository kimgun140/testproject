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
    /// Login1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login1 : Page
    {
        public Login1()
        {
            InitializeComponent();
        }
        public int CC_login(string id, string pw) // 고객  로그인 
        {
            try
            {
                List<string> aaaa = new List<string>();
                byte[] data;

                TcpClient client = new TcpClient("10.10.21.111", 5558); //연결객체
                NetworkStream stream = client.GetStream(); //데이터 전송에 사용된 스트림


                string send_msg;

                // 회원가입 플래그 보내기 

                data = null;
                data = new byte[256];
                send_msg = "_for_cc_login_";// 시그널
                data = Encoding.UTF8.GetBytes(send_msg);
                stream.Write(data, 0, data.Length);//전송할 데이터의 바이트 배열, 전송을 시작할 배열의 인덱스, 전송할 데이터의 길이.

                Thread.Sleep(100);


                data = null;
                data = new byte[256];
                send_msg = id;// 아이디
                data = Encoding.UTF8.GetBytes(send_msg);
                stream.Write(data, 0, data.Length);//전송할 데이터의 바이트 배열, 전송을 시작할 배열의 인덱스, 전송할 데이터의 길이.

                Thread.Sleep(100);



                data = null;
                data = new byte[256];
                send_msg = pw;// 비밀번호 
                data = Encoding.UTF8.GetBytes(send_msg);
                stream.Write(data, 0, data.Length);//전송할 데이터의 바이트 배열, 전송을 시작할 배열의 인덱스, 전송할 데이터의 길이.

                Thread.Sleep(100);



                //read
                data = null;
                data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length);//받는 데이터의 바이트배열, 인덱스, 길이
                string responses = Encoding.UTF8.GetString(data, 0, bytes);
                MessageBox.Show(responses);
                if (responses == "로그인 되었습니다.\n")
                {
                    //NavigationService.Navigate(
                    //new Uri("/chatting.xaml", UriKind.Relative));
                    MessageBox.Show("responses");
                    NavigationService.Navigate(
                    new Uri("/chatting.xaml", UriKind.Relative));
                    return 1;


                }

                stream.Close();
                client.Close();
                return -1;

            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
                return -1;
            }
        }
        private void btn_signup_Click(object sender, RoutedEventArgs e)
            // 회원가입창으로 이동 
        {
            NavigationService.Navigate(
                        new Uri("/realsignup.xaml", UriKind.Relative));
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string ccid = MyTextBoxid.Text.ToUpper(); // 대문자로 변환 
            string ccpw = MyTextBoxpw.Text.ToUpper();// 대문자로 변환 
            CC_login(ccid,ccpw);
            MyTextBoxid.Clear();
            MyTextBoxpw.Clear();
        }

        private void MyTextBoxid_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MyTextBoxid.Text == "ID")
            {
                MyTextBoxid.Clear();
            }
        }

        private void MyTextBoxpw_GotFocus(object sender, RoutedEventArgs e)
        {
            if(MyTextBoxpw.Text == "PassWord")
            {
                MyTextBoxpw.Clear();
            }
        }

        private void MyTextBoxpw_LostFocus(object sender, RoutedEventArgs e)
        {
             if (MyTextBoxpw.Text == "")
            {
                MyTextBoxpw.Text = "Password";
            }
        }

        private void MyTextBoxid_LostFocus(object sender, RoutedEventArgs e)
        {
             if (MyTextBoxid.Text == "")
            {
                MyTextBoxid.Text = "ID";
            }
        }
    }
}
