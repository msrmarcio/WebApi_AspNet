using System.ComponentModel.DataAnnotations;

namespace Impacta.Tarefas.Models
{
	public class TarefaViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nome da Tarefa")]
		[StringLength(200, MinimumLength =5, ErrorMessage = "Minimo de 5 e Maximo de 200 caracteres")]
		public string Nome { get; set; }
        [Required]
        [Display(Name = "Prioridade Definida")]
        public int Prioridade { get; set; }
        [Required]
        [Display(Name = "Tarefa Concluída?")]
        public bool Concluida { get; set; }
        [StringLength(200, ErrorMessage ="Maximo de 200 caracteres")]
        public string Observacao { get; set; }
	}
}