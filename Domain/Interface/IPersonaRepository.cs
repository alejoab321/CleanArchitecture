using Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IPersonaRepository
    {
        public Task<List<Espectador>> GetEspectadors();
    }
}
