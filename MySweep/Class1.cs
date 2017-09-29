#region namespace imports
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.PMAlign;

#endregion

public class CogToolBlockAdvancedScript : CogToolBlockAdvancedScriptBase
{
	#region Private Member Variables
	private Cognex.VisionPro.ToolBlock.CogToolBlock mToolBlock;
	Form form1 = new Form();
	#endregion

	/// <summary>
	/// 当父工具运行时调用
	/// 在这添加代码进行自定义或者替换正常运行的代码
	/// </summary>
	/// <param name="message">在工具的RunStatus内设置Message</param>
	/// <param name="result">在工具的Runstatus内设置Result</param>
	/// <returns>True if the tool should run normally,
	///          False if GroupRun customizes run behavior</returns>
	public override bool GroupRun(ref string message, ref CogToolResultConstants result)
	{
		// To let the execution stop in this script when a debugger is attached, uncomment the following lines.
#if DEBUG
		if (System.Diagnostics.Debugger.IsAttached) System.Diagnostics.Debugger.Break();
#endif


		// Run each tool using the RunTool function
		foreach (ICogTool tool in mToolBlock.Tools)
			mToolBlock.RunTool(tool, ref message, ref result);
		CogPMAlignTool pm = new CogPMAlignTool();
		pm.Pattern = mToolBlock.Inputs["Input"].Value as CogPMAlignPattern;
		mToolBlock.Outputs["Output"].Value = mToolBlock.Inputs["Input"].Value;
		return false;
	}

	#region When the Current Run Record is Created
	/// <summary>
	/// Called when the current record may have changed and is being reconstructed
	/// </summary>
	/// <param name="currentRecord">
	/// The new currentRecord is available to be initialized or customized.</param>
	public override void ModifyCurrentRunRecord(Cognex.VisionPro.ICogRecord currentRecord)
	{
	}
	#endregion

	#region When the Last Run Record is Created
	/// <summary>
	/// Called when the last run record may have changed and is being reconstructed
	/// </summary>
	/// <param name="lastRecord">
	/// The new last run record is available to be initialized or customized.</param>
	public override void ModifyLastRunRecord(Cognex.VisionPro.ICogRecord lastRecord)
	{
	}
	#endregion

	#region When the Script is Initialized
	/// <summary>
	/// Perform any initialization required by your script here
	/// </summary>
	/// <param name="host">The host tool</param>
	public override void Initialize(Cognex.VisionPro.ToolGroup.CogToolGroup host)
	{
		// DO NOT REMOVE - Call the base class implementation first - DO NOT REMOVE
		base.Initialize(host);


		// Store a local copy of the script host
		this.mToolBlock = ((Cognex.VisionPro.ToolBlock.CogToolBlock)(host));
		form1.Show();
	}

	#endregion

}

