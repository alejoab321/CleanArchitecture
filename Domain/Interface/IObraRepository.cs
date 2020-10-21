using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureTeatro.Interface.ObraInfra
{
    public interface IObraRepository
    {
        Task<List<Obra>> GetObrasByIdTeatro(int idTeatro);
    }
}
