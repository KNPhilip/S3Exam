global using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Entities;

namespace Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;

        public ResidentController(SOSUPowerContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        [Route("GetResidents")]
        public async Task<ActionResult<List<Resident>>> Get()
        {
            try
            {
                var returning = await unitOfWork.ResidentRepository.GetAllAsync();
                return Ok(returning);
            }
            catch
            {
                string returning = "Der skete en fejl, beboeren kunne ikke hentes, prøv igen";
                return BadRequest(returning);
            }
        }
    }
}