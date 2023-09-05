using JPweb.Data.Repositorio.Interfaces;
using JPweb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JPweb.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Aluno()
        {
            //lista de alunos
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
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.Adicionar(aluno);
            }
            catch (Exception e)
            {

                TempData["MsgErro"] = "Erro ao inserir Aluno";
            }
            TempData["MsgErro"] = "Aluno adicionado com sucesso!!";

            return RedirectToAction("Aluno");

        }

        public IActionResult Editar(int Id)
        {
            Aluno aluno = _alunoRepositorio.ListarPorId(Id);
            return View(aluno);
        }

        public IActionResult ExcluirConfirmacao(int Id)
        {
            Aluno aluno = _alunoRepositorio.ListarPorId(Id);
            return View(aluno);
        }

        public IActionResult Apagar(int Id)
        {
            _alunoRepositorio.Apagar(Id);
            return RedirectToAction("Aluno");
        }

        public IActionResult Alterar(Aluno aluno)
        {
           _alunoRepositorio.Atualizar(aluno);

            return RedirectToAction("Aluno");

        }

    }
   
}
