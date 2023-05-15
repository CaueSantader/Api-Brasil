using ApiBrasil.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiBrasil.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnderecoController : ControllerBase
    {
        public readonly IEnderecoService enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            this.enderecoService = enderecoService;
        }
        [HttpGet("buscar/{cep}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> BuscarEndereco([FromRoute] string cep) 
        {
            var response = await enderecoService.BuscarEndereco(cep);

            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else 
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        } 
    }
}
