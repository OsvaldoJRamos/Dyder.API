namespace Dyder.Domain.Entities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal ValorOriginal { get; private set; }
        public decimal? ValorPromocional { get; private set; }
        public int? QtdeAdicionaisGratis { get; private set; }
        public int? QtdeAdicionaisPagos { get; private set; }

        public Produto(int id, string descricao, decimal valorOriginal, decimal? valorPromocional, int? qtdeAdicionaisGratis, int? qtdeAdicionaisPagos)
        {
            Id = id;
            Descricao = descricao;
            ValorOriginal = valorOriginal;
            ValorPromocional = valorPromocional;
            QtdeAdicionaisGratis = qtdeAdicionaisGratis;
            QtdeAdicionaisPagos = qtdeAdicionaisPagos;
        }
    }
}
