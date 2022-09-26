using ASP_hometask1.Entity;
using ASP_hometask1.Interfaces;

namespace ASP_hometask1.Services
{
    public class InitialProvider : IActions
    {
        private IProvider _provider;

        public InitialProvider(IProvider provider)
        {
            _provider = provider;
        }

        public void Create(Flora flora)
        {
            _provider.Create(flora);
        }

        public void Delete(int id)
        {
            _provider.Delete(id);
        }

        public Flora Read(int id)
        {
            return _provider.Read(id);
        }

        public void Update(Flora flora)
        {
            _provider.Update(flora);
        }
    }
}
