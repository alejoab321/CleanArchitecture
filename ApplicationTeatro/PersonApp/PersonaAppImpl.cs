using Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTeatro.PersonApp
{
    public class PersonaAppImpl : IPersonaApp
    {
        public Task<List<Espectador>> GetEspectadors()
        {
            throw new NotImplementedException();
        }
    }
}
