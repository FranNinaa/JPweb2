using JPweb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JPweb.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;

        public AlunoController(IConfiguration configuration)
        {
          _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View("Aluno");
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();

            try
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });
                }
                else
                {
                    ViewData["MsgErro"] = "Erro n a busca do endereço !";
                }

            }
            catch (Exception)
            {

                throw;
            }
            ViewData["MsgAcept"] = "Sucesso na Busca do Endereço !";
            return View("Aluno");
        }
        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }
    }
   
}
