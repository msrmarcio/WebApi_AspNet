namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Editora",
                c => new
                    {
                        EditoraId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Cnpj = c.String(nullable: false),
                        Telefone = c.String(),
                        Endereco_Id = c.Int(),
                    })
                .PrimaryKey(t => t.EditoraId)
                .ForeignKey("dbo.Endereco", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Cep = c.String(),
                        Municipio = c.String(),
                        Uf = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        LivroId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Editora_EditoraId = c.Int(),
                    })
                .PrimaryKey(t => t.LivroId)
                .ForeignKey("dbo.Editora", t => t.Editora_EditoraId)
                .Index(t => t.Editora_EditoraId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "Editora_EditoraId", "dbo.Editora");
            DropForeignKey("dbo.Editora", "Endereco_Id", "dbo.Endereco");
            DropIndex("dbo.Livro", new[] { "Editora_EditoraId" });
            DropIndex("dbo.Editora", new[] { "Endereco_Id" });
            DropTable("dbo.Livro");
            DropTable("dbo.Endereco");
            DropTable("dbo.Editora");
        }
    }
}
