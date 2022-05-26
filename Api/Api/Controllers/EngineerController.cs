using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EngineerController : ControllerBase
    {
        private readonly IEngineerRepository _engineerRepository;

        public EngineerController(IEngineerRepository engineerRepository)
        {
            _engineerRepository = engineerRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Engineer> GetEngineers()
        {
            return _engineerRepository.GetAll();
        }
    }
} 
