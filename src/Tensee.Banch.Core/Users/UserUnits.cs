using Abp.Domain.Entities;
using System;

namespace Tensee.Banch
{
    public class UserUnits : Entity<long>, IMayHaveTenant
    {
        /// <summary>
        /// 职务*
        /// </summary>
        public virtual string EmpLevel { get; set; }
        /// <summary>
        /// 岗位*
        /// </summary>
        public virtual string LevelDesc { get; set; }
        /// <summary>
        /// 是否试用期
        /// </summary>
        public virtual bool IsTry { get; set; }
        /// <summary>
        /// 入职日期*
        /// </summary>
        public virtual DateTime InDate { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime BirthDate { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 性别*
        /// </summary>
        public virtual string Sex { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public virtual string PhoneNumber { get; set; }
        public int? TenantId { get; set; }
        public long? UserId { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        //public virtual string Age { get; set; }
    }
}
