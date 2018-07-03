using Abp.IdentityServer4;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tensee.Banch.Authorization.Roles;
using Tensee.Banch.Authorization.Users;
using Tensee.Banch.Chat;
using Tensee.Banch.Editions;
using Tensee.Banch.Friendships;
using Tensee.Banch.MultiTenancy;
using Tensee.Banch.MultiTenancy.Accounting;
using Tensee.Banch.MultiTenancy.Payments;
using Tensee.Banch.Storage;
using Tensee.Banch.Wechat;

namespace Tensee.Banch.EntityFrameworkCore
{
    public class BanchDbContext : AbpZeroDbContext<Tenant, Role, User, BanchDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define an IDbSet for each entity of the application */
         
       public virtual DbSet<User> AbpUsers { get; set; }
        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual DbSet<Friendship> Friendships { get; set; }

        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }

        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        #region 后台基础
        /// <summary>
        /// 数据字典
        /// </summary>
        public virtual DbSet<Dictionary> Dictionary { get; set; }

        /// <summary>
        /// 组织架构 拓展
        /// </summary>
        public virtual DbSet<Organization> Organization { get; set; }

     

        /// <summary>
        ///用户表 拓展
        /// </summary>
        public virtual DbSet<UserUnits> UserUnits { get; set; }

        ///// <summary>
        /////消息推送  (废掉)
        ///// </summary>
        //public virtual DbSet<Messagemanagement> Messagemanagement { get; set; }

        /// <summary>
        ///推送消息池
        /// </summary>
        public virtual DbSet<MessagePool> MessagePool { get; set; }

        /// <summary>
        ///推送消息池历史
        /// </summary>
        public virtual DbSet<MessagePoolHistory> MessagePoolHistory { get; set; }

        /// <summary>
        /// 企业微信配置表
        /// </summary>
        public virtual DbSet<WechatConfig> WechatConfig { get; set; }

        public virtual DbSet<WeChatUnionInfo> WeChatUnionInfos { get; set; }
        #endregion




        public BanchDbContext(DbContextOptions<BanchDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BinaryObject>(b =>
            {
                b.HasIndex(e => new { e.TenantId });
            });

            modelBuilder.Entity<ChatMessage>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId, e.ReadState });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.UserId, e.ReadState });
            });

            modelBuilder.Entity<Friendship>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId });
                b.HasIndex(e => new { e.TenantId, e.FriendUserId });
                b.HasIndex(e => new { e.FriendTenantId, e.UserId });
                b.HasIndex(e => new { e.FriendTenantId, e.FriendUserId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { e.PaymentId, e.Gateway });
            });

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
