using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTeatro.TeatroApp
{
    public interface ITeatroApp
    {
        public Task<List<Teatro>> GetAllTeatro();
    }
}
