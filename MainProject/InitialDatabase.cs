﻿using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainProject
{
    public class InitialDatabase : Migration
    {
        public override void Up()
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Down()
        {

        }
    }
}