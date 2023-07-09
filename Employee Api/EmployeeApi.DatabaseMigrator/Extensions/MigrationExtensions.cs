using FluentMigrator.Builders.Create.Table;

namespace EmployeeApi.DatabaseMigrator.Extensions
{
    public static class MigrationExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax WithIDColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("ID")
                .AsInt32()
                .NotNullable()
                .PrimaryKey()
                .Identity();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithRegistrationDetails(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("RegDate").AsDate().WithDefaultValue(DateTime.Now)
                .WithColumn("RegUser").AsInt32().NotNullable().WithDefaultValue(0);
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithStatusColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("Status")
                .AsInt32()
                .NotNullable()
                .WithDefaultValue(0);
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax AsMaxString(this ICreateTableColumnAsTypeSyntax createTableColumnAsTypeSyntax)
        {
            return createTableColumnAsTypeSyntax.AsString(int.MaxValue);
        }

    }
}
