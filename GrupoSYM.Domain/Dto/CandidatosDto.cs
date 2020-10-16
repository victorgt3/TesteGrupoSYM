using GrupoSYM.Repository.Entities;
using System;

namespace GrupoSYM.Domain.Dto
{
    public class CandidatosDto
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string UrlLinkedin { get; set; }
        public string UsuarioGithub { get; set; }

        public static implicit operator CandidatosDto(Candidatos candidatos)
        {
            return new Candidatos
            {
                Id = candidatos.Id,
                Nome = candidatos.Nome,
                Telefone = candidatos.Telefone,
                UrlLinkedin = candidatos.UrlLinkedin,
                UsuarioGithub = candidatos.UsuarioGithub
            };
        }
    }
}
