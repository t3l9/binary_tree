namespace binary_tree
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.построитьБинарноеДеревоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инфикснымОбходомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.постфикснымОбходомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.префикснымОбходомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделатьBДеревоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьКрасночерноеДеревоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.построитьБинарноеДеревоToolStripMenuItem,
            this.вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem,
            this.сделатьBДеревоToolStripMenuItem,
            this.построитьКрасночерноеДеревоToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1471, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // построитьБинарноеДеревоToolStripMenuItem
            // 
            this.построитьБинарноеДеревоToolStripMenuItem.Name = "построитьБинарноеДеревоToolStripMenuItem";
            this.построитьБинарноеДеревоToolStripMenuItem.Size = new System.Drawing.Size(176, 20);
            this.построитьБинарноеДеревоToolStripMenuItem.Text = "Построить бинарное дерево";
            this.построитьБинарноеДеревоToolStripMenuItem.Click += new System.EventHandler(this.построитьБинарноеДеревоToolStripMenuItem_Click);
            // 
            // вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem
            // 
            this.вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.инфикснымОбходомToolStripMenuItem,
            this.постфикснымОбходомToolStripMenuItem,
            this.префикснымОбходомToolStripMenuItem});
            this.вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem.Name = "вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem";
            this.вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem.Size = new System.Drawing.Size(430, 20);
            this.вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem.Text = "Вывести элементы дерева на экран используя следующие обходы дерева:";
            this.вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem.Click += new System.EventHandler(this.вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem_Click);
            // 
            // инфикснымОбходомToolStripMenuItem
            // 
            this.инфикснымОбходомToolStripMenuItem.Name = "инфикснымОбходомToolStripMenuItem";
            this.инфикснымОбходомToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.инфикснымОбходомToolStripMenuItem.Text = "Инфиксным обходом";
            this.инфикснымОбходомToolStripMenuItem.Click += new System.EventHandler(this.инфикснымОбходомToolStripMenuItem_Click);
            // 
            // постфикснымОбходомToolStripMenuItem
            // 
            this.постфикснымОбходомToolStripMenuItem.Name = "постфикснымОбходомToolStripMenuItem";
            this.постфикснымОбходомToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.постфикснымОбходомToolStripMenuItem.Text = "Постфиксным обходом";
            this.постфикснымОбходомToolStripMenuItem.Click += new System.EventHandler(this.постфикснымОбходомToolStripMenuItem_Click);
            // 
            // префикснымОбходомToolStripMenuItem
            // 
            this.префикснымОбходомToolStripMenuItem.Name = "префикснымОбходомToolStripMenuItem";
            this.префикснымОбходомToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.префикснымОбходомToolStripMenuItem.Text = "Префиксным обходом";
            this.префикснымОбходомToolStripMenuItem.Click += new System.EventHandler(this.префикснымОбходомToolStripMenuItem_Click);
            // 
            // сделатьBДеревоToolStripMenuItem
            // 
            this.сделатьBДеревоToolStripMenuItem.Name = "сделатьBДеревоToolStripMenuItem";
            this.сделатьBДеревоToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.сделатьBДеревоToolStripMenuItem.Text = "Построить B+ дерево";
            this.сделатьBДеревоToolStripMenuItem.Click += new System.EventHandler(this.сделатьBДеревоToolStripMenuItem_Click);
            // 
            // построитьКрасночерноеДеревоToolStripMenuItem
            // 
            this.построитьКрасночерноеДеревоToolStripMenuItem.Name = "построитьКрасночерноеДеревоToolStripMenuItem";
            this.построитьКрасночерноеДеревоToolStripMenuItem.Size = new System.Drawing.Size(206, 20);
            this.построитьКрасночерноеДеревоToolStripMenuItem.Text = "Построить красно-черное дерево";
            this.построитьКрасночерноеДеревоToolStripMenuItem.Click += new System.EventHandler(this.построитьКрасночерноеДеревоToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Сумма бинарного дерева",
            "Произведение элементов кратных 3",
            "Вершина с неравном числом потомков в левом и правом поддеревьях",
            "Вершина с различной высотой левого и правого поддеревьев",
            "Количество вхождений x (-8) в бинарное дерево",
            "Максимальный элемент в бинарном дерево и его кол-во повторений",
            "Есть ли в бинарном дереве хотя бы 2 одинаковых элемента",
            "Максимальное количество одинаковых элементов бинарного дерева",
            "Является ли дерево симметричным",
            "Является ли бинарное дерево - деревом поиска",
            "Листья дерева поиска в порядке возрастания",
            "Два сбалансированных дерева из отрицательных и неотрицательных элементов",
            "Минимальные пути от корня к листьям дерева, у которых вес эл-ов минимальный",
            "Последний номер из всех уровней, на которых есть положительные элементы",
            "Максимальный элемент на каждом уровне",
            "Количество внутренних вершин и листьев на каждом уровне дерева",
            "Сумма элементов всех нечетных уровней",
            "Минимальные и максимальные пути между листьями",
            "Удалить из дерева наименьшее кол-во вершин, чтобы дерево было строго бинарным"});
            this.listBox1.Location = new System.Drawing.Point(1012, 61);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(447, 277);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(1012, 390);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(451, 20);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Сбалансированное дерево из отрицательных элементов";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(1012, 426);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(453, 20);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Сбалансированное дерево из положительных элементов";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(994, 626);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Положительные";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(994, 626);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отрицательные";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(6, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1457, 626);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "B+ дерево";
            this.groupBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox3_Paint);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(0, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1471, 626);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Красно-черное дерево";
            this.groupBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox4_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 665);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem построитьБинарноеДеревоToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инфикснымОбходомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem постфикснымОбходомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem префикснымОбходомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сделатьBДеревоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построитьКрасночерноеДеревоToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

