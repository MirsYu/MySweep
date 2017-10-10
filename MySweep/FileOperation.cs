using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MySweep
{
	class FileOperation
	{
		public static string Read(string path)
		{
			string strResult = "";
			try
			{
				FileStream readFile = new FileStream(path, FileMode.Open);
				StreamReader steamRead = new StreamReader(readFile);
				string strLine = steamRead.ReadLine();
				while (strLine != null)
				{
					strLine = strLine + "\r\n";
					strResult += strLine;
					strLine = steamRead.ReadLine();
				}
				steamRead.Close();
				readFile.Close();
			}
			catch (IOException e)
			{
				return e.ToString();
			}
			return strResult;
		}

		public static bool WriteLine(string path,string txt)
		{
			try
			{
				if (!File.Exists(path))
				{
                    File.Create(path);
				}

				StreamWriter steamWriter = new StreamWriter(path,true);
				steamWriter.WriteLine(txt);
				steamWriter.Flush();
				steamWriter.Close();
			}
			catch (IOException ex)
			{
				return true;
			}
			return true;
		}

		public static void WriteAll(string path,string txt)
		{
			try
			{
				//FileStream fs = new FileStream(path, FileMode.Create);
				StreamWriter sw = new StreamWriter(path, false);
				//开始写入
				sw.Write(txt);
				//清空缓冲区
				sw.Flush();
				//关闭流
				sw.Close();
				//fs.Close();
			}
			catch (Exception)
			{
				return;
			}
		}

		public static string ReadConfig(string path, string name)
		{
			string baseTxT;
			string flag;
			string result;
			baseTxT = Read(path);
			flag = "[" + name + "]" + "=";
			baseTxT = baseTxT.Replace("\r\n", "");
			baseTxT = baseTxT.Trim();
			if (baseTxT.IndexOf(flag) != -1)
			{
				result = baseTxT.Remove(0, baseTxT.IndexOf(flag) + flag.Length);
				flag = "[";
				if (result.IndexOf(flag) > 0)
				{
					result = result.Substring(0, result.IndexOf(flag));
				}

				return result;
			}
			else
			{
				return "0";
			}
		}
	}
}
