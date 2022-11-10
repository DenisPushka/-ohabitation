using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("api")]
    class ApiControllerCohabitation : ControllerBase
    {
        private readonly ICohabitationRepository _cohabitationRepository;

        public ApiControllerCohabitation(ICohabitationRepository cohabitationRepository) => _cohabitationRepository = cohabitationRepository;

        [HttpGet("Add")]
        public IActionResult AddPerson([FromBody] Cohabitation coh) => Ok(_cohabitationRepository.AddCohabitation(coh));
    }
}
