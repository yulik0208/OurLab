using Limilabs.Client.SMTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLab.DB.Context;
using VirtualLab.DB.Models;

namespace VirtualLab
{
    public partial class Form1 : Form
    {
        User userLogged = new User();
        public Form1(User user)
        {
            userLogged = user;
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelTests.Visible = true;
            comboBoxTests.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            client.EnableSsl = true;


            MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
            // кому отправляем
            MailAddress to = new MailAddress("somemail@yandex.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            smtp.EnableSsl = true;
            smtp.Send(m);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = userLogged.Name + " " + userLogged.Surname;
            textBox2.Text = userLogged.Name;
            textBox3.Text = userLogged.Surname;
            textBox4.Text = userLogged.Email;
            textBox5.Text = userLogged.Name;
            textBox6.Text = userLogged.Surname;
            textBox7.Text = userLogged.Email;
            label2.Text = Enum.GetName(typeof(UserLevel), (int)userLogged.Level);
            textBox8.PasswordChar = '*';
            textBox9.PasswordChar = '*';
            textBox10.PasswordChar = '*';

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Введіть дані!");
                return;
            }
            using (Context db = new Context())
            {
                var userChange = new User();
                userChange.Name = textBox5.Text;
                userChange.Surname = textBox6.Text;
                userChange.Email = textBox7.Text;
                var users = db.Users;
                foreach (var user in db.Users)
                {
                    if (userLogged.Email == user.Email)
                    {
                        user.Name = userChange.Name;
                        user.Surname = userChange.Surname;
                        user.Email = userChange.Email;
                        userLogged.Name = userChange.Name;
                        userLogged.Surname = userChange.Surname;
                        userLogged.Email = userChange.Email;
                        textBox1.Text = userLogged.Name + " " + userLogged.Surname;
                        textBox2.Text = userLogged.Name;
                        textBox3.Text = userLogged.Surname;
                        textBox4.Text = userLogged.Email;
                        textBox5.Text = userLogged.Name;
                        textBox6.Text = userLogged.Surname;
                        textBox7.Text = userLogged.Email;
                        
                    }
                }

                db.SaveChanges();
                MessageBox.Show("Дані оновлено!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool checkedPass = false;
            if (textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Введіть дані!");
                return;
            }
            if (textBox9.Text != textBox10.Text)
            {
                MessageBox.Show("Паролі не співпадають!");
                return;
            }
            using (Context db = new Context())
            {
                var users = db.Users;
                foreach (var user in db.Users)
                {
                    if (textBox8.Text == user.Password && textBox8.Text == userLogged.Password)
                    {
                        user.Password = textBox9.Text;
                        checkedPass = true;
                    }
                }
                if (!checkedPass)
                {
                    MessageBox.Show("Ви ввели неправильний пароль");
                    return;
                }

                db.SaveChanges();
            }
            MessageBox.Show("Пароль змінено!");
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FirstForm form = new FirstForm();
            this.Visible = false;
            form.Visible = true;           
        }
    }
}
