using System;
using System.Threading.Tasks;
using GrupoSYM.Domain.Command.CandidatosCommand;
using GrupoSYM.Domain.DependencyInjection.Configuration.ErroHandler;
using GrupoSYM.Domain.Dto;
using GrupoSYM.Repository.Entities;
using GrupoSYM.Repository.Repositories.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrupoSYM.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly IGenericRepository<Candidatos> _repositoryCandidatos;
        private readonly IMediator _mediator;
        public CandidatosController(IGenericRepository<Candidatos> repositoryCandidatos,
            IMediator mediator)
        {
            _repositoryCandidatos = repositoryCandidatos;
            _mediator = mediator;
        }

        [HttpGet]
        public virtual async Task<ActionResult<CandidatosDto>> Get()
        {

            return Ok(await _repositoryCandidatos.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidatosDto>> GetById(Guid id)
        {
            var candidatos = await _repositoryCandidatos.GetByIdAsync(id);
            if (candidatos == null)
            {
                return NotFound(new ErroHandlerResponse(404, "Candidato not found"));
            }
            return Ok(candidatos);
        }

        [HttpPost]
        public virtual async Task<ActionResult<CandidatosDto>> Post(CandidatosAddCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public virtual async Task<ActionResult<CandidatosDto>> Put(CandidatosPutCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var candidatos = await _repositoryCandidatos.GetByIdAsync(id);

            if (candidatos == null)
            {
                return NotFound(new ErroHandlerResponse(404, "Candidato not found"));
            }

            return Ok(await _repositoryCandidatos.DeleteAsync(candidatos));
        }
    }
}
