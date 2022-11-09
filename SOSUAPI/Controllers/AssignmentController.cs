global using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Entities;

namespace Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;

        public AssignmentController(SOSUPowerContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        [Route("GetAssignments")]
        public async Task<ActionResult<List<Assignment>>> Get()
        {
            try
            {
                var returning = await unitOfWork.AssignmentRepository.GetAllAsync();
                return Ok(returning);
            }
            catch
            {
                string returning = "Der skete en fejl, opgaverne kunne ikke hentes, prøv igen";
                return BadRequest(returning);
            }
        }

        [HttpPost]
        [Route("CreateAssignment")]
        public async Task<ActionResult<Assignment>> SaveNewAssignment(int assignmentId, string notes, DateTime startDate, DateTime expectedEndDate, DateTime actualEndDate, bool solved, int solvedBy, int resident)
        {
            Assignment a = new()
            {
                Id = assignmentId,
                Notes = notes,
                StartDate = startDate,
                ExpectedEndDate = expectedEndDate,
                ActualEndDate = actualEndDate,
                Solved = solved,
                SolvedBy = solvedBy,
                ResidentId = resident
            };
            try
            {
                unitOfWork.AssignmentRepository.Insert(a);
                await unitOfWork.SaveAsync();
                string returning = "Opgaven blev gemt";
                return Ok(returning);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateAssignment")]
        public async Task<ActionResult<Assignment>> UpdateAssignment(Assignment request)
        {
            List<Assignment> assignments = (List<Assignment>)await unitOfWork.AssignmentRepository.GetAllAsync();
            var assignment = assignments.Find(s => s.Id == request.Id);
            if (assignment == null)
            {
                string returning = "Opgave ikke fundet";
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
                    string returning = "Opgaven blev opdateret";
                    return Ok(returning);
                }
                catch
                {
                    string returning = "Der skete en fejl, prøv igen";
                    return BadRequest(returning);
                }
            }
        }
    }
}