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
    public partial class AddPedForm : Form
    {
        public AddPedForm()
        {
            InitializeComponent();

            NameField.Text = "Имя";
            NameField.ForeColor = Color.Gray;
            SurnameField.Text = "Фамилия";
            SurnameField.ForeColor = Color.Gray;
            SecondNameField.Text = "Отчество";
            SecondNameField.ForeColor = Color.Gray;
            SubjectField.Text = "Предмет";
            SubjectField.ForeColor = Color.Gray;
        }

        

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
        }

        private void MainLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (NameField.Text == "Имя")
            {
                MessageBox.Show("Заполните все данные!");
                return;
            }
            if (SurnameField.Text == "Фамилия")
            {
                MessageBox.Show("Заполните все данные!");
                return;
            }
            if (SecondNameField.Text == "Отчество")
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
            MySqlCommand command = new MySqlCommand("INSERT INTO `teachers` (`Name`, `Surname`, `SecondName`, `Subject`) VALUES (@name, @surname, @secName, @subject);", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameField.Text;
            command.Parameters.Add("@secName", MySqlDbType.VarChar).Value = SecondNameField.Text;
            command.Parameters.Add("@subject", MySqlDbType.VarChar).Value = SubjectField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Преподаватель успешно добавлен");
                MainLabel_Click(sender, e);
            }
            else
                MessageBox.Show("Ошибка: преподаватель не был добавлен");
            db.closeConnection();
        }

        private void SurnameField_Enter(object sender, EventArgs e)
        {
            if (SurnameField.Text == "Фамилия")
            {
                SurnameField.Text = "";
                SurnameField.ForeColor = Color.Black;
            }
        }

        private void SurnameField_Leave(object sender, EventArgs e)
        {
            if (SurnameField.Text == "")
            {
                SurnameField.Text = "Фамилия";
                SurnameField.ForeColor = Color.Gray;
            }
        }

        private void NameField_Enter(object sender, EventArgs e)
        {
            if (NameField.Text == "Имя")
            {
                NameField.Text = "";
                NameField.ForeColor = Color.Black;
            }
        }

        private void NameField_Leave(object sender, EventArgs e)
        {
            if (NameField.Text == "")
            {
                NameField.Text = "Имя";
                NameField.ForeColor = Color.Gray;
            }
        }

        private void SecondNameField_Enter(object sender, EventArgs e)
        {
            if (SecondNameField.Text == "Отчество")
            {
                SecondNameField.Text = "";
                SecondNameField.ForeColor = Color.Black;
            }
        }

        private void SecondNameField_Leave(object sender, EventArgs e)
        {
            if (SecondNameField.Text == "")
            {
                SecondNameField.Text = "Отчество";
                SecondNameField.ForeColor = Color.Gray;
            }
        }

        private void SubjectField_Enter(object sender, EventArgs e)
        {
            if (SubjectField.Text == "Предмет")
            {
                SubjectField.Text = "";
                SubjectField.ForeColor = Color.Black;
            }
        }

        private void SubjectField_Leave(object sender, EventArgs e)
        {
            if (SubjectField.Text == "")
            {
                SubjectField.Text = "Предмет";
                SubjectField.ForeColor = Color.Gray;
            }
        }
    }
}
