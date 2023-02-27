using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs
{
    public partial class AddMarkForm : Form
    {
        public AddMarkForm()
        {
            InitializeComponent();

            StudField.Text = "ID студента";
            StudField.ForeColor = Color.Gray;
            MarkField.Text = "Оценка";
            MarkField.ForeColor = Color.Gray;
            SubjectField.Text = "Предмет";
            SubjectField.ForeColor = Color.Gray;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (StudField.Text == "ID студента")
            {
                MessageBox.Show("Заполните все данные!");
                return;
            }
            if (MarkField.Text == "Оценка")
            {
                MessageBox.Show("Заполните все данные!");
                return;
            }
            if (SubjectField.Text == "Предмет")
            {
                MessageBox.Show("Заполните все данные!");
                return;
            }



            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `exam` (`stud`, `subject`, `mark`) VALUES (@stud, @sub, @mark);", db.getConnection());
            command.Parameters.Add("@stud", MySqlDbType.VarChar).Value = StudField.Text;
            command.Parameters.Add("@mark", MySqlDbType.VarChar).Value = MarkField.Text;
            command.Parameters.Add("@sub", MySqlDbType.VarChar).Value = SubjectField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Оценка успешно добавлен");
                MainLabel_Click(sender, e);
            }
            else
                MessageBox.Show("Ошибка: оценка не была добавлена");
            db.closeConnection();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void MainLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.Show();
        }
    }
}
