﻿namespace MySweep
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageBase = new System.Windows.Forms.TabPage();
			this.checkBoxLog = new System.Windows.Forms.CheckBox();
			this.labelRedMe2 = new System.Windows.Forms.Label();
			this.txtBoxTime = new System.Windows.Forms.TextBox();
			this.labelTime = new System.Windows.Forms.Label();
			this.labelReadME = new System.Windows.Forms.Label();
			this.txtBoxDelay = new System.Windows.Forms.TextBox();
			this.labelDelay = new System.Windows.Forms.Label();
			this.btnStop = new System.Windows.Forms.Button();
			this.labPriceLow = new System.Windows.Forms.Label();
			this.txtBoxPriceLow = new System.Windows.Forms.TextBox();
			this.radioBtnLow = new System.Windows.Forms.RadioButton();
			this.radioBtnSweep = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.btnHwndForward = new System.Windows.Forms.Button();
			this.txtBoxLog = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnBegin = new System.Windows.Forms.Button();
			this.btnStartGame = new System.Windows.Forms.Button();
			this.btnCheckHwnd = new System.Windows.Forms.Button();
			this.txtBoxHwnd = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnChoosePath = new System.Windows.Forms.Button();
			this.txtBoxPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPageAdmin = new System.Windows.Forms.TabPage();
			this.btnFormMoveHide = new System.Windows.Forms.Button();
			this.btnGetPicture = new System.Windows.Forms.Button();
			this.groupBoxValue = new System.Windows.Forms.GroupBox();
			this.labelMs = new System.Windows.Forms.Label();
			this.checkBoxShowTime = new System.Windows.Forms.CheckBox();
			this.txtBoxHwndChildName = new System.Windows.Forms.TextBox();
			this.txtBoxHwndName = new System.Windows.Forms.TextBox();
			this.labelHwndChildName = new System.Windows.Forms.Label();
			this.labelHwndName = new System.Windows.Forms.Label();
			this.tabPageRead = new System.Windows.Forms.TabPage();
			this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
			this.FileDialog = new System.Windows.Forms.OpenFileDialog();
			this.timerThread = new System.Windows.Forms.Timer(this.components);
			this.timerClean = new System.Windows.Forms.Timer(this.components);
			this.timerUpdate = new System.Windows.Forms.Timer(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tabPageBase.SuspendLayout();
			this.tabPageAdmin.SuspendLayout();
			this.groupBoxValue.SuspendLayout();
			this.tabPageRead.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageBase);
			this.tabControl.Controls.Add(this.tabPageAdmin);
			this.tabControl.Controls.Add(this.tabPageRead);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(553, 284);
			this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl.TabIndex = 0;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
			// 
			// tabPageBase
			// 
			this.tabPageBase.Controls.Add(this.button1);
			this.tabPageBase.Controls.Add(this.checkBoxLog);
			this.tabPageBase.Controls.Add(this.labelRedMe2);
			this.tabPageBase.Controls.Add(this.txtBoxTime);
			this.tabPageBase.Controls.Add(this.labelTime);
			this.tabPageBase.Controls.Add(this.labelReadME);
			this.tabPageBase.Controls.Add(this.txtBoxDelay);
			this.tabPageBase.Controls.Add(this.labelDelay);
			this.tabPageBase.Controls.Add(this.btnStop);
			this.tabPageBase.Controls.Add(this.labPriceLow);
			this.tabPageBase.Controls.Add(this.txtBoxPriceLow);
			this.tabPageBase.Controls.Add(this.radioBtnLow);
			this.tabPageBase.Controls.Add(this.radioBtnSweep);
			this.tabPageBase.Controls.Add(this.label4);
			this.tabPageBase.Controls.Add(this.btnHwndForward);
			this.tabPageBase.Controls.Add(this.txtBoxLog);
			this.tabPageBase.Controls.Add(this.label3);
			this.tabPageBase.Controls.Add(this.btnBegin);
			this.tabPageBase.Controls.Add(this.btnStartGame);
			this.tabPageBase.Controls.Add(this.btnCheckHwnd);
			this.tabPageBase.Controls.Add(this.txtBoxHwnd);
			this.tabPageBase.Controls.Add(this.label2);
			this.tabPageBase.Controls.Add(this.btnChoosePath);
			this.tabPageBase.Controls.Add(this.txtBoxPath);
			this.tabPageBase.Controls.Add(this.label1);
			this.tabPageBase.Location = new System.Drawing.Point(4, 22);
			this.tabPageBase.Name = "tabPageBase";
			this.tabPageBase.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageBase.Size = new System.Drawing.Size(545, 258);
			this.tabPageBase.TabIndex = 0;
			this.tabPageBase.Text = "基础功能";
			this.tabPageBase.UseVisualStyleBackColor = true;
			// 
			// checkBoxLog
			// 
			this.checkBoxLog.AutoSize = true;
			this.checkBoxLog.Location = new System.Drawing.Point(247, 79);
			this.checkBoxLog.Name = "checkBoxLog";
			this.checkBoxLog.Size = new System.Drawing.Size(42, 16);
			this.checkBoxLog.TabIndex = 23;
			this.checkBoxLog.Text = "Log";
			this.checkBoxLog.UseVisualStyleBackColor = true;
			// 
			// labelRedMe2
			// 
			this.labelRedMe2.AutoSize = true;
			this.labelRedMe2.Location = new System.Drawing.Point(317, 94);
			this.labelRedMe2.Name = "labelRedMe2";
			this.labelRedMe2.Size = new System.Drawing.Size(47, 12);
			this.labelRedMe2.TabIndex = 22;
			this.labelRedMe2.Text = "F9:停止";
			// 
			// txtBoxTime
			// 
			this.txtBoxTime.Location = new System.Drawing.Point(268, 46);
			this.txtBoxTime.Name = "txtBoxTime";
			this.txtBoxTime.Size = new System.Drawing.Size(96, 21);
			this.txtBoxTime.TabIndex = 20;
			this.txtBoxTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxTime_KeyPress);
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
			this.labelReadME.Location = new System.Drawing.Point(317, 70);
			this.labelReadME.Name = "labelReadME";
			this.labelReadME.Size = new System.Drawing.Size(47, 12);
			this.labelReadME.TabIndex = 18;
			this.labelReadME.Text = "F8:开始";
			// 
			// txtBoxDelay
			// 
			this.txtBoxDelay.Location = new System.Drawing.Point(264, 112);
			this.txtBoxDelay.Name = "txtBoxDelay";
			this.txtBoxDelay.Size = new System.Drawing.Size(100, 21);
			this.txtBoxDelay.TabIndex = 10;
			this.txtBoxDelay.Text = "1";
			this.txtBoxDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxDelay_KeyPress);
			// 
			// labelDelay
			// 
			this.labelDelay.AutoSize = true;
			this.labelDelay.Location = new System.Drawing.Point(181, 115);
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
			this.labPriceLow.Location = new System.Drawing.Point(20, 115);
			this.labPriceLow.Name = "labPriceLow";
			this.labPriceLow.Size = new System.Drawing.Size(59, 12);
			this.labPriceLow.TabIndex = 15;
			this.labPriceLow.Text = "最低价格:";
			// 
			// txtBoxPriceLow
			// 
			this.txtBoxPriceLow.Location = new System.Drawing.Point(95, 112);
			this.txtBoxPriceLow.Name = "txtBoxPriceLow";
			this.txtBoxPriceLow.Size = new System.Drawing.Size(70, 21);
			this.txtBoxPriceLow.TabIndex = 9;
			this.txtBoxPriceLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxPriceLow_KeyPress);
			// 
			// radioBtnLow
			// 
			this.radioBtnLow.AutoSize = true;
			this.radioBtnLow.Location = new System.Drawing.Point(160, 79);
			this.radioBtnLow.Name = "radioBtnLow";
			this.radioBtnLow.Size = new System.Drawing.Size(59, 16);
			this.radioBtnLow.TabIndex = 6;
			this.radioBtnLow.Text = "低价秒";
			this.radioBtnLow.UseVisualStyleBackColor = true;
			// 
			// radioBtnSweep
			// 
			this.radioBtnSweep.AutoSize = true;
			this.radioBtnSweep.Checked = true;
			this.radioBtnSweep.Location = new System.Drawing.Point(95, 79);
			this.radioBtnSweep.Name = "radioBtnSweep";
			this.radioBtnSweep.Size = new System.Drawing.Size(59, 16);
			this.radioBtnSweep.TabIndex = 5;
			this.radioBtnSweep.TabStop = true;
			this.radioBtnSweep.Text = "直接秒";
			this.radioBtnSweep.UseVisualStyleBackColor = true;
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
			// txtBoxLog
			// 
			this.txtBoxLog.Location = new System.Drawing.Point(95, 149);
			this.txtBoxLog.Multiline = true;
			this.txtBoxLog.Name = "txtBoxLog";
			this.txtBoxLog.Size = new System.Drawing.Size(325, 99);
			this.txtBoxLog.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 149);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 12);
			this.label3.TabIndex = 8;
			this.label3.Text = "工作日志:";
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
			// txtBoxHwnd
			// 
			this.txtBoxHwnd.Location = new System.Drawing.Point(95, 45);
			this.txtBoxHwnd.Name = "txtBoxHwnd";
			this.txtBoxHwnd.ReadOnly = true;
			this.txtBoxHwnd.Size = new System.Drawing.Size(100, 21);
			this.txtBoxHwnd.TabIndex = 3;
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
			// txtBoxPath
			// 
			this.txtBoxPath.Location = new System.Drawing.Point(95, 8);
			this.txtBoxPath.Name = "txtBoxPath";
			this.txtBoxPath.ReadOnly = true;
			this.txtBoxPath.Size = new System.Drawing.Size(269, 21);
			this.txtBoxPath.TabIndex = 1;
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
			// tabPageAdmin
			// 
			this.tabPageAdmin.Controls.Add(this.btnFormMoveHide);
			this.tabPageAdmin.Controls.Add(this.btnGetPicture);
			this.tabPageAdmin.Controls.Add(this.groupBoxValue);
			this.tabPageAdmin.Location = new System.Drawing.Point(4, 22);
			this.tabPageAdmin.Name = "tabPageAdmin";
			this.tabPageAdmin.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAdmin.Size = new System.Drawing.Size(545, 258);
			this.tabPageAdmin.TabIndex = 1;
			this.tabPageAdmin.Text = "管理员功能";
			this.tabPageAdmin.UseVisualStyleBackColor = true;
			// 
			// btnFormMoveHide
			// 
			this.btnFormMoveHide.Location = new System.Drawing.Point(6, 142);
			this.btnFormMoveHide.Name = "btnFormMoveHide";
			this.btnFormMoveHide.Size = new System.Drawing.Size(75, 23);
			this.btnFormMoveHide.TabIndex = 2;
			this.btnFormMoveHide.Text = "移动屏幕外";
			this.btnFormMoveHide.UseVisualStyleBackColor = true;
			this.btnFormMoveHide.Click += new System.EventHandler(this.btnFormMoveHide_Click);
			// 
			// btnGetPicture
			// 
			this.btnGetPicture.Location = new System.Drawing.Point(6, 112);
			this.btnGetPicture.Name = "btnGetPicture";
			this.btnGetPicture.Size = new System.Drawing.Size(75, 23);
			this.btnGetPicture.TabIndex = 1;
			this.btnGetPicture.Text = "获取截图";
			this.btnGetPicture.UseVisualStyleBackColor = true;
			this.btnGetPicture.Click += new System.EventHandler(this.btnGetPicture_Click);
			// 
			// groupBoxValue
			// 
			this.groupBoxValue.Controls.Add(this.labelMs);
			this.groupBoxValue.Controls.Add(this.checkBoxShowTime);
			this.groupBoxValue.Controls.Add(this.txtBoxHwndChildName);
			this.groupBoxValue.Controls.Add(this.txtBoxHwndName);
			this.groupBoxValue.Controls.Add(this.labelHwndChildName);
			this.groupBoxValue.Controls.Add(this.labelHwndName);
			this.groupBoxValue.Location = new System.Drawing.Point(8, 6);
			this.groupBoxValue.Name = "groupBoxValue";
			this.groupBoxValue.Size = new System.Drawing.Size(200, 100);
			this.groupBoxValue.TabIndex = 0;
			this.groupBoxValue.TabStop = false;
			this.groupBoxValue.Text = "参数设置";
			// 
			// labelMs
			// 
			this.labelMs.AutoSize = true;
			this.labelMs.Location = new System.Drawing.Point(87, 79);
			this.labelMs.Name = "labelMs";
			this.labelMs.Size = new System.Drawing.Size(35, 12);
			this.labelMs.TabIndex = 5;
			this.labelMs.Text = "000ms";
			// 
			// checkBoxShowTime
			// 
			this.checkBoxShowTime.AutoSize = true;
			this.checkBoxShowTime.Location = new System.Drawing.Point(9, 78);
			this.checkBoxShowTime.Name = "checkBoxShowTime";
			this.checkBoxShowTime.Size = new System.Drawing.Size(72, 16);
			this.checkBoxShowTime.TabIndex = 4;
			this.checkBoxShowTime.Text = "查看时间";
			this.checkBoxShowTime.UseVisualStyleBackColor = true;
			// 
			// txtBoxHwndChildName
			// 
			this.txtBoxHwndChildName.Location = new System.Drawing.Point(84, 48);
			this.txtBoxHwndChildName.Name = "txtBoxHwndChildName";
			this.txtBoxHwndChildName.Size = new System.Drawing.Size(110, 21);
			this.txtBoxHwndChildName.TabIndex = 3;
			this.txtBoxHwndChildName.Text = "《梦幻西游》手游";
			// 
			// txtBoxHwndName
			// 
			this.txtBoxHwndName.Location = new System.Drawing.Point(84, 18);
			this.txtBoxHwndName.Name = "txtBoxHwndName";
			this.txtBoxHwndName.Size = new System.Drawing.Size(110, 21);
			this.txtBoxHwndName.TabIndex = 2;
			this.txtBoxHwndName.Text = "梦幻西游手游";
			// 
			// labelHwndChildName
			// 
			this.labelHwndChildName.AutoSize = true;
			this.labelHwndChildName.Location = new System.Drawing.Point(7, 51);
			this.labelHwndChildName.Name = "labelHwndChildName";
			this.labelHwndChildName.Size = new System.Drawing.Size(71, 12);
			this.labelHwndChildName.TabIndex = 1;
			this.labelHwndChildName.Text = "子句柄名字:";
			// 
			// labelHwndName
			// 
			this.labelHwndName.AutoSize = true;
			this.labelHwndName.Location = new System.Drawing.Point(7, 21);
			this.labelHwndName.Name = "labelHwndName";
			this.labelHwndName.Size = new System.Drawing.Size(71, 12);
			this.labelHwndName.TabIndex = 0;
			this.labelHwndName.Text = "父句柄名字:";
			// 
			// tabPageRead
			// 
			this.tabPageRead.Controls.Add(this.cogRecordDisplay1);
			this.tabPageRead.Location = new System.Drawing.Point(4, 22);
			this.tabPageRead.Name = "tabPageRead";
			this.tabPageRead.Size = new System.Drawing.Size(545, 258);
			this.tabPageRead.TabIndex = 2;
			this.tabPageRead.Text = "图片识别功能";
			this.tabPageRead.UseVisualStyleBackColor = true;
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
			this.cogRecordDisplay1.Location = new System.Drawing.Point(3, 3);
			this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
			this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
			this.cogRecordDisplay1.Name = "cogRecordDisplay1";
			this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
			this.cogRecordDisplay1.Size = new System.Drawing.Size(472, 400);
			this.cogRecordDisplay1.TabIndex = 10;
			// 
			// FileDialog
			// 
			this.FileDialog.FileName = "mymain";
			this.FileDialog.Filter = "应用程序(*.exe)|*.exe|所有文件|*.*";
			// 
			// timerThread
			// 
			this.timerThread.Interval = 200;
			this.timerThread.Tick += new System.EventHandler(this.timerThread_Tick);
			// 
			// timerClean
			// 
			this.timerClean.Interval = 30000;
			this.timerClean.Tick += new System.EventHandler(this.timerClean_Tick);
			// 
			// timerUpdate
			// 
			this.timerUpdate.Interval = 3600000;
			this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(370, 79);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 24;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(553, 284);
			this.Controls.Add(this.tabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Opacity = 0.85D;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.tabControl.ResumeLayout(false);
			this.tabPageBase.ResumeLayout(false);
			this.tabPageBase.PerformLayout();
			this.tabPageAdmin.ResumeLayout(false);
			this.groupBoxValue.ResumeLayout(false);
			this.groupBoxValue.PerformLayout();
			this.tabPageRead.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageBase;
		private System.Windows.Forms.TabPage tabPageAdmin;
		private System.Windows.Forms.Button btnChoosePath;
		private System.Windows.Forms.TextBox txtBoxPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnStartGame;
		private System.Windows.Forms.Button btnCheckHwnd;
		private System.Windows.Forms.TextBox txtBoxHwnd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtBoxLog;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnBegin;
		private System.Windows.Forms.Button btnHwndForward;
		private System.Windows.Forms.OpenFileDialog FileDialog;
		private System.Windows.Forms.TabPage tabPageRead;
		private System.Windows.Forms.GroupBox groupBoxValue;
		private System.Windows.Forms.Label labelHwndChildName;
		private System.Windows.Forms.Label labelHwndName;
		private System.Windows.Forms.TextBox txtBoxHwndChildName;
		private System.Windows.Forms.TextBox txtBoxHwndName;
		private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton radioBtnLow;
		private System.Windows.Forms.RadioButton radioBtnSweep;
		private System.Windows.Forms.Label labPriceLow;
		private System.Windows.Forms.TextBox txtBoxPriceLow;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Timer timerThread;
		private System.Windows.Forms.TextBox txtBoxDelay;
		private System.Windows.Forms.Label labelDelay;
		private System.Windows.Forms.Timer timerClean;
		private System.Windows.Forms.Timer timerUpdate;
		private System.Windows.Forms.Label labelReadME;
		private System.Windows.Forms.Button btnGetPicture;
		private System.Windows.Forms.Button btnFormMoveHide;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.TextBox txtBoxTime;
		private System.Windows.Forms.Label labelRedMe2;
		private System.Windows.Forms.CheckBox checkBoxLog;
		private System.Windows.Forms.CheckBox checkBoxShowTime;
		private System.Windows.Forms.Label labelMs;
		private System.Windows.Forms.Button button1;
	}
}
