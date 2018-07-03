using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.DingTalk.Dto
{
    public class DingTalkSenderInfo
    {
        public string touser { get; set; }
        public string toparty { get; set; }
        public string agentid { get; set; }

        public string msgtype { get { return "action_card"; } }

        public action_card action_card { get; set; }
    }

    public class action_card
    {
        public string title { get; set; }
        public string markdown { get; set; }

        public string btn_orientation { get; set; }

        public List<btn_json_list> btn_json_list { get; set; }

    }

    public class btn_json_list
    {
        public string title { get; set; }
        public string action_url { get; set; }

    }

}
