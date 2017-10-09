using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using System.Drawing;
using System.Collections;

namespace MySweep
{
    static class Vision
    {
        public static bool loadvpp(string filename)
        {
            try
            {
                block = (CogToolBlock)CogSerializer.LoadObjectFromFile(filename);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static CogToolBlock block;
        
        public static void Run(Bitmap image, int index, out ArrayList data)
        {
            ICogImage outimage = new CogImage8Grey(image);
            block.Inputs["InputImage"].Value = outimage;
            block.Inputs["Index"].Value = index;
            block.Run();
            if (block.RunStatus.Result == CogToolResultConstants.Accept)
            {
                data = (ArrayList)block.Outputs["data"].Value;
            }
            else
            {
                throw new Exception("Vision Run Fail");
            }
        }

        public static void Run(Bitmap image,int index, out ArrayList data, out ICogImage outimage, out ICogRecord outrecord)
        {
            outimage = new CogImage8Grey(image);
            block.Inputs["InputImage"].Value = outimage;
            block.Inputs["Index"].Value = index;
            block.Run();
            outrecord = block.CreateLastRunRecord();
            if (block.RunStatus.Result == CogToolResultConstants.Accept)
            {
                data = (ArrayList)block.Outputs["data"].Value;
            }
            else
            {
                throw new Exception("Vision Run Fail");
            }
        }
    }
}
