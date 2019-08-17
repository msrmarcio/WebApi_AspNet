// vamos adicionar o Entity Framework
using Impacta.MOD;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient; 

namespace Impacta.Tarefas.EF
{
	public class RealBooksContexto : DbContext
	{
        string conexao;

		public RealBooksContexto() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RealBooks;Integrated Security=True;Pooling=False")
			//base(@"Data Source=LAPTOP-LRFTCEPN;Initial Catalog=RealBooks;User ID=sa;Password=Whois@2008;")
		{
			//Database.SetInitializer<RealBooksContexto>(new DropCreateDatabaseAlways<RealBooksContexto>());

		}

		// Para trabalhar EF, você precisa de uma classe
		// para representar o seu BD que é nossa classe CONTEXTO
		// que deve Herdar de DbContext
		// Todas as tabelas que você desejar trabalhar no Banco de dados
		// devem ser mapeadas aqui com os DBSet<>
		public DbSet<Editora> Editoras { get; set; }
		public DbSet<Livro> Livros { get; set; } 



		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

			// Por padrão do EF as entidades geradas no banco dados
			// utilizam o plural do ingles: Ex: Livros -> Livroes
			// desabilita o padrão de plural automatico do EF 6
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<Editora>().Property(t => t.Nome).HasMaxLength(50);

		}



	}
}
/*
Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Pessoal;Integrated Security=True		 
		public RealBooksContexto() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RealBooks;Integrated Security=True;Pooling=False")
		 */
