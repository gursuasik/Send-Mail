using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SendMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool SendMail(string to, string subject, string message, string name)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential(textBox1.Text.Trim(), textBox2.Text.Trim());
                mail.To.Add(to);
                mail.Subject = subject;
                mail.From = new System.Net.Mail.MailAddress(textBox3.Text, name);
                mail.IsBodyHtml = true;
                mail.Body = message;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = cred;
                smtp.Send(mail);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
      //"Maili gönderilmesi için gerekli kodlar aşağıdadır. "
        private void Form1_Load(object sender, EventArgs e)
        {
            Char Karakter = '*';
            textBox2.PasswordChar = Karakter;
            toolTip1.SetToolTip(textBox1, "Kullanıcı Adı Girilecek");  
            toolTip1.SetToolTip(textBox3, "Mail'in Kime Gidileceği Girilecek");
            toolTip1.SetToolTip(textBox4, "Tekrar Kullanıcı Adı Girilecek");
            //
            toolTip1.ToolTipTitle = "Mail Bilgileri";
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;   
        }
   // "Gönderme Butonuna Yazılacak Kodlar Aşağıda bulunmaktadır."
   private void button1_Click(object sender, EventArgs e)
        {
            if (SendMail(textBox3.Text, textBox5.Text, textBox6.Text, textBox4.Text))
                MessageBox.Show("Mail gönderme başarılı");

            else
                MessageBox.Show("Mail gönderme başarısız");
            String Metin;
            Metin = textBox2.Text;
            if (Metin.Length <= 0) 
            {
                errorProvider1.SetError(textBox2, "Şifreyi Girmek Zorundasınız");  
            }
        }
    }
}




