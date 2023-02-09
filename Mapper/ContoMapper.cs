
using ShinobiServer.Models;
using ShinobiServer.Models.DTOs.BindDTO;
using ShinobiServer.Models.DTOs.ContoDTO;

namespace ShinobiServer.Mapper
{
    public class ContoMapper
    {
        public Conto? Map(editConto source, Conto dest)
        {
            if (source == null || dest == null)
            {
                return null;
            }

            if (source.Titulo == null && source.Titulo == null)
            {
                return null;
            }

            if(source.Titulo != null)
            {
                dest.Titulo = source.Titulo;
            }

            if (source.Conteudo != null)
            {
                dest.Conteudo = source.Conteudo;
            }

            return dest;
        }

        public Conto? Map(createConto source)
        {
            Conto dest = new Conto();

            if (source.Titulo == null || source.Conteudo == null || source.DataPostagem == null)
            {
                return null;
            }

            dest.Titulo = source.Titulo;
            dest.Conteudo = source.Conteudo;
            dest.DataPostagem = source.DataPostagem;

            return dest;
        }

        public Conto? Map(bindConto source, Conto dest)
        {
            if(source == null)
            {
                return null;
            }
            
            if(source.IdHabilidade != null)
            {
                dest.IdHabilidade = source.IdHabilidade;
            }

            if (source.IdTerritorio != null)
            {
                dest.IdTerritorio = source.IdTerritorio;
            }

            if (source.IdPersonagem != null)
            {
                dest.IdPersonagem = source.IdPersonagem;
            }

            return dest;
        }

    }

}
