using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MySweep
{
	public static class DLLInclude
	{
		[DllImport("User32.dll", EntryPoint = "FindWindow")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		public extern static int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);

		[DllImport("user32.dll", EntryPoint = "ShowWindow")]
		public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);

		[DllImport("User32.dll", EntryPoint = "FindWindowEx")]
		public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		public static extern int GetWindowRect(IntPtr hWnd, out RECT lpRect);
		[DllImport("user32.dll")]
		public static extern IntPtr GetTopWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		[DllImport("user32.dll")]
		public static extern IntPtr GetWindow(IntPtr hWnd, UInt32 uCmd);

		[DllImport("user32.dll")]
		public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		public static readonly UInt32 GW_HWNDNEXT = 2;

		/// <summary>
		/// 注册热键
		/// </summary>
		/// <param name="hWnd">句柄</param>
		/// <param name="id">热键标识</param>
		/// <param name="modkey">修改键</param>
		/// <param name="vk">虚键码</param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool RegisterHotKey(IntPtr hWnd,int id,KeyModifiers modkey,Keys vk);

		/// <summary>
		/// 卸载热键
		/// </summary>
		/// <param name="hWnd">窗口句柄</param>
		/// <param name="id">热键标识</param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool UnregisterHotKey(IntPtr hWnd,int id);

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left;                             //最左坐标
			public int Top;                             //最上坐标
			public int Right;                           //最右坐标
			public int Bottom;                        //最下坐标
		}
	}
}
