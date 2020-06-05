using System.ComponentModel.DataAnnotations;

namespace auditor_de_contrato.domain.tipo_de_contrato_aggregation
{
    public class TipoDeContrato
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
