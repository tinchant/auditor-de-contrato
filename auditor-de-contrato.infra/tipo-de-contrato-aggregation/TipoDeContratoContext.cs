using Microsoft.EntityFrameworkCore;

namespace auditor_de_contrato.api.infra.tipo_de_contrato_aggregation
{
    public class TipoDeContratoContext : DbContext
    {
        public TipoDeContratoContext (DbContextOptions<TipoDeContratoContext> options)
            : base(options)
        {
        }

        public DbSet<auditor_de_contrato.domain.tipo_de_contrato_aggregation.TipoDeContrato> TipoDeContrato { get; set; }
    }
}
