using ShinobiServer.Mapper;
using Microsoft.AspNetCore.Mvc;
using ShinobiServer.Data;
using ShinobiServer.Models.DTOs.ContoDTO;
using ShinobiServer.Models;
using ShinobiServer.Models.DTOs.BindDTO;

namespace ShinobiServer.Controllers
{
    public class ContosController : Controller
    {
        
        private ShinobiflawlessiiContext shinobiflawlessiiContext;
        private ContoMapper contoMapper;
        public ContosController(ShinobiflawlessiiContext shinobiflawlessiiContext, ContoMapper contoMapper)
        {
            this.shinobiflawlessiiContext = shinobiflawlessiiContext;
            this.contoMapper = contoMapper;
        }

        /// <summary>
        /// Cria um novo conto na base de dados.
        /// </summary>
        /// <param name="createConto"> Corpo de criação para um novo registro </param>
        /// <returns></returns>
        [HttpPost("/conto/create")]
        public async Task<IActionResult> CreateConto([FromBody]createConto createConto)
        {
            try
            {
                Conto? conto = contoMapper.Map(createConto);

                if (conto == null)
                {
                    return BadRequest("400 - Um dos campos não foi preenchido corretamente. Registro não pôde ser salvo");
                }

                await shinobiflawlessiiContext.Contos.AddAsync(conto);
                shinobiflawlessiiContext.SaveChanges();
                return Created("201 - Conto criado com sucesso", conto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            

        }

        /// <summary>
        /// Retorna todos os registros de contos que estão salvos na base de dados.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/conto/")]
        public async Task<IActionResult> GetAllContos()
        {
            try
            {
                return Ok(shinobiflawlessiiContext.Contos.ToList());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        /// <summary>
        /// Retorna um conto específico baseado no identificador informado.
        /// </summary>
        /// <param name="id"> Identificador do objeto </param>
        /// <returns></returns>
        [HttpGet("/conto/{id}")]
        public async Task<IActionResult> GetContoById(int id)
        {
            try
            {
                var conto = await shinobiflawlessiiContext.Contos.FindAsync(id);

                if (conto == null)
                {
                    return NotFound("404 - Conto não encontrado");
                }

                return Ok(conto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        /// <summary>
        /// Altera um registro específico baseado no identificador informado.
        /// </summary>
        /// <param name="editConto"> Corpo de edição </param>
        /// <param name="id"> Identificador do objeto </param>
        /// <returns></returns>
        [HttpPut("/conto/{id}")]
        public async Task<IActionResult> UpdateContoById(int id, [FromBody] editConto editConto)
        {
            try
            {
                var conto = await shinobiflawlessiiContext.Contos.FindAsync(id);
                if (conto == null)
                {
                    return NotFound("404 - Conto não encontrado");
                }
                conto = contoMapper.Map(editConto, conto);
                if (conto == null)
                {
                    return BadRequest("400 - formulário de edição está vazio");
                }

                shinobiflawlessiiContext.Update(conto);
                shinobiflawlessiiContext.SaveChanges();

                return Ok("200 - Conto editado com sucesso\n" + conto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        /// <summary>
        /// Associa outros registros ao conto baseado nos identificadores informados no corpo da requisição.
        /// </summary>
        /// <param name="id"> Identificador do conto </param>
        /// <param name="bindConto"> Corpo de requisição com os identificadores necessários </param>
        /// <returns></returns>
        [HttpPut("/conto/bind/{id}")]
        public async Task<IActionResult> AssociarRegistros(int id, [FromBody] bindConto bindConto)
        {
            try
            {
                var conto = await shinobiflawlessiiContext.Contos.FindAsync(id);

                if (conto == null)
                {
                    return NotFound("404 - Conto não encontrado");
                }

                conto = contoMapper.Map(bindConto, conto);

                if (conto == null)
                {
                    return BadRequest("400 - formulário de edição está vazio");
                }

                shinobiflawlessiiContext.Update(conto);
                shinobiflawlessiiContext.SaveChanges();

                return Ok("200 - Associações realizadas com sucesso com sucesso\n" + conto);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        /// <summary>
        /// Deleta um registro específico baseado no identificador informado.
        /// </summary>
        /// <param name="id"> Identificador do objeto </param>
        /// <returns></returns>
        [HttpDelete("/conto/{id}")]
        public async Task<IActionResult> DeleteContoById(int id)
        {
            try
            {
                var conto = await shinobiflawlessiiContext.Contos.FindAsync(id);

                if (conto == null)
                {
                    return NotFound("404 - Conto não encontrado");
                }

                shinobiflawlessiiContext.Contos.Remove(conto);
                shinobiflawlessiiContext.SaveChanges();
                return Ok("200 - Conto deletado com sucesso\n" + conto);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

    }
}

