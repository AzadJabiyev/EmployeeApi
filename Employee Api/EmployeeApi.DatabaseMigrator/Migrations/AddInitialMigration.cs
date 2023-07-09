using EmployeeApi.DatabaseMigrator.Extensions;
using EmployeeApi.Models;
using FluentMigrator;
using FluentMigrator.SqlServer;

namespace EmployeeApi.DatabaseMigrator.Migrations
{
    [Migration(1)]
    public class AddInitialMigration : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Employees")
                .Row(new EmployeeModel
                {
                    Age = 32,
                    Name = "Azad Jabiyev",
                });

            Delete.Table("Employees");
        }

        public override void Up()
        {
            Create.Table("Employees")
                .WithIDColumn()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Age").AsString().NotNullable()
                .WithRegistrationDetails();

            Insert.IntoTable("Employees")
            .Row(new EmployeeModel
            {
                Age = 32,
                Name = "Azad Jabiyev",
            }).WithIdentityInsert();
        }
    }
}
