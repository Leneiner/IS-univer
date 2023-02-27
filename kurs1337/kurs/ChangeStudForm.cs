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
    public partial class ChangeStudForm : Form
    {
        public ChangeStudForm()
        {
            InitializeComponent();
        }

        private void MainLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void LoadComboBox()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM groups ORDER BY id", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();

            }

            reader.Close();

            db.closeConnection();

            foreach (string[] s in data)
                dataGridViewGroup.Rows.Add(s);
            int countRows = 0;
            while (countRows < dataGridViewGroup.Rows.Count)
            {
                GroupComboBox.Items.Add(dataGridViewGroup[1, countRows].Value.ToString());
                countRows++;
            }
        }

        public Boolean isGroupExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `groups` WHERE `name` = @group", db.getConnection());
            command.Parameters.Add("@group", MySqlDbType.VarChar).Value = GroupComboBox.Text;

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
            HeadID.Visible=false;

            SurnameField.Visible = true;
            SurnameField.Enabled = true;
            NameField.Visible = true;
            NameField.Enabled = true;
            SecondNameField.Visible = true;
            SecondNameField.Enabled = true;
            GroupComboBox.Visible = true;
            GroupComboBox.Enabled = true;

            buttonChangeID.Visible = false;
            buttonChangeID.Enabled = false;
            buttonChange.Visible = true;
            buttonChange.Enabled = true;
            
            LoadComboBox();
            AutoBut_Click(sender, e);





        }

        private void LoadData()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM students WHERE `id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID_Field.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();

            }

            reader.Close();

            db.closeConnection();

           foreach (string[] s in data)
              dataGridView1.Rows.Add(s);
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

        public Boolean isIdExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `students` WHERE `id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID_Field.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }

            else
            {
                MessageBox.Show("Такого студента не существует");
                return true;
            }
        }

        public void AutoBut_Click(object sender, EventArgs e)
        {
            
              this.dataGridView1.Rows.Clear();
                LoadData();
              SurnameField.Text = dataGridView1[2, 0].Value.ToString();
              NameField.Text = dataGridView1[1, 0].Value.ToString();
              SecondNameField.Text = dataGridView1[3, 0].Value.ToString();
              GroupComboBox.Text = dataGridView1[4,0].Value.ToString();
          
        }

        private void buttonChange_Click(object sender, EventArgs e)   // запрос на изменение данных базы данных
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
            if (GroupComboBox.Text == "")
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }

            if (isGroupExist())
                return;


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `students` SET `Name` = @Name, `Surname` = @surname, `SecondName` = @secname, `Group` = @Group WHERE `students`.`id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID_Field.Text;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = NameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameField.Text;
            command.Parameters.Add("@secname", MySqlDbType.VarChar).Value = SecondNameField.Text;
            command.Parameters.Add("@Group", MySqlDbType.VarChar).Value = GroupComboBox.Text;

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
