using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureTeatro.Interface.TeatroInfra
{
    public interface ITeatroRepository
    {
        public Task<List<Teatro>> GetAllTeatro();
    }
}
