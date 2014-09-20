using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

using Owin;

using Microsoft.Owin;

using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

using TicTacToe.Data;
using TicTacToe.Data.Contracts;
using TicTacToe.Services.Infrastructure;
using TicTacToe.Logic;

[assembly: OwinStartup(typeof(TicTacToe.Services.Startup))]

namespace TicTacToe.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            BindTypes(kernel);

            return kernel;
        }

        private static void BindTypes(StandardKernel kernel)
        {
            kernel.Bind<ITicTacToeData>().To<TicTacToeData>()
                .WithConstructorArgument("databaseContext", obj => new TicTacToeDbContext());

            kernel.Bind<IUserProvider>().To<AspNetUserProvider>();

            kernel.Bind<ITicTacToeLogic>().To<TicTacToeLogic>();
        }
    }
}
