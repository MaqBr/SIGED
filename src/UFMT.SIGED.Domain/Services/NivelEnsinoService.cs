using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;
using UFMT.SIGED.Domain.Interfaces.Repository;
using UFMT.SIGED.Domain.Interfaces.Services;

namespace UFMT.SIGED.Domain.Services
{
    public class NivelEnsinoService : INivelEnsinoService
    {

        private readonly INivelEnsinoRepository _nivelEnsinoRepository;

        public NivelEnsinoService(INivelEnsinoRepository nivelEnsinoRepository)
        {
            _nivelEnsinoRepository = nivelEnsinoRepository;
        }

        public NivelEnsino Adicionar(NivelEnsino obj)
        {
            return _nivelEnsinoRepository.Adicionar(obj);
        }

        public NivelEnsino Atualizar(NivelEnsino obj)
        {
            return _nivelEnsinoRepository.Atualizar(obj);
        }

        public IEnumerable<NivelEnsino> Buscar(Expression<Func<NivelEnsino, bool>> predicado)
        {
            return _nivelEnsinoRepository.Buscar(predicado);
        }

        public void Dispose()
        {
            _nivelEnsinoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public NivelEnsino ObterPorId(int id)
        {
            return _nivelEnsinoRepository.ObterPorId(id);
        }

        public IEnumerable<NivelEnsino> ObterTodos()
        {
            return _nivelEnsinoRepository.ObterTodos();
        }

        public void Remover(int id)
        {
            _nivelEnsinoRepository.Remover(id);
        }
    }
}
