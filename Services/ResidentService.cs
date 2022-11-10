using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using Entities;

namespace Services
{
    public class ResidentService : SOSUService<Resident>, IResidentService<Resident>
    {
        public async Task<List<Resident>> GetAllResidentsAsync()
        {
            return await DoHttpGetRequest("Resident/GetResidents");
        }
    }
}