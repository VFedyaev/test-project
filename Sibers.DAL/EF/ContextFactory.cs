using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.DAL.EF
{
    public class ContextFactory : IDbContextFactory<ApplicationContext>
    {
        public ApplicationContext Create()
        {
            return new ApplicationContext("ApplicationContext");
        }
    }
}
