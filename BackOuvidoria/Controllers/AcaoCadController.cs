using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ouvidoria.Models;
using Ouvidoria.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace Ouvidoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcaoCadController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IParametrosSistemaDal _parametrosSistemaDal;

        public AcaoCadController(IConfiguration configuration, IParametrosSistemaDal parametrosRepository)
        {
            _configuration = configuration;
            _parametrosSistemaDal = parametrosRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AcaoCadRequest requestCad)
        {
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent(requestCad.IdCaso), "idCaso");
                form.Add(new StringContent(requestCad.IdUsuario), "idUsuario");
                Task<List<string>> lista = null;
                requestCad.IdAcao = getIdAcaoCad(requestCad.Acao);
                form.Add(new StringContent(requestCad.IdAcao), "idAcao");

                switch (requestCad.Acao)
                {
                    case "OuvidoriaAcaoApiCadContato":
                        lista = buscaCamposDinamicosContato(requestCad);
                        form.Add(new StringContent(JObject.Parse(requestCad.CamposDinamicos)["ObservacaoContato"].ToString()), "observacao");
                        break;

                    case "OuvidoriaAcaoApiCadEncaminhar":
                        lista = buscaCamposDinamicosEncaminhar(requestCad);
                        form.Add(new StringContent(JObject.Parse(requestCad.CamposDinamicos)["RegistroParcial"].ToString()), "observacao");
                        break;

                    case "OuvidoriaAcaoApiCadFinalizar":
                        lista = buscaCamposDinamicosFinalizar(requestCad);
                        form.Add(new StringContent("Registro de finalização via Front-Ouvidoria"), "observacao");
                        break;


                    case "OuvidoriaAcaoApiCadAgendar":
                        return Ok(await acaoAgendar(requestCad));


                    case "OuvidoriaAcaoApiCadAnexar":
                        return Ok(await acaoAnexar(requestCad));

                }

                if (lista != null && (requestCad.Acao != "OuvidoriaAcaoApiCadAgendar" && requestCad.Acao != "OuvidoriaAcaoApiCadAnexar"))
                {
                    foreach (var item in lista.Result)
                        form.Add(new StringContent(item.ToString()), "listaCamposDinamicos");

                    using (var httpClient = new HttpClient())
                    {
                        Uri address = new Uri(string.Concat(_configuration["ApisCad:executaAcao"], requestCad.IdAcao));
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, address);
                        request.Content = form;
                        request.Headers.Add("Cookie", string.Concat("sso_client=", requestCad.sso_client, ";ROUTEID=.1"));
                        HttpResponseMessage response = await httpClient.SendAsync(request);

                        return Ok(response.StatusCode);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private async Task<IJEnumerable<JToken>> consultaApiCad(AcaoCadRequest requestCad)
        {
            using (var httpClient = new HttpClient())
            {
                Uri address = new Uri(string.Concat(_configuration["ApisCad:buscaCampoDinamico"], requestCad.IdAcao, "/case/", requestCad.IdCaso));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, address);
                request.Headers.Add("Cookie", string.Concat("sso_client=", requestCad.sso_client, ";ROUTEID=.1"));
                HttpResponseMessage response = await httpClient.SendAsync(request);
                var contentJson = (JObject)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                if (response.IsSuccessStatusCode)
                    return contentJson["listaCamposDinamicos"].Value<JArray>();

                return contentJson;
            }
        }

        private async Task<List<string>> buscaCamposDinamicosContato(AcaoCadRequest requestCad)
        {
            var json = await consultaApiCad(requestCad);
            var listaDinamica = new List<string>();

            JObject campoDinamicoFront = JObject.Parse(requestCad.CamposDinamicos);

            foreach (JToken item in json)
            {
                JObject lista = JObject.Parse(item.ToString());

                if ((string)lista["nome"] == "Data Contato")
                    lista["valor"] = new DateTimeOffset(DateTime.Parse(campoDinamicoFront["DataContato"].ToString())).ToUnixTimeMilliseconds();

                if ((string)lista["nome"] == "Contato")
                    lista["valor"] = campoDinamicoFront["Contato"];

                if ((string)lista["nome"] == "Resultado Contato")
                {
                    var jsonLista = (JObject)JsonConvert.DeserializeObject("{'valorSelecionadoLista':[{'idCampoDominio':" + campoDinamicoFront["ResultadoContatoId"] + ",'valorCampoDominio':'" + campoDinamicoFront["ResultadoContatoValor"] + "'}]}");
                    var valor = jsonLista["valorSelecionadoLista"].Value<JArray>();
                    lista["valorSelecionadoLista"] = valor;
                }

                if ((string)lista["nome"] == "Telefones")
                {
                    var jsonLista = (JObject)JsonConvert.DeserializeObject("{'valorSelecionadoLista':[{'idCampoDominio':" + campoDinamicoFront["TelefoneId"] + ",'valorCampoDominio':'" + campoDinamicoFront["TelefoneValor"] + "'}]}");
                    var valor = jsonLista["valorSelecionadoLista"].Value<JArray>();
                    lista["valorSelecionadoLista"] = valor;
                }

                if ((string)lista["nome"] == "Observação Contato")
                    lista["valor"] = campoDinamicoFront["ObservacaoContato"];

                listaDinamica.Add(lista.ToString());
            }

            return listaDinamica;
        }

        private async Task<List<string>> buscaCamposDinamicosEncaminhar(AcaoCadRequest requestCad)
        {
            var json = await consultaApiCad(requestCad);
            var listaDinamica = new List<string>();

            JObject campoDinamicoFront = JObject.Parse(requestCad.CamposDinamicos);

            foreach (JToken item in json)
            {
                JObject lista = JObject.Parse(item.ToString());

                if ((string)lista["nome"] == "Fila pendente com")
                {
                    var jsonLista = (JObject)JsonConvert.DeserializeObject("{'valorSelecionadoLista':[{'idCampoDominio':" + campoDinamicoFront["FilaPendenteId"] + ",'valorCampoDominio':'" + campoDinamicoFront["FilaPendenteValor"] + "'}]}");
                    var valor = jsonLista["valorSelecionadoLista"].Value<JArray>();
                    lista["valorSelecionadoLista"] = valor;
                }

                if ((string)lista["nome"] == "Prazo para retorno")
                    lista["valor"] = new DateTimeOffset(DateTime.Parse(campoDinamicoFront["DataPrazoRetorno"].ToString())).ToUnixTimeSeconds();

                if ((string)lista["nome"] == "Registro Parcial")
                    lista["valor"] = campoDinamicoFront["RegistroParcial"];

                listaDinamica.Add(lista.ToString());
            }

            return listaDinamica;

        }

        private async Task<List<string>> buscaCamposDinamicosFinalizar(AcaoCadRequest requestCad)
        {
            var json = await consultaApiCad(requestCad);
            var listaDinamica = new List<string>();

            JObject campoDinamicoFront = JObject.Parse(requestCad.CamposDinamicos);

            foreach (JToken item in json)
            {
                JObject lista = JObject.Parse(item.ToString());

                if ((string)lista["nome"] == "Grupo Causa Raiz")
                    lista["valor"] = campoDinamicoFront["GrupoCausaRaiz"];

                if ((string)lista["nome"] == "Causa Raiz do Problema")
                    lista["valor"] = campoDinamicoFront["CausaRaizProblema"];

                if ((string)lista["nome"] == "Tipo de Finalização")
                    lista["valor"] = campoDinamicoFront["TipoFinalizao"];

                if ((string)lista["nome"] == "Solução do Problema Raiz")
                    lista["valor"] = campoDinamicoFront["SolucaoProblemaRaiz"];

                if ((string)lista["nome"] == "Resolução")
                    lista["valor"] = campoDinamicoFront["Resolucao"];

                if ((string)lista["nome"] == "Status da solicitacao")
                    lista["valor"] = campoDinamicoFront["StatusSolicitacao"];

                listaDinamica.Add(lista.ToString());
            }

            return listaDinamica;
        }

        private async Task<string> acaoAgendar(AcaoCadRequest requestCad)
        {
            using (var httpClient = new HttpClient())
            {
                Uri address = new Uri(string.Concat(_configuration["ApisCad:executaAcao"], requestCad.IdAcao));

                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent(requestCad.IdCaso), "idCaso");
                form.Add(new StringContent(requestCad.IdUsuario), "idUsuario");
                form.Add(new StringContent(requestCad.IdAcao), "idAcao");

                JObject campoDinamicoFront = JObject.Parse(requestCad.CamposDinamicos);

                var dataAgendamento = new DateTimeOffset(DateTime.Parse(campoDinamicoFront["dataAgendamento"].ToString())).ToUnixTimeMilliseconds();

                form.Add(new StringContent(dataAgendamento.ToString()), "dataAgendamento");
                form.Add(new StringContent(campoDinamicoFront["observacao"].ToString()), "observacao");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, address);
                request.Content = form;
                request.Headers.Add("Cookie", string.Concat("sso_client=", requestCad.sso_client, ";ROUTEID=.1"));
                HttpResponseMessage response = await httpClient.SendAsync(request);

                return await response.Content.ReadAsStringAsync();
            }
        }

        private async Task<string> acaoAnexar(AcaoCadRequest requestCad)
        {
            using (var httpClient = new HttpClient())
            {
                Uri resourceAddress = new Uri(string.Concat(_configuration["ApisCad:executaAcao"], requestCad.IdAcao));

                JObject campoDinamicoFront = JObject.Parse(requestCad.CamposDinamicos);
                var obs = campoDinamicoFront["observacao"].ToString();
                var base64 = campoDinamicoFront["base64"].ToString();
                var pathName = campoDinamicoFront["name"].ToString();

                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent(requestCad.IdCaso), "idCaso");
                form.Add(new StringContent(requestCad.IdUsuario), "idUsuario");
                form.Add(new StringContent(requestCad.IdAcao), "idAcao");
                form.Add(new StringContent("Registro de anexo via Front-Ouvidoria"), "observacao");

                var separa = base64.Split(",");
                var temp_backToBytes = Convert.FromBase64String(separa[1]);
                var imageContent = new ByteArrayContent(temp_backToBytes);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(imageContent, "file", pathName);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, resourceAddress);
                request.Content = form;
                request.Headers.Add("Cookie", string.Concat("sso_client=", requestCad.sso_client, ";ROUTEID=.1"));
                HttpResponseMessage response = await httpClient.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
        }

        private string getIdAcaoCad(string acaoCad)
        {
            return _parametrosSistemaDal.Read().Where(x => x.Chave.Equals(acaoCad)).FirstOrDefault().Valor;
        }
    }
}
