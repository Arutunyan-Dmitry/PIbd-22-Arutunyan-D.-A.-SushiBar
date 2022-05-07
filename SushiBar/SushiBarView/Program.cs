using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using SushiBarContracts.BuisnessLogicContracts;
using SushiBarContracts.StoragesContracts;
using SushiBarBusinessLogic.BusinessLogic;
using SushiBarDatabaseImplement.Implements;
using SushiBarBusinessLogic.OfficePackage;
using SushiBarBusinessLogic.OfficePackage.Implements;

namespace SushiBarView
{
    static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }     
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {           
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
         }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IIngredientStorage, IngredientStorage>(new 
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDishStorage, DishStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageFacilityStorage, StorageFacilityStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientLogic, IngredientLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDishLogic, DishLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageFacilityLogic, StorageFacilityLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportLogic, ReportLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToExcel, SaveToExcel>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToWord, SaveToWord>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<AbstractSaveToPdf, SaveToPdf>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }

    }
}
