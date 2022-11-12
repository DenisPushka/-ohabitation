using System.Threading.Tasks;
using DataAccess.Models.Interface;
using DataAccess.Models.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("coha")]
    public class ApiControllerCohabitation : ControllerBase
    {
        private readonly ICohabitationRepository _cohabitationRepository;

        public ApiControllerCohabitation(ICohabitationRepository cohabitationRepository) => _cohabitationRepository = cohabitationRepository;

        [HttpPost("add")]
        public async Task<IActionResult> AddPerson([FromBody] Cohabitation coh) => Ok(await _cohabitationRepository.AddCohabitation(coh));

        [HttpPost("authorization")]
        public async Task<IActionResult> Authorization([FromBody] CohabitationDTO cohabitationDTO) => Ok();
        
        [HttpGet]
        public async Task<IActionResult> GetPersons() => Ok(await _cohabitationRepository.GetArrayCohabitations());
    }
}
