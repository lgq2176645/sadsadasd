using System;
using Abp.Application.Services.Dto;

namespace Tensee.Banch.Organizations.Dto
{
    public class OrganizationUnitUserListDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public bool Istry { get; set; }

        public string DisplayName { get; set; }

        public string OrganizationDisplayName { get; set; }

        public DateTime Indate { get; set; }

        public Guid? ProfilePictureId { get; set; }

        public DateTime AddedTime { get; set; }
        ///// <summary>
        ///// 职务
        ///// </summary>
        //public string EmpLevel { get; set; }
        ///// <summary>
        ///// 岗位
        ///// </summary>
        //public virtual string LevelDesc { get; set; }
        ///// <summary>
        ///// 入职日期
        ///// </summary>
        //public virtual DateTime InDate { get; set; }
        ///// <summary>
        ///// 性别
        ///// </summary>
        //public virtual string Sex { get; set; }
    }
}