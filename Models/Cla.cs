using System;
using System.Collections.Generic;

namespace ShinobiServer.Models;

public partial class Cla
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Historia { get; set; }

    public int? IdTerritorio { get; set; }

    public int? IdImagem { get; set; }

    public virtual Imagem? IdImagemNavigation { get; set; }

    public virtual Territorio? IdTerritorioNavigation { get; set; }

    public virtual ICollection<Imagem> Imagems { get; } = new List<Imagem>();

    public virtual ICollection<Personagem> Personagems { get; } = new List<Personagem>();
}
