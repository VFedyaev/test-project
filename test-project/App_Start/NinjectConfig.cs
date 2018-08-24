using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testproject.infrastructure.UnitOfWork;

namespace test_project.App_Start
{
    public class NinjectConfig : NinjectModule
    {
        private string connectionString;
        public NinjectConfig(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}