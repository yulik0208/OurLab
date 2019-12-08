namespace VirtualLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFixes : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Topics", name: "Result_Id1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Topics", name: "Result_Id", newName: "Result_Id1");
            RenameColumn(table: "dbo.Topics", name: "__mig_tmp__0", newName: "Result_Id");
            RenameIndex(table: "dbo.Topics", name: "IX_Result_Id1", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Topics", name: "IX_Result_Id", newName: "IX_Result_Id1");
            RenameIndex(table: "dbo.Topics", name: "__mig_tmp__0", newName: "IX_Result_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Topics", name: "IX_Result_Id", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Topics", name: "IX_Result_Id1", newName: "IX_Result_Id");
            RenameIndex(table: "dbo.Topics", name: "__mig_tmp__0", newName: "IX_Result_Id1");
            RenameColumn(table: "dbo.Topics", name: "Result_Id", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Topics", name: "Result_Id1", newName: "Result_Id");
            RenameColumn(table: "dbo.Topics", name: "__mig_tmp__0", newName: "Result_Id1");
        }
    }
}
