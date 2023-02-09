using ShinobiServer.Models;
using ShinobiServer.Models.DTOs.BindDTO;
using ShinobiServer.Models.DTOs.ClaDTO;

namespace ShinobiServer.Mapper
{
    public class ClaMapper
    {
        public Cla? Map(editCla source, Cla dest)
        {
            if (source == null || dest == null)
            {
                return null;
            }

            if (source.Nome == null && source.Historia == null)
            {
                return null;
            }

            if (source.Nome != null)
            {
                dest.Nome = source.Nome;
            }

            if (source.Historia != null)
            {
                dest.Historia = source.Historia;
            }

            return dest;
        }

        public Cla? Map(createCla source)
        {
            Cla dest = new Cla();

            if (source.Nome == null || source.Historia == null)
            {
                return null;
            }

            dest.Nome = source.Nome;
            dest.Historia = source.Historia;

            return dest;
        }

        public Cla? Map(bindCla source, Cla dest)
        {
            if (source == null)
            {
                return null;
            }

            if (source.IdImagem != null)
            {
                dest.IdImagem = source.IdImagem;
            }

            if (source.IdTerritorio != null)
            {
                dest.IdTerritorio = source.IdTerritorio;
            }

            return dest;
        }
    }
}
