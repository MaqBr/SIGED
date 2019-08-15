using SimpleInjector;
using UFMT.SIGED.Application.Interfaces;
using UFMT.SIGED.Application.Services;
using UFMT.SIGED.Domain.Interfaces.Repository;
using UFMT.SIGED.Domain.Interfaces.Services;
using UFMT.SIGED.Domain.Services;
using UFMT.SIGED.Infra.Data;
using UFMT.SIGED.Infra.Data.Context;
using UFMT.SIGED.Infra.Data.UoW;

namespace UFMT.SIGED.Infra.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.RegisterPerWebRequest<INivelEnsinoAppService, NivelEnsinoAppService>();

            // Domain
            container.RegisterPerWebRequest<INivelEnsinoService, NivelEnsinoService>();

            // Infra Dados
            container.RegisterPerWebRequest<INivelEnsinoRepository, NivelEnsinoRepository>();
            container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();
            container.RegisterPerWebRequest<SIGEDContext>();

        }
    }
}
