using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tensee.Banch.Migrations
{
    public partial class UpdateTravels_AddUserId_liguo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "WeChatExpand");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "WeChatExpand");

            migrationBuilder.DropColumn(
                name: "Career",
                table: "WeChatExpand");

            migrationBuilder.DropColumn(
                name: "DeActivatedReason",
                table: "WeChatExpand");

            migrationBuilder.DropColumn(
                name: "Dream",
                table: "WeChatExpand");

            migrationBuilder.DropColumn(
                name: "InsightsOnLife",
                table: "WeChatExpand");

            migrationBuilder.DropColumn(
                name: "Interest",
                table: "WeChatExpand");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "WeChatExpand");

            migrationBuilder.DropColumn(
                name: "Profiles",
                table: "WeChatExpand");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "WeChatExpand");

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

            migrationBuilder.AlterColumn<long>(
                name: "ReplyToUserId",
                table: "TravelComment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "TravelComment",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "TravelComment",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "TravelArticle",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "AuthorAvatarUrl",
                table: "TravelArticle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorNickName",
                table: "TravelArticle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "TravelArticle",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AgentId",
                table: "TravelArea",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "TravelAnswer",
                nullable: false,
                oldClrType: typeof(int));

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
                name: "TravelAgentExpand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    AvatarUrl = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Career = table.Column<string>(maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeActivatedReason = table.Column<string>(maxLength: 500, nullable: true),
                    Dream = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    InsightsOnLife = table.Column<string>(nullable: true),
                    Interest = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    OpenId = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Profiles = table.Column<string>(maxLength: 1024, nullable: true),
                    UserCode = table.Column<string>(maxLength: 20, nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgentExpand", x => x.Id);
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
                name: "TravelAgentExpand");

            migrationBuilder.DropTable(
                name: "UserSalarySchemes");

            migrationBuilder.DropTable(
                name: "UserSalarysItems");

            migrationBuilder.DropTable(
                name: "UsersSalarys");

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
                name: "ParentId",
                table: "TravelComment");

            migrationBuilder.DropColumn(
                name: "AuthorAvatarUrl",
                table: "TravelArticle");

            migrationBuilder.DropColumn(
                name: "AuthorNickName",
                table: "TravelArticle");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "TravelArticle");

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

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "WeChatExpand",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "WeChatExpand",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Career",
                table: "WeChatExpand",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeActivatedReason",
                table: "WeChatExpand",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dream",
                table: "WeChatExpand",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsightsOnLife",
                table: "WeChatExpand",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interest",
                table: "WeChatExpand",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "WeChatExpand",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profiles",
                table: "WeChatExpand",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "WeChatExpand",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AlterColumn<int>(
                name: "ReplyToUserId",
                table: "TravelComment",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "TravelComment",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "TravelArticle",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "TravelArea",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TravelAnswer",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
