using System.Web.Mvc;
using testproject.core.Entities;
using testproject.core.Interfaces;
using testproject.infrastructure.Repositories;
using testproject.infrastructure.UnitOfWork;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace test_project
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}