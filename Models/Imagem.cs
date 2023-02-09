using System;
using System.Collections.Generic;

namespace ShinobiServer.Models;

public partial class Imagem
{
    public int Id { get; set; }

    public string? Link { get; set; }

    public string? Descricao { get; set; }

    public int? IdTerritorio { get; set; }

    public int? IdHabilidade { get; set; }

    public int? IdPersonagem { get; set; }

    public int? IdCla { get; set; }

    public int? IdMonstro { get; set; }

    public virtual ICollection<Cla> Clas { get; } = new List<Cla>();

    public virtual ICollection<Habilidade> Habilidades { get; } = new List<Habilidade>();

    public virtual Cla? IdClaNavigation { get; set; }

    public virtual Habilidade? IdHabilidadeNavigation { get; set; }

    public virtual Monstro? IdMonstroNavigation { get; set; }

    public virtual Personagem? IdPersonagemNavigation { get; set; }

    public virtual Territorio? IdTerritorioNavigation { get; set; }
}
