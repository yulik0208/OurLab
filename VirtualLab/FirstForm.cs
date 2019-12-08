using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLab.DB.Context;
using VirtualLab.DB.Models;

namespace VirtualLab
{
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Log In button implementation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заповніть всі поля");
                return;
            }
            
            var userLogged = new User();
            userLogged.Email = textBox1.Text;
            userLogged.Password = textBox2.Text;

            using (Context db = new Context())
            {
                var users = db.Users;
                foreach (var user in users)
                {
                    if(userLogged.Email == user.Email)
                    {
                        if(userLogged.Password == user.Password)
                        {
                            userLogged = user;
                            Form1 form = new Form1(userLogged);
                            this.Visible = false;
                            form.Visible = true;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Неправильний пароль");
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Цей email не зареєстрований");
                        return;
                    }
                }
            }
            

        }
        /// <summary>
        /// Registration button implementation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" )
            {
                MessageBox.Show("Заповніть всі поля");
                return;
            }
            if(textBox6.Text != textBox7.Text)
            {
                MessageBox.Show("Паролі не співпадають");
                return;
            }
            
            User userRegistration = new User();
            userRegistration.Name = textBox3.Text;
            userRegistration.Surname = textBox4.Text;
            userRegistration.Email = textBox5.Text;
            userRegistration.Password = textBox6.Text;
            userRegistration.Level = UserLevel.LOW;

            using (Context db = new Context())
            {
                var users = db.Users;
                foreach(var user in users)
                {
                    if(user.Email == userRegistration.Email)
                    {
                        MessageBox.Show("Цей email вже зареєстрований");
                        return;
                    }
                }
                db.Users.Add(userRegistration);
                db.SaveChanges();
                MessageBox.Show("Ви успішно зареєструвалися");
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void FirstForm_Load(object sender, EventArgs e)
        {
            textBox6.PasswordChar = '*';
            textBox7.PasswordChar = '*';
            textBox2.PasswordChar = '*';
        }

        private void FirstForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}