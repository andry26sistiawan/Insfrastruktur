using AutoMapper;
using Infra.BusinessLogic.MahasiswaManagement.DTO;
using Infra.DataAccess.Model;
using Infra.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.BusinessLogic.MahasiswaManagement
{
    public class MahasiswaService
    {

        private readonly IMapper _mapper;
        private readonly MahasiswaRepository mahasiswaRepository;

        public MahasiswaService()
        {
            mahasiswaRepository ??= new MahasiswaRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MahasiswaPostDTO, Mahasiswa>();
                cfg.CreateMap<TestDTO, Mahasiswa>()
                .ForMember(dst => dst.NIP, opt => opt.MapFrom(src => src.NIP1))
                .ForMember(dst => dst.Alamat, opt => opt.MapFrom(src => src.Alamat1));
            });
            _mapper = config.CreateMapper();

        }

        public async Task<Mahasiswa> TestMapper(TestDTO param)
        {
            var ress = _mapper.Map<Mahasiswa>(param);

            return ress;
        }

        public async Task<Mahasiswa> CreateMahasiswa(MahasiswaPostDTO mahasiswaPostDTO)
        {
            var data = _mapper.Map<Mahasiswa>(mahasiswaPostDTO);
            var res = await mahasiswaRepository.CreateMahasiswa(data);

            return res;
        }

        public async Task<string> TestMahasiswa()
        {
            return "Mahasiswa";
        }

    }
}
