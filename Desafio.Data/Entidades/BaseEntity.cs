using Desafio.Data.Helpers;

namespace Desafio.Data.Entidades
{
    public class BaseEntity : Entity
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public Guid IdentificadorManipulador { get; set; }
    }
}
