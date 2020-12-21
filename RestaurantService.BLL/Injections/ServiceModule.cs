using RestaurantService.DAL;
using RestaurantService.DAL.Interfaces;
using Unity;
using Unity.Resolution;

namespace RestaurantService.BLL.Injections
{
    /// <summary>
    /// Dependency injection service
    /// </summary>
    public class ServiceModule
    {
        private static IUnityContainer _container;

        private static IUnityContainer Container 
        {
            get
            {
                if (_container == null)
                {
                    _container = new UnityContainer();

                    _container.RegisterType<IDB, RestaurantDB>();
                }

                return _container;
            }
        }
        
        public static T Init<T>(string connection)
        {
            return Container.Resolve<T>(
                new ParameterOverride("connection", connection));
        }
    }
}
