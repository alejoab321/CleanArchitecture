using Domain.Entities.Person;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTeatro.PersonApp
{
    public class PersonaAppImpl : IPersonaApp
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonaAppImpl(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
                
        public async Task<List<Espectador>> GetEspectadors()
        {
            return await _personaRepository.GetEspectadors();
        }
    }
}
