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
    public partial class ChangeGroupForm : Form
    {
        public ChangeGroupForm()
        {
            InitializeComponent();
        }

        private void AutoBut_Click(object sender, EventArgs e)
        {
            this.dataGridViewGroup.Rows.Clear();
            LoadDataGroup();
            NameField.Text = dataGridViewGroup[2, 0].Value.ToString();
            SpecialtyField.Text = dataGridViewGroup[1, 0].Value.ToString();
            CourseField.Text = dataGridViewGroup[3, 0].Value.ToString();
            ChainPedField.Text = dataGridViewGroup[4, 0].Value.ToString();
        }

        public Boolean isIdExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `groups` WHERE `id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID_Field.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }

            else
            {
                MessageBox.Show("Такой группы не существует");
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

            SpecialtyField.Visible = true;
            SpecialtyField.Enabled = true;
            NameField.Visible = true;
            NameField.Enabled = true;
            CourseField.Visible = true;
            CourseField.Enabled = true;
            ChainPedField.Visible = true;
            ChainPedField.Enabled = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;

            buttonChangeID.Visible = false;
            buttonChangeID.Enabled = false;
            buttonChange.Visible = true;
            buttonChange.Enabled = true;

            AutoBut_Click(sender, e);
        }

        private void LoadDataGroup()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM groups WHERE `id` = @id", db.getConnection());
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
                dataGridViewGroup.Rows.Add(s);
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

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (SpecialtyField.Text == "")
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }
            if (NameField.Text == "")
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }
            if (CourseField.Text == "")
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }
            if (ChainPedField.Text == "")
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }

            if (isPedExist())
                return;


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `groups` SET `Name` = @Name, `Specialty` = @spec, `Course` = @course, `ChainPed` = @chainPed WHERE `groups`.`id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID_Field.Text;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = NameField.Text;
            command.Parameters.Add("@spec", MySqlDbType.VarChar).Value = SpecialtyField.Text;
            command.Parameters.Add("@course", MySqlDbType.VarChar).Value = CourseField.Text;
            command.Parameters.Add("@chainPed", MySqlDbType.VarChar).Value = ChainPedField.Text;

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
    }
}
