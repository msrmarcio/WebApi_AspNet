namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPais : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endereco", "Pais", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Endereco", "Pais");
        }
    }
}
