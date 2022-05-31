namespace Dyder.API.ViewModels
{
    public class EstabelecimentoViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool EstaAberto { get; set; }
        public List<EstabelecimentoPagamentoViewModel> FormasPagamento { get; set; }
        public List<HorarioFuncionamentoViewModel> HorariosFuncionamento { get; set; }
    }
}
