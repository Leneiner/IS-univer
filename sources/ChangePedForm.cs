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
    public partial class ChangePedForm : Form
    {
        public ChangePedForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainLabel_Click(object sender, EventArgs e)
        {

            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        public Boolean isIdExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `teachers` WHERE `id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID_Field.Text;

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

        private void buttonChangeID_Click(object sender, EventArgs e)
        {
            if (isIdExist())
                return;

            ID_Field.Visible = false;
            ID_Field.Enabled = false;
            HeadID.Visible = false;

            SurnameField.Visible = true;
            SurnameField.Enabled = true;
            NameField.Visible = true;
            NameField.Enabled = true;
            SecondNameField.Visible = true;
            SecondNameField.Enabled = true;
            SubjectField.Visible = true;
            SubjectField.Enabled = true;

            buttonChangeID.Visible = false;
            buttonChangeID.Enabled = false;
            buttonChange.Visible = true;
            buttonChange.Enabled = true;

            AutoBut_Click(sender, e);

        }

        private void LoadDataTeachers()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM teachers WHERE `id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID_Field.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[2].ToString();
                data[data.Count - 1][2] = reader[1].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();

            }

            reader.Close();

            db.closeConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void AutoBut_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            LoadDataTeachers();
            SurnameField.Text = dataGridView1[1, 0].Value.ToString();
            NameField.Text = dataGridView1[2, 0].Value.ToString();
            SecondNameField.Text = dataGridView1[3, 0].Value.ToString();
            SubjectField.Text = dataGridView1[4, 0].Value.ToString();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (NameField.Text == "")
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }
            if (SurnameField.Text == "")
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }
            if (SecondNameField.Text == "")
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }
            if (SubjectField.Text == "")
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `teachers` SET `Name` = @Name, `Surname` = @surname, `SecondName` = @secname, `Subject` = @subject WHERE `teachers`.`id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID_Field.Text;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = NameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameField.Text;
            command.Parameters.Add("@secname", MySqlDbType.VarChar).Value = SecondNameField.Text;
            command.Parameters.Add("@subject", MySqlDbType.VarChar).Value = SubjectField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запрос выполнен");

            }
            else
                MessageBox.Show("Запрос не выполнен");
            db.closeConnection();
            AutoBut_Click(sender, e);
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
