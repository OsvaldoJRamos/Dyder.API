using AutoMapper;
using Dyder.API.ViewModels;
using Dyder.Domain.Dto;
using Dyder.Domain.Entities;

namespace Dyder.API.Profiles
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Estabelecimento, EstabelecimentoViewModel>().ReverseMap();

            CreateMap<EstabelecimentoPagamento, EstabelecimentoPagamentoViewModel>()
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.FormaPagamento.Descricao))
                .ReverseMap();

            CreateMap<HorarioFuncionamento, HorarioFuncionamentoViewModel>();

            CreateMap<TimeOnly, TimeOnlyDto>()
                .ForMember(dest => dest.Hora, opt => opt.MapFrom(src => src.Hour))
                .ForMember(dest => dest.Minuto, opt => opt.MapFrom(src => src.Minute))
                .ReverseMap();
        }
    }
}
