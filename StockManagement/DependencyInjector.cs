using Unity;

namespace StockManagement
{
    public static class DependencyInjector
    {
        private static readonly UnityContainer _unityContainer = new UnityContainer();
        
        public static void Register<I, T>() where T : I
        {
            _unityContainer.RegisterType<I, T>();
        }

        public static T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }
    }
}
