using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainProject.App_Start
{
    [Migration(1)]
    public class CreateUserTable : Migration
    {
        public override void Up()
        {
            if (!Schema.Table("Users").Exists())
            {
                Create.Table("Users")
                    .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                    .WithColumn("UserName").AsString(255).NotNullable()
                    .WithColumn("Password").AsString(255).NotNullable()
                    .WithColumn("ClientId").AsString(255).NotNullable();
            }
        }

        public override void Down()
        {
            
        }
    }
}