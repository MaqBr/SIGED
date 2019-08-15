using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Application.ViewModels;

namespace UFMT.SIGED.Application.Interfaces
{
    public interface INivelEnsinoAppService : IDisposable
    {
        AdicionarNivelEnsinoViewModel Adicionar(AdicionarNivelEnsinoViewModel obj);
        AtualizarNivelEnsinoViewModel Atualizar(AtualizarNivelEnsinoViewModel obj);
        IEnumerable<NivelDeEnsinoViewModel> ObterTodos();
        NivelDeEnsinoViewModel ObterPorId(int id);
        IEnumerable<NivelDeEnsinoViewModel> Buscar(Expression<Func<NivelDeEnsinoViewModel
            , bool>> predicado);
        void Remover(int id);
    }
}
