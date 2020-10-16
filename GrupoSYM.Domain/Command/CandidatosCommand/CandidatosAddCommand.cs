using GrupoSYM.Domain.Dto;
using GrupoSYM.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GrupoSYM.Domain.Command.CandidatosCommand
{
    public class CandidatosAddCommand : IRequest<ActionResult<CandidatosDto>>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string UrlLinkedin { get; set; }
        public string UsuarioGithub { get; set; }

        public static implicit operator Candidatos(CandidatosAddCommand candidatos)
        {
            return new Candidatos
            {
                Id = Guid.NewGuid(), 
                Nome = candidatos.Nome,
                Telefone = candidatos.Telefone,
                UrlLinkedin = candidatos.UrlLinkedin,
                UsuarioGithub = candidatos.UsuarioGithub
            };
        }
    }
}
