using AutoMapper;
using Infra.BusinessLogic.MahasiswaManagement.DTO;
using Infra.DataAccess.Model;
using Infra.DataAccess.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.BusinessLogic.MahasiswaManagement
{
    public class MahasiswaService
    {

        private readonly IMapper _mapper;
        private readonly MahasiswaRepository mahasiswaRepository;
        private readonly FakultasRepository fakultasRepository;

        public MahasiswaService()
        {
            mahasiswaRepository ??= new MahasiswaRepository();
            fakultasRepository ??= new FakultasRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MahasiswaPostDTO, Mahasiswa>();
                cfg.CreateMap<MahasiswaRespDTO, Mahasiswa>();
                cfg.CreateMap<TestDTO, Mahasiswa>()
                .ForMember(dst => dst.NIP, opt => opt.MapFrom(src => src.NIP1))
                .ForMember(dst => dst.Alamat, opt => opt.MapFrom(src => src.Alamat1));
            });
            _mapper = config.CreateMapper();

        }
        public async Task<string> TestMahasiswa()
        {
            return "Mahasiswa";
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
        public async Task<Mahasiswa> GetMahasiswaByNIP(string nip)
        {
            var res = await mahasiswaRepository.GetByNIP(nip);
            return res;
        }

        public async Task<List<Mahasiswa>> CreateListMahasiswa(List<MahasiswaPostDTO> data)
        {
            List<Mahasiswa> listOfMahasiswa = _mapper.Map<List<Mahasiswa>>(data);
            var res = await mahasiswaRepository.CreateListMahasiswa(listOfMahasiswa);
            return res;
        }
        
        public async Task<List<MahasiswaRespDTO>> GetMahasiswa()
        {
            var listMahasiswa = await mahasiswaRepository.GetMahasiswas();
            var listFakultas = await fakultasRepository.GetFakultas();
            var id = listFakultas.Select(x => x.FakultasId);

            var res = new List<MahasiswaRespDTO>();

            //foreach(var mhs in listMahasiswa.ToList())
            //{
            //    MahasiswaRespDTO mappedJurusan = _mapper.Map<MahasiswaRespDTO>(mhs);
            //    mappedJurusan.JurusanNama = listFakultas.Where(x => x.FakultasId == mappedJurusan.FakultasId).Select(a => a.Nama).FirstOrDefault();
            //    res.Add(mappedJurusan);
            //}

            var q =
               from c in listMahasiswa
               join p in listFakultas on c.FakultasId equals p.FakultasId into ps
               from p in ps.DefaultIfEmpty()
               select new MahasiswaRespDTO
               {
                   NIP = c.NIP,
                   Fullname = c.Fullname,
                   Alamat = c.Alamat,
                   Hobby = c.Hobby,
                   JurusanNama = p?.Nama,
                   FakultasId = p.FakultasId

               };

            return q.ToList();
        }

    }
}
