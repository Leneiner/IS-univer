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
    public partial class AddStudForm : Form
    {
        public AddStudForm()
        {
            InitializeComponent();

            
            
            NameField.Text = "Имя";
            NameField.ForeColor = Color.Gray;
            SurnameField.Text = "Фамилия";
            SurnameField.ForeColor = Color.Gray;
            SecondNameField.Text = "Отчество";
            SecondNameField.ForeColor = Color.Gray;
            GroupCobmoBox.Text = "Группа";
            GroupCobmoBox.ForeColor = Color.Gray;
            LoadComboBox();
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
                GroupCobmoBox.Items.Add(dataGridViewGroup[1, countRows].Value.ToString());
                countRows++;
            }
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
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

        

       

        public Boolean isGroupExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `groups` WHERE `name` = @group", db.getConnection());
            command.Parameters.Add("@group", MySqlDbType.VarChar).Value = GroupCobmoBox.Text;

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

        private void buttonRegister_Click(object sender, EventArgs e)   // запрос на добавление данных в базу данных
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
            if (GroupCobmoBox.Text == "Группа")
            {
                MessageBox.Show("Заполните все данные!");
                return;
            }
            if (isGroupExist())
                return;



            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `students` (`Name`, `Surname`, `SecondName`, `Group`) VALUES (@name, @surname, @secName, @group);", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameField.Text;
            command.Parameters.Add("@secName", MySqlDbType.VarChar).Value = SecondNameField.Text;
            command.Parameters.Add("@Group", MySqlDbType.VarChar).Value = GroupCobmoBox.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Студент успешно добавлен");
                LoginLabel_Click(sender, e);
            }
            else
                MessageBox.Show("Ошибка: студент не был добавлен");
            db.closeConnection();
        }
        

        private void LoginLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void MainLabel_MouseEnter(object sender, EventArgs e)
        {
            MainLabel.ForeColor = Color.Red;
        }

        private void MainLabel_MouseLeave(object sender, EventArgs e)
        {
            MainLabel.ForeColor = Color.Black;
        }

        private void GroupCobmoBox_Enter(object sender, EventArgs e)
        {
            GroupCobmoBox.ForeColor = Color.Black;
        }
    }
}
