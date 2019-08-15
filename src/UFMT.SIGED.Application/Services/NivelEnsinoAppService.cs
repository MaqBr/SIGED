using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using UFMT.SIGED.Application.Interfaces;
using UFMT.SIGED.Application.ViewModels;
using UFMT.SIGED.Domain.Entity;
using UFMT.SIGED.Domain.Interfaces.Services;
using UFMT.SIGED.Infra.Data.UoW;

namespace UFMT.SIGED.Application.Services
{
    public class NivelEnsinoAppService : ApplicationService, INivelEnsinoAppService
    {

        private readonly INivelEnsinoService _nivelEnsinoService;

        public NivelEnsinoAppService(INivelEnsinoService nivelEnsinoService, IUnitOfWork uow)
            : base(uow)
        {
            _nivelEnsinoService = nivelEnsinoService;
        }

        public AdicionarNivelEnsinoViewModel Adicionar(AdicionarNivelEnsinoViewModel obj)
        {
            
            var nivelEnsino = Mapper.Map<AdicionarNivelEnsinoViewModel, NivelEnsino>(obj);

            BeginTransaction();
            var nivelEnsinoReturn = _nivelEnsinoService.Adicionar(nivelEnsino);
            Commit();

            return Mapper.Map<NivelEnsino, AdicionarNivelEnsinoViewModel>(nivelEnsinoReturn);

        }

        public AtualizarNivelEnsinoViewModel Atualizar(AtualizarNivelEnsinoViewModel obj)
        {
            BeginTransaction();
            var nivelEnsinoReturn = _nivelEnsinoService.Atualizar(Mapper.Map<AtualizarNivelEnsinoViewModel, NivelEnsino>(obj));
            Commit();

            return Mapper.Map<NivelEnsino, AtualizarNivelEnsinoViewModel>(nivelEnsinoReturn);
        }

        public IEnumerable<NivelDeEnsinoViewModel> Buscar(Expression<Func<NivelDeEnsinoViewModel, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _nivelEnsinoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public NivelDeEnsinoViewModel ObterPorId(int id)
        {
            return Mapper.Map<NivelEnsino, NivelDeEnsinoViewModel>(_nivelEnsinoService.ObterPorId(id));
        }

        public IEnumerable<NivelDeEnsinoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<NivelEnsino>, IEnumerable<NivelDeEnsinoViewModel>>(_nivelEnsinoService.ObterTodos());
        }

        public void Remover(int id)
        {
            _nivelEnsinoService.Remover(id);
        }
    }
}
