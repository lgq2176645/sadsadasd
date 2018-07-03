using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tensee.Banch.Migrations
{
    public partial class CreateTravels_liguo_20180507 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvitedCode",
                table: "WeChatExpand");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "IntegralLog",
                newName: "Status");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Wx_OrderInfo",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "AttributesXml",
                table: "Wx_OrderInfo",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BigImgName",
                table: "Wx_OrderInfo",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoodsCode",
                table: "Wx_OrderInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SKUCode",
                table: "Wx_OrderInfo",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SimpleName",
                table: "Wx_OrderInfo",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Wx_OrderInfo",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TopAgentPrice",
                table: "Wx_OrderInfo",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AddressInfo",
                table: "Wx_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Wx_Order",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Wx_Order",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consignee",
                table: "Wx_Order",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "OrderAgentClass",
                table: "Wx_Order",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "OrderUserName",
                table: "Wx_Order",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayTime",
                table: "Wx_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Wx_Order",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Wx_Order",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpressCode",
                table: "Wx_logistics",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Express",
                table: "Wx_logistics",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Wx_GoodsCar",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Wx_Goods",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Wx_Goods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SimpleName",
                table: "Wx_Goods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormJson",
                table: "WorkFlows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartnerCode",
                table: "WeChatExpand",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PromotionDate",
                table: "UserOtherMsg",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProbationEnd",
                table: "UserOtherMsg",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProbationBegin",
                table: "UserOtherMsg",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InDate",
                table: "UserOtherMsg",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEnd",
                table: "UserOtherMsg",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractBegin",
                table: "UserOtherMsg",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "UserOtherMsg",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "UserHistoryJob",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeginDate",
                table: "UserHistoryJob",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "UserEducation",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeginDate",
                table: "UserEducation",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "IntegralLog",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OpenId",
                table: "IntegralLog",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OpenId",
                table: "Integral",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FreezingIntegral",
                table: "Integral",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Integral",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "WaitingIntegral",
                table: "Integral",
                nullable: false,
                defaultValue: 0m);

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
                    AuthorAvatarUrl = table.Column<string>(maxLength: 1024, nullable: true),
                    AuthorId = table.Column<long>(nullable: false),
                    AuthorNickName = table.Column<string>(maxLength: 50, nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 4096, nullable: true),
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
                name: "UserSalarySchemes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable:false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
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
                name: "WorkflowInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Approver = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    InstanceNo = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowFormData_InstanceId",
                table: "WorkflowFormData",
                column: "InstanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryItems");

            migrationBuilder.DropTable(
                name: "SalarySchemes");

            migrationBuilder.DropTable(
                name: "SalarySchemesItems");

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
                name: "UserSalarySchemes");

            migrationBuilder.DropTable(
                name: "UserSalarysItems");

            migrationBuilder.DropTable(
                name: "UsersSalarys");

            migrationBuilder.DropTable(
                name: "WeChatUser");

            migrationBuilder.DropTable(
                name: "WorkflowFormData");

            migrationBuilder.DropTable(
                name: "Wx_HomePage");

            migrationBuilder.DropTable(
                name: "WorkflowInstances");

            migrationBuilder.DropColumn(
                name: "AttributesXml",
                table: "Wx_OrderInfo");

            migrationBuilder.DropColumn(
                name: "BigImgName",
                table: "Wx_OrderInfo");

            migrationBuilder.DropColumn(
                name: "GoodsCode",
                table: "Wx_OrderInfo");

            migrationBuilder.DropColumn(
                name: "SKUCode",
                table: "Wx_OrderInfo");

            migrationBuilder.DropColumn(
                name: "SimpleName",
                table: "Wx_OrderInfo");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Wx_OrderInfo");

            migrationBuilder.DropColumn(
                name: "TopAgentPrice",
                table: "Wx_OrderInfo");

            migrationBuilder.DropColumn(
                name: "AddressInfo",
                table: "Wx_Order");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Wx_Order");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Wx_Order");

            migrationBuilder.DropColumn(
                name: "Consignee",
                table: "Wx_Order");

            migrationBuilder.DropColumn(
                name: "OrderAgentClass",
                table: "Wx_Order");

            migrationBuilder.DropColumn(
                name: "OrderUserName",
                table: "Wx_Order");

            migrationBuilder.DropColumn(
                name: "PayTime",
                table: "Wx_Order");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Wx_Order");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Wx_Order");

            migrationBuilder.DropColumn(
                name: "Express",
                table: "Wx_logistics");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Wx_Goods");

            migrationBuilder.DropColumn(
                name: "SimpleName",
                table: "Wx_Goods");

            migrationBuilder.DropColumn(
                name: "FormJson",
                table: "WorkFlows");

            migrationBuilder.DropColumn(
                name: "PartnerCode",
                table: "WeChatExpand");

            migrationBuilder.DropColumn(
                name: "FreezingIntegral",
                table: "Integral");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Integral");

            migrationBuilder.DropColumn(
                name: "WaitingIntegral",
                table: "Integral");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "IntegralLog",
                newName: "status");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Wx_OrderInfo",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "ExpressCode",
                table: "Wx_logistics",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Wx_GoodsCar",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Wx_Goods",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvitedCode",
                table: "WeChatExpand",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PromotionDate",
                table: "UserOtherMsg",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProbationEnd",
                table: "UserOtherMsg",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProbationBegin",
                table: "UserOtherMsg",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InDate",
                table: "UserOtherMsg",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEnd",
                table: "UserOtherMsg",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractBegin",
                table: "UserOtherMsg",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "UserOtherMsg",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "UserHistoryJob",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeginDate",
                table: "UserHistoryJob",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "UserEducation",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeginDate",
                table: "UserEducation",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "IntegralLog",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OpenId",
                table: "IntegralLog",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OpenId",
                table: "Integral",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
