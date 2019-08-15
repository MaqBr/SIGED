using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;

namespace UFMT.SIGED.Domain.Interfaces.Services
{
    public interface INivelEnsinoService : IDisposable
    {
        NivelEnsino Adicionar(NivelEnsino obj);
        NivelEnsino Atualizar(NivelEnsino obj);
        IEnumerable<NivelEnsino> ObterTodos();
        NivelEnsino ObterPorId(int id);
        IEnumerable<NivelEnsino> Buscar(Expression<Func<NivelEnsino
            , bool>> predicado);
        void Remover(int id);
    }
}
