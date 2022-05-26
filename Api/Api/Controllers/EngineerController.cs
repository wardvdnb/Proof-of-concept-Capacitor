using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.DTOs;
using Api.Models;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EngineerController : ControllerBase
    {
        private readonly IEngineerRepository _engineerRepository;

        public EngineerController(IEngineerRepository engineerRepository)
        {
            _engineerRepository = engineerRepository;
        }

        /// <summary>
        /// Get the details of the authenticated engineer
        /// </summary>
        /// <returns>the engineer</returns>
        //[HttpGet()]
        //public ActionResult<EngineerDTO> GetEngineer()
        //{
        //    Engineer engineer = _engineerRepository.GetBy(User.Identity.Name);
        //    return new EngineerDTO(engineer);
        //}

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Engineer> GetEngineers()
        {
            return _engineerRepository.GetAll();
        }
    }
} 
