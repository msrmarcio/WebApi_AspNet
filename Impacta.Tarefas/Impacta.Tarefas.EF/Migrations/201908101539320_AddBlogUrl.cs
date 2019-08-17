namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Editora", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Editora", "Url");
        }
    }
}
