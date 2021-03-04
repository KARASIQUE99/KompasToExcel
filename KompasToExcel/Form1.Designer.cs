
namespace KompasToExcel
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
            this.btn_select_dir_in = new System.Windows.Forms.Button();
            this.dir_in = new System.Windows.Forms.TextBox();
            this.dir_out = new System.Windows.Forms.TextBox();
            this.btn_select_dir_out = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.info_label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_select_spw = new System.Windows.Forms.Button();
            this.spw_path = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cb_connect_all = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.multiplier = new System.Windows.Forms.NumericUpDown();
            this.cb_use_spw = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiplier)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_select_dir_in
            // 
            this.btn_select_dir_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_select_dir_in.Location = new System.Drawing.Point(452, 23);
            this.btn_select_dir_in.Name = "btn_select_dir_in";
            this.btn_select_dir_in.Size = new System.Drawing.Size(169, 23);
            this.btn_select_dir_in.TabIndex = 0;
            this.btn_select_dir_in.Text = "Путь к папке с исходниками";
            this.btn_select_dir_in.UseVisualStyleBackColor = true;
            this.btn_select_dir_in.Click += new System.EventHandler(this.btn_select_dir_in_Click);
            // 
            // dir_in
            // 
            this.dir_in.Enabled = false;
            this.dir_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dir_in.Location = new System.Drawing.Point(6, 25);
            this.dir_in.Name = "dir_in";
            this.dir_in.Size = new System.Drawing.Size(436, 21);
            this.dir_in.TabIndex = 1;
            // 
            // dir_out
            // 
            this.dir_out.Enabled = false;
            this.dir_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dir_out.Location = new System.Drawing.Point(6, 53);
            this.dir_out.Name = "dir_out";
            this.dir_out.Size = new System.Drawing.Size(436, 21);
            this.dir_out.TabIndex = 2;
            // 
            // btn_select_dir_out
            // 
            this.btn_select_dir_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_select_dir_out.Location = new System.Drawing.Point(452, 50);
            this.btn_select_dir_out.Name = "btn_select_dir_out";
            this.btn_select_dir_out.Size = new System.Drawing.Size(169, 23);
            this.btn_select_dir_out.TabIndex = 3;
            this.btn_select_dir_out.Text = "Путь к папке с результатом";
            this.btn_select_dir_out.UseVisualStyleBackColor = true;
            this.btn_select_dir_out.Click += new System.EventHandler(this.btn_select_dir_out_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ok.Location = new System.Drawing.Point(6, 85);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(165, 22);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "Конвертировать";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // info_label
            // 
            this.info_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info_label.Location = new System.Drawing.Point(17, 349);
            this.info_label.Name = "info_label";
            this.info_label.Size = new System.Drawing.Size(800, 23);
            this.info_label.TabIndex = 7;
            this.info_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_select_spw);
            this.groupBox2.Controls.Add(this.spw_path);
            this.groupBox2.Controls.Add(this.dir_in);
            this.groupBox2.Controls.Add(this.btn_select_dir_in);
            this.groupBox2.Controls.Add(this.dir_out);
            this.groupBox2.Controls.Add(this.btn_select_dir_out);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(17, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 114);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Директории и файлы";
            // 
            // btn_select_spw
            // 
            this.btn_select_spw.Enabled = false;
            this.btn_select_spw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_select_spw.Location = new System.Drawing.Point(452, 78);
            this.btn_select_spw.Name = "btn_select_spw";
            this.btn_select_spw.Size = new System.Drawing.Size(169, 23);
            this.btn_select_spw.TabIndex = 8;
            this.btn_select_spw.Text = "Загрузить спецификацию";
            this.btn_select_spw.UseVisualStyleBackColor = true;
            this.btn_select_spw.Click += new System.EventHandler(this.btn_select_spw_Click);
            // 
            // spw_path
            // 
            this.spw_path.Enabled = false;
            this.spw_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spw_path.Location = new System.Drawing.Point(6, 80);
            this.spw_path.Name = "spw_path";
            this.spw_path.Size = new System.Drawing.Size(436, 21);
            this.spw_path.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Location = new System.Drawing.Point(17, 132);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(806, 212);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(800, 193);
            this.listBox1.TabIndex = 0;
            // 
            // cb_connect_all
            // 
            this.cb_connect_all.AutoSize = true;
            this.cb_connect_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_connect_all.Location = new System.Drawing.Point(20, 23);
            this.cb_connect_all.Name = "cb_connect_all";
            this.cb_connect_all.Size = new System.Drawing.Size(145, 17);
            this.cb_connect_all.TabIndex = 14;
            this.cb_connect_all.Text = "Соединить в один файл";
            this.cb_connect_all.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.multiplier);
            this.groupBox1.Controls.Add(this.cb_use_spw);
            this.groupBox1.Controls.Add(this.cb_connect_all);
            this.groupBox1.Controls.Add(this.btn_ok);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(652, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 114);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(36, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Множитель:";
            // 
            // multiplier
            // 
            this.multiplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multiplier.Location = new System.Drawing.Point(108, 61);
            this.multiplier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.multiplier.Name = "multiplier";
            this.multiplier.Size = new System.Drawing.Size(37, 20);
            this.multiplier.TabIndex = 16;
            this.multiplier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cb_use_spw
            // 
            this.cb_use_spw.AutoSize = true;
            this.cb_use_spw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_use_spw.Location = new System.Drawing.Point(20, 43);
            this.cb_use_spw.Name = "cb_use_spw";
            this.cb_use_spw.Size = new System.Drawing.Size(104, 17);
            this.cb_use_spw.TabIndex = 15;
            this.cb_use_spw.Text = "Загрузка с spw";
            this.cb_use_spw.UseVisualStyleBackColor = true;
            this.cb_use_spw.CheckedChanged += new System.EventHandler(this.cb_use_spw_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 390);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.info_label);
            this.MaximumSize = new System.Drawing.Size(1000, 428);
            this.MinimumSize = new System.Drawing.Size(857, 428);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конвертер таблиц";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiplier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_select_dir_in;
        private System.Windows.Forms.TextBox dir_in;
        private System.Windows.Forms.TextBox dir_out;
        private System.Windows.Forms.Button btn_select_dir_out;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label info_label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_select_spw;
        private System.Windows.Forms.TextBox spw_path;
        private System.Windows.Forms.CheckBox cb_connect_all;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_use_spw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown multiplier;
    }
}

