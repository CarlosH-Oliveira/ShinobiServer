using System;
using System.Collections.Generic;

namespace ShinobiServer.Models;

public partial class Monstro
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Historia { get; set; }

    public int? IdTerritorio { get; set; }

    public int? IdPersonagem { get; set; }

    public virtual Personagem? IdPersonagemNavigation { get; set; }

    public virtual Territorio? IdTerritorioNavigation { get; set; }

    public virtual ICollection<Imagem> Imagems { get; } = new List<Imagem>();

    public virtual ICollection<Personagem> Personagems { get; } = new List<Personagem>();
}
