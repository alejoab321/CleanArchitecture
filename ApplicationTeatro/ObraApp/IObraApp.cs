using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTeatro.ObraApp
{
    public interface IObraApp
    {
        Task<List<Obra>> GetObrasByIdTeatro(int idTeatro);
    }
}
