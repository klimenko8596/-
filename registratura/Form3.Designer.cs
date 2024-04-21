namespace registratura
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.пациентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.врачToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.специализацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отделенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приёмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.учётМедицинскихКартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учётПриёмовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(975, 553);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(967, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Работа с базой данных";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(731, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Здравствуйте, Администратор!";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(961, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пациентыToolStripMenuItem,
            this.врачToolStripMenuItem,
            this.специализацииToolStripMenuItem,
            this.отделенияToolStripMenuItem,
            this.приёмToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(84, 24);
            this.toolStripDropDownButton1.Text = "Объекты";
            // 
            // пациентыToolStripMenuItem
            // 
            this.пациентыToolStripMenuItem.Name = "пациентыToolStripMenuItem";
            this.пациентыToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.пациентыToolStripMenuItem.Text = "Пациенты";
            this.пациентыToolStripMenuItem.Click += new System.EventHandler(this.пациентыToolStripMenuItem_Click);
            // 
            // врачToolStripMenuItem
            // 
            this.врачToolStripMenuItem.Name = "врачToolStripMenuItem";
            this.врачToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.врачToolStripMenuItem.Text = "Врачи";
            this.врачToolStripMenuItem.Click += new System.EventHandler(this.врачToolStripMenuItem_Click);
            // 
            // специализацииToolStripMenuItem
            // 
            this.специализацииToolStripMenuItem.Name = "специализацииToolStripMenuItem";
            this.специализацииToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.специализацииToolStripMenuItem.Text = "Специализации";
            this.специализацииToolStripMenuItem.Click += new System.EventHandler(this.специализацииToolStripMenuItem_Click);
            // 
            // отделенияToolStripMenuItem
            // 
            this.отделенияToolStripMenuItem.Name = "отделенияToolStripMenuItem";
            this.отделенияToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.отделенияToolStripMenuItem.Text = "Отделения";
            this.отделенияToolStripMenuItem.Click += new System.EventHandler(this.отделенияToolStripMenuItem_Click);
            // 
            // приёмToolStripMenuItem
            // 
            this.приёмToolStripMenuItem.Name = "приёмToolStripMenuItem";
            this.приёмToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.приёмToolStripMenuItem.Text = "Приём";
            this.приёмToolStripMenuItem.Click += new System.EventHandler(this.приёмToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учётМедицинскихКартToolStripMenuItem,
            this.учётПриёмовToolStripMenuItem});
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(175, 24);
            this.toolStripDropDownButton2.Text = "Выходные документы";
            // 
            // учётМедицинскихКартToolStripMenuItem
            // 
            this.учётМедицинскихКартToolStripMenuItem.Name = "учётМедицинскихКартToolStripMenuItem";
            this.учётМедицинскихКартToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.учётМедицинскихКартToolStripMenuItem.Text = "Учёт медицинских карт";
            this.учётМедицинскихКартToolStripMenuItem.Click += new System.EventHandler(this.учётМедицинскихКартToolStripMenuItem_Click);
            // 
            // учётПриёмовToolStripMenuItem
            // 
            this.учётПриёмовToolStripMenuItem.Name = "учётПриёмовToolStripMenuItem";
            this.учётПриёмовToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.учётПриёмовToolStripMenuItem.Text = "Учёт приёмов";
            this.учётПриёмовToolStripMenuItem.Click += new System.EventHandler(this.учётПриёмовToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(798, 56);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(724, 485);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 574);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form3";
            this.Text = "Регистратура";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem пациентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem врачToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem специализацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem учётМедицинскихКартToolStripMenuItem;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem учётПриёмовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отделенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приёмToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}