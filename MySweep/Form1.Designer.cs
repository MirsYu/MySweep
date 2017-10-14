namespace MySweep
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.timerEmail = new System.Windows.Forms.Timer(this.components);
            this.tabData = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ClCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClSuccess = new Cognex.VisionPro.Implementation.CogGridViewCheckBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPageRead = new System.Windows.Forms.TabPage();
            this.Run = new System.Windows.Forms.Button();
            this.cogToolBlockEditV21 = new Cognex.VisionPro.ToolBlock.CogToolBlockEditV2();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.tabPageBase = new System.Windows.Forms.TabPage();
            this.btnGetPicture = new System.Windows.Forms.Button();
            this.checkBoxMail = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtBoxTime = new System.Windows.Forms.TextBox();
            this.txtBoxDelay = new System.Windows.Forms.TextBox();
            this.txtBoxPriceLow = new System.Windows.Forms.TextBox();
            this.txtBoxHwnd = new System.Windows.Forms.TextBox();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelRedMe2 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelReadME = new System.Windows.Forms.Label();
            this.labelDelay = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.labPriceLow = new System.Windows.Forms.Label();
            this.radioBtnLow = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHwndForward = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnCheckHwnd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChoosePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.txtBox_Name = new System.Windows.Forms.TextBox();
            this.timerThread = new System.Windows.Forms.Timer(this.components);
            this.tabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.tabPageBase.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "mymain";
            this.FileDialog.Filter = "应用程序(*.exe)|*.exe|所有文件|*.*";
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 3600000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // timerEmail
            // 
            this.timerEmail.Tick += new System.EventHandler(this.timerEmail_Tick);
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.dataGridView1);
            this.tabData.Controls.Add(this.button5);
            this.tabData.Controls.Add(this.button4);
            this.tabData.Controls.Add(this.button3);
            this.tabData.Controls.Add(this.button2);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Size = new System.Drawing.Size(551, 276);
            this.tabData.TabIndex = 3;
            this.tabData.Text = "数据视图";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClCount,
            this.ClPrice,
            this.ClSuccess});
            this.dataGridView1.Location = new System.Drawing.Point(125, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(423, 265);
            this.dataGridView1.TabIndex = 17;
            // 
            // ClCount
            // 
            this.ClCount.HeaderText = "Count";
            this.ClCount.Name = "ClCount";
            // 
            // ClPrice
            // 
            this.ClPrice.HeaderText = "Price";
            this.ClPrice.Name = "ClPrice";
            // 
            // ClSuccess
            // 
            this.ClSuccess.Electric = false;
            this.ClSuccess.ElectricIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.ClSuccess.ElectricIconHidden = false;
            this.ClSuccess.ElectricIconPadding = -10;
            this.ClSuccess.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight;
            this.ClSuccess.ErrorIconPadding = -36;
            this.ClSuccess.HeaderText = "ReadSuccess";
            this.ClSuccess.Name = "ClSuccess";
            this.ClSuccess.Path = null;
            this.ClSuccess.SubjectInUseMode = Cognex.VisionPro.CogSubjectInUseModeConstants.ReadOnly;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(31, 159);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "Stop";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(31, 114);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Continue Run";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(31, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Run";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "First";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPageRead
            // 
            this.tabPageRead.Controls.Add(this.Run);
            this.tabPageRead.Controls.Add(this.cogToolBlockEditV21);
            this.tabPageRead.Controls.Add(this.cogRecordDisplay1);
            this.tabPageRead.Location = new System.Drawing.Point(4, 22);
            this.tabPageRead.Name = "tabPageRead";
            this.tabPageRead.Size = new System.Drawing.Size(551, 276);
            this.tabPageRead.TabIndex = 2;
            this.tabPageRead.Text = "图片识别功能";
            this.tabPageRead.UseVisualStyleBackColor = true;
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(8, 397);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 12;
            this.Run.Text = "button2";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // cogToolBlockEditV21
            // 
            this.cogToolBlockEditV21.AllowDrop = true;
            this.cogToolBlockEditV21.ContextMenuCustomizer = null;
            this.cogToolBlockEditV21.Location = new System.Drawing.Point(0, -1);
            this.cogToolBlockEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogToolBlockEditV21.Name = "cogToolBlockEditV21";
            this.cogToolBlockEditV21.ShowNodeToolTips = true;
            this.cogToolBlockEditV21.Size = new System.Drawing.Size(489, 392);
            this.cogToolBlockEditV21.SuspendElectricRuns = false;
            this.cogToolBlockEditV21.TabIndex = 11;
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(482, -4);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(472, 400);
            this.cogRecordDisplay1.TabIndex = 10;
            // 
            // tabPageBase
            // 
            this.tabPageBase.Controls.Add(this.txtBox_Name);
            this.tabPageBase.Controls.Add(this.btnGetPicture);
            this.tabPageBase.Controls.Add(this.checkBoxMail);
            this.tabPageBase.Controls.Add(this.textBox1);
            this.tabPageBase.Controls.Add(this.txtBoxTime);
            this.tabPageBase.Controls.Add(this.txtBoxDelay);
            this.tabPageBase.Controls.Add(this.txtBoxPriceLow);
            this.tabPageBase.Controls.Add(this.txtBoxHwnd);
            this.tabPageBase.Controls.Add(this.txtBoxPath);
            this.tabPageBase.Controls.Add(this.label5);
            this.tabPageBase.Controls.Add(this.labelRedMe2);
            this.tabPageBase.Controls.Add(this.labelTime);
            this.tabPageBase.Controls.Add(this.labelReadME);
            this.tabPageBase.Controls.Add(this.labelDelay);
            this.tabPageBase.Controls.Add(this.btnStop);
            this.tabPageBase.Controls.Add(this.labPriceLow);
            this.tabPageBase.Controls.Add(this.radioBtnLow);
            this.tabPageBase.Controls.Add(this.label4);
            this.tabPageBase.Controls.Add(this.btnHwndForward);
            this.tabPageBase.Controls.Add(this.btnBegin);
            this.tabPageBase.Controls.Add(this.btnStartGame);
            this.tabPageBase.Controls.Add(this.btnCheckHwnd);
            this.tabPageBase.Controls.Add(this.label2);
            this.tabPageBase.Controls.Add(this.btnChoosePath);
            this.tabPageBase.Controls.Add(this.label1);
            this.tabPageBase.Location = new System.Drawing.Point(4, 22);
            this.tabPageBase.Name = "tabPageBase";
            this.tabPageBase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBase.Size = new System.Drawing.Size(551, 276);
            this.tabPageBase.TabIndex = 0;
            this.tabPageBase.Text = "基础功能";
            this.tabPageBase.UseVisualStyleBackColor = true;
            // 
            // btnGetPicture
            // 
            this.btnGetPicture.Location = new System.Drawing.Point(287, 226);
            this.btnGetPicture.Name = "btnGetPicture";
            this.btnGetPicture.Size = new System.Drawing.Size(75, 23);
            this.btnGetPicture.TabIndex = 27;
            this.btnGetPicture.Text = "获取截图";
            this.btnGetPicture.UseVisualStyleBackColor = true;
            this.btnGetPicture.Click += new System.EventHandler(this.btnGetPicture_Click);
            // 
            // checkBoxMail
            // 
            this.checkBoxMail.AutoSize = true;
            this.checkBoxMail.Location = new System.Drawing.Point(22, 226);
            this.checkBoxMail.Name = "checkBoxMail";
            this.checkBoxMail.Size = new System.Drawing.Size(84, 16);
            this.checkBoxMail.TabIndex = 26;
            this.checkBoxMail.Text = "收邮件模式";
            this.checkBoxMail.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "200";
            // 
            // txtBoxTime
            // 
            this.txtBoxTime.Location = new System.Drawing.Point(268, 46);
            this.txtBoxTime.Name = "txtBoxTime";
            this.txtBoxTime.Size = new System.Drawing.Size(99, 21);
            this.txtBoxTime.TabIndex = 20;
            this.txtBoxTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxTime_KeyPress);
            // 
            // txtBoxDelay
            // 
            this.txtBoxDelay.Location = new System.Drawing.Point(316, 166);
            this.txtBoxDelay.Name = "txtBoxDelay";
            this.txtBoxDelay.Size = new System.Drawing.Size(46, 21);
            this.txtBoxDelay.TabIndex = 10;
            this.txtBoxDelay.Text = "100";
            this.txtBoxDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxDelay_KeyPress);
            // 
            // txtBoxPriceLow
            // 
            this.txtBoxPriceLow.Location = new System.Drawing.Point(98, 120);
            this.txtBoxPriceLow.Name = "txtBoxPriceLow";
            this.txtBoxPriceLow.Size = new System.Drawing.Size(70, 21);
            this.txtBoxPriceLow.TabIndex = 9;
            this.txtBoxPriceLow.Text = "70";
            this.txtBoxPriceLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxPriceLow_KeyPress);
            // 
            // txtBoxHwnd
            // 
            this.txtBoxHwnd.Location = new System.Drawing.Point(98, 45);
            this.txtBoxHwnd.Name = "txtBoxHwnd";
            this.txtBoxHwnd.ReadOnly = true;
            this.txtBoxHwnd.Size = new System.Drawing.Size(100, 21);
            this.txtBoxHwnd.TabIndex = 3;
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(98, 8);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.ReadOnly = true;
            this.txtBoxPath.Size = new System.Drawing.Size(269, 21);
            this.txtBoxPath.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "按键间隔(ms):";
            // 
            // labelRedMe2
            // 
            this.labelRedMe2.AutoSize = true;
            this.labelRedMe2.Location = new System.Drawing.Point(233, 134);
            this.labelRedMe2.Name = "labelRedMe2";
            this.labelRedMe2.Size = new System.Drawing.Size(47, 12);
            this.labelRedMe2.TabIndex = 22;
            this.labelRedMe2.Text = "F9:停止";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(204, 49);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(59, 12);
            this.labelTime.TabIndex = 19;
            this.labelTime.Text = "点击次数:";
            // 
            // labelReadME
            // 
            this.labelReadME.AutoSize = true;
            this.labelReadME.Location = new System.Drawing.Point(233, 110);
            this.labelReadME.Name = "labelReadME";
            this.labelReadME.Size = new System.Drawing.Size(47, 12);
            this.labelReadME.TabIndex = 18;
            this.labelReadME.Text = "F8:开始";
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(233, 169);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(83, 12);
            this.labelDelay.TabIndex = 17;
            this.labelDelay.Text = "搜索间隔(ms):";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(429, 226);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(108, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // labPriceLow
            // 
            this.labPriceLow.AutoSize = true;
            this.labPriceLow.Location = new System.Drawing.Point(20, 123);
            this.labPriceLow.Name = "labPriceLow";
            this.labPriceLow.Size = new System.Drawing.Size(59, 12);
            this.labPriceLow.TabIndex = 15;
            this.labPriceLow.Text = "最低价格:";
            // 
            // radioBtnLow
            // 
            this.radioBtnLow.AutoSize = true;
            this.radioBtnLow.Location = new System.Drawing.Point(98, 79);
            this.radioBtnLow.Name = "radioBtnLow";
            this.radioBtnLow.Size = new System.Drawing.Size(59, 16);
            this.radioBtnLow.TabIndex = 6;
            this.radioBtnLow.Text = "低价秒";
            this.radioBtnLow.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "工作模式:";
            // 
            // btnHwndForward
            // 
            this.btnHwndForward.Location = new System.Drawing.Point(429, 138);
            this.btnHwndForward.Name = "btnHwndForward";
            this.btnHwndForward.Size = new System.Drawing.Size(108, 23);
            this.btnHwndForward.TabIndex = 8;
            this.btnHwndForward.Text = "窗口前置";
            this.btnHwndForward.UseVisualStyleBackColor = true;
            this.btnHwndForward.Click += new System.EventHandler(this.btnHwndForward_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(429, 182);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(108, 23);
            this.btnBegin.TabIndex = 11;
            this.btnBegin.Text = "开始";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(429, 50);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(108, 23);
            this.btnStartGame.TabIndex = 4;
            this.btnStartGame.Text = "启动程序";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnCheckHwnd
            // 
            this.btnCheckHwnd.Location = new System.Drawing.Point(429, 94);
            this.btnCheckHwnd.Name = "btnCheckHwnd";
            this.btnCheckHwnd.Size = new System.Drawing.Size(108, 23);
            this.btnCheckHwnd.TabIndex = 7;
            this.btnCheckHwnd.Text = "查找句柄";
            this.btnCheckHwnd.UseVisualStyleBackColor = true;
            this.btnCheckHwnd.Click += new System.EventHandler(this.btnCheckHwnd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "窗口句柄:";
            // 
            // btnChoosePath
            // 
            this.btnChoosePath.Location = new System.Drawing.Point(429, 6);
            this.btnChoosePath.Name = "btnChoosePath";
            this.btnChoosePath.Size = new System.Drawing.Size(108, 23);
            this.btnChoosePath.TabIndex = 2;
            this.btnChoosePath.Text = "选择路径";
            this.btnChoosePath.UseVisualStyleBackColor = true;
            this.btnChoosePath.Click += new System.EventHandler(this.btnChoosePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件路径:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageBase);
            this.tabControl.Controls.Add(this.tabPageRead);
            this.tabControl.Controls.Add(this.tabData);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(559, 302);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // txtBox_Name
            // 
            this.txtBox_Name.Location = new System.Drawing.Point(268, 81);
            this.txtBox_Name.Name = "txtBox_Name";
            this.txtBox_Name.Size = new System.Drawing.Size(100, 21);
            this.txtBox_Name.TabIndex = 28;
            // 
            // timerThread
            // 
            this.timerThread.Interval = 3600000;
            this.timerThread.Tick += new System.EventHandler(this.timerThread_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 302);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.tabPageBase.ResumeLayout(false);
            this.tabPageBase.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.OpenFileDialog FileDialog;
		private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Timer timerEmail;
		private System.Windows.Forms.TabPage tabData;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TabPage tabPageRead;
		private System.Windows.Forms.Button Run;
		private Cognex.VisionPro.ToolBlock.CogToolBlockEditV2 cogToolBlockEditV21;
		private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
		private System.Windows.Forms.TabPage tabPageBase;
		private System.Windows.Forms.Button btnGetPicture;
		private System.Windows.Forms.CheckBox checkBoxMail;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox txtBoxTime;
		private System.Windows.Forms.TextBox txtBoxDelay;
		public System.Windows.Forms.TextBox txtBoxPriceLow;
		private System.Windows.Forms.TextBox txtBoxHwnd;
		private System.Windows.Forms.TextBox txtBoxPath;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelRedMe2;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.Label labelReadME;
		private System.Windows.Forms.Label labelDelay;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Label labPriceLow;
		private System.Windows.Forms.RadioButton radioBtnLow;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnHwndForward;
		private System.Windows.Forms.Button btnBegin;
		private System.Windows.Forms.Button btnStartGame;
		private System.Windows.Forms.Button btnCheckHwnd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnChoosePath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClCount;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClPrice;
		private Cognex.VisionPro.Implementation.CogGridViewCheckBoxColumn ClSuccess;
        private System.Windows.Forms.TextBox txtBox_Name;
        private System.Windows.Forms.Timer timerThread;
    }
}

