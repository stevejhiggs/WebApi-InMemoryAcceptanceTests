using Microsoft.Practices.Unity;
using Repository.Web.Repositories;
using System;

namespace Repository.Web
{
    public static class UnityHelpers
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion


        public static void RegisterTypes(IUnityContainer container)
        {
		    // Add your register logic here...
            // var myAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("your_assembly_Name")).ToArray();

            container.RegisterType(typeof(Startup));

            container.RegisterType<IItemRepository, ItemRepository>();

            // container.RegisterTypes(
            //     UnityHelpers.GetTypesWithCustomAttribute<ContainerControlledAttribute>(myAssemblies),
            //     WithMappings.FromMatchingInterface,
            //     WithName.Default,
            //     WithLifetime.ContainerControlled,
            //     null
            //    ).RegisterTypes(
            //             UnityHelpers.GetTypesWithCustomAttribute<TransientLifetimeAttribute>(myAssemblies),
            //             WithMappings.FromMatchingInterface,
            //             WithName.Default,
            //             WithLifetime.Transient);

        }

    }
}
