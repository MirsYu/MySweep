using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace MySweep
{
	public static class ProgramOperation
	{
		public static int StartProgram(string path)
		{
			ProcessStartInfo pInfo = new ProcessStartInfo();
			pInfo.UseShellExecute = false;
			pInfo.FileName = path;
			pInfo.CreateNoWindow = true;
			Process p = Process.Start(pInfo);
			p.WaitForExit(2000);
			return p.Id;
		}

		public static bool CheckHwnd(string name, ref IntPtr hwnd)
		{
			while (hwnd == IntPtr.Zero)
			{
				Thread.Sleep(10);
				hwnd = DLLInclude.FindWindow(null, name);
			}
			if (hwnd != IntPtr.Zero)
			{
				Form1.MainHwnd = hwnd;
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool CheckHwnd(string name,string childename, ref IntPtr hwnd)
		{
			IntPtr Temp = IntPtr.Zero;
			if(CheckHwnd(name,ref Temp))
			{
				// 查找子句柄
				//hwnd = DLLInclude.FindWindowEx(Temp, IntPtr.Zero, null, childename);
				if (hwnd != IntPtr.Zero)
					return true;
				else
					return false;
			}
			else
			{
				return false;
			}
		}

		public static bool ForwardWindow(IntPtr hwnd)
		{
			if (hwnd != IntPtr.Zero)
			{
				DLLInclude.ShowWindow(hwnd, 1);
				DLLInclude.SetWindowPos(hwnd, -1, 0, 0, 0, 0, 1 | 2);
				DLLInclude.MoveWindow(hwnd, 0, 0, 1600, 900, true);
			}
			return true;
		}

		public static bool OutScreen(IntPtr hwnd)
		{
			Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
			if (hwnd != IntPtr.Zero)
			{
				if(DLLInclude.MoveWindow(hwnd, rect.Width, rect.Height, 1032, 815, true))
				{
					return true;
				}
			}
			return false;
		}

		public static bool BackWindow(IntPtr hwnd)
		{
			if (hwnd != IntPtr.Zero)
			{
				if(DLLInclude.SetWindowPos(hwnd, -1, 0, 0, 0, 0, 0x0080 | 0x0010))
				{
					return true;
				}
			}
			return false;
		}

		public static Bitmap ALT(IntPtr hwnd)
		{
			DLLInclude.RECT rectHwnd;
			DLLInclude.GetWindowRect(hwnd, out rectHwnd);
			Bitmap myImage = new Bitmap(rectHwnd.Right - rectHwnd.Left, rectHwnd.Bottom - rectHwnd.Top);
			Graphics gr = Graphics.FromImage(myImage);
			gr.CopyFromScreen(new Point(rectHwnd.Left, rectHwnd.Top), new Point(0, 0), new Size(rectHwnd.Right - rectHwnd.Left, rectHwnd.Bottom - rectHwnd.Top));
			Bitmap bitImage = myImage;
			return bitImage;
		}

		public static IntPtr GetWnd(Int32 pID, String text)
		{
			IntPtr h = DLLInclude.GetTopWindow(IntPtr.Zero);
			while (h != IntPtr.Zero)
			{
				UInt32 newID;
				DLLInclude.GetWindowThreadProcessId(h, out newID);
				if (newID == pID)
				{
					StringBuilder sbClassName = new StringBuilder(200);
					StringBuilder sbText = new StringBuilder(200);

					DLLInclude.GetClassName(h, sbClassName, 200);
					DLLInclude.GetWindowText(h, sbText, 200);
					if (sbText.ToString().IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0)
					{
						break;
					}
				}

				h = DLLInclude.GetWindow(h, DLLInclude.GW_HWNDNEXT);
			}

			return h;
		}
	}
}
