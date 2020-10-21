using Domain.Entities;
using InfrastructureTeatro.Interface.TeatroInfra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTeatro.TeatroApp
{
    public class TeatroAppImpl : ITeatroApp
    {
        private readonly ITeatroRepository _teatroRepository;
        public TeatroAppImpl(ITeatroRepository teatroRepository)
        {
            _teatroRepository = teatroRepository;
        }
        public Task<List<Teatro>> GetAllTeatro()
        {
            return _teatroRepository.GetAllTeatro();
        }
    }
}
