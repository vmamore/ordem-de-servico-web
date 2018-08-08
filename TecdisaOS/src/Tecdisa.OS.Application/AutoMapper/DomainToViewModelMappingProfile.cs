using AutoMapper;
using Tecdisa.OS.Application.ViewModel;
using Tecdisa.OS.Domain.DTO;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            // Domínio
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Paged<Cliente>, PagedViewModel<ClienteViewModel>>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<OrdemDeServico, OrdemDeServicoViewModel>().ReverseMap();
            CreateMap<Tecnico, TecnicoViewModel>().ReverseMap();
            CreateMap<Programador, ProgramadorViewModel>().ReverseMap();
            CreateMap<Sistema, SistemaViewModel>().ReverseMap();
            CreateMap<Modulo, ModuloViewModel>().ReverseMap();

        }
    }
}
