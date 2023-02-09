using System;
using System.Collections.Generic;

namespace ShinobiServer.Models;

public partial class Habilidade
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public string? Tipo { get; set; }

    public int? IdImagem { get; set; }

    public virtual ICollection<Conto> Contos { get; } = new List<Conto>();

    public virtual Imagem? IdImagemNavigation { get; set; }

    public virtual ICollection<Imagem> Imagems { get; } = new List<Imagem>();
}
