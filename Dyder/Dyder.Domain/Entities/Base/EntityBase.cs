namespace Dyder.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public DateTime CriadoEm { get; private set; } = DateTime.Now;
        public DateTime? ModificadoEm { get; private set; }
        public DateTime? DeletadoEm { get; private set; }
        public bool EstaAtivo { get; private set; } = true;
        //public abstract void Validar();
    }
}
