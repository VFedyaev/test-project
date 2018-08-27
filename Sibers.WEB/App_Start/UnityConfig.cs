using Sibers.BLL.Interfaces;
using Sibers.BLL.Services;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Sibers.WEB
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // DI

            container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}