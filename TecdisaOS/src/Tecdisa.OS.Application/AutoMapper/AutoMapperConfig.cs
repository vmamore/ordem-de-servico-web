using AutoMapper;

namespace Tecdisa.OS.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegistarMappings()
        {
            Mapper.Initialize(i =>
            {
                i.AddProfile<DomainToViewModelMappingProfile>();
            });
        }
    }
}
