using Microsoft.AspNetCore.Mvc;
using Api.DTOs;
using Api.Models;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEngineerRepository _engineerRepository;

        public TicketsController(ITicketRepository context, IEngineerRepository engineerRepository)
        {
            _ticketRepository = context;
            _engineerRepository = engineerRepository;
        }

        // GET: api/Tickets
        /// <summary>
        /// Get all tickets ordered by name
        /// </summary>
        /// <returns>array of tickets</returns>
        [HttpGet]
        public IEnumerable<Ticket> GetTickets(string title = null)
        {
            if (string.IsNullOrEmpty(title))
                return _ticketRepository.GetAll();
            return _ticketRepository.GetBy(title);
        }

        // GET: api/Tickets/5
        /// <summary>
        /// Get the ticket with given id
        /// </summary>
        /// <param name="id">the id of the ticket</param>
        /// <returns>The ticket</returns>
        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicket(int id)
        {
            Ticket ticket = _ticketRepository.GetBy(id);
            if (ticket == null) return NotFound();
            return ticket;
        }

        // POST: api/Tickets
        /// <summary>
        /// Adds a new ticket
        /// </summary>
        /// <param name="ticket">the new ticket</param>
        [HttpPost]
        public ActionResult<Ticket> PostTicket(TicketDTO ticket)
        {
            Ticket ticketToCreate = new Ticket() { Title = ticket.Title, Description = ticket.Description };
            foreach (var e in ticket.Engineer)
                ticketToCreate.Engineer = new Engineer(e.FirstName, e.LastName, e.Email);
            _ticketRepository.Add(ticketToCreate);
            _ticketRepository.SaveChanges();

            return CreatedAtAction(nameof(GetTicket), new { id = ticketToCreate.Id }, ticketToCreate);
        }

        // PUT: api/Tickets/5
        /// <summary>
        /// Modifies a ticket
        /// </summary>
        /// <param name="id">id of the ticket to be modified</param>
        /// <param name="ticket">the modified ticket</param>
        [HttpPut("{id}")]
        public IActionResult PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }
            _ticketRepository.Update(ticket);
            _ticketRepository.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Tickets/5
        /// <summary>
        /// Deletes a ticket
        /// </summary>
        /// <param name="id">the id of the ticket to be deleted</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            Ticket ticket = _ticketRepository.GetBy(id);
            if (ticket == null)
            {
                return NotFound();
            }
            _ticketRepository.Delete(ticket);
            _ticketRepository.SaveChanges();
            return NoContent();
        }
    }
}
