using System;
using System.Collections.Generic;

namespace ShinobiServer.Models;

public partial class Territorio
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Historia { get; set; }

    public string? ClimaTerreno { get; set; }

    public virtual ICollection<Cla> Clas { get; } = new List<Cla>();

    public virtual ICollection<Conto> Contos { get; } = new List<Conto>();

    public virtual ICollection<Imagem> Imagems { get; } = new List<Imagem>();

    public virtual ICollection<Monstro> Monstros { get; } = new List<Monstro>();

    public virtual ICollection<Personagem> Personagems { get; } = new List<Personagem>();
}
