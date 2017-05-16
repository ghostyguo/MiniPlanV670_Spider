namespace MySpiderRobot
{
    partial class MySpiderForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.hScrollBar3 = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.hScrollBar4 = new System.Windows.Forms.HScrollBar();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.hScrollBar5 = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.hScrollBar6 = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.hScrollBar7 = new System.Windows.Forms.HScrollBar();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.hScrollBar8 = new System.Windows.Forms.HScrollBar();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.hScrollBar9 = new System.Windows.Forms.HScrollBar();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.hScrollBar10 = new System.Windows.Forms.HScrollBar();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.hScrollBar11 = new System.Windows.Forms.HScrollBar();
            this.label0 = new System.Windows.Forms.Label();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.hScrollBar0 = new System.Windows.Forms.HScrollBar();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.cbPortList = new System.Windows.Forms.ComboBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.radioAngle = new System.Windows.Forms.RadioButton();
            this.radioPulseWidth = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridViewCommand = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.hScrollBarTime = new System.Windows.Forms.HScrollBar();
            this.btnSaveArduino = new System.Windows.Forms.Button();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCommand)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(233, 407);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(100, 43);
            this.btnMoveUp.TabIndex = 0;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Enabled = false;
            this.hScrollBar1.Location = new System.Drawing.Point(50, 151);
            this.hScrollBar1.Maximum = 189;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Value = 90;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(406, 151);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(53, 27);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "90";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(13, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "#01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(13, 203);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "#02";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(406, 199);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(53, 27);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "90";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Enabled = false;
            this.hScrollBar2.Location = new System.Drawing.Point(50, 199);
            this.hScrollBar2.Maximum = 189;
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar2.TabIndex = 4;
            this.hScrollBar2.Value = 90;
            this.hScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar2_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(13, 251);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "#03";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(406, 247);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(53, 27);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "90";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar3
            // 
            this.hScrollBar3.Enabled = false;
            this.hScrollBar3.Location = new System.Drawing.Point(50, 247);
            this.hScrollBar3.Maximum = 189;
            this.hScrollBar3.Name = "hScrollBar3";
            this.hScrollBar3.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar3.TabIndex = 7;
            this.hScrollBar3.Value = 90;
            this.hScrollBar3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar3_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(13, 299);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "#04";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(406, 295);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(53, 27);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "90";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar4
            // 
            this.hScrollBar4.Enabled = false;
            this.hScrollBar4.Location = new System.Drawing.Point(50, 295);
            this.hScrollBar4.Maximum = 189;
            this.hScrollBar4.Name = "hScrollBar4";
            this.hScrollBar4.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar4.TabIndex = 16;
            this.hScrollBar4.Value = 90;
            this.hScrollBar4.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar4_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(13, 347);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "#05";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(406, 343);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(53, 27);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = "90";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar5
            // 
            this.hScrollBar5.Enabled = false;
            this.hScrollBar5.Location = new System.Drawing.Point(50, 343);
            this.hScrollBar5.Maximum = 189;
            this.hScrollBar5.Name = "hScrollBar5";
            this.hScrollBar5.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar5.TabIndex = 13;
            this.hScrollBar5.Value = 90;
            this.hScrollBar5.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar5_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(522, 107);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "#06";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(915, 103);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(53, 27);
            this.textBox6.TabIndex = 11;
            this.textBox6.Text = "90";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar6
            // 
            this.hScrollBar6.Enabled = false;
            this.hScrollBar6.Location = new System.Drawing.Point(559, 103);
            this.hScrollBar6.Maximum = 189;
            this.hScrollBar6.Name = "hScrollBar6";
            this.hScrollBar6.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar6.TabIndex = 10;
            this.hScrollBar6.Value = 90;
            this.hScrollBar6.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar6_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(520, 155);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 19);
            this.label7.TabIndex = 36;
            this.label7.Text = "#07";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(915, 151);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(53, 27);
            this.textBox7.TabIndex = 35;
            this.textBox7.Text = "90";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar7
            // 
            this.hScrollBar7.Enabled = false;
            this.hScrollBar7.Location = new System.Drawing.Point(559, 151);
            this.hScrollBar7.Maximum = 189;
            this.hScrollBar7.Name = "hScrollBar7";
            this.hScrollBar7.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar7.TabIndex = 34;
            this.hScrollBar7.Value = 90;
            this.hScrollBar7.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar7_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(523, 203);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 19);
            this.label8.TabIndex = 33;
            this.label8.Text = "#08";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(916, 199);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(53, 27);
            this.textBox8.TabIndex = 32;
            this.textBox8.Text = "90";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar8
            // 
            this.hScrollBar8.Enabled = false;
            this.hScrollBar8.Location = new System.Drawing.Point(560, 199);
            this.hScrollBar8.Maximum = 189;
            this.hScrollBar8.Name = "hScrollBar8";
            this.hScrollBar8.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar8.TabIndex = 31;
            this.hScrollBar8.Value = 90;
            this.hScrollBar8.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar8_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(523, 251);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 19);
            this.label9.TabIndex = 30;
            this.label9.Text = "#09";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(916, 247);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(53, 27);
            this.textBox9.TabIndex = 29;
            this.textBox9.Text = "90";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar9
            // 
            this.hScrollBar9.Enabled = false;
            this.hScrollBar9.Location = new System.Drawing.Point(560, 247);
            this.hScrollBar9.Maximum = 189;
            this.hScrollBar9.Name = "hScrollBar9";
            this.hScrollBar9.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar9.TabIndex = 28;
            this.hScrollBar9.Value = 90;
            this.hScrollBar9.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar9_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(523, 299);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 19);
            this.label10.TabIndex = 27;
            this.label10.Text = "#10";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(915, 295);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(53, 27);
            this.textBox10.TabIndex = 26;
            this.textBox10.Text = "90";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar10
            // 
            this.hScrollBar10.Enabled = false;
            this.hScrollBar10.Location = new System.Drawing.Point(559, 295);
            this.hScrollBar10.Maximum = 189;
            this.hScrollBar10.Name = "hScrollBar10";
            this.hScrollBar10.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar10.TabIndex = 25;
            this.hScrollBar10.Value = 90;
            this.hScrollBar10.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar10_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(523, 347);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 19);
            this.label11.TabIndex = 24;
            this.label11.Text = "#11";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(915, 343);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(53, 27);
            this.textBox11.TabIndex = 23;
            this.textBox11.Text = "90";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar11
            // 
            this.hScrollBar11.Enabled = false;
            this.hScrollBar11.Location = new System.Drawing.Point(559, 343);
            this.hScrollBar11.Maximum = 189;
            this.hScrollBar11.Name = "hScrollBar11";
            this.hScrollBar11.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar11.TabIndex = 22;
            this.hScrollBar11.Value = 90;
            this.hScrollBar11.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar11_Scroll);
            // 
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label0.Location = new System.Drawing.Point(13, 107);
            this.label0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(36, 19);
            this.label0.TabIndex = 21;
            this.label0.Text = "#00";
            // 
            // textBox0
            // 
            this.textBox0.Location = new System.Drawing.Point(405, 103);
            this.textBox0.Margin = new System.Windows.Forms.Padding(4);
            this.textBox0.Name = "textBox0";
            this.textBox0.ReadOnly = true;
            this.textBox0.Size = new System.Drawing.Size(53, 27);
            this.textBox0.TabIndex = 20;
            this.textBox0.Text = "90";
            this.textBox0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBar0
            // 
            this.hScrollBar0.Enabled = false;
            this.hScrollBar0.Location = new System.Drawing.Point(50, 103);
            this.hScrollBar0.Maximum = 189;
            this.hScrollBar0.Name = "hScrollBar0";
            this.hScrollBar0.Size = new System.Drawing.Size(352, 27);
            this.hScrollBar0.TabIndex = 19;
            this.hScrollBar0.Value = 90;
            this.hScrollBar0.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar0_Scroll);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(341, 407);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(100, 43);
            this.btnMoveDown.TabIndex = 37;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(750, 407);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 43);
            this.btnClear.TabIndex = 38;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(869, 508);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 43);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(449, 407);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(100, 43);
            this.btnPlay.TabIndex = 40;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(125, 407);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 43);
            this.btnDelete.TabIndex = 41;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(17, 407);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(100, 43);
            this.btnAddNew.TabIndex = 43;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // cbPortList
            // 
            this.cbPortList.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbPortList.FormattingEnabled = true;
            this.cbPortList.Location = new System.Drawing.Point(76, 32);
            this.cbPortList.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbPortList.Name = "cbPortList";
            this.cbPortList.Size = new System.Drawing.Size(118, 24);
            this.cbPortList.TabIndex = 112;
            this.cbPortList.Text = "Refresh";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPort.Location = new System.Drawing.Point(16, 35);
            this.labelPort.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(50, 16);
            this.labelPort.TabIndex = 113;
            this.labelPort.Text = "COM :";
            this.labelPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(200, 28);
            this.btnStart.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 37);
            this.btnStart.TabIndex = 111;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbServer
            // 
            this.tbServer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbServer.Location = new System.Drawing.Point(76, 35);
            this.tbServer.Margin = new System.Windows.Forms.Padding(4);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(118, 27);
            this.tbServer.TabIndex = 114;
            this.tbServer.Text = "192.168.2.3";
            this.tbServer.Visible = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMessage});
            this.statusStrip.Location = new System.Drawing.Point(0, 692);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1007, 25);
            this.statusStrip.TabIndex = 115;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripMessage
            // 
            this.toolStripMessage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripMessage.Name = "toolStripMessage";
            this.toolStripMessage.Size = new System.Drawing.Size(992, 20);
            this.toolStripMessage.Spring = true;
            this.toolStripMessage.Text = "Ready";
            this.toolStripMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioAngle
            // 
            this.radioAngle.AutoSize = true;
            this.radioAngle.Checked = true;
            this.radioAngle.Location = new System.Drawing.Point(15, 26);
            this.radioAngle.Name = "radioAngle";
            this.radioAngle.Size = new System.Drawing.Size(64, 20);
            this.radioAngle.TabIndex = 116;
            this.radioAngle.TabStop = true;
            this.radioAngle.Text = "Angle";
            this.radioAngle.UseVisualStyleBackColor = true;
            this.radioAngle.CheckedChanged += new System.EventHandler(this.radioAngle_CheckedChanged);
            // 
            // radioPulseWidth
            // 
            this.radioPulseWidth.AutoSize = true;
            this.radioPulseWidth.Location = new System.Drawing.Point(85, 26);
            this.radioPulseWidth.Name = "radioPulseWidth";
            this.radioPulseWidth.Size = new System.Drawing.Size(101, 20);
            this.radioPulseWidth.TabIndex = 117;
            this.radioPulseWidth.Text = "Pulse Width";
            this.radioPulseWidth.UseVisualStyleBackColor = true;
            this.radioPulseWidth.CheckedChanged += new System.EventHandler(this.radioPulseWidth_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPortList);
            this.groupBox1.Controls.Add(this.tbServer);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.labelPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 76);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioAngle);
            this.groupBox2.Controls.Add(this.radioPulseWidth);
            this.groupBox2.Location = new System.Drawing.Point(556, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 59);
            this.groupBox2.TabIndex = 119;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Command";
            this.groupBox2.Visible = false;
            // 
            // gridViewCommand
            // 
            this.gridViewCommand.AllowUserToAddRows = false;
            this.gridViewCommand.AllowUserToDeleteRows = false;
            this.gridViewCommand.AllowUserToResizeRows = false;
            this.gridViewCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewCommand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewCommand.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewCommand.Location = new System.Drawing.Point(11, 457);
            this.gridViewCommand.Name = "gridViewCommand";
            this.gridViewCommand.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridViewCommand.RowTemplate.Height = 24;
            this.gridViewCommand.RowTemplate.ReadOnly = true;
            this.gridViewCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridViewCommand.Size = new System.Drawing.Size(839, 217);
            this.gridViewCommand.TabIndex = 123;
            this.gridViewCommand.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewCommand_RowEnter);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(868, 457);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 43);
            this.btnLoad.TabIndex = 124;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(511, 55);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 19);
            this.label12.TabIndex = 127;
            this.label12.Text = "時間";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(916, 50);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(53, 27);
            this.textBoxTime.TabIndex = 126;
            this.textBoxTime.Text = "500";
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollBarTime
            // 
            this.hScrollBarTime.Enabled = false;
            this.hScrollBarTime.Location = new System.Drawing.Point(559, 50);
            this.hScrollBarTime.Maximum = 59;
            this.hScrollBarTime.Minimum = 1;
            this.hScrollBarTime.Name = "hScrollBarTime";
            this.hScrollBarTime.Size = new System.Drawing.Size(353, 27);
            this.hScrollBarTime.TabIndex = 125;
            this.hScrollBarTime.Value = 25;
            this.hScrollBarTime.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarTime_Scroll);
            // 
            // btnSaveArduino
            // 
            this.btnSaveArduino.Location = new System.Drawing.Point(868, 559);
            this.btnSaveArduino.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveArduino.Name = "btnSaveArduino";
            this.btnSaveArduino.Size = new System.Drawing.Size(100, 43);
            this.btnSaveArduino.TabIndex = 128;
            this.btnSaveArduino.Text = "Arduino";
            this.btnSaveArduino.UseVisualStyleBackColor = true;
            this.btnSaveArduino.Click += new System.EventHandler(this.btnSaveArduino_Click);
            // 
            // timerPlay
            // 
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(359, 44);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 43);
            this.btnReset.TabIndex = 129;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // MySpiderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1007, 717);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSaveArduino);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.hScrollBarTime);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.gridViewCommand);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.hScrollBar7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.hScrollBar8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.hScrollBar9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.hScrollBar10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.hScrollBar11);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.textBox0);
            this.Controls.Add(this.hScrollBar0);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.hScrollBar4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.hScrollBar5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.hScrollBar6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.hScrollBar3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.hScrollBar2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.btnMoveUp);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MySpiderForm";
            this.Text = "My Spider Robot";
            this.Load += new System.EventHandler(this.MySpiderForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCommand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.HScrollBar hScrollBar3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.HScrollBar hScrollBar4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.HScrollBar hScrollBar5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.HScrollBar hScrollBar6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.HScrollBar hScrollBar7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.HScrollBar hScrollBar8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.HScrollBar hScrollBar9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.HScrollBar hScrollBar10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.HScrollBar hScrollBar11;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.TextBox textBox0;
        private System.Windows.Forms.HScrollBar hScrollBar0;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNew;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox cbPortList;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripMessage;
        private System.Windows.Forms.RadioButton radioAngle;
        private System.Windows.Forms.RadioButton radioPulseWidth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridViewCommand;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.HScrollBar hScrollBarTime;
        private System.Windows.Forms.Button btnSaveArduino;
        private System.Windows.Forms.Timer timerPlay;
        private System.Windows.Forms.Button btnReset;
    }
}

