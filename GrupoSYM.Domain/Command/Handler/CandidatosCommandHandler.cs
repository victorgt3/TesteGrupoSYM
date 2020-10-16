using GrupoSYM.Domain.Command.CandidatosCommand;
using GrupoSYM.Domain.DependencyInjection.Configuration.ErroHandler;
using GrupoSYM.Domain.Dto;
using GrupoSYM.Repository.Entities;
using GrupoSYM.Repository.Repositories.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace GrupoSYM.Domain.Command.Handler
{
    public class CandidatosCommandHandler : ControllerBase,
        IRequestHandler<CandidatosAddCommand, ActionResult<CandidatosDto>>,
        IRequestHandler<CandidatosPutCommand, ActionResult<CandidatosDto>>
    {
        private readonly IGenericRepository<Candidatos> _repositoryCandidatos;
        public CandidatosCommandHandler(IGenericRepository<Candidatos> repositoryCandidatos)
        {
            _repositoryCandidatos = repositoryCandidatos;
        }
        public async Task<ActionResult<CandidatosDto>> Handle(CandidatosAddCommand request, CancellationToken cancellationToken)
        {
            var candidatoExists = await _repositoryCandidatos.GetAsync(e => e.Nome == request.Nome);

            if (candidatoExists != null)
                return StatusCode(409, new ErroHandlerResponse(409, "Nome já existe na base de dados."));

            var candidatos = await _repositoryCandidatos.AddAsync(request);

            return Created("", candidatos);
        }

        public async Task<ActionResult<CandidatosDto>> Handle(CandidatosPutCommand request, CancellationToken cancellationToken)
        {
            var candidatos = await _repositoryCandidatos.UpdateAsync(request);

            return Created("", candidatos);
        }
    }
}
