using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Organizations.Dto
{
   public  class WeChatUser
    {
        /// <summary>
        /// 成员UserID。对应管理端的帐号，企业内必须唯一。不区分大小写，长度为1~64个字节
        /// 必须字段
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 成员名称。长度为1~64个字节
        /// 必须字段
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 英文名。长度为1-64个字节。
        /// </summary>
        public string english_name { get; set; }
        /// <summary>
        /// 手机号码。企业内必须唯一，mobile/email二者不能同时为空
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// /成员所属部门id列表,不超过20个
        ///  必须字段
        /// </summary>
        public List<long> department { get; set; }

        /// <summary>
        /// 部门内的排序值，默认为0，成员次序以创建时间从小到大排列。数量必须和department一致，数值越大排序越前面。有效的值范围是[0, 2^32)
        /// </summary>
        public List<int> order { get; set; }
        /// <summary>
        /// 职位信息。长度为0~64个字节
        /// </summary>
        public string position { get; set; }

        /// <summary>
        /// 性别。1表示男性，2表示女性
        /// </summary>
        public int gender { get; set; }

        /// <summary>
        /// 邮箱。长度为0~64个字节。企业内必须唯一，mobile/email二者不能同时为空
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 座机。由1-64位的纯数字或’-‘号组成。
        /// </summary>
        public string telephone { get; set; }

        /// <summary>
        /// 上级字段，标识是否为上级。在审批等应用里可以用来标识上级审批人
        /// </summary>
        public int isleader { get; set; }

        /// <summary>
        /// 成员头像的mediaid，通过素材管理接口上传图片获得的mediaid
        /// </summary>
        public string avatar_mediaid { get; set; }

        /// <summary>
        /// 启用/禁用成员。1表示启用成员，0表示禁用成员
        /// </summary>
        public int enable { get; set; }

        /// <summary>
        /// /自定义字段。自定义字段需要先在WEB管理端添加，见扩展属性添加方法，否则忽略未知属性的赋值。自定义字段长度最多32个中文或32个英文字母，超过将被截断。
        /// </summary>
        public string extattr { get; set; }

        /// <summary>
        /// 应用的value
        /// </summary>
        public string value { get; set; }
    }
}
