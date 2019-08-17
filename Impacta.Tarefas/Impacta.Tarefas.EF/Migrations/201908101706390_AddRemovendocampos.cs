namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemovendocampos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Editora", "Url");
            DropColumn("dbo.Editora", "NumeroCelular");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Editora", "NumeroCelular", c => c.String());
            AddColumn("dbo.Editora", "Url", c => c.String());
        }
    }
}
