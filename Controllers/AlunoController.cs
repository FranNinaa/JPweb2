using JPweb.Data.Repositorio.Interfaces;
using JPweb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JPweb.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Index()
        {
          var aluno = _alunoRepositorio.BuscarAlunos();
          return View(aluno);
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

            return View("Endereco", endereco);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult InserirAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.InserirAluno(aluno);
            }
            catch (Exception e)
            {

                TempData["MsgErro"] = "Erro ao inserir Aluno";
            }
            TempData["MsgErro"] = "Aluno adicionado com sucesso!!";

            return RedirectToAction("Aluno");

        }

        public IActionResult Editar()
        {
            return View();
        }
    }
   
}
