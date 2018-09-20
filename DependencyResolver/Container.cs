using System;
using Autofac;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;

namespace DependencyResolver
{
    public static class Container
    {
        public static IContainer MainContainer { get; private set; }

        static Container() 
        {
            var builder = new ContainerBuilder();

            RegisterTypes(ref builder);

            MainContainer = builder.Build();
        }

        private static void RegisterTypes(ref ContainerBuilder builder) {
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();
            builder.RegisterType<SexRepository>().As<ISexRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<WorkMethodologyRepository>().As<IWorkMethodologyRepository>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
        }
    }
}   
