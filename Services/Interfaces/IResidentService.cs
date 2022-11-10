using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Interfaces
{
    public interface IResidentService<TEntity> : ISOSUService<TEntity> where TEntity : class
    {
        Task<List<Resident>> GetAllResidentsAsync();
    }
}