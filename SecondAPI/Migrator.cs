using FluentMigrator;

namespace SecondAPI
{
    [Migration(1)]
    public class Migrator : Migration
    {
        public override void Up()
        {
            Create.Table("CpuMetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
        }

        public override void Down()
        {
            Delete.Table("CpuMetrics");
        }
    }
}
