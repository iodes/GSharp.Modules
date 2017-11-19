using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Net.Mail;
using System.Windows.Forms;
using System.Text;
using System.Net.NetworkInformation;

namespace GSharp.Modules.Email
{

    public class GEmail : GModule
    {
        static MailMessage mail;
        static SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

        [GCommand("보내는 이메일(GMail){0} 받는 이메일 {1} 설정하기")]
        public static void setEmail(string FromEmail, string ToEmail)
        {
            mail = new MailMessage(FromEmail, ToEmail);
        }

        [GCommand("이메일 제목 {0} 과 내용 {1}")]
        public static void getSubjCont(string Subject, string Content)
        {
            try
            {
                mail.Subject = Subject;
                mail.Body = Content;

                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = Encoding.UTF8;
            }
            catch
            {
                MessageBox.Show("이메일을 먼저 설정해주세요");
            }
        }

        [GCommand("보내는 이메일 비밀번호 {0}")]
        public static void setPassword(string pw)
        {
            try
            {
                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = mail.From.Address,
                    Password = pw
                };
            }
            catch
            {
                MessageBox.Show("이메일을 먼저 설정해 주세요");
            }

        }
        [GCommand("이메일 보내기")]
        public static void sendEmail()
        {
            smtpClient.EnableSsl = true;

            //'보안 수준이 낮은 앱 허용' 이 able 되어 있어도 생기는 오류 떄문에 넣은 코드 입니다.
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            try
            {
                smtpClient.Send(mail);
                MessageBox.Show("성공적으로 이메일을 보냈습니다.");
            }
            catch (SmtpException)
            {
                bool connected = NetworkInterface.GetIsNetworkAvailable();
                if (connected)
                    MessageBox.Show("이메일 또는 비밀번호가 올바르지 않거나, Gmail 계정설정에서 '보안 수준이 낮은 앱 허용'이 Unable 되어있습니다. ");
                else
                    MessageBox.Show("네트워크 연결이 되어 있지 않습니다.");
            }
            finally
            {
                mail.Dispose();
            }
        }
    }
}