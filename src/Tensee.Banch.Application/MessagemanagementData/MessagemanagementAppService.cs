using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.MessagemanagementData.Dto;

namespace Tensee.Banch.MessagemanagementData
{
    public class MessagemanagementAppService : BanchAppServiceBase, IMessagemanagementAppService
    {
        private readonly IRepository<Messagemanagement> _messagemanagement;
        public MessagemanagementAppService(IRepository<Messagemanagement> messagemanagement)
        {
            _messagemanagement = messagemanagement;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 备注：查询不了
        public List<Messagemanagement> GetPushmessage(GetPushmessageInput input)
        {
            
            List<Messagemanagement> list = new List<Messagemanagement>();
            if (!string.IsNullOrWhiteSpace(input.value))
            {
                var data = _messagemanagement.GetAll().Where(t => (t.SenderID.ToString().Contains(input.value)
                 || t.SenderName.ToString().Contains(input.value)
                 || t.ReceiverID.ToString().Contains(input.value)
                 || t.ReceiverName.ToString().Contains(input.value)) && t.IsSend == input.IsSend).ToList(); ;
                list.AddRange(data);
            }
            else
            {
                var data = _messagemanagement.GetAll().Where(t => ((t.CreationTime <= input.StartTime) || (input.EndTime >= t.CreationTime)) && t.IsSend == input.IsSend).ToList();//查询创建时间
                list.AddRange(data);
            }
            return list;

            //    if (input.IsSend == true)
            //    {
            //        if (string.IsNullOrWhiteSpace(input.value))
            //        {
            //            var data = _messagemanagement.GetAll().Where(t => (t.SenderID.ToString().Contains(input.value)
            //             || t.SenderName.ToString().Contains(input.value)
            //             || t.ReceiverID.ToString().Contains(input.value)
            //             || t.ReceiverName.ToString().Contains(input.value)) && t.IsSend==input.IsSend);
            //            return data.ToList();
            //        }
            //        else
            //        {
            //            var data = _messagemanagement.GetAll().Where(t => (t.SendTime >= input.StartTime) || (input.EndTime >= t.SendTime));//查询发送时间
            //            return data.ToList();
            //        }

            //    }
            //    else
            //    {
            //        if (string.IsNullOrWhiteSpace(input.value))
            //        {
            //            var data = _messagemanagement.GetAll().Where(t => t.SenderID.ToString().Contains(input.value)
            //             || t.SenderName.ToString().Contains(input.value)
            //             || t.ReceiverID.ToString().Contains(input.value)
            //             || t.ReceiverName.ToString().Contains(input.value));
            //            return data.ToList();
            //        }
            //        else
            //        {
            //            var data = _messagemanagement.GetAll().Where(t => (t.CreationTime >= input.StartTime) || (input.EndTime >= t.CreationTime));//查询创建时间
            //            return data.ToList();
            //        }
            //    }


        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleNonPushMessage(EntityDto input)
        {
            var obj = await _messagemanagement.GetAsync(input.Id);
            var data = _messagemanagement.DeleteAsync(obj);
            var re = 0;
            if (data == null)
            {
                re = 1;
            }
           
            await _messagemanagement.DeleteAsync(obj);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string CreaNonPushessage(CreaNonPushessageInput input)
        {
            var mode = "";
            Messagemanagement _Messagemanagement = new Messagemanagement();

            _Messagemanagement.SenderID = input.SenderID;
            _Messagemanagement.SenderName = input.SenderName;
            _Messagemanagement.Title = input.Title;
            _Messagemanagement.MessageType = input.MessageType;
            //_Messagemanagement.SendTime = DateTime.Now;
            _Messagemanagement.Content = input.Content;
            _Messagemanagement.ReceiverID = input.ReceiverID;
            _Messagemanagement.ReceiverName = input.ReceiverName;
            _Messagemanagement.IsSend = false;
            _Messagemanagement.IsOpen = false;
            //_Messagemanagement.OpenTime = input.OpenTime;
            var addto = _messagemanagement.Insert(_Messagemanagement);
            if (addto == null)
            {
                mode = "添加失败";
            }
            else
            {
                mode = "添加成功";
            }
            return mode;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task <string> UpdaNonPushessage(UpdateNonPushessageInput input)
        {
            var er = "修改成功";
            Debug.Assert(input.id != null, "input.id should be set.");
            var data = await _messagemanagement.GetAsync(input.id.Value);
            data.Title = input.Title;
            data.MessageType = input.MessageType;
            data.Content = input.Content;
            data.ReceiverID = input.ReceiverID;
            data.ReceiverName = input.ReceiverName;
              var addto = _messagemanagement.UpdateAsync(data);
            if (!string.IsNullOrWhiteSpace(addto.ToString()))
            {
                return er;
            }
            else {
                return er = "修改失败";
            }

        }




       
    }
}
