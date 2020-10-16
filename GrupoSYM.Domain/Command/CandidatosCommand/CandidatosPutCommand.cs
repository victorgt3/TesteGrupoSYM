using GrupoSYM.Domain.Dto;
using GrupoSYM.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GrupoSYM.Domain.Command.CandidatosCommand
{
    public class CandidatosPutCommand : IRequest<ActionResult<CandidatosDto>>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string UrlLinkedin { get; set; }
        public string UsuarioGithub { get; set; }

        public static implicit operator Candidatos(CandidatosPutCommand candidatos)
        {
            return new Candidatos
            {
                Id = candidatos.Id == Guid.Empty ? Guid.NewGuid() : candidatos.Id,
                Nome = candidatos.Nome,
                Telefone = candidatos.Telefone,
                UrlLinkedin = candidatos.UrlLinkedin,
                UsuarioGithub = candidatos.UsuarioGithub
            };
        }
    }
}
