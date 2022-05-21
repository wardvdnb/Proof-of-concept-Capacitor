using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.DTOs;
using Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [AllowAnonymous]
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

        /// <summary>
        /// Get favorite tickets of current user
        /// </summary>
        [HttpGet("Favorites")]
        public IEnumerable<Ticket> GetTickets()
        {
            Engineer engineer = _engineerRepository.GetBy(User.Identity.Name);
            return engineer.Tickets;
        }

        // POST: api/Tickets
        /// <summary>
        /// Adds a new ticket
        /// </summary>
        /// <param name="ticket">the new ticket</param>
        [HttpPost]
        public ActionResult<Ticket> PostTicket(TicketDTO ticket)
        {
            Ticket ticketToCreate = new Ticket() { Title = ticket.Title };
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

        ///// <summary>
        ///// Get an ingredient for a ticket
        ///// </summary>
        ///// <param name="id">id of the ticket</param>
        ///// <param name="ingredientId">id of the ingredient</param>
        //[HttpGet("{id}/ingredients/{ingredientId}")]
        //public ActionResult<Ingredient> GetIngredient(int id, int ingredientId)
        //{
        //    if (!_ticketRepository.TryGetTicket(id, out var ticket))
        //    {
        //        return NotFound();
        //    }
        //    Ingredient ingredient = ticket.GetIngredient(ingredientId);
        //    if (ingredient == null)
        //        return NotFound();
        //    return ingredient;
        //}

        ///// <summary>
        ///// Adds an ingredient to a ticket
        ///// </summary>
        ///// <param name="id">the id of the ticket</param>
        ///// <param name="ingredient">the ingredient to be added</param>
        //[HttpPost("{id}/ingredients")]
        //public ActionResult<Ingredient> PostIngredient(int id, IngredientDTO ingredient)
        //{
        //    if (!_ticketRepository.TryGetTicket(id, out var ticket))
        //    {
        //        return NotFound();
        //    }
        //    var ingredientToCreate = new Ingredient(ingredient.Name, ingredient.Amount, ingredient.Unit);
        //    ticket.AddIngredient(ingredientToCreate);
        //    _ticketRepository.SaveChanges();
        //    return CreatedAtAction("GetIngredient", new { id = ticket.Id, ingredientId = ingredientToCreate.Id }, ingredientToCreate);
        //}
    }
}
