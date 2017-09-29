﻿using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MySweep
{
	public partial class Form1 : Form
	{
		// 鼠标
		private CDD dd;
		// 视觉模块
		private CogToolBlock block;
		// 识别失败图片保存路径
		string strFailCheck;
		// 图像识别模块路径
		string strVisPath;
		// Log路径组合
		string strLogPath;
		// Config文件路径
		string strConfigPath;
		// 父句柄
		public static IntPtr MainHwnd;
		// 子句柄
		IntPtr Hwnd;
		// 启动的程序PID
		int pid;
		// 时间记录
		double time = 0;

		public Form1()
		{
			strLogPath = AppDomain.CurrentDomain.BaseDirectory + "Log" + "\\" + TimeToFile() + ".log";
			strVisPath = AppDomain.CurrentDomain.BaseDirectory + "图像识别模块" + "\\" + "RunBlock.vpp";
			strFailCheck = AppDomain.CurrentDomain.BaseDirectory + "无法识别图片" + "\\";
			strConfigPath = AppDomain.CurrentDomain.BaseDirectory + "配置文件" + "\\" + "config.ini";
			string strConfigResult = FileOperation.Read(strConfigPath);
			InitializeComponent();
			if (strConfigResult == "")
				WriteConfig();
			else
				ReadConfig();

			// 加载视觉模块
			loadvpp(strVisPath);
			// 注册热键
			reg_hotkey();
			// 初始化鼠标驱动
			dd = new CDD();
			// DDHID64
			string dllfile = "";
			LoadDllFile(dllfile);
		}

		private void LogShowWrite(string log)
		{
			if (checkBoxLog.Checked)
			{
				// log信息处理
				string Temp = "[" + DateTime.Now + "]" + ":" + log;
				// 先写入box
				txtBoxLog.Text += Temp + "\r\n";
				txtBoxLog.Focus();//获取焦点
				txtBoxLog.Select(txtBoxLog.TextLength, 0);//光标定位到文本最后
				txtBoxLog.ScrollToCaret();//滚动到光标处
				if (!FileOperation.WriteLine(strLogPath, Temp))
				{
					MessageBox.Show(Temp + "\r\n" + "写入Log文件失败");
				}
			}
		}

		private bool ProcessMode1()
		{
			LogShowWrite("模式1启动");
			Bitmap image;
			CogImage24PlanarColor imageSource;
			CogImageConvertTool convertTool = block.Tools["CogImageConvertTool1"] as CogImageConvertTool;
			CogPMAlignMultiTool pmMultiTool = block.Tools["CogPMAlignMultiTool1"] as CogPMAlignMultiTool;
			CogPMAlignResults PMAResult;
			CogPMAlignResult buyPageResult;
			CogPMAlignResult buyCenterResult;
			CogPMAlignResult objBuyButtonResult;
			CogPMAlignResult numSelectButtonResult;
			CogPMAlignResult buyUpdateResult;
			CogPMAlignResult lookPetBtnResult;

			Point mouseClick = new Point();
			image = null;
			imageSource = null;
			image = ProgramOperation.ALT(Hwnd);
			if (image != null) LogShowWrite("截图成功");
			else { LogShowWrite("截图失败"); return false; }
			imageSource = new CogImage24PlanarColor(image);
			if(imageSource != null) LogShowWrite("灰度图转换成功");
			else { LogShowWrite("灰度图转换失败"); return false; }
			convertTool.InputImage = imageSource;
			convertTool.Run();
			block.Run();
			this.cogRecordDisplay1.Image = (CogImage8Grey)convertTool.OutputImage;
			this.cogRecordDisplay1.Record = block.CreateLastRunRecord();
			this.cogRecordDisplay1.AutoFit = true;
			// 一次只点击一次
			PMAResult = block.Outputs["Results_PMAlignResults"].Value as CogPMAlignResults;
			// 遍历结果
			objBuyButtonResult = CheckName(PMAResult, "物品购买按钮");
			numSelectButtonResult = CheckName(PMAResult, "数量选择按钮");
			buyPageResult = CheckName(PMAResult, "摆摊界面购买按钮");
			buyCenterResult = CheckName(PMAResult, "商会按钮(用于刷新)");
			buyUpdateResult = CheckName(PMAResult,"摆摊按钮");
			lookPetBtnResult = CheckName(PMAResult, "公示宠物按钮");

			if (objBuyButtonResult != null && numSelectButtonResult != null)
			{
				mouseClick.X = (int)(numSelectButtonResult.GetPose().TranslationX);
				mouseClick.Y = (int)(numSelectButtonResult.GetPose().TranslationY);
				MouseMoveClick(CalcPointScreenpos(mouseClick), int.Parse(txtBoxTime.Text));
				mouseClick.X = (int)(objBuyButtonResult.GetPose().TranslationX);
				mouseClick.Y = (int)(objBuyButtonResult.GetPose().TranslationY);
				MouseMoveClick(CalcPointScreenpos(mouseClick), 1);
				LogShowWrite("物品数量选择界面");
			}
			else if (lookPetBtnResult != null)
			{
				mouseClick.X = (int)(lookPetBtnResult.GetPose().TranslationX);
				mouseClick.Y = (int)(lookPetBtnResult.GetPose().TranslationY);
				MouseMoveClick(CalcPointScreenpos(mouseClick), int.Parse(txtBoxTime.Text));
				LogShowWrite("关注界面");
			}
			else if (buyPageResult != null)
			{
				#region 2种模式
				if (radioBtnLow.Checked == true)
				{
					if (int.Parse(block.Outputs["Result"].Value.ToString()) <= int.Parse(txtBoxPriceLow.Text) &&
					block.Outputs["Result"].Value.ToString() != "??")
					{
						mouseClick.X = (int)(double.Parse(block.Outputs["X1"].Value.ToString()));
						mouseClick.Y = (int)(double.Parse(block.Outputs["Y1"].Value.ToString()));
						MouseMoveClick(CalcPointScreenpos(mouseClick), 1);
						LogShowWrite("选中了商品");
						LogShowWrite("购买成功当前价格:" + block.Outputs["Result"].Value.ToString() + ",目标价格为:" + int.Parse(txtBoxPriceLow.Text));
					}
					else
					{
						LogShowWrite("购买失败当前价格:" + block.Outputs["Result"].Value.ToString() + ",目标价格为:" + int.Parse(txtBoxPriceLow.Text));
					}
				}
				else if (radioBtnSweep.Checked == true)
				{
					mouseClick.X = (int)(double.Parse(block.Outputs["X1"].Value.ToString()));
					mouseClick.Y = (int)(double.Parse(block.Outputs["Y1"].Value.ToString()));
					MouseMoveClick(CalcPointScreenpos(mouseClick), 1);
					LogShowWrite("选中了商品");
					LogShowWrite("购买成功当前价格:" + block.Outputs["Result"].Value.ToString() + ",目标价格为:" + int.Parse(txtBoxPriceLow.Text));
				}
				#endregion
				mouseClick.X = (int)(buyPageResult.GetPose().TranslationX);
				mouseClick.Y = (int)(buyPageResult.GetPose().TranslationY);
				MouseMoveClick(CalcPointScreenpos(mouseClick), 1);
				LogShowWrite("摆摊界面购买按钮");
			}

			Thread.Sleep(int.Parse(txtBoxDelay.Text));
			if (buyUpdateResult != null)
			{
				mouseClick.X = (int)(buyUpdateResult.GetPose().TranslationX);
				mouseClick.Y = (int)(buyUpdateResult.GetPose().TranslationY);
				MouseMoveClick(CalcPointScreenpos(mouseClick), 1);
				LogShowWrite("摆摊界面按钮");
				return true;
			}
			else if (buyCenterResult != null)
			{
				mouseClick.X = (int)(buyCenterResult.GetPose().TranslationX);
				mouseClick.Y = (int)(buyCenterResult.GetPose().TranslationY);
				MouseMoveClick(CalcPointScreenpos(mouseClick), 1);
				LogShowWrite("刷新界面按钮");
				return true;
			}
			else
			{
				image.Save(strFailCheck + TimeToFile() + ".png");
				LogShowWrite("未知错误");
				return false;
			}
		}

		private void loadvpp(string filepath)
		{
			object obj = CogSerializer.LoadObjectFromFile(filepath);
			block = (CogToolBlock)obj;
			if (block !=null)
			{
				LogShowWrite("视觉模块加载成功");
			}
		}

		private string TimeToFile()
		{
			string time = DateTime.Now.ToString();
			time = time.Replace("/", "_");
			time = time.Replace(':', '_');
			time = time.Replace(' ', '@');
			return time;
		}

		private Point CalcPointScreenpos(Point pos)
		{
			DLLInclude.RECT rect = new DLLInclude.RECT();
			DLLInclude.GetWindowRect(Hwnd, out rect);
			Point newPos = new Point();
			newPos.X = rect.Left + pos.X;
			newPos.Y = rect.Top + pos.Y;
			return newPos;
		}

		// 鼠标驱动初始化
		private void LoadDllFile(string dllfile)
		{
			System.IO.FileInfo fi = new System.IO.FileInfo(dllfile);
			if (!fi.Exists)
			{
				MessageBox.Show("文件不存在");
				return;
			}

			int ret = dd.Load(dllfile);
			dd.ini(0);
			return;
		}
		private void MouseMoveClick(Point pos,int time)
		{
			dd.mov(pos.X, pos.Y);
			for (int i = 0; i < time; i++)
			{
				dd.btn(1);
				dd.btn(2);
			}
			LogShowWrite("(" + pos.X + "," + pos.Y + ")" + "点击了"+time+"下");
		}

		#region "热键设置相关代码"
		void reg_hotkey()
		{
			DLLInclude.RegisterHotKey(this.Handle, 80, 0, Keys.F8);
			DLLInclude.RegisterHotKey(this.Handle, 90, 0, Keys.F9);
		}

		void unreg_hotkey()
		{
			DLLInclude.UnregisterHotKey(this.Handle, 80);
			DLLInclude.UnregisterHotKey(this.Handle, 90);
		}

		protected override void WndProc(ref Message m)
		{
			const int WM_HOTKEY = 0x0312;                        //0x0312表示用户热键
			switch (m.Msg)
			{
				case WM_HOTKEY:
					ProcessHotkey(m);                                      //调用ProcessHotkey()函数
					break;
			}
			base.WndProc(ref m);
		}

		private void ProcessHotkey(Message msg)              //按下设定的键时调用该函数
		{
			switch (msg.WParam.ToInt32())
			{
				case 80:
					Fun80();
					break;
				case 90:
					Fun90();                                                         //调用相关函数
					break;
			}
		}

		private void Fun80()
		{
			btnBegin.PerformClick();
		}

		private void Fun90()
		{
			btnStop.PerformClick();
		}

		#endregion

		private CogPMAlignResult CheckName(CogPMAlignResults result,string name)
		{
			for (int i = 0; i < result.Count; i++)
			{
				if (result[i].ModelName == name)
				{
					return result[i];
				}
			}
			return null;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Random rad = new Random();
			this.Text = FileOperation.ReadConfig(strConfigPath, "Head" + (int)rad.Next(0, 22));
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (this.tabControl.SelectedIndex)
			{
				case 0:
					this.Size = new Size(569, 323);
					break;
				case 1:
					this.Size = new Size(569, 323);
					break;
				case 2:
					this.Size = new Size(758, 512);
					tabControl.Size = new Size(742, 473);
					tabPageRead.Size = new Size(734, 447);
					break;
				default:
					break;
			}
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			tabControl.Refresh();
		}

		private void btnChoosePath_Click(object sender, EventArgs e)
		{
			string flag = "mymain.exe";
			if (FileDialog.ShowDialog() == DialogResult.OK)
			{
				txtBoxPath.Text = FileDialog.FileName.ToString();
			}

			if (txtBoxPath.Text.IndexOf(flag) != -1)
			{
				btnChoosePath.Enabled = false;
				LogShowWrite("选择文件路径成功");
			}
			else
			{
				LogShowWrite("选择文件路径失败");
			}
		}

		private void btnStartGame_Click(object sender, EventArgs e)
		{
			if (txtBoxPath.Text == "")
			{
				btnChoosePath.Enabled = true;
				LogShowWrite("程序路径是空的");
				return;
			}
			pid = ProgramOperation.StartProgram(txtBoxPath.Text);
			if (pid != 0)
			{
				btnStartGame.Enabled = false;
				LogShowWrite("程序启动成功");
			}
			else
			{
				btnChoosePath.Enabled = true;
				LogShowWrite("程序启动失败");
			}
		}

		private void btnCheckHwnd_Click(object sender, EventArgs e)
		{
			MainHwnd = ProgramOperation.GetWnd(pid, txtBoxHwndName.Text);
			if (MainHwnd != IntPtr.Zero)
			{
				Hwnd = DLLInclude.FindWindowEx(MainHwnd, IntPtr.Zero, null, txtBoxHwndChildName.Text);
				if (Hwnd != IntPtr.Zero)
				{
					txtBoxHwnd.Text = Hwnd.ToString();
					btnCheckHwnd.Enabled = false;
					LogShowWrite("句柄查找成功");
					return;
				}
			}

			if (ProgramOperation.CheckHwnd(txtBoxHwndName.Text, txtBoxHwndChildName.Text, ref Hwnd))
			{
				txtBoxHwnd.Text = Hwnd.ToString();
				btnCheckHwnd.Enabled = false;
				LogShowWrite("句柄查找成功");
			}
			else
			{
				btnStartGame.Enabled = true;
				LogShowWrite("句柄查找失败");
			}
		}

		private void btnHwndForward_Click(object sender, EventArgs e)
		{
			if(Hwnd == IntPtr.Zero)
			{
				btnCheckHwnd.Enabled = true;
				LogShowWrite("句柄未找到");
				return;
			}
			if(ProgramOperation.ForwardWindow(MainHwnd))
			{
				btnHwndForward.Enabled = false;
				LogShowWrite("窗体前置成功");
			}
			else
			{
				btnCheckHwnd.Enabled = true;
				LogShowWrite("窗体前置失败");
			}
		}

		private void txtBoxPriceLow_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
			if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
			if (e.KeyChar > 0x20)
			{
				try
				{
					double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
				}
				catch
				{
					e.KeyChar = (char)0;   //处理非法字符
					LogShowWrite("请输入数字");
				}
			}
		}

		private void txtBoxDelay_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
			if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
			if (e.KeyChar > 0x20)
			{
				try
				{
					double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
				}
				catch
				{
					e.KeyChar = (char)0;   //处理非法字符
					LogShowWrite("请输入数字");
				}
			}
		}

		private void btnBegin_Click(object sender, EventArgs e)
		{
			// 写入配置文件
			WriteConfig();
			// 开启线程
			LogShowWrite("模式1即将启动");
			timerThread.Start();
			timerClean.Start();
			timerUpdate.Start();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			timerThread.Stop();
			timerClean.Stop();
			timerUpdate.Stop();
		}

		System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
		private void timerThread_Tick(object sender, EventArgs e)
		{
			timerThread.Enabled = false;
			if(checkBoxShowTime.Checked) stopwatch.Start();
			if (!ProcessMode1())
			{
				LogShowWrite("遇到了未知错误");
			}
			else
			{

			}
			if (checkBoxShowTime.Checked)
			{
				stopwatch.Stop();
				TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
				double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
				
				labelMs.Text = milliseconds - time + "ms";
				time = milliseconds;
			}
			timerThread.Enabled = true;
		}

		private void timerClean_Tick(object sender, EventArgs e)
		{
			txtBoxLog.Text = "";
		}

		private void timerUpdate_Tick(object sender, EventArgs e)
		{
			strLogPath = AppDomain.CurrentDomain.BaseDirectory + "Log" + "\\" + TimeToFile() + ".log";
		}

		private void WriteConfig()
		{
			string write = "";
			write += "[Path]=" + txtBoxPath.Text + "\r\n";
			write += "[Mode]=" + (radioBtnSweep.Checked ? "Sweep" : "Low") + "\r\n";
			write += "[Hwnd]=" + txtBoxHwndName.Text + "\r\n";
			write += "[ChildHwnd]=" + txtBoxHwndChildName.Text + "\r\n";
			write += "[DelayTime]=" + txtBoxDelay.Text + "\r\n";
			write += "[ClickTime]=" + txtBoxTime.Text + "\r\n";
			write += "[LowPrice]=" + txtBoxPriceLow.Text + "\r\n";
			write += "[Log]=" + checkBoxLog.Checked + "\r\n";
			write += "[ShowTime]=" + checkBoxShowTime.Checked + "\r\n";
			write += "[Head0]=" + "韭菜馅的脑子勾过芡的心"+"\r\n";
			write += "[Head1]=" + "最假的是眼泪，最真的看不见" + "\r\n";
			write += "[Head2]=" + "我期待，辉煌灿烂后黑暗的深邃，我渴望，喧哗飞扬后宁静的永恒，就像烈焰散尽的灰烟，自由自在，四处飘荡" + "\r\n";
			write += "[Head3]=" + "祝你永远不孤独" + "\r\n";
			write += "[Head4]=" + "即使今日，我仍然要因她这种天生势必会惹人宠爱呵护的美质，而势必要旁观寂寞" + "\r\n";
			write += "[Head5]=" + "高山有崖，林木有枝。忧来无方，人莫知之" + "\r\n";
			write += "[Head6]=" + "如果爱，请深爱" + "\r\n";
			write += "[Head7]=" + "人啊，长了颗红楼梦的心，却生活在水浒的世界，想交些三国里的桃园弟兄，却总遇到些西游记里的妖魔鬼怪" + "\r\n";
			write += "[Head8]=" + "从来没有遇见你就好了，就不会体会到和深爱的人在一起是这么幸福，也不会体会到和深爱的人分开是这么痛苦，世界最大的遗憾就是，你来过，但不能陪到最后" + "\r\n";
			write += "[Head9]=" + "那一瞬间 我仿佛知道了永远、心灵以及灵魂的所在 仿佛将自己的一切都分享给了对方 这之后的下一瞬 是无比的悲伤" + "\r\n";
			write += "[Head10]=" + "没有人喜欢孤独。只是不愿失望" + "\r\n";
			write += "[Head11]=" + "人生不需要有理想，需要的是行动规范" + "\r\n";
			write += "[Head12]=" + "十九二十岁，对人格的成熟是至关重要的时期，如果在这一时期无谓地糟蹋自己，到老时会感到痛苦的，这可是千真万确。所以，要慎重地考虑。你要是想珍惜爱人，那么也要珍惜自己" + "\r\n";
			write += "[Head13]=" + "人呐永远无法活成自己想的样子,因为欲望本身就是无止境的" + "\r\n";
			write += "[Head14]=" + "爱上一个人是难得的好事，倘若那爱情是真诚的，谁也不至于被抛入迷宫，要有自信" + "\r\n";
			write += "[Head15]=" + "每个人的心里都有一团火，路过的人只看到烟，但是总有一个人，总有那么一个人能看到这火，然后走过来，陪我一起" + "\r\n";
			write += "[Head16]=" + "剑未佩妥，出门已是江湖" + "\r\n";
			write += "[Head17]=" + "我曾以为生命中最糟糕的事，就是孤独终老，其实不是。最糟糕的是与那些让你感到孤独的人一起终老" + "\r\n";
			write += "[Head18]=" + "正如地产大亨冯仑所说：创业5年的成活率只有7%。  数据显示：大学生创业的成功率只有1%，即使你起早贪黑、呕心沥血、侥幸成为了那极少数的成功者，你的公司也很可能在瞬间崩塌" + "\r\n";
			write += "[Head19]=" + "你的一生我只借一程 感谢在人生的交汇点 你瞬间的绽放 温暖我心一生 秋天里的擦肩而过 能妆点出春天的" + "\r\n";
			write += "[Head20]=" + "总要有一些东西，不敢提及，不忍触碰，生怕玷污一分，周围布满残垣断壁一片狼藉之时，仍处于高台，永不崩坏，兀自生辉" + "\r\n";
			write += "[Head21]=" + "能用钱解决的事，尽量不要用人情" + "\r\n";
			write += "[Head22]=" + "人和人的隔阂是根深蒂固的" + "\r\n";
			write += "[Head23]=" + "孤独不会摧毁人，在孤独中选择堕落的人才会被摧毁" + "\r\n";
			write += "[Head24]=" + "你看，孤独都让我自恋了......" + "\r\n";
			write += "[Head25]=" + "愿你准备启程的那天下午，是个晴朗有风的日子，愿你以喜欢的方式度过一生。 " + "\r\n";
			write += "[Head26]=" + "大部分人的爱情对象也只是存在于自己的想象之中。他们所爱的并不是现实中的她，而只是想象中的她，现实中的她只是他们创造梦中情人的一个模板，他们迟早会发现梦中情人与模板之间的差异，如果适应这种差异他们就会走到一起，无法适应就分开，就这么简单。你与大多数人不同的是，你不需要模板。" + "\r\n";
			write += "[Head27]=" + "人性的解放必然带来科学与技术的进步" + "\r\n";
			write += "[Head28]=" + "给时光以生命，而不是给生命以时光" + "\r\n";
			write += "[Head29]=" + "我爱你,与你有何相干? " + "\r\n";
			write += "[Head30]=" + "I would rather share one lifetime with you than face all the ages of this world alone ." + "\r\n";

			FileOperation.WriteAll(strConfigPath, write);
			LogShowWrite("配置文件写入成功");
		}

		private void ReadConfig()
		{
			txtBoxPath.Text = FileOperation.ReadConfig(strConfigPath, "Path");
			if (FileOperation.ReadConfig(strConfigPath, "Mode") == "Sweep")
			{
				radioBtnSweep.Checked = true;
				radioBtnLow.Checked = false;
			}
			else
			{
				radioBtnSweep.Checked = false;
				radioBtnLow.Checked = true;
			}
			if(FileOperation.ReadConfig(strConfigPath, "Log") == "True")
			{
				checkBoxLog.Checked = true;
			}
			else
			{
				checkBoxLog.Checked = false;
			}
			if (FileOperation.ReadConfig(strConfigPath, "ShowTime") == "True")
			{
				checkBoxShowTime.Checked = true;
			}
			else
			{
				checkBoxShowTime.Checked = false;
			}
			txtBoxHwndName.Text = FileOperation.ReadConfig(strConfigPath, "Hwnd");
			txtBoxHwndChildName.Text = FileOperation.ReadConfig(strConfigPath, "ChildHwnd");
			txtBoxDelay.Text = FileOperation.ReadConfig(strConfigPath, "DelayTime");
			txtBoxPriceLow.Text = FileOperation.ReadConfig(strConfigPath, "LowPrice");
			txtBoxTime.Text = FileOperation.ReadConfig(strConfigPath, "ClickTime");
			LogShowWrite("配置文件读取成功");
		}

		private void btnGetPicture_Click(object sender, EventArgs e)
		{
			Bitmap image;
			image = ProgramOperation.ALT(Hwnd);
			if (image != null) LogShowWrite("截图成功");
			else { LogShowWrite("截图失败"); return ; }
			image.Save(strFailCheck + TimeToFile() + ".png");
		}

		private void btnFormMoveHide_Click(object sender, EventArgs e)
		{
			ProgramOperation.OutScreen(MainHwnd);
		}

		private void txtBoxTime_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
			if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
			if (e.KeyChar > 0x20)
			{
				try
				{
					double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
				}
				catch
				{
					e.KeyChar = (char)0;   //处理非法字符
					LogShowWrite("请输入数字");
				}
			}
		}
	}
}