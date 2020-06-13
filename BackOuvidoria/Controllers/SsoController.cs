using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ouvidoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SsoController : Controller
    {
        private readonly IConfiguration _configuration;

        public SsoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("authenticate")]
        public async Task<HttpResponseMessage> Get()
        {
            string[] url = Request.QueryString.Value.Split('?');
            string sessionid = HttpUtility.ParseQueryString(string.Concat("?", url[1])).Get("sessionid") != null ? Uri.UnescapeDataString(HttpUtility.ParseQueryString(string.Concat("?", url[1])).Get("sessionid")) : null; 
            string hostid = HttpUtility.ParseQueryString(string.Concat("?", url[1])).Get("hostid") != null ? Uri.UnescapeDataString(HttpUtility.ParseQueryString(string.Concat("?", url[1])).Get("hostid")) : null;
            string idCaso = HttpUtility.ParseQueryString(string.Concat("?", url[1])).Get("idCaso") != null ? Uri.UnescapeDataString(HttpUtility.ParseQueryString(string.Concat("?", url[1])).Get("idCaso")) : null;
            string protocolo = HttpUtility.ParseQueryString(string.Concat("?", url[1])).Get("protocolo") != null ? Uri.UnescapeDataString(HttpUtility.ParseQueryString(string.Concat("?", url[1])).Get("protocolo")) : null;
            string idUsuario = HttpUtility.ParseQueryString(string.Concat("?", url[1])).Get("idUsuario") != null ? Uri.UnescapeDataString(HttpUtility.ParseQueryString(string.Concat("?", url[1])).Get("idUsuario")) : null;

            if (url.Length > 2)
            {
                sessionid = Uri.UnescapeDataString(HttpUtility.ParseQueryString(string.Concat("?", url[2])).Get("sessionid"));
                hostid = Uri.UnescapeDataString(HttpUtility.ParseQueryString(string.Concat("?", url[2])).Get("hostid"));

                HttpClient httpClient = new HttpClient();
                Uri address = new Uri(string.Concat(_configuration["ApisCad:geraSsoClient"], sessionid, "/", hostid));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, address);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                var option = new CookieOptions();
                option.Path = "/";
                option.Domain = "bcccanaiscriticos.com.br";
                Response.Cookies.Append("sso_client", response.Content.ReadAsStringAsync().Result, option);
            }

            if (sessionid == null)
                Response.Redirect("https://bcccanaiscriticos.com.br/sso/faces/autenticacao/Autenticacao.xhtml?fromclient=true&page=" + HttpUtility.UrlEncode("https://bcccanaiscriticos.com.br/ouvidoria/api/sso/authenticate?idCaso=" + idCaso + "&protocolo=" + protocolo + "&idUsuario=" + idUsuario + "", Encoding.UTF8) + "");
            else
                Response.Redirect("https://bcccanaiscriticos.com.br/ouvidoria/?idCaso=" + idCaso + "&protocolo=" + protocolo + "&idUsuario=" + idUsuario + "");

            return new HttpResponseMessage();
        }

    }
}

