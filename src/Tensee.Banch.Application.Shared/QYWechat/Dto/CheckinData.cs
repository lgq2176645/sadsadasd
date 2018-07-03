using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
    public class CheckinData
    {
        public int opencheckindatatype { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string[] useridlist { get; set; }

    }

   
}
