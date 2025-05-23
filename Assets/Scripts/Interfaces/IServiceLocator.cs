namespace Interfaces
{
    public interface IServiceLocator
    {
        public void Register<TService>(TService service);
        public TService Resolve<TService>();
    }
}