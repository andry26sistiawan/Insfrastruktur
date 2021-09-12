using AutoMapper;
using Infra.BusinessLogic.Fakultas.DTO;
using Infra.DataAccess.Repository;
using Infra.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.BusinessLogic.Fakultas
{
    public class FakultasService
    {
        private readonly FakultasRepository fakultasRepository;
        private readonly IMapper _mapper;

        public FakultasService()
        {
            fakultasRepository ??= new FakultasRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FakultasPostDTO, DataAccess.Model.Fakultas>();
            });
            _mapper = config.CreateMapper();
        }

        public async Task<DataAccess.Model.Fakultas> CreateFakultas(FakultasPostDTO fakultasPostDTO)
        {
            var data = _mapper.Map<DataAccess.Model.Fakultas>(fakultasPostDTO);
            var res = await fakultasRepository.CreateFakultas(data);

            return res;
        }

        public async Task<DataAccess.Model.Fakultas> GetFakultasById(string id)
        {
            var res = await fakultasRepository.GetByID(id);
            return res;
        }

        public async Task<List<DataAccess.Model.Fakultas>> GetFakultas()
        {
            var res = await fakultasRepository.GetFakultas();
            return res;
        }
    }
}
