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
    public partial class AddGroupForm : Form
    {
        public AddGroupForm()
        {
            InitializeComponent();

            NameField.Text = "Название";
            NameField.ForeColor = Color.Gray;
            SpecialtyField.Text = "Специальность";
            SpecialtyField.ForeColor = Color.Gray;
            CourseField.Text = "Курс";
            CourseField.ForeColor = Color.Gray;
            ChainPedField.Text = "Закрепленный преподаватель";
            ChainPedField.ForeColor = Color.Gray;
        }

        public Boolean isPedExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `teachers` WHERE `id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ChainPedField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }

            else
            {
                MessageBox.Show("Такого преподавателя не существует");
                return true;
            }
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (NameField.Text == "Название")
            {
                MessageBox.Show("Заполните все данные!");
                return;
            }
            if (SpecialtyField.Text == "Спецаильность")
            {
                MessageBox.Show("Заполните все данные!");
                return;
            }
            if (CourseField.Text == "Курс")
            {
                MessageBox.Show("Заполните все данные!");
                return;
            }
            if (ChainPedField.Text == "Закрепленный преподаватель")
            {
                MessageBox.Show("Заполните все данные!");
                return;
            }

            if (isPedExist())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `groups` (`Name`, `Specialty`, `Course`, `ChainPed`) VALUES (@name, @spec, @course, @ped);", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
            command.Parameters.Add("@spec", MySqlDbType.VarChar).Value = SpecialtyField.Text;
            command.Parameters.Add("@course", MySqlDbType.VarChar).Value = CourseField.Text;
            command.Parameters.Add("@ped", MySqlDbType.VarChar).Value = ChainPedField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Группа успешно добавлена");
                MainLabel_Click(sender, e);
            }
            else
                MessageBox.Show("Ошибка: группа не была добавлена");
            db.closeConnection();
        }

        private void NameField_Enter(object sender, EventArgs e)
        {
            if (NameField.Text == "Название")
            {
                NameField.Text = "";
                NameField.ForeColor = Color.Black;
            }
        }

        private void NameField_Leave(object sender, EventArgs e)
        {
            if (NameField.Text == "")
            {
                NameField.Text = "Название";
                NameField.ForeColor = Color.Gray;
            }
        }

        private void SpecialtyField_Enter(object sender, EventArgs e)
        {
            if (SpecialtyField.Text == "Специальность")
            {
                SpecialtyField.Text = "";
                SpecialtyField.ForeColor = Color.Black;
            }
        }

        private void SpecialtyField_Leave(object sender, EventArgs e)
        {
            if (SpecialtyField.Text == "")
            {
                SpecialtyField.Text = "Специальность";
                SpecialtyField.ForeColor = Color.Gray;
            }
        }

        private void CourseField_Enter(object sender, EventArgs e)
        {
            if (CourseField.Text == "Курс")
            {
                CourseField.Text = "";
                CourseField.ForeColor = Color.Black;
            }
        }

        private void CourseField_Leave(object sender, EventArgs e)
        {
            if (CourseField.Text == "")
            {
                CourseField.Text = "Курс";
                CourseField.ForeColor = Color.Gray;
            }
        }

        private void CountStudField_Enter(object sender, EventArgs e)
        {
            if (ChainPedField.Text == "Закрепленный преподаватель")
            {
                ChainPedField.Text = "";
                ChainPedField.ForeColor = Color.Black;
            }
        }

        private void CountStudField_Leave(object sender, EventArgs e)
        {
            if (ChainPedField.Text == "")
            {
                ChainPedField.Text = "Закрепленный преподаватель";
                ChainPedField.ForeColor = Color.Gray;
            }
        }
    }
}
