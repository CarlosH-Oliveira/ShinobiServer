using System;
using System.Collections.Generic;

namespace ShinobiServer.Models;

public partial class Conto
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Conteudo { get; set; }

    public DateTime? DataPostagem { get; set; }

    public int? IdTerritorio { get; set; }

    public int? IdHabilidade { get; set; }

    public int? IdPersonagem { get; set; }

    public virtual Habilidade? IdHabilidadeNavigation { get; set; }

    public virtual Personagem? IdPersonagemNavigation { get; set; }

    public virtual Territorio? IdTerritorioNavigation { get; set; }
}
