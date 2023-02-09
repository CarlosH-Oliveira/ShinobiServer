using Microsoft.AspNetCore.Mvc;
using ShinobiServer.Data;
using ShinobiServer.Mapper;
using ShinobiServer.Models;
using ShinobiServer.Models.DTOs.BindDTO;
using ShinobiServer.Models.DTOs.ClaDTO;

namespace ShinobiServer.Controllers
{
    public class ClasController : Controller
    {

            private ShinobiflawlessiiContext shinobiflawlessiiContext;
            private ClaMapper claMapper;
            public ClasController(ShinobiflawlessiiContext shinobiflawlessiiContext, ClaMapper claMapper)
            {
                this.shinobiflawlessiiContext = shinobiflawlessiiContext;
                this.claMapper = claMapper;
            }

            /// <summary>
            /// Cria um novo clã na base de dados.
            /// </summary>
            /// <param name="createCla"> Corpo de criação para um novo registro </param>
            /// <returns></returns>
            [HttpPost("/cla/create")]
            public async Task<IActionResult> CreateCla([FromBody] createCla createCla)
            {
                try
                {
                    Cla? cla = claMapper.Map(createCla);

                    if (cla == null)
                    {
                        return BadRequest("400 - Um dos campos não foi preenchido corretamente. Registro não pôde ser salvo");
                    }

                    await shinobiflawlessiiContext.Clas.AddAsync(cla);
                    shinobiflawlessiiContext.SaveChanges();
                    return Created("201 - Clã criado com sucesso", cla);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }


            }

            /// <summary>
            /// Retorna todos os registros de clãs que estão salvos na base de dados.
            /// </summary>
            /// <returns></returns>
            [HttpGet("/cla/")]
            public async Task<IActionResult> GetAllClas()
            {
                try
                {
                    return Ok(shinobiflawlessiiContext.Clas.ToList());
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

            }

            /// <summary>
            /// Retorna um clã específico baseado no identificador informado.
            /// </summary>
            /// <param name="id"> Identificador do objeto </param>
            /// <returns></returns>
            [HttpGet("/cla/{id}")]
            public async Task<IActionResult> GetClaById(int id)
            {
                try
                {
                    var cla = await shinobiflawlessiiContext.Clas.FindAsync(id);

                    if (cla == null)
                    {
                        return NotFound("404 - Clã não encontrado");
                    }

                    return Ok(cla);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

            }

            /// <summary>
            /// Altera um registro específico baseado no identificador informado.
            /// </summary>
            /// <param name="editCla"> Corpo de edição </param>
            /// <param name="id"> Identificador do objeto </param>
            /// <returns></returns>
            [HttpPut("/cla/{id}")]
            public async Task<IActionResult> UpdateClaById(int id, [FromBody] editCla editCla)
            {
                try
                {
                    var cla = await shinobiflawlessiiContext.Clas.FindAsync(id);
                    if (cla == null)
                    {
                        return NotFound("404 - Clã não encontrado");
                    }
                    cla = claMapper.Map(editCla, cla);
                    if (cla == null)
                    {
                        return BadRequest("400 - formulário de edição está vazio");
                    }

                    shinobiflawlessiiContext.Update(cla);
                    shinobiflawlessiiContext.SaveChanges();

                    return Ok("200 - Clã editado com sucesso\n" + cla);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

            }

            /// <summary>
            /// Associa outros registros ao clã baseado nos identificadores informados no corpo da requisição.
            /// </summary>
            /// <param name="id"> Identificador do conto </param>
            /// <param name="bindCla"> Corpo de requisição com os identificadores necessários </param>
            /// <returns></returns>
            [HttpPut("/cla/bind/{id}")]
            public async Task<IActionResult> AssociarRegistros(int id, [FromBody] bindCla bindCla)
            {
                try
                {
                    var cla = await shinobiflawlessiiContext.Clas.FindAsync(id);

                    if (cla == null)
                    {
                        return NotFound("404 - Clã não encontrado");
                    }

                    cla = claMapper.Map(bindCla, cla);

                    if (cla == null)
                    {
                        return BadRequest("400 - formulário de edição está vazio");
                    }

                    shinobiflawlessiiContext.Update(cla);
                    shinobiflawlessiiContext.SaveChanges();

                    return Ok("200 - Associações realizadas com sucesso com sucesso\n" + cla);

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
            [HttpDelete("/cla/{id}")]
            public async Task<IActionResult> DeleteClaById(int id)
            {
                try
                {
                    var cla = await shinobiflawlessiiContext.Clas.FindAsync(id);

                    if (cla == null)
                    {
                        return NotFound("404 - Clã não encontrado");
                    }

                    shinobiflawlessiiContext.Clas.Remove(cla);
                    shinobiflawlessiiContext.SaveChanges();
                    return Ok("200 - Clã deletado com sucesso\n" + cla);

                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

            }

        }
    }
