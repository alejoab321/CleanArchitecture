using Domain.Entities;
using InfrastructureTeatro.Interface.ObraInfra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTeatro.ObraApp
{
    public class ObraAppImpl : IObraApp
    {
        private readonly IObraRepository _obraRepository;
        public ObraAppImpl(IObraRepository obraRepository)
        {
            _obraRepository = obraRepository;
        }
        public async Task<List<Obra>> GetObrasByIdTeatro(int idTeatro)
        {
            return await _obraRepository.GetObrasByIdTeatro(idTeatro);
        }
    }
}
