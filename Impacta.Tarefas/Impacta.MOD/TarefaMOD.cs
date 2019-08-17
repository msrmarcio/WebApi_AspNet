namespace Impacta.MOD
{
	// passar a classe para PUBLIC
	// para que os outros projetos possam referenciar
	// e utilizar a classe
	public class TarefaMOD
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Prioridade { get; set; }
        public bool Concluida { get; set; }
        public string Observacoes { get; set; }
    }
}
