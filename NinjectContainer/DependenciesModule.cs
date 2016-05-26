using Interfaces;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModelBuilder;

namespace NinjectContainer
{
    public class DependenciesModule : IDependencyResolver
    {
        //private readonly IKernel _kernel;
        private readonly IResolutionRoot _resolutionRoot;

        public DependenciesModule()
        {

        }
        //public DependenciesModule(IKernel kernel)
        //{
        //    _kernel = kernel;
        //    AddBindings();
        //}

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IViewModelBuilder>().To<Builder>();
        }
    }
}
