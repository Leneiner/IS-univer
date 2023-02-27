namespace kurs
{
    partial class ChangeGroupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dataGridViewGroup = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutoBut = new System.Windows.Forms.Button();
            this.buttonChangeID = new System.Windows.Forms.Button();
            this.HeadID = new System.Windows.Forms.Label();
            this.ID_Field = new System.Windows.Forms.TextBox();
            this.ChainPedField = new System.Windows.Forms.TextBox();
            this.MainLabel = new System.Windows.Forms.Label();
            this.CourseField = new System.Windows.Forms.TextBox();
            this.SpecialtyField = new System.Windows.Forms.TextBox();
            this.NameField = new System.Windows.Forms.TextBox();
            this.buttonChange = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.dataGridViewGroup);
            this.mainPanel.Controls.Add(this.AutoBut);
            this.mainPanel.Controls.Add(this.buttonChangeID);
            this.mainPanel.Controls.Add(this.HeadID);
            this.mainPanel.Controls.Add(this.ID_Field);
            this.mainPanel.Controls.Add(this.ChainPedField);
            this.mainPanel.Controls.Add(this.MainLabel);
            this.mainPanel.Controls.Add(this.CourseField);
            this.mainPanel.Controls.Add(this.SpecialtyField);
            this.mainPanel.Controls.Add(this.NameField);
            this.mainPanel.Controls.Add(this.buttonChange);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(424, 450);
            this.mainPanel.TabIndex = 4;
            // 
            // dataGridViewGroup
            // 
            this.dataGridViewGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.Surname,
            this.secondname,
            this.group});
            this.dataGridViewGroup.Enabled = false;
            this.dataGridViewGroup.Location = new System.Drawing.Point(356, 116);
            this.dataGridViewGroup.Name = "dataGridViewGroup";
            this.dataGridViewGroup.Size = new System.Drawing.Size(30, 21);
            this.dataGridViewGroup.TabIndex = 14;
            this.dataGridViewGroup.Visible = false;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            // 
            // name
            // 
            this.name.HeaderText = "name";
            this.name.Name = "name";
            // 
            // Surname
            // 
            this.Surname.HeaderText = "Surname";
            this.Surname.Name = "Surname";
            // 
            // secondname
            // 
            this.secondname.HeaderText = "secondname";
            this.secondname.Name = "secondname";
            // 
            // group
            // 
            this.group.HeaderText = "group";
            this.group.Name = "group";
            // 
            // AutoBut
            // 
            this.AutoBut.Enabled = false;
            this.AutoBut.Location = new System.Drawing.Point(356, 156);
            this.AutoBut.Name = "AutoBut";
            this.AutoBut.Size = new System.Drawing.Size(25, 16);
            this.AutoBut.TabIndex = 13;
            this.AutoBut.Text = "button1";
            this.AutoBut.UseVisualStyleBackColor = true;
            this.AutoBut.Visible = false;
            this.AutoBut.Click += new System.EventHandler(this.AutoBut_Click);
            // 
            // buttonChangeID
            // 
            this.buttonChangeID.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonChangeID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChangeID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonChangeID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonChangeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangeID.Location = new System.Drawing.Point(92, 341);
            this.buttonChangeID.Name = "buttonChangeID";
            this.buttonChangeID.Size = new System.Drawing.Size(230, 36);
            this.buttonChangeID.TabIndex = 11;
            this.buttonChangeID.Text = "Принять";
            this.buttonChangeID.UseVisualStyleBackColor = false;
            this.buttonChangeID.Click += new System.EventHandler(this.buttonChangeID_Click);
            // 
            // HeadID
            // 
            this.HeadID.AutoSize = true;
            this.HeadID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeadID.Location = new System.Drawing.Point(138, 128);
            this.HeadID.Name = "HeadID";
            this.HeadID.Size = new System.Drawing.Size(153, 20);
            this.HeadID.TabIndex = 10;
            this.HeadID.Text = "Введите ID группы";
            // 
            // ID_Field
            // 
            this.ID_Field.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ID_Field.Location = new System.Drawing.Point(119, 189);
            this.ID_Field.Multiline = true;
            this.ID_Field.Name = "ID_Field";
            this.ID_Field.Size = new System.Drawing.Size(194, 31);
            this.ID_Field.TabIndex = 9;
            // 
            // ChainPedField
            // 
            this.ChainPedField.Enabled = false;
            this.ChainPedField.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChainPedField.Location = new System.Drawing.Point(119, 277);
            this.ChainPedField.Multiline = true;
            this.ChainPedField.Name = "ChainPedField";
            this.ChainPedField.Size = new System.Drawing.Size(194, 31);
            this.ChainPedField.TabIndex = 8;
            this.ChainPedField.Visible = false;
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainLabel.Location = new System.Drawing.Point(172, 411);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(74, 20);
            this.MainLabel.TabIndex = 7;
            this.MainLabel.Text = "Отмена";
            this.MainLabel.Click += new System.EventHandler(this.MainLabel_Click);
            // 
            // CourseField
            // 
            this.CourseField.Enabled = false;
            this.CourseField.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CourseField.Location = new System.Drawing.Point(119, 240);
            this.CourseField.Multiline = true;
            this.CourseField.Name = "CourseField";
            this.CourseField.Size = new System.Drawing.Size(194, 31);
            this.CourseField.TabIndex = 6;
            this.CourseField.Visible = false;
            // 
            // SpecialtyField
            // 
            this.SpecialtyField.Enabled = false;
            this.SpecialtyField.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpecialtyField.Location = new System.Drawing.Point(119, 160);
            this.SpecialtyField.Multiline = true;
            this.SpecialtyField.Name = "SpecialtyField";
            this.SpecialtyField.Size = new System.Drawing.Size(194, 74);
            this.SpecialtyField.TabIndex = 5;
            this.SpecialtyField.Visible = false;
            // 
            // NameField
            // 
            this.NameField.Enabled = false;
            this.NameField.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameField.Location = new System.Drawing.Point(119, 123);
            this.NameField.Multiline = true;
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(194, 31);
            this.NameField.TabIndex = 4;
            this.NameField.Visible = false;
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChange.Enabled = false;
            this.buttonChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange.Location = new System.Drawing.Point(92, 366);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(230, 36);
            this.buttonChange.TabIndex = 3;
            this.buttonChange.Text = "Принять";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Visible = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 100);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.Black;
            this.closeButton.Location = new System.Drawing.Point(378, 9);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(23, 24);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Х";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Изменить данные группы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "ID закрепленного\r\n     преподавателя";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Курс";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Специальность";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Название";
            this.label5.Visible = false;
            // 
            // ChangeGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangeGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeGroupForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView dataGridViewGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondname;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        public System.Windows.Forms.Button AutoBut;
        private System.Windows.Forms.Button buttonChangeID;
        private System.Windows.Forms.Label HeadID;
        private System.Windows.Forms.TextBox ID_Field;
        private System.Windows.Forms.TextBox ChainPedField;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.TextBox CourseField;
        private System.Windows.Forms.TextBox SpecialtyField;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}