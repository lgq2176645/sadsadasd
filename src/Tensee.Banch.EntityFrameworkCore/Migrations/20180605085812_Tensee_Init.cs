using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tensee.Banch.Migrations
{
    public partial class Tensee_Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AppBinaryObjects",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "AbpUserTokens",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbpUserTokens",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AbpUserTokens",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "AbpUsers",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AbpUsers",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpUsers",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrowserInfo",
                table: "AbpUserLoginAttempts",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClaimType",
                table: "AbpUserClaims",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AbpUserAccounts",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "AbpUserAccounts",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpRoles",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClaimType",
                table: "AbpRoleClaims",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AbpOrganizationUnits",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Depth",
                table: "AbpOrganizationUnits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsShop",
                table: "AbpOrganizationUnits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Leader",
                table: "AbpOrganizationUnits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "AbpOrganizationUnits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AbpOrganizationUnits",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrowserInfo",
                table: "AbpAuditLogs",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AbpEntityChangeSets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ExtensionData = table.Column<string>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    Reason = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChangeSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendancesCalculationMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    JsonText = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    MethodCode = table.Column<string>(nullable: true),
                    MethodName = table.Column<string>(nullable: true),
                    SchemeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancesCalculationMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendancesScheme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttendanceCode = table.Column<string>(nullable: true),
                    AttendanceName = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancesScheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendancesSchemeItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SchemeCode = table.Column<string>(nullable: true),
                    SchemeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancesSchemeItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatComplains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplainedUserId = table.Column<long>(nullable: false),
                    Content = table.Column<string>(maxLength: 500, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ScreenShots = table.Column<string>(maxLength: 2048, nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatComplains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatEstimates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(maxLength: 100, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    EstimatedUserId = table.Column<long>(nullable: false),
                    Remark = table.Column<string>(maxLength: 300, nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatEstimates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatInvitations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    Topics = table.Column<string>(maxLength: 80, nullable: true),
                    WatchWord = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatInvitations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatKnockLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChatId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DesUserId = table.Column<long>(nullable: false),
                    HasRead = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatKnockLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatRefundApplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditRemark = table.Column<string>(maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Evidences = table.Column<string>(maxLength: 2048, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Reason = table.Column<string>(maxLength: 150, nullable: true),
                    RefundState = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 150, nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRefundApplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatSessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    During = table.Column<TimeSpan>(nullable: false),
                    FriendShipId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    RecieverId = table.Column<long>(nullable: false),
                    RecieverPayOrderId = table.Column<int>(nullable: true),
                    RecieverPayStatus = table.Column<bool>(nullable: false),
                    SenderId = table.Column<long>(nullable: false),
                    SenderPayOrderId = table.Column<int>(nullable: true),
                    SenderPayStatus = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatTransactionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Remake = table.Column<string>(maxLength: 150, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatTransactionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatUserExpands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Education = table.Column<string>(maxLength: 20, nullable: true),
                    NickName = table.Column<string>(maxLength: 60, nullable: true),
                    Province = table.Column<string>(maxLength: 30, nullable: true),
                    Sex = table.Column<string>(maxLength: 8, nullable: true),
                    UserChatState = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUserExpands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    ReviewText = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Condition = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpressInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Express = table.Column<string>(nullable: true),
                    ExpressCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrderItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpressInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    MobileId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HarvestAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressInfo = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Consignee = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ZipPostalCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    ImgType = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Integral",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailableIntegral = table.Column<decimal>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FreezingIntegral = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OpenId = table.Column<string>(maxLength: 50, nullable: true),
                    TotalIntegral = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    WaitingIntegral = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegralLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplyIntegral = table.Column<decimal>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OpenId = table.Column<string>(maxLength: 50, nullable: true),
                    Result = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegralLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messagemanagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsOpen = table.Column<bool>(nullable: false),
                    IsSend = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    MessageType = table.Column<string>(nullable: true),
                    OpenTime = table.Column<DateTime>(nullable: false),
                    ReceiverID = table.Column<int>(nullable: false),
                    ReceiverName = table.Column<string>(nullable: true),
                    SendTime = table.Column<DateTime>(nullable: false),
                    SenderID = table.Column<int>(nullable: false),
                    SenderName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messagemanagement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessagePool",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    JsonText = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    Operation = table.Column<string>(nullable: true),
                    OrtherMsg = table.Column<string>(nullable: true),
                    PlatForm = table.Column<string>(nullable: true),
                    ResultText = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagePool", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessagePoolHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    JsonText = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    Operation = table.Column<string>(nullable: true),
                    OrtherMsg = table.Column<string>(nullable: true),
                    PlatForm = table.Column<string>(nullable: true),
                    ResultText = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagePoolHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CouponId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GoodsId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Mode = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    ServiceTime = table.Column<DateTime>(nullable: true),
                    ShippingAddressId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(nullable: true),
                    ActualSale = table.Column<double>(nullable: false),
                    CardCode = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrderCode = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrganizationCode = table.Column<string>(nullable: true),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    TargetSale = table.Column<double>(nullable: false),
                    TotalCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonMonthTarget",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    JointRate = table.Column<double>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    NewVip = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<long>(nullable: false),
                    SprintJointRate = table.Column<double>(nullable: false),
                    SprintNewVip = table.Column<int>(nullable: false),
                    SprintTargetSale = table.Column<double>(nullable: false),
                    SprintVipSaleTarget = table.Column<double>(nullable: false),
                    TargetSale = table.Column<double>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    VipSaleTarget = table.Column<double>(nullable: false),
                    ZMonth = table.Column<int>(nullable: false),
                    ZYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonMonthTarget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryCalculationMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    JsonText = table.Column<string>(nullable: true),
                    MethodCode = table.Column<string>(nullable: true),
                    MethodName = table.Column<string>(nullable: true),
                    SchemeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryCalculationMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalarySchemes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SchemeCode = table.Column<string>(nullable: true),
                    SchemeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalarySchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalarySchemesItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    JsonText = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SchemeCode = table.Column<string>(nullable: true),
                    SchemeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalarySchemesItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopDayTarget",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DayTarget = table.Column<double>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    SprintDayTarget = table.Column<double>(nullable: false),
                    ZMonth = table.Column<int>(nullable: false),
                    ZYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopDayTarget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopFormationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Actual = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    Plan = table.Column<int>(nullable: false),
                    Post = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopFormationInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopMonthTarget",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BasicsJointRate = table.Column<double>(nullable: false),
                    BasicsNewVip = table.Column<int>(nullable: false),
                    BasicsVipSaleTarget = table.Column<double>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: false),
                    SprintJointRate = table.Column<double>(nullable: false),
                    SprintNewVip = table.Column<int>(nullable: false),
                    SprintTargetSale = table.Column<double>(nullable: false),
                    SprintVipSaleTarget = table.Column<double>(nullable: false),
                    TargetSale = table.Column<double>(nullable: false),
                    ZMonth = table.Column<int>(nullable: false),
                    ZYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopMonthTarget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopOtherMsg",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CityPostal = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GraduationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Lat = table.Column<double>(nullable: false),
                    Lon = table.Column<double>(nullable: false),
                    OpenDate = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    PhoneNum = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    RestDay = table.Column<int>(nullable: false),
                    ShopAdress = table.Column<string>(nullable: true),
                    ShopArea = table.Column<double>(nullable: false),
                    ShopCode = table.Column<string>(nullable: true),
                    ShopPhoto = table.Column<string>(nullable: true),
                    ShopType = table.Column<string>(nullable: true),
                    WarehouseArea = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOtherMsg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopScheduling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EndDate1 = table.Column<DateTime>(nullable: false),
                    EndDate2 = table.Column<DateTime>(nullable: false),
                    EndDate3 = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShiftCode = table.Column<string>(nullable: true),
                    ShiftColor = table.Column<string>(nullable: true),
                    ShiftName = table.Column<string>(nullable: true),
                    StartDate1 = table.Column<DateTime>(nullable: false),
                    StartDate2 = table.Column<DateTime>(nullable: false),
                    StartDate3 = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Week = table.Column<int>(nullable: false),
                    ZDay = table.Column<int>(nullable: false),
                    ZMonth = table.Column<int>(nullable: false),
                    ZYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopScheduling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopShiftGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopShiftGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopShiftGroupList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GroupId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ShiftCode = table.Column<string>(nullable: true),
                    ShiftColor = table.Column<string>(nullable: true),
                    ShiftName = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopShiftGroupList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopShiftInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EndDate1 = table.Column<string>(nullable: true),
                    EndDate2 = table.Column<string>(nullable: true),
                    EndDate3 = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShiftCode = table.Column<string>(nullable: true),
                    StartDate1 = table.Column<string>(nullable: true),
                    StartDate2 = table.Column<string>(nullable: true),
                    StartDate3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopShiftInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelAccountOptLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    OptType = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAccountOptLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgentApplay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Advice = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: false),
                    AuditComment = table.Column<string>(nullable: true),
                    AuditStatus = table.Column<int>(nullable: false),
                    Career = table.Column<string>(maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Dream = table.Column<string>(nullable: true),
                    InsightsOnLife = table.Column<string>(nullable: true),
                    Interest = table.Column<string>(maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LastestPhoto = table.Column<string>(nullable: true),
                    SelfEvaluation = table.Column<string>(nullable: true),
                    TestId = table.Column<int>(nullable: false),
                    UnderstandingOfConvetion = table.Column<string>(nullable: true),
                    UnderstandingOfSpirit = table.Column<string>(nullable: true),
                    UnderstandingOfTravels = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgentApplay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerContent = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OptionId = table.Column<int>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    TestId = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAnswer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelArea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgentId = table.Column<long>(nullable: true),
                    AreaCode = table.Column<string>(maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name_en = table.Column<string>(maxLength: 50, nullable: true),
                    Name_zh = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Pictures = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelArticle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: true),
                    ArticleType = table.Column<int>(nullable: false),
                    Audio = table.Column<string>(maxLength: 1024, nullable: true),
                    AuthorAvatarUrl = table.Column<string>(maxLength: 1024, nullable: true),
                    AuthorId = table.Column<long>(nullable: false),
                    AuthorNickName = table.Column<string>(maxLength: 50, nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LikeCount = table.Column<int>(nullable: false),
                    ReadCount = table.Column<int>(nullable: false),
                    ShareCount = table.Column<int>(nullable: false),
                    SubTitle = table.Column<string>(maxLength: 200, nullable: true),
                    SurfacePlot = table.Column<string>(maxLength: 1024, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    TopVideo = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelArticle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelArticleLikeLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    CommentId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelArticleLikeLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<long>(nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LikeCount = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    ReplyToUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelComment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelExpand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: true),
                    BankName = table.Column<string>(maxLength: 100, nullable: true),
                    BankNumber = table.Column<string>(maxLength: 50, nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    ContactAddr = table.Column<string>(maxLength: 1024, nullable: true),
                    DeActivatedReason = table.Column<string>(maxLength: 500, nullable: true),
                    IDCardBack = table.Column<string>(maxLength: 1024, nullable: true),
                    IDCardFront = table.Column<string>(maxLength: 1024, nullable: true),
                    Identity = table.Column<string>(maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    JoinTime = table.Column<DateTime>(nullable: true),
                    LastestPhoto = table.Column<string>(maxLength: 1024, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Profiles = table.Column<string>(maxLength: 1024, nullable: true),
                    Sex = table.Column<string>(maxLength: 5, nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelExpand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelOpitons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelOpitons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelQueston",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionName = table.Column<string>(maxLength: 500, nullable: true),
                    QuestionType = table.Column<byte>(nullable: false),
                    TestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelQueston", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TestName = table.Column<string>(maxLength: 100, nullable: true),
                    TestType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelTest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCoupon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CouponId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsUse = table.Column<int>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCoupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEducation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeginDate = table.Column<DateTime>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    EducationUnit = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFamily",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Job = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    RelationShip = table.Column<string>(nullable: true),
                    RelativesName = table.Column<string>(nullable: true),
                    TelPhone = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    WorkUnit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFamily", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserHistoryJob",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeginDate = table.Column<DateTime>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LeaveReason = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    ProveName = table.Column<string>(nullable: true),
                    ProvePhone = table.Column<int>(nullable: false),
                    UnitName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistoryJob", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOtherMsg",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ContractBegin = table.Column<DateTime>(nullable: true),
                    ContractEnd = table.Column<DateTime>(nullable: true),
                    ContractYear = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeptName = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    EmpLevel = table.Column<string>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    Household = table.Column<string>(nullable: true),
                    IdentityAdress = table.Column<string>(nullable: true),
                    IdentityCode = table.Column<string>(nullable: true),
                    InDate = table.Column<DateTime>(nullable: true),
                    IsBear = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsMarry = table.Column<bool>(nullable: false),
                    IsTry = table.Column<int>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LevelDesc = table.Column<string>(nullable: true),
                    Nation = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Political = table.Column<string>(nullable: true),
                    ProbationBegin = table.Column<DateTime>(nullable: true),
                    ProbationEnd = table.Column<DateTime>(nullable: true),
                    PromotionDate = table.Column<DateTime>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    QQ = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    UrgencyAdress = table.Column<string>(nullable: true),
                    UrgencyName = table.Column<string>(nullable: true),
                    UrgencyPhone = table.Column<int>(nullable: false),
                    UrgencyPost = table.Column<string>(nullable: true),
                    UrgencyType = table.Column<string>(nullable: true),
                    UrgencyUnit = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    WeChat = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOtherMsg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSalarySchemes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    SchemesCode = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSalarySchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSalarysItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    ItemValue = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    UsersSalarysId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSalarysItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsConfirm = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSend = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAttendance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersAttendanceItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    ItemValue = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    UsersSalarysId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAttendanceItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersAttendancesScheme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    SchemesCode = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAttendancesScheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersSalarys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsConfirm = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSend = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSalarys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    EmpLevel = table.Column<string>(nullable: true),
                    InDate = table.Column<DateTime>(nullable: false),
                    IsTry = table.Column<bool>(nullable: false),
                    LevelDesc = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WechatConfig",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgentId = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PageName = table.Column<string>(nullable: true),
                    PageRuslt = table.Column<string>(nullable: true),
                    Secret = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WechatConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeChatExpand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgentClass = table.Column<byte>(nullable: false),
                    Brank = table.Column<string>(nullable: true),
                    BrankNumber = table.Column<string>(nullable: true),
                    BrankUserName = table.Column<string>(maxLength: 150, nullable: true),
                    CanCreate = table.Column<bool>(nullable: false),
                    ContactAddr = table.Column<string>(maxLength: 70, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    PartnerCode = table.Column<string>(maxLength: 20, nullable: true),
                    PartnerId = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Remark = table.Column<string>(maxLength: 50, nullable: true),
                    SaleBrand = table.Column<string>(nullable: true),
                    UserCode = table.Column<string>(maxLength: 20, nullable: true),
                    UserType = table.Column<byte>(nullable: false),
                    WeChatUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeChatExpand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeChatUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvatarUrl = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NickName = table.Column<string>(nullable: true),
                    OpenId = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    UserCode = table.Column<string>(maxLength: 20, nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeChatUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovalTime = table.Column<DateTime>(nullable: true),
                    Approver = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    InstanceId = table.Column<int>(nullable: false),
                    IsCurrentStep = table.Column<bool>(nullable: false),
                    PreStepId = table.Column<int>(nullable: true),
                    StepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowApprovals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Approver = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CurrentStep = table.Column<string>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FlowId = table.Column<int>(nullable: false),
                    InstanceNo = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Json = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FlowNoIndex = table.Column<int>(nullable: false),
                    FlowNoLength = table.Column<int>(nullable: false),
                    FlowNoPrefix = table.Column<string>(nullable: true),
                    FlowType = table.Column<string>(nullable: true),
                    FormJson = table.Column<string>(nullable: true),
                    HtmlText = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PageUrl = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StepJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlowStepRelations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Condtion = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    FlowId = table.Column<int>(nullable: false),
                    FromStep = table.Column<int>(nullable: false),
                    ToStep = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowStepRelations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlowSteps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApproverList = table.Column<string>(nullable: true),
                    CopyerList = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FlowId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    StepButton = table.Column<string>(nullable: true),
                    StepName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlowTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FlowId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Table = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_AfterSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AfterPicture = table.Column<string>(nullable: true),
                    AfterReason = table.Column<string>(nullable: true),
                    Afterstatus = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    OriginalStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_AfterSale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_AgentOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgentClass = table.Column<byte>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    PayStatus = table.Column<int>(nullable: false),
                    Payment = table.Column<decimal>(nullable: false),
                    PreAgentOrderId = table.Column<int>(nullable: true),
                    ReceiveStatus = table.Column<int>(nullable: false),
                    Received = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_AgentOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_Attribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    InputType = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSalesAttributes = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ValueType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_Attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_AttributeValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_AttributeValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_Goods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BigImgName = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FullDescription = table.Column<string>(nullable: true),
                    GoodsCode = table.Column<string>(maxLength: 40, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    SimpleName = table.Column<string>(maxLength: 50, nullable: true),
                    SupplyCode = table.Column<string>(maxLength: 40, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_Goods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_GoodsAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GoodsId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_GoodsAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_GoodsAttributeValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributesXml = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GoodsId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PriceAdjustment = table.Column<int>(nullable: true),
                    StockQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_GoodsAttributeValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_GoodsCar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    GoodsId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SkuId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_GoodsCar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_GoodsImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GoodsId = table.Column<int>(nullable: false),
                    ImagesId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_GoodsImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_GoodsSku",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributesXml = table.Column<string>(maxLength: 200, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GoodsId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PriceAdjustment = table.Column<int>(nullable: false),
                    SkuCode = table.Column<string>(maxLength: 200, nullable: true),
                    StockQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_GoodsSku", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_HomePage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Configuration = table.Column<string>(nullable: true),
                    ModuleCode = table.Column<string>(maxLength: 30, nullable: true),
                    ModuleName = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_HomePage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_logistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Express = table.Column<string>(maxLength: 30, nullable: true),
                    ExpressCode = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_logistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressInfo = table.Column<string>(nullable: true),
                    Area = table.Column<string>(maxLength: 40, nullable: true),
                    City = table.Column<string>(maxLength: 40, nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    Consignee = table.Column<string>(maxLength: 50, nullable: true),
                    CouponId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrderAgentClass = table.Column<byte>(nullable: false),
                    OrderUserName = table.Column<string>(maxLength: 50, nullable: true),
                    PayTime = table.Column<DateTime>(nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Province = table.Column<string>(maxLength: 20, nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    ShippingAddressId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TopAgentClass = table.Column<byte>(nullable: false),
                    TopAgentId = table.Column<int>(nullable: false),
                    TopAgentName = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_OrderInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributesXml = table.Column<string>(maxLength: 200, nullable: true),
                    BigImgName = table.Column<string>(maxLength: 500, nullable: true),
                    Count = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GoodsCode = table.Column<string>(nullable: true),
                    GoodsId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SKUCode = table.Column<string>(maxLength: 40, nullable: true),
                    SimpleName = table.Column<string>(maxLength: 50, nullable: true),
                    SkuId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    TopAgentPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_OrderInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wx_UserPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgentClass = table.Column<byte>(nullable: false),
                    AttributeValueId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GoodsId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wx_UserPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityChangeSetId = table.Column<long>(nullable: false),
                    EntityId = table.Column<string>(maxLength: 48, nullable: true),
                    EntityTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityChanges_AbpEntityChangeSets_EntityChangeSetId",
                        column: x => x.EntityChangeSetId,
                        principalTable: "AbpEntityChangeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppWeChatUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvatarUrl = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ExpandId = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    OpenId = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppWeChatUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppWeChatUser_WeChatExpand_ExpandId",
                        column: x => x.ExpandId,
                        principalTable: "WeChatExpand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowFormData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FieldName = table.Column<string>(nullable: true),
                    FieldValue = table.Column<string>(nullable: true),
                    InstanceId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LineId = table.Column<int>(nullable: false),
                    Table = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowFormData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowFormData_WorkflowInstances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "WorkflowInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlowFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ControlId = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FieldLable = table.Column<string>(nullable: true),
                    FieldPlaceholder = table.Column<string>(nullable: true),
                    FieldType = table.Column<string>(nullable: true),
                    FlowId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    JsText = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OtherCss = table.Column<string>(nullable: true),
                    TableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkFlowFields_WorkFlowTables_TableId",
                        column: x => x.TableId,
                        principalTable: "WorkFlowTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityChangeId = table.Column<long>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 96, nullable: true),
                    PropertyTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalTable: "AbpEntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_EntityChangeSetId",
                table: "AbpEntityChanges",
                column: "EntityChangeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_EntityTypeFullName_EntityId",
                table: "AbpEntityChanges",
                columns: new[] { "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_CreationTime",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_Reason",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "Reason" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_UserId",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityPropertyChanges_EntityChangeId",
                table: "AbpEntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppWeChatUser_ExpandId",
                table: "AppWeChatUser",
                column: "ExpandId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowFields_TableId",
                table: "WorkFlowFields",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowFormData_InstanceId",
                table: "WorkflowFormData",
                column: "InstanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AppWeChatUser");

            migrationBuilder.DropTable(
                name: "AttendancesCalculationMethod");

            migrationBuilder.DropTable(
                name: "AttendancesScheme");

            migrationBuilder.DropTable(
                name: "AttendancesSchemeItems");

            migrationBuilder.DropTable(
                name: "ChatComplains");

            migrationBuilder.DropTable(
                name: "ChatEstimates");

            migrationBuilder.DropTable(
                name: "ChatInvitations");

            migrationBuilder.DropTable(
                name: "ChatKnockLog");

            migrationBuilder.DropTable(
                name: "ChatRefundApplies");

            migrationBuilder.DropTable(
                name: "ChatSessions");

            migrationBuilder.DropTable(
                name: "ChatTransactionDetails");

            migrationBuilder.DropTable(
                name: "ChatUserExpands");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Dictionary");

            migrationBuilder.DropTable(
                name: "ExpressInfo");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "HarvestAddress");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Integral");

            migrationBuilder.DropTable(
                name: "IntegralLog");

            migrationBuilder.DropTable(
                name: "Messagemanagement");

            migrationBuilder.DropTable(
                name: "MessagePool");

            migrationBuilder.DropTable(
                name: "MessagePoolHistory");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderSale");

            migrationBuilder.DropTable(
                name: "PersonMonthTarget");

            migrationBuilder.DropTable(
                name: "SalaryCalculationMethod");

            migrationBuilder.DropTable(
                name: "SalaryItems");

            migrationBuilder.DropTable(
                name: "SalarySchemes");

            migrationBuilder.DropTable(
                name: "SalarySchemesItems");

            migrationBuilder.DropTable(
                name: "ShopDayTarget");

            migrationBuilder.DropTable(
                name: "ShopFormationInfo");

            migrationBuilder.DropTable(
                name: "ShopMonthTarget");

            migrationBuilder.DropTable(
                name: "ShopOtherMsg");

            migrationBuilder.DropTable(
                name: "ShopScheduling");

            migrationBuilder.DropTable(
                name: "ShopShiftGroup");

            migrationBuilder.DropTable(
                name: "ShopShiftGroupList");

            migrationBuilder.DropTable(
                name: "ShopShiftInfo");

            migrationBuilder.DropTable(
                name: "TravelAccountOptLog");

            migrationBuilder.DropTable(
                name: "TravelAgentApplay");

            migrationBuilder.DropTable(
                name: "TravelAnswer");

            migrationBuilder.DropTable(
                name: "TravelArea");

            migrationBuilder.DropTable(
                name: "TravelArticle");

            migrationBuilder.DropTable(
                name: "TravelArticleLikeLog");

            migrationBuilder.DropTable(
                name: "TravelComment");

            migrationBuilder.DropTable(
                name: "TravelExpand");

            migrationBuilder.DropTable(
                name: "TravelOpitons");

            migrationBuilder.DropTable(
                name: "TravelQueston");

            migrationBuilder.DropTable(
                name: "TravelTest");

            migrationBuilder.DropTable(
                name: "UserCoupon");

            migrationBuilder.DropTable(
                name: "UserEducation");

            migrationBuilder.DropTable(
                name: "UserFamily");

            migrationBuilder.DropTable(
                name: "UserHistoryJob");

            migrationBuilder.DropTable(
                name: "UserOtherMsg");

            migrationBuilder.DropTable(
                name: "UserSalarySchemes");

            migrationBuilder.DropTable(
                name: "UserSalarysItems");

            migrationBuilder.DropTable(
                name: "UsersAttendance");

            migrationBuilder.DropTable(
                name: "UsersAttendanceItems");

            migrationBuilder.DropTable(
                name: "UsersAttendancesScheme");

            migrationBuilder.DropTable(
                name: "UsersSalarys");

            migrationBuilder.DropTable(
                name: "UserUnits");

            migrationBuilder.DropTable(
                name: "WechatConfig");

            migrationBuilder.DropTable(
                name: "WeChatUser");

            migrationBuilder.DropTable(
                name: "WorkflowApprovals");

            migrationBuilder.DropTable(
                name: "WorkFlowFields");

            migrationBuilder.DropTable(
                name: "WorkflowFormData");

            migrationBuilder.DropTable(
                name: "WorkFlows");

            migrationBuilder.DropTable(
                name: "WorkFlowStepRelations");

            migrationBuilder.DropTable(
                name: "WorkFlowSteps");

            migrationBuilder.DropTable(
                name: "Wx_AfterSale");

            migrationBuilder.DropTable(
                name: "Wx_AgentOrder");

            migrationBuilder.DropTable(
                name: "Wx_Attribute");

            migrationBuilder.DropTable(
                name: "Wx_AttributeValue");

            migrationBuilder.DropTable(
                name: "Wx_Goods");

            migrationBuilder.DropTable(
                name: "Wx_GoodsAttribute");

            migrationBuilder.DropTable(
                name: "Wx_GoodsAttributeValue");

            migrationBuilder.DropTable(
                name: "Wx_GoodsCar");

            migrationBuilder.DropTable(
                name: "Wx_GoodsImages");

            migrationBuilder.DropTable(
                name: "Wx_GoodsSku");

            migrationBuilder.DropTable(
                name: "Wx_HomePage");

            migrationBuilder.DropTable(
                name: "Wx_logistics");

            migrationBuilder.DropTable(
                name: "Wx_Order");

            migrationBuilder.DropTable(
                name: "Wx_OrderInfo");

            migrationBuilder.DropTable(
                name: "Wx_UserPrice");

            migrationBuilder.DropTable(
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "WeChatExpand");

            migrationBuilder.DropTable(
                name: "WorkFlowTables");

            migrationBuilder.DropTable(
                name: "WorkflowInstances");

            migrationBuilder.DropTable(
                name: "AbpEntityChangeSets");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "AppBinaryObjects");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Depth",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "IsShop",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Leader",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AbpOrganizationUnits");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "AbpUserTokens",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbpUserTokens",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AbpUserTokens",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrowserInfo",
                table: "AbpUserLoginAttempts",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClaimType",
                table: "AbpUserClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AbpUserAccounts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "AbpUserAccounts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpRoles",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClaimType",
                table: "AbpRoleClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrowserInfo",
                table: "AbpAuditLogs",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 512,
                oldNullable: true);
        }
    }
}
