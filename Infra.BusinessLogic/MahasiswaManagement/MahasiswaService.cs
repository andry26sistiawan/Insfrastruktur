using AutoMapper;
using Infra.BusinessLogic.MahasiswaManagement.DTO;
using Infra.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.BusinessLogic.MahasiswaManagement
{
    public class MahasiswaService
    {

        private readonly IMapper _mapper;

        public MahasiswaService()
        {
            var convig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MahasiswaPostDTO, Mahasiswa>();
                cfg.CreateMap<TestDTO, Mahasiswa>()
                .ForMember(dst => dst.NIP, opt => opt.MapFrom(src => src.NIP1))
                .ForMember(dst => dst.Alamat, opt => opt.MapFrom(src => src.Alamat1));
            });
        }

        public async Task<Mahasiswa> TestMapper(TestDTO param)
        {
            var ress = _mapper.Map<Mahasiswa>(param);

            return ress;
        }

    }
}
