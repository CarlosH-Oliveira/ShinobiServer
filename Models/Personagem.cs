using System;
using System.Collections.Generic;

namespace ShinobiServer.Models;

public partial class Personagem
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public long? Idade { get; set; }

    public string? Patente { get; set; }

    public string? Historia { get; set; }

    public string? Dinheiro { get; set; }

    public int? IdCla { get; set; }

    public int? IdTerritorio { get; set; }

    public int? IdMonstro { get; set; }

    public virtual ICollection<Conto> Contos { get; } = new List<Conto>();

    public virtual Cla? IdClaNavigation { get; set; }

    public virtual Monstro? IdMonstroNavigation { get; set; }

    public virtual Territorio? IdTerritorioNavigation { get; set; }

    public virtual ICollection<Imagem> Imagems { get; } = new List<Imagem>();

    public virtual ICollection<Monstro> Monstros { get; } = new List<Monstro>();
}
