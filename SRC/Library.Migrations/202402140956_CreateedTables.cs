using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Migrations;

[Migration(202402140956)]
public class _202402140956_CreateedTables : Migration

{
    public override void Up()
    {


        Create.Table("Authers")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(100).WithDefaultValue("hichkas").NotNullable();
        Create.Table("Genres")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(100).WithDefaultValue("hichi").NotNullable();
        Create.Table("Books")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(100).WithDefaultValue("hichi").NotNullable()
            .WithColumn("Category").AsString(100).WithDefaultValue("hichi").NotNullable()
            .WithColumn("Count").AsInt32()
            .WithColumn("NumberOfBorrowBook").AsInt32()
            .WithColumn("RestOfBook").AsInt32()
            .WithColumn("AutherId").AsInt32()
            .ForeignKey("FK_Books_Authers", "Authers", "Id")
            .WithColumn("GenreId").AsInt32()
            .ForeignKey("FK_Books_Genres", "Genres", "Id");
        Create.Table("Users")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(100).WithDefaultValue("Tavvv").NotNullable()
            .WithColumn("Email").AsString(150).WithDefaultValue("tavv.gmail.com").NotNullable()
            .WithColumn("Phone").AsString(14).WithDefaultValue("+989174443333").NotNullable();
        Create.Table("Orders")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("NumberOfNotReturnedBook").AsInt32()
            .WithColumn("OrderDate").AsDateTime2().NotNullable()
            .WithColumn("UserId").AsInt32()
            .ForeignKey("FK_Orders_Users", "Users", "Id");
        Create.Table("OrderItems")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("NumberOfBook").AsInt32().NotNullable()
            .WithColumn("ReturnDate").AsDateTime2().NotNullable()
            .WithColumn("OrderDate").AsDateTime2().NotNullable()
            .WithColumn("ReturnStatus").AsBoolean()
            .WithColumn("BookId").AsInt32()
            .ForeignKey("FK_OrderItems_Books", "Books", "Id")
            .WithColumn("OrderId").AsInt32()
            .ForeignKey("FK_OrderItems_Orders", "Orders", "Id");
    }
    public override void Down()
    {
        Delete.Table("OrderItems");
        Delete.Table("Orders");
        Delete.Table("Users");
        Delete.Table("Books");
        Delete.Table("Genres");
        Delete.Table("Authers");
    }
}
