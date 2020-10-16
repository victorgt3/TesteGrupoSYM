using GrupoSYM.Repository.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoSYM.Repository.Entities
{
    public class Candidatos : IEntityCommonProperty
    {
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(25)]
        public string Telefone { get; set; }

        [StringLength(500)]
        public string UrlLinkedin { get; set; }

        [StringLength(150)]
        public string UsuarioGithub { get; set; }
    }
}
