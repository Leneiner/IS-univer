using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs
{
    public partial class MainForm : Form
    {
        public MainForm() // инициализация формы
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            dataGridViewPed.Visible = false;
            DeletePedPanel.Visible = false;
            DeletePedPanel.Enabled = false;
            this.DeletePedPanel.BringToFront();
            this.DeleteStudPanel.BringToFront();
            this.GroupPanel.BringToFront();
            this.DelGroupPanel.BringToFront();

            LoadComboBox();
            LoadComboBox2();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadData()  //загрузка данных из базы данных
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM students ORDER BY id", db.getConnection());
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
        private void LoadDataExam()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT exam.id, subject, students.Group, Name, Surname, Mark FROM `students`, `exam` WHERE exam.stud = students.id", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[6]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[4].ToString();
                data[data.Count - 1][4] = reader[3].ToString();
                data[data.Count - 1][5] = reader[5].ToString();


            }

            reader.Close();

            db.closeConnection();

            foreach (string[] s in data)
                dataGridViewExam.Rows.Add(s);
        }

        private void LoadDataTeachers()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM teachers ORDER BY id", db.getConnection());
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
                dataGridViewPed.Rows.Add(s);
        }

        private void LoadDataGroup()
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
        }


        private void buttonStudents_Click(object sender, EventArgs e)   //Вывод данных базы данных в поле отображения информации
        {
            dataGridViewPed.Visible = false;
            AddPedBut.Enabled = false;
            AddPedBut.Visible = false;
            ChangePedBut.Enabled = false;
            ChangePedBut.Visible = false;
            DelPedBut.Enabled = false;
            DelPedBut.Visible = false;
            AddGroupBut.Visible = false;
            dataGridViewGroup.Visible = false;
            DeletePedPanel.Visible = false;
            DeletePedPanel.Enabled = false;
            DelGroupBut.Visible = false;
            DelGroupBut.Enabled = false;
            DelGroupPanel.Visible = false;
            ChangeGroupBut.Visible = false;
            ChangeGroupBut.Enabled = false;
            DelMarkPanel.Enabled = false;
            DelMarkPanel.Visible = false;
            AddMarkBut.Visible = false;
            DelMarkBut.Visible = false;
            dataGridViewExam.Visible = false;
            SearchButExam.Visible = false;
            DropFiltersExam.Visible = false;


            this.dataGridView1.Rows.Clear();
            AddStudBut.Enabled = true;
            AddStudBut.Visible = true;
            ChangeStudBut.Enabled=true;
            ChangeStudBut.Visible = true;
            DeleteStudBut.Enabled=true;
            DeleteStudBut.Visible = true;
            SortGroupBut.Enabled = true;
            SortGroupBut.Visible = true;
            label2.Visible=true;
            SearchBox.Visible=true;
            SearchButPed.Visible = false;
            SearchButStud.Visible = true;
            SearchButGroup.Visible = false;
            DropFiltersStud.Visible = true;
            DropFiltersGroup.Visible = false;
            DropFiltersPed.Visible = false;


            LoadData();
            dataGridView1.Visible = true;
        }

        private void buttonDeleteStud_Click(object sender, EventArgs e)
        {
            DeleteStudPanel.Enabled = true;
            DeleteStudPanel.Visible = true;
            DeletePedPanel.Visible = false;
            DeletePedPanel.Enabled = false;
            GroupPanel.Visible = false;
            GroupPanel.Enabled = false;
            DelMarkPanel.Enabled = false;
            DelMarkPanel.Visible = false;
        }

        private void buttonDeleteStud2_Click(object sender, EventArgs e) // запрос на удаление записи из бд
        {
            string ID = DeleteStudTextField.Text;
            DB db = new DB();


            MySqlCommand command = new MySqlCommand("DELETE FROM `students` WHERE `students`.`id` = @idStud", db.getConnection());
            command.Parameters.Add("@idStud", MySqlDbType.VarChar).Value = ID;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Студент успешно удален");
                DeleteStudPanel.Enabled = false;
                DeleteStudPanel.Visible = false;
                buttonStudents_Click(sender, e);
            }

            else
                MessageBox.Show("Такого ID не существует");

            db.closeConnection();

        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
        }

        private void CloseButDelPanel_Click(object sender, EventArgs e)
        {
            DeleteStudPanel.Enabled = false;
            DeleteStudPanel.Visible = false;
            buttonStudents_Click(sender, e);
        }

        private void CloseButDelPanel_MouseEnter(object sender, EventArgs e)
        {
            CloseButDelPanel.ForeColor = Color.Red;
        }

        private void CloseButDelPanel_MouseLeave(object sender, EventArgs e)
        {
            CloseButDelPanel.ForeColor = Color.Black;
        }

        private void AddStudBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStudForm addStudForm = new AddStudForm();
            addStudForm.Show();
        }

        private void SortGroupBut_Click(object sender, EventArgs e)
        {
            
            GroupPanel.Enabled = true;
            GroupPanel.Visible = true;
            DeleteStudPanel.Visible = false;
            DeleteStudPanel.Enabled = false;
            DeletePedPanel.Visible = false;
            DeletePedPanel.Enabled = false;
            DelMarkPanel.Enabled = false;
            DelMarkPanel.Visible = false;
        }

        private void CloseButGroupPanel_Click(object sender, EventArgs e)
        {
            GroupPanel.Enabled = false;
            GroupPanel.Visible = false;
        }

        private void CloseButGroupPanel_MouseEnter(object sender, EventArgs e)
        {
            CloseButGroupPanel.ForeColor = Color.Red;
        }

        private void CloseButGroupPanel_MouseLeave(object sender, EventArgs e)
        {
            CloseButGroupPanel.ForeColor = Color.Black;
        }


        private void EnterGroupBut_Click(object sender, EventArgs e)   // группировка студентов одной группы
        {
            
            string group = GroupComboBox.Text;
            if (isGroupExist())
                return;
            this.dataGridView1.Rows.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `students` WHERE `Group` = @group ORDER BY id", db.getConnection());
            command.Parameters.Add("@group", MySqlDbType.VarChar).Value = group;
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
            GroupPanel.Visible = false;
            GroupPanel.Enabled = false;
            AllStudBut.Enabled = true;
            AllStudBut.Visible = true;
            
        }

        public Boolean isGroupExist() // проверка на существование группы
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `groups` WHERE `Name` = @group", db.getConnection());
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

        private void LoadComboBox()    // загрузка данных в комбобокс 
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
            GroupComboBox.Items.Clear();
            int countRows = 0;
            while (countRows < dataGridViewGroup.Rows.Count)
            {
                GroupComboBox.Items.Add(dataGridViewGroup[1, countRows].Value.ToString());
                countRows++;


            }

            
        }

        private void AllStudBut_Click(object sender, EventArgs e)
        {
            buttonStudents_Click(sender, e);
            AllStudBut.Enabled=false;
            AllStudBut.Visible = false;
        }

        private void ChangeStudBut_Click(object sender, EventArgs e)
        {

            this.Hide();
            ChangeStudForm changeStudForm = new ChangeStudForm();
            changeStudForm.Show();
            
        }

        private void buttonTeachers_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridViewGroup.Visible = false;
            AddStudBut.Visible = false;
            DeleteStudBut.Visible = false;
            ChangeStudBut.Visible = false;
            SortGroupBut.Visible = false;
            AllStudBut.Visible = false;
            AddGroupBut.Visible = false;
            DeleteStudPanel.Visible = false;
            DeleteStudPanel.Enabled = false;
            GroupPanel.Visible = false;
            GroupPanel.Enabled = false;
            DelGroupBut.Visible = false;
            DelGroupBut.Enabled = false;
            DelMarkPanel.Enabled = false;
            DelMarkPanel.Visible = false;
            DelGroupPanel.Visible = false;
            ChangeGroupBut.Visible = false;
            ChangeGroupBut.Enabled = false;
            AddMarkBut.Visible = false;
            DelMarkBut.Visible = false;
            dataGridViewExam.Visible = false;
            SearchButExam.Visible = false;
            DropFiltersExam.Visible = false;

            this.dataGridViewPed.Rows.Clear();
            AddPedBut.Enabled = true;
            AddPedBut.Visible = true;
            ChangePedBut.Enabled = true;
            ChangePedBut.Visible = true;
            DelPedBut.Enabled = true;
            DelPedBut.Visible = true;
            label2.Visible = true;
            SearchBox.Visible = true;
            SearchButPed.Visible = true;
            SearchButStud.Visible = false;
            SearchButGroup.Visible = false;
            DropFiltersStud.Visible = false;
            DropFiltersGroup.Visible = false;
            DropFiltersPed.Visible = true;



            LoadDataTeachers();
            dataGridViewPed.Visible = true;
        }

        private void AddPedBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPedForm addPedForm = new AddPedForm();
            addPedForm.Show();
        }

        private void CloseButDelPanelPed_Click(object sender, EventArgs e)
        {

            DeletePedPanel.Enabled = false;
            DeletePedPanel.Visible = false;
            buttonTeachers_Click(sender, e);
        }

        private void buttonDeletePed2_Click(object sender, EventArgs e)
        {
            string ID = DeletePedTextField.Text;
            DB db = new DB();


            MySqlCommand command = new MySqlCommand("DELETE FROM `teachers` WHERE `teachers`.`id` = @idPed", db.getConnection());
            command.Parameters.Add("@idPed", MySqlDbType.VarChar).Value = ID;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Преподаватель успешно удален");
                DeletePedPanel.Enabled = false;
                DeletePedPanel.Visible = false;
                buttonTeachers_Click(sender, e);
            }

            else
                MessageBox.Show("Такого ID не существует");

            db.closeConnection();
        }

        private void DelPedBut_Click(object sender, EventArgs e)
        {
            DeletePedPanel.Enabled = true;
            DeletePedPanel.Visible = true;
            DeleteStudPanel.Visible = false;
            DeleteStudPanel.Enabled = false;
            GroupPanel.Visible = false;
            GroupPanel.Enabled = false;
            DelMarkPanel.Enabled = false;
            DelMarkPanel.Visible = false;
        }

        private void ChangePedBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePedForm changePedForm = new ChangePedForm();
            changePedForm.Show();
        }

        private void SearchBut_Click(object sender, EventArgs e)       // процедура поиска информации по ключевому слову
        {
            if (SearchBox.Text == "")
            {
                MessageBox.Show("Введите данные для поиска!");
                return;
            }
            string Search = SearchBox.Text;
            this.dataGridViewPed.Rows.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `teachers` WHERE `id` LIKE @search OR `Name` LIKE @search OR `Surname` LIKE @search OR `SecondName` LIKE @search OR `Subject` LIKE @search", db.getConnection());
            command.Parameters.Add("@search", MySqlDbType.VarChar).Value = Search;
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
                dataGridViewPed.Rows.Add(s);
            if (dataGridViewPed.Rows.Count < 1)
            {
                MessageBox.Show("Ничего не найдено");
            }
            else
            {
                MessageBox.Show("Запрос выполнен");
            }
        }

        private void SearchButStud_Click(object sender, EventArgs e)
        {
            if (SearchBox.Text == "")
            {
                MessageBox.Show("Введите данные для поиска!");
                return;
            }
            string Search = SearchBox.Text;
            this.dataGridView1.Rows.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `students` WHERE `id` LIKE @search OR `Name` LIKE @search OR `Surname` LIKE @search OR `SecondName` LIKE @search OR `Group` LIKE @search", db.getConnection());
            command.Parameters.Add("@search", MySqlDbType.VarChar).Value = Search;
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
            if (dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("Ничего не найдено");
            }
            else
            {
                MessageBox.Show("Запрос выполнен");
            }
        }

        private void buttonGroup_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            AddStudBut.Visible = false;
            DeleteStudBut.Visible = false;
            ChangeStudBut.Visible = false;
            SortGroupBut.Visible = false;
            AllStudBut.Visible = false;
            dataGridViewPed.Visible = false;
            DeletePedPanel.Visible = false;
            DeleteStudPanel.Visible = false;
            GroupPanel.Visible = false;
            DelMarkPanel.Enabled = false;
            DelMarkPanel.Visible = false;
            AddMarkBut.Visible = false;
            DelMarkBut.Visible = false;
            dataGridViewExam.Visible = false;
            SearchButExam.Visible = false; 
            DropFiltersExam.Visible = false; 

            this.dataGridViewGroup.Rows.Clear();
            AddPedBut.Enabled = false;
            AddPedBut.Visible = false;
            ChangePedBut.Enabled = false;
            ChangePedBut.Visible = false;
            DelPedBut.Enabled = false;
            DelPedBut.Visible = false;
            label2.Visible = false;
            SearchBox.Visible = false;
            SearchButPed.Visible = false;
            SearchButStud.Visible = false;
            DropFiltersStud.Visible = false;
            DropFiltersGroup.Visible = true;
            DropFiltersPed.Visible = false;

            AddGroupBut.Visible = true;
            AddGroupBut.Enabled = true;
            DelGroupBut.Visible = true;
            DelGroupBut.Enabled = true;
            ChangeGroupBut.Visible = true;
            ChangeGroupBut.Enabled = true;
            SearchButGroup.Visible = true;
            label2.Visible = true;
            SearchBox.Visible = true;

            LoadDataGroup();
            dataGridViewGroup.Visible = true;
        }

        private void AddGroupBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddGroupForm addGroupForm = new AddGroupForm();
            addGroupForm.Show();
        }

        public Boolean isGroupHaveStudExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `students` WHERE `Group` = @group", db.getConnection());
            command.Parameters.Add("@group", MySqlDbType.VarChar).Value = GroupComboBox2.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Нельзя удалить группу пока за ней закреплены студенты!");
                return true;
            }

            else
            {
             
                return false;
            }
        }

        private void LoadComboBox2()
        {

            DB db = new DB();
            this.dataGridViewGroup.Rows.Clear();
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
            GroupComboBox2.Items.Clear();
            int countRows = 0;
            while (countRows < dataGridViewGroup.Rows.Count)
            {
                GroupComboBox2.Items.Add(dataGridViewGroup[1, countRows].Value.ToString());
                countRows++;


            }
            

        }

        private void DelGroupBut2_Click(object sender, EventArgs e)
        {


            if (isGroupHaveStudExist())
                return;

            string ID = GroupComboBox2.Text;
            DB db = new DB();


            MySqlCommand command = new MySqlCommand("DELETE FROM `groups` WHERE `groups`.`Name` = @NameGroup", db.getConnection());
            command.Parameters.Add("@NameGroup", MySqlDbType.VarChar).Value = ID;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Группа успешно удалена");
                DelGroupPanel.Enabled = false;
                DelGroupPanel.Visible = false;
                buttonGroup_Click(sender, e);
                LoadComboBox2();
            }

            else
                MessageBox.Show("Такого ID не существует");

            db.closeConnection();
        }

        private void DelGroupBut_Click(object sender, EventArgs e)
        {
            DeletePedPanel.Enabled = false;
            DeletePedPanel.Visible = false;
            DeleteStudPanel.Visible = false;
            DeleteStudPanel.Enabled = false;
            GroupPanel.Visible = false;
            GroupPanel.Enabled = false;
            DelGroupPanel.Visible = true;
            DelGroupPanel.Enabled = true;
            DelMarkPanel.Enabled = false;
            DelMarkPanel.Visible = false;
        }

        private void CloseButDelGroupPanel_Click(object sender, EventArgs e)
        {
            DelGroupPanel.Enabled = false;
            DelGroupPanel.Visible = false;
            buttonGroup_Click(sender, e);
        }

        private void ChangeGroupBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeGroupForm changeGroupForm = new ChangeGroupForm();
            changeGroupForm.Show();
        }

        private void SearchButGroup_Click(object sender, EventArgs e)
        {
            if (SearchBox.Text == "")
            {
                MessageBox.Show("Введите данные для поиска!");
                return;
            }
            string Search = SearchBox.Text;
            this.dataGridViewGroup.Rows.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `groups` WHERE `id` LIKE @search OR `Name` LIKE @search OR `Specialty` LIKE @search OR `Course` LIKE @search OR `ChainPed` LIKE @search", db.getConnection());
            command.Parameters.Add("@search", MySqlDbType.VarChar).Value = Search;
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
            if (dataGridViewGroup.Rows.Count < 1)
            {
                MessageBox.Show("Ничего не найдено");
            }
            else
            {
                MessageBox.Show("Запрос выполнен");
            }
        }

        private void DropFiltersStud_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "";
            buttonStudents_Click(sender, e);
        }

        private void DropFiltersPed_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "";
            buttonTeachers_Click(sender, e);
        }

        private void DropFiltersGroup_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "";
            buttonGroup_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            AddStudBut.Visible = false;
            DeleteStudBut.Visible = false;
            ChangeStudBut.Visible = false;
            SortGroupBut.Visible = false;
            AllStudBut.Visible = false;
            dataGridViewPed.Visible = false;
            DeletePedPanel.Visible = false;
            DeleteStudPanel.Visible = false;
            GroupPanel.Visible = false;
            DelMarkPanel.Enabled = false;
            DelMarkPanel.Visible = false;


            this.dataGridViewExam.Rows.Clear();
            AddPedBut.Enabled = false;
            AddPedBut.Visible = false;
            ChangePedBut.Enabled = false;
            ChangePedBut.Visible = false;
            DelPedBut.Enabled = false;
            DelPedBut.Visible = false;
            label2.Visible = false;
            SearchBox.Visible = false;
            SearchButPed.Visible = false;
            SearchButStud.Visible = false;
            DropFiltersStud.Visible = false;
            DropFiltersGroup.Visible = false;
            DropFiltersPed.Visible = false;

            AddGroupBut.Visible = false;
            AddGroupBut.Enabled = false;
            DelGroupBut.Visible = false;
            DelGroupBut.Enabled = false;
            ChangeGroupBut.Visible = false;
            ChangeGroupBut.Enabled = false;
            SearchButGroup.Visible = false;
            label2.Visible = true;
            SearchBox.Visible = true;
            SearchButExam.Visible = true;
            DropFiltersExam.Visible = true;
            dataGridViewGroup.Visible = false;


            dataGridViewExam.Visible = true;
            AddMarkBut.Visible = true;
            DelMarkBut.Visible=true;
            LoadDataExam();


          
           
        }

        private void AddMarkBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddMarkForm addMarkForm = new AddMarkForm();
            addMarkForm.Show();
        }

        private void DelMarkBut2_Click(object sender, EventArgs e)
        {
            string ID = DelMarkField.Text;
            DB db = new DB();


            MySqlCommand command = new MySqlCommand("DELETE FROM `exam` WHERE `exam`.`id` = @idExam", db.getConnection());
            command.Parameters.Add("@idExam", MySqlDbType.VarChar).Value = ID;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Оценка успешно удален");
                DelMarkPanel.Enabled = false;
                DelMarkPanel.Visible = false;
                button1_Click(sender, e);
            }

            else
                MessageBox.Show("Такого ID не существует");

            db.closeConnection();
        }

        private void DelMarkBut_Click(object sender, EventArgs e)
        {
            DeleteStudPanel.Enabled = false;
            DeleteStudPanel.Visible = false;
            DeletePedPanel.Visible = false;
            DeletePedPanel.Enabled = false;
            GroupPanel.Visible = false;
            GroupPanel.Enabled = false;
            DelMarkPanel.Enabled = true;
            DelMarkPanel.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

            DelMarkPanel.Enabled = false;
            DelMarkPanel.Visible = false;
            button1_Click(sender, e);
        }

        private void DropFiltersExam_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "";
            button1_Click(sender, e);
        }

        private void SearchButExam_Click(object sender, EventArgs e)
        {
            if (SearchBox.Text == "")
            {
                MessageBox.Show("Введите данные для поиска!");
                return;
            }
            string Search = SearchBox.Text;
            this.dataGridViewExam.Rows.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT exam.id, subject, students.Group, Name, Surname, Mark FROM `students`, `exam` WHERE (exam.stud = students.id) AND (students.Name LIKE @search OR students.Surname LIKE @search OR students.Group LIKE @search OR exam.subject LIKE @search OR exam.mark LIKE @search); ", db.getConnection());
            command.Parameters.Add("@search", MySqlDbType.VarChar).Value = Search;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[6]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[4].ToString();
                data[data.Count - 1][4] = reader[3].ToString();
                data[data.Count - 1][5] = reader[5].ToString();

            }

            reader.Close();

            db.closeConnection();

            foreach (string[] s in data)
                dataGridViewExam.Rows.Add(s);
            if (dataGridViewExam.Rows.Count < 1)
            {
                MessageBox.Show("Ничего не найдено");
            }
            else
            {
                MessageBox.Show("Запрос выполнен");
            }
        }
    }
    
}

