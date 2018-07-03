using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Organizations.Dto
{
    public class UpdateWXMemberInput
    {
        public int userid { get; set; }
        public string name { get; set; }
        public string english_name { get; set; }
        public string mobile { get; set; }
        public List<int> department { get; set; }
        public List<int> order { get; set; }
        public string position { get; set; }
        public int gender { get; set; }
        public string email { get; set; }
        public int isleader { get; set; }
        public int enable { get; set; }
        public string avatar_mediaid { get; set; }
        public string telephone { get; set; }
        public string extattr { get; set; }
    }
}
