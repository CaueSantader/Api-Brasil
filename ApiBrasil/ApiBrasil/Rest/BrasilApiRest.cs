using ApiBrasil.Dtos;
using ApiBrasil.Interfaces;
using ApiBrasil.Models;
using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace ApiBrasil.Rest
{
    public class BrasilApiRest : IBrasilApi
    {

        public async Task<ResponseGenerico<EnderecoModel>> BuscarEnderecoPorCEP(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            var respose = new ResponseGenerico<EnderecoModel>();

            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<EnderecoModel>(contentResp);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    respose.CodigoHttp = responseBrasilApi.StatusCode;
                    respose.DadosRetorno = objResponse;
                }
                else 
                {
                    respose.CodigoHttp = responseBrasilApi.StatusCode;
                    respose.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp );
                }
                
            }

            return respose;

        } 
        public async Task<ResponseGenerico<List<BancoModel>>> BuscarTodosBancos()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://brasilapi.com.br/api/banks/v1");

            var respose = new ResponseGenerico<List<BancoModel>>();

            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<List<BancoModel>>(contentResp);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    respose.CodigoHttp = responseBrasilApi.StatusCode;
                    respose.DadosRetorno = objResponse;
                }
                else
                {
                    respose.CodigoHttp = responseBrasilApi.StatusCode;
                    respose.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }

            }

            return respose;
        }
        public async  Task<ResponseGenerico<BancoModel>> BuscarBanco(string codigoBanco)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1/{codigoBanco}");

            var respose = new ResponseGenerico<BancoModel>();

            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<BancoModel>(contentResp);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    respose.CodigoHttp = responseBrasilApi.StatusCode;
                    respose.DadosRetorno = objResponse;
                }
                else
                {
                    respose.CodigoHttp = responseBrasilApi.StatusCode;
                    respose.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }

            }

            return respose;
        }


    }
}
