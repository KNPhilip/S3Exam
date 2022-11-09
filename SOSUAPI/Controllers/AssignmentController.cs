global using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Entities;

namespace Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        #region Fields
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AssignmentController(SOSUPowerContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }
        #endregion

        #region Http Methods
        [HttpPost]
        [Route("Assignment")]
        public async Task<ActionResult<Assignment>> SaveNewCustomer(int assignmentId, string notes, DateTime startDate, DateTime expectedEndDate, DateTime actualEndDate, bool solved, Employee solvedBy, Resident resident)
        {
            Assignment a = new()
            {
                Id = assignmentId,
                Notes = notes,
                StartDate = startDate,
                ExpectedEndDate = expectedEndDate,
                ActualEndDate = actualEndDate,
                Solved = solved,
                SolvedBy = solvedBy.Id,
                ResidentId = resident.Id
            };
            try
            {
                unitOfWork.AssignmentRepository.Insert(a);
                await unitOfWork.SaveAsync();
                string returning = "Kunden blev gemt";
                return Ok(returning);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("Assignment")]
        public async Task<ActionResult<Assignment>> UpdateCustomer(Assignment request)
        {
            List<Assignment> assignments = (List<Assignment>)await unitOfWork.AssignmentRepository.GetAllAsync();
            var assignment = assignments.Find(s => s.Id == request.Id);
            if (assignment == null)
            {
                string returning = "Kunde ikke fundet";
                return BadRequest(returning);
            }
            else
            {
                assignment.Notes = request.Notes;
                assignment.Solved = request.Solved;
                assignment.SolvedBy = request.SolvedBy;
                try
                {
                    unitOfWork.AssignmentRepository.Update(assignment);
                    await unitOfWork.SaveAsync();
                    string returning = "Kunden blev opdateret korrekt";
                    return Ok(returning);
                }
                catch
                {
                    string returning = "Der skete en fejl, prøv igen";
                    return BadRequest(returning);
                }
            }
        }
        #endregion
    }
}