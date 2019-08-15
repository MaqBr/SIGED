using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UFMT.SIGED.Domain.Entity;
using UFMT.SIGED.Infra.Data.Context;
using UFMT.SIGED.Infra.Data;
using UFMT.SIGED.Infra.Data.UoW;
using UFMT.SIGED.Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading;
using PagedList;
using PagedList.Mvc;
using UFMT.SIGED.UI.Web.Filtros;
using UFMT.SIGED.Application.Interfaces;

namespace Areas.Administracao.Controllers
{
    [AutorizacaoUsuarioFilter]
    public class NivelEnsinoController : Controller
    {
        private readonly INivelEnsinoAppService _nivelEnsinoAppService;

        private const int pageSize = 10;

        public NivelEnsinoController(INivelEnsinoAppService nivelEnsinoAppService)
        {
            _nivelEnsinoAppService = nivelEnsinoAppService;
        }

        public ActionResult DetalheNivelEnsinoEstudante()
        {
            var estudanteNivelEnsino =
                _nivelEnsinoAppService
                .ObterPorId(1);

            var vm = new EstudanteNivelEnsinoViewModel
            {
                NivelEnsinoId = estudanteNivelEnsino.NivelEnsinoId,
                Descricao = estudanteNivelEnsino.Descricao,
                Nome = estudanteNivelEnsino.Estudantes.FirstOrDefault().Nome,
                EstudanteId = estudanteNivelEnsino.Estudantes.FirstOrDefault().EstudanteId,
                DataNascimento = estudanteNivelEnsino.Estudantes.FirstOrDefault().DataNascimento,
                TotalEstudantes = estudanteNivelEnsino.Estudantes.Count()

            };

            return View(vm);
        }

        public ActionResult ObterMaiorNivelEnsino()
        {
            var vm = _nivelEnsinoAppService.ObterTodos().AsQueryable()
                .ProjectTo<NivelDeEnsinoViewModel>()
                .FirstOrDefault();
            return PartialView("_ObterMaiorNivelEnsino", vm);
        }


        public ActionResult Buscar(int? pagina, string criterio = null)
        {
            //Sleep de 5 segundos apenas para visualizar o loading
            //Não adicionar em produção
            //Thread.Sleep(5000);

            int pageNumber = pagina ?? 1;

            var vm = _nivelEnsinoAppService
                .ObterTodos();

            if (!String.IsNullOrWhiteSpace(criterio))
            {

                vm =  _nivelEnsinoAppService
                        .Buscar(e =>
                                e.Descricao.ToUpper()
                                .Contains(criterio.ToUpper())
                               );
            }

            return PartialView("_ObterTodos", vm.OrderBy(x => x.Descricao)
                .ToPagedList(pageNumber, pageSize));

        }

        public ActionResult Index(int? pagina)
        {
            #region erro de lógica

            ////string[] nomes = new string[] { "Marcio", "Guilherme" };
            ////string nome = nomes[2];

            #endregion

            int pageNumber = pagina ?? 1;

            var vm = _nivelEnsinoAppService.ObterTodos();

            return View(vm.OrderBy(x=>x.Descricao)
                .ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            var vm =
                _nivelEnsinoAppService
                .ObterPorId(id.GetValueOrDefault());

            return PartialView("_Details", vm);
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            AdicionarNivelEnsinoViewModel nivelEnsinoVM)
        {

            //Sleep de 5 segundos apenas para visualizar o loading
            //Não adicionar em produção
            //Thread.Sleep(5000);

            if (ModelState.IsValid)
            {
                _nivelEnsinoAppService.Adicionar(nivelEnsinoVM);
                return ObterTodos();
            }

            return PartialView("_Create", nivelEnsinoVM);
        }

        
        public ActionResult Edit(int? id)
        {

            var vm =
                _nivelEnsinoAppService
                .ObterPorId(id.GetValueOrDefault());

  
            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            AtualizarNivelEnsinoViewModel nivelEnsinoVM)
        {
            //Sleep de 5 segundos apenas para visualizar o loading
            //Não adicionar em produção
            //Thread.Sleep(5000);

            if (ModelState.IsValid)
            {
                _nivelEnsinoAppService.Atualizar(nivelEnsinoVM);
                return ObterTodos();
            }
            return PartialView("_Edit", nivelEnsinoVM);
        }

        public ActionResult Delete(int? id)
        {
            var vm =
                _nivelEnsinoAppService
                .ObterPorId(id.GetValueOrDefault());

            return PartialView("_Delete", vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Sleep de 5 segundos apenas para visualizar o loading
            //Não adicionar em produção
            //Thread.Sleep(5000);
            _nivelEnsinoAppService.Remover(id);
            return ObterTodos();
        }

        public ActionResult ObterTodos()
        {
            var vm = _nivelEnsinoAppService.ObterTodos();

            return PartialView("_ObterTodos", vm.OrderBy(x => x.Descricao)
                    .ToPagedList(1, pageSize));
        }

    }
}
