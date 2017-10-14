using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MySweep
{
	public struct VisionData
	{
		public List<int> Prices;
		public List<int> Counts;
		public List<int> Xs;
		public List<int> Ys;
		public List<bool> IsSuccess;
	}
	public partial class Form1 : Form
	{
		// 鼠标
		private CDD dd;
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
		// 启动的程序PID
		int pid;


		public Form1()
		{
			strLogPath = AppDomain.CurrentDomain.BaseDirectory + "Log" + "\\" + TimeToFile() + ".txt";
			strVisPath = AppDomain.CurrentDomain.BaseDirectory + "图像识别模块" + "\\" + "RunBlock.vpp";
			strFailCheck = AppDomain.CurrentDomain.BaseDirectory + "无法识别图片" + "\\";
			strConfigPath = AppDomain.CurrentDomain.BaseDirectory + "配置文件" + "\\" + "config.ini";
			if (!Directory.Exists(strLogPath))
			{
				File.Create(strLogPath);
			}
			if (!Directory.Exists(strFailCheck))
			{
				Directory.CreateDirectory(strFailCheck);
			}
			if (!File.Exists(strVisPath))
			{
				File.Create(strVisPath);
			}
			if (!File.Exists(strConfigPath))
			{
				File.Create(strConfigPath);
			}
			string strConfigResult = FileOperation.Read(strConfigPath);
			InitializeComponent();
			if (strConfigResult == "")
				WriteConfig();
			else
				ReadConfig();
			// 加载视觉模块
			Vision.loadvpp(strVisPath);
			cogToolBlockEditV21.Subject = Vision.block;
			// 注册热键
			reg_hotkey();
			// 初始化鼠标驱动
			dd = new CDD();
			// DDHID64
			string dllfile = "DDHID64.dll";
			LoadDllFile(dllfile);
			updatemethod = new delegateUpdateGUI(UpdateGrid);
			ResourceManager rm = new ResourceManager("MySweep.Properties.Resources", Assembly.GetExecutingAssembly());
			this.Icon = (Icon)(rm.GetObject("GreyEyes1303"));
		}

        Bitmap image1, image2;
		private void VisionRun(int index)
		{
            DateTime dtStart = DateTime.Now;
			//Run
			try
			{
				ArrayList data = new ArrayList();
                image2 = ProgramOperation.ALT(MainHwnd);
                if (image2 != null && image2 != image1)
					image1 = image2; 
                else
					return;
				Vision.Run(image1, index, out data);
                switch (index)
                {
                    case 0:
                        IsGameExit = (bool)Vision.block.Outputs["GameExit"].Value;
                        IsCenterExit = (bool)Vision.block.Outputs["CenterExit"].Value;
                        IsSearchButtonExit = (bool)Vision.block.Outputs["SearchButtonExit"].Value;
                        //IsExitInputName = (bool)Vision.block.Outputs["IsExitInputName"].Value;
                        SearchX = Convert.ToInt32(Vision.block.Outputs["SearchX"].Value);
                        SearchY = Convert.ToInt32(Vision.block.Outputs["SearchY"].Value);
                        InputX = Convert.ToInt32(Vision.block.Outputs["InputX"].Value);
                        InputY = Convert.ToInt32(Vision.block.Outputs["InputY"].Value);
                        BuyX = Convert.ToInt32(Vision.block.Outputs["BuyX"].Value);
                        BuyY = Convert.ToInt32(Vision.block.Outputs["BuyY"].Value);
                        InputCountX = Convert.ToInt32(Vision.block.Outputs["InputCountX"].Value);
                        InputCountY = Convert.ToInt32(Vision.block.Outputs["InputCountY"].Value);
                        CheckX = Convert.ToInt32(Vision.block.Outputs["CheckX"].Value);
                        CheckY = Convert.ToInt32(Vision.block.Outputs["CheckY"].Value);
                        YesX = Convert.ToInt32(Vision.block.Outputs["YesX"].Value);
                        YesY = Convert.ToInt32(Vision.block.Outputs["YesY"].Value);
                        MaxX = Convert.ToInt32(Vision.block.Outputs["MaxX"].Value);
                        MaxY = Convert.ToInt32(Vision.block.Outputs["MaxY"].Value);
                        FailCheckX = Convert.ToInt32(Vision.block.Outputs["FailCheckX"].Value);
                        FailCheckY = Convert.ToInt32(Vision.block.Outputs["FailCheckY"].Value);
                        break;
                    case 1:
                        Parsedata(data);
                        break;
                    case 2:
                        IsSearchOK = (bool)Vision.block.Outputs["IsSearchOK"].Value;
                        break;
                }
				//cogRecordDisplay1.Image = outimage;
				//cogRecordDisplay1.Record = record;
				//UpdateGrid(data);
			}
			catch
            {
                timerUpdate.Stop();
            }
            DateTime dtEnd = DateTime.Now;
            TimeSpan diffTime = dtEnd - dtStart;
            CTinMm = diffTime.Milliseconds;


        }

		bool IsGameExit = false;
		bool IsCenterExit = false;
		bool IsSearchButtonExit = false;
		bool IsExitInputName = false;
        bool IsBuy = false;
		int SearchX, SearchY;
		int InputX, InputY;
		int BuyX, BuyY;
		int InputCountX, InputCountY;
		int CheckX, CheckY;
		int YesX, YesY;
        int MaxX, MaxY;
        int FailCheckX, FailCheckY;
        int MoveDelayTime = 100;
        int CTinMm = 0;
        bool IsSearchOK = false;

        private bool ProcessMode1()
        {
            IsBuy = false;
            Point pos = new Point();
            // 视觉模块
            // 获取是否在黑市界面
            if (!(IsGameExit && IsCenterExit && IsSearchButtonExit))
            {
                VisionRun(0);
                //return false;
            }
            if (IsCenterExit && IsSearchButtonExit)
            {
                // 首先判断输入框里有没有指定的物品名称
                if (IsExitInputName)
                {
                    // 找到搜索按钮
                    IsSearchOK = false;
                    int searchLimit = 100;
                    int searchDelayTime = 10;
                    int searchTime = 0;
                    pos = new Point(SearchX, SearchY);
                    MouseMoveClick(pos, 1);  // 点击一次搜索按钮
                    while (!IsSearchOK && searchTime < searchLimit)
                    {
                        VisionRun(2);
                        //Thread.Sleep(searchDelayTime);
                        searchTime++;
                    }
                    if (searchTime == searchLimit)
                    {
                        IsExitInputName = false;
                        DDkey(100, 500); // esc
                        IsSearchButtonExit = false;
                        return false;
                    }

                    // 获取每个多少价格
                    VisionRun(1);
                    if (!(visiondata.IsSuccess[0] || visiondata.IsSuccess[1] ||
                            visiondata.IsSuccess[2] || visiondata.IsSuccess[3] ||
                            visiondata.IsSuccess[4] || visiondata.IsSuccess[5] || visiondata.IsSuccess[6]))
                    {
                        IsGameExit = false;
                        IsCenterExit = false;
                        IsSearchButtonExit = false;
                        return false;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        if (visiondata.IsSuccess[0] && visiondata.IsSuccess[1] &&
                            visiondata.IsSuccess[2] && visiondata.IsSuccess[3] &&
                            visiondata.IsSuccess[4] && visiondata.IsSuccess[5] && visiondata.IsSuccess[6])
                        {
                            if (visiondata.Prices[i] <= int.Parse(txtBoxPriceLow.Text) && visiondata.Prices[i] != 1 && visiondata.Counts[i] != 0)
                            {
                                //File.AppendAllText("1.txt", visiondata.Prices[i].ToString() + "\r\n");
                                //return false;
                                //Buy
                                pos = new Point(visiondata.Xs[i], visiondata.Ys[i]);
                                MouseMoveClick(pos, 1);
                                // 输入数量
                                pos = new Point(MaxX, MaxY);
                                MouseMoveClick(pos, 1);
                                // 购买
                                pos = new Point(BuyX, BuyY);
                                MouseMoveClick(pos, 1);
                                // 确认

                                DDkey(313, 200); // enter
                                                 // pos = new Point(CheckX, CheckY);
                                                 //MouseMoveClick(pos, 1);
                                                 //Thread.Sleep(400);
                                                 // Yes

                                DDkey(313, 200); // enter
                                                 //pos = new Point(YesX, YesY);
                                                 //MouseMoveClick(pos, 1);
                                                 // FailCheck

                                                 //pos = new Point(FailCheckX, FailCheckY);
                                                 //MouseMoveClick(pos, 1);

                                //Thread.Sleep(1000);
                                // 弹出数量确认框
                                // 分别找到 +1 +10 +100 最大 按钮
                                // 因为你买的时候别人可能已经买走了一两个 最大按钮可能是用不了的
                                // 比如是+100按钮

                                /* pos = new Point(100, 100);
                                 MouseMoveClick(pos, 3); // 点击+100 3次
                                 MouseMoveClick(pos, 3); // 点击+100 3次
                                 MouseMoveClick(pos, 3); // 点击+100 3次
                                 pos = new Point(100, 100);
                                 MouseMoveClick(pos, 3); // 点击购买*/

                                // 至此购买完毕
                            }

                        }

                    }
                }
                else
                {
                    // 找到输入框的位置
                    pos = new Point(InputX, InputY);
                    MouseMoveClick(pos, 1);
                    Thread.Sleep(10);
                    char[] charName = txtBox_Name.Text.ToCharArray();
                    for (int i = 0; i < charName.Length; i++)
                    {
                        Thread.Sleep(500);
                        dd.str(charName[i].ToString());
                        IsExitInputName = true;
                    }
                    VisionRun(0);
                }
            }
            else
            {
                // 保证目标窗口是焦点(因为窗体已经前置  dd鼠标去点一下)
                pos = new Point(100, 100);
                MouseMoveClick(pos, 1);
                // 所有时间间隔待测试
                DDkey(100, 500); // esc

                Thread.Sleep(100);
                DDkey(505, 500); // b

                VisionRun(0);
            }
            return false;
        }


        private bool ProcessMode2()
        { 
            int allx = 250;
            int ally = 490;
            int getx = 400;
            int gety = 1027;
            int yesx = 910;
            int yesy = 628;
            int deletex = 497;
            int deletey = 1027;

            //全选
            Point pos = new Point(allx, ally);
            MouseMoveClick(pos, 1);
            //领取
            pos = new Point(getx, gety);
            MouseMoveClick(pos, 1);
            //确认
            pos = new Point(yesx, yesy);
            MouseMoveClick(pos, 1);
            //全选
            pos = new Point(allx, ally);
            MouseMoveClick(pos, 1);
            //删除
            pos = new Point(deletex, deletey);
            MouseMoveClick(pos, 1);
            //确认
            pos = new Point(yesx, yesy);
            MouseMoveClick(pos, 1);

            dd.str("m");//物品名称
            Thread.Sleep(10);

            IsBuy = false;
            return false;
        }

        // 键盘按键
        private void DDkey(int KeyCode, int delayTime)
		{
			dd.key(KeyCode, 1);
			delayTime += new Random().Next(1, 100);
			Thread.Sleep(delayTime);
			dd.key(KeyCode, 2);
		}

		private string TimeToFile()
		{
			string time = DateTime.Now.ToString();
			time = time.Replace("/", "_");
			time = time.Replace(':', '_');
			time = time.Replace(' ', '@');
			return time;
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
		private void MouseMoveClick(Point pos, int time)
		{
			dd.mov(pos.X, pos.Y);
			Thread.Sleep(new Random().Next(0, 10));
			for (int i = 0; i < time; i++)
			{
				dd.btn(1);
				Thread.Sleep(new Random().Next(0, 5));
				dd.btn(2);
				Thread.Sleep(MoveDelayTime);
			}
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

		private void Form1_Load(object sender, EventArgs e)
		{
			Random rad = new Random();
			this.Text = FileOperation.ReadConfig(strConfigPath, "Head" + (int)rad.Next(0, 22));
			Rectangle rect = new Rectangle();
			rect = Screen.GetWorkingArea(this);
			this.Left = rect.Width-this.Width;
			this.Top = 0;
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (this.tabControl.SelectedIndex)
			{
				case 0:
					this.Size = new Size(569, 323);
					break;
				case 1:
					this.Size = new Size(985, 478);
					break;
				case 2:
					this.Size = new Size(569, 323);
					dataGridView1.Focus();
					break;
				default:
					break;
			}
			this.Refresh();
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
			}
			else
			{
			}
		}

		private void btnStartGame_Click(object sender, EventArgs e)
		{
			if (txtBoxPath.Text == "")
			{
				btnChoosePath.Enabled = true;
				return;
			}
			pid = ProgramOperation.StartProgram(txtBoxPath.Text);
			if (pid != 0)
			{
				btnStartGame.Enabled = false;
			}
			else
			{
				btnChoosePath.Enabled = true;
			}
		}

		private void btnCheckHwnd_Click(object sender, EventArgs e)
		{
			if (ProgramOperation.CheckHwnd("冒险岛2 - 尬萌不限号", "", ref MainHwnd))
			{
				txtBoxHwnd.Text = MainHwnd.ToString();
				btnCheckHwnd.Enabled = false;
			}
			else
			{
				btnStartGame.Enabled = true;
			}
		}

		private void btnHwndForward_Click(object sender, EventArgs e)
		{
			if (MainHwnd == IntPtr.Zero)
			{
				btnCheckHwnd.Enabled = true;
				return;
			}
			if (ProgramOperation.ForwardWindow(MainHwnd))
			{
				btnHwndForward.Enabled = false;
			}
			else
			{
				btnCheckHwnd.Enabled = true;
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
				}
			}
		}

        private void btnBegin_Click(object sender, EventArgs e)
        {
            MoveDelayTime = Convert.ToInt32(textBox1.Text);
            timerThread.Interval = Convert.ToInt32(txtBoxDelay.Text);
            // 写入配置文件
            WriteConfig();
            // 开启线程
            if (checkBoxMail.Checked)
            {
                timerEmail.Start();
            }
            else
            {
                timerThread.Start();
            }
			timerUpdate.Start();
            checkBoxMail.Enabled = false;

        }

		private void btnStop_Click(object sender, EventArgs e)
		{
            timerThread.Stop();
			timerUpdate.Stop();
            timerEmail.Stop();
            checkBoxMail.Enabled = true;
        }

        object lockobj = new object();

		private void timerUpdate_Tick(object sender, EventArgs e)
		{

			strLogPath = AppDomain.CurrentDomain.BaseDirectory + "Log" + "\\" + TimeToFile() + ".txt";
		}

		private void WriteConfig()
		{
			string write = "";
			write += "[Path]=" + txtBoxPath.Text + "\r\n";
			write += "[Mode]=" + "Low" + "\r\n";
			write += "[DelayTime]=" + txtBoxDelay.Text + "\r\n";
			write += "[ClickTime]=" + txtBoxTime.Text + "\r\n";
			write += "[LowPrice]=" + txtBoxPriceLow.Text + "\r\n";
			write += "[Head0]=" + "韭菜馅的脑子勾过芡的心" + "\r\n";
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
		}

		private void ReadConfig()
		{
			txtBoxPath.Text = FileOperation.ReadConfig(strConfigPath, "Path");
			if (FileOperation.ReadConfig(strConfigPath, "Mode") == "Sweep")
			{
				radioBtnLow.Checked = false;
			}
			else
			{
				radioBtnLow.Checked = true;
			}
            txtBoxDelay.Text = FileOperation.ReadConfig(strConfigPath, "DelayTime"); 
			txtBoxPriceLow.Text = FileOperation.ReadConfig(strConfigPath, "LowPrice");
			txtBoxTime.Text = FileOperation.ReadConfig(strConfigPath, "ClickTime");

		}

		private void btnGetPicture_Click(object sender, EventArgs e)
		{
			Bitmap image;
			image = ProgramOperation.ALT(MainHwnd);
			if (image == null)
				return;
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
				}
			}
		}

		private void Run_Click(object sender, EventArgs e)
		{
			try
			{
				ICogImage outimage = new CogImage8Grey();
				ICogRecord record;
				ArrayList data = new ArrayList();
				Bitmap image;
				image = ProgramOperation.ALT(MainHwnd);
				if (image == null)
					return;
				Vision.Run(image, 0, out data, out outimage, out record);
				cogRecordDisplay1.Image = outimage;
				cogRecordDisplay1.Record = record;
			}
			catch
			{

			}
		}

		Thread thread;
		VisionData visiondata = new VisionData();
		private delegate void delegateUpdateGUI(ArrayList list);
		private delegateUpdateGUI updatemethod;

        private void timerEmail_Tick(object sender, EventArgs e)
        {

            lock (lockobj)
            {
                timerEmail.Enabled = false;
				ProcessMode2();
                timerEmail.Enabled = true;
            }
        }

		private void timerClean_Tick(object sender, EventArgs e)
		{

		}

        private void timerThread_Tick(object sender, EventArgs e)
        {
            timerThread.Enabled = false;
            ProcessMode1();
            timerThread.Enabled = true;
        }

        private void UpdateGrid(ArrayList list)
		{
			dataGridView1.Rows.Clear();
			int count = 7;
			for (int i = 0; i < count; i++)
			{
				dataGridView1.Rows.Add();
				dataGridView1.Rows[i].Cells[1].Value = list[count * 0 + i];
				dataGridView1.Rows[i].Cells[0].Value = list[count * 1 + i];
				dataGridView1.Rows[i].Cells[2].Value = list[count * 2 + i];
			}
		}

		private void Parsedata(ArrayList list)
		{
			if (list.Count == 35)
			{
				visiondata.Counts = new List<int>();
				visiondata.Prices = new List<int>();
				visiondata.IsSuccess = new List<bool>();
				visiondata.Xs = new List<int>();
				visiondata.Ys = new List<int>();

				int m = 0;
				for (int i = 0 + m * 7; i < 7 + m * 7; i++)
				{
					visiondata.Prices.Add(Convert.ToInt32(list[i]));
				}
				m++;
				for (int i = 0 + m * 7; i < 7 + m * 7; i++)
				{
					visiondata.Counts.Add(Convert.ToInt32(list[i]));
				}
				m++;
				for (int i = 0 + m * 7; i < 7 + m * 7; i++)
				{
					visiondata.IsSuccess.Add(Convert.ToBoolean(list[i]));
				}
				m++;
				for (int i = 0 + m * 7; i < 7 + m * 7; i++)
				{
					visiondata.Xs.Add(Convert.ToInt32(list[i]));
				}
				m++;
				for (int i = 0 + m * 7; i < 7 + m * 7; i++)
				{
					visiondata.Ys.Add(Convert.ToInt32(list[i]));
				}
                IsBuy = (bool)Vision.block.Outputs["IsBuy"].Value;
			}
			else
			{
				throw new Exception("Data Count Error");
			}
		}

		bool isContinueRun = false;
		private void ContinueRun()
		{
			while (isContinueRun)
			{
				try
				{
					ICogImage outimage = new CogImage8Grey();
					ICogRecord record;
					ArrayList data = new ArrayList();
					Bitmap image;
					image = ProgramOperation.ALT(MainHwnd);
					if (image == null)
						return;
					Vision.Run(image, 1, out data, out outimage, out record);
					cogRecordDisplay1.Image = outimage;
					cogRecordDisplay1.Record = record;
					this.Invoke(updatemethod, data);
                    image.Dispose();
                    Thread.Sleep(500);
                    Application.DoEvents();
				}
				catch
				{

				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{

			try
			{
				ICogImage outimage = new CogImage8Grey();
				ICogRecord record;
				ArrayList data = new ArrayList();
				Bitmap image;
				image = ProgramOperation.ALT(MainHwnd);
				if (image == null)
					return; 
				Vision.Run(image, 0, out data, out outimage, out record);
				cogRecordDisplay1.Image = outimage;
				cogRecordDisplay1.Record = record;
			}
			catch
			{

			}
		}

		private void button3_Click(object sender, EventArgs e)
		{

			try
			{
				ICogImage outimage = new CogImage8Grey();
				ICogRecord record;
				ArrayList data = new ArrayList();
				Bitmap image;
				image = ProgramOperation.ALT(MainHwnd);
				if (image == null)
					return; 
				Vision.Run(image, 1, out data, out outimage, out record);
				cogRecordDisplay1.Image = outimage;
				cogRecordDisplay1.Record = record;
				UpdateGrid(data);
			}
			catch
			{

			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			isContinueRun = true;
			thread = new Thread(ContinueRun);
			thread.Start();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			isContinueRun = false;
			thread.Abort();
			thread.Join();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			isContinueRun = false;
		}
	}
}