using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Domain.Entities;

namespace Tensee.Banch.Storage
{
    [Table("AppBinaryObjects")]
    public class BinaryObject : Entity<Guid>, IMayHaveTenant
    {
        public virtual int? TenantId { get; set; }

        [Required]
        public virtual byte[] Bytes { get; set; }

        public string Code { get; set; }

        public BinaryObject()
        {
            Id = SequentialGuidGenerator.Instance.Create();
        }

        public BinaryObject(int? tenantId, byte[] bytes,string code)
            : this()
        {
            TenantId = tenantId;
            Bytes = bytes;
            Code = code;
        }
    }
}
