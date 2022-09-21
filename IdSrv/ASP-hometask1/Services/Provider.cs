using ASP_hometask1.Entity;
using ASP_hometask1.Interfaces;

namespace ASP_hometask1.Services
{
    public class Provider : IProvider
    {
        private readonly List<Flora> _flora;

        public Provider()
        {
            _flora = new List<Flora>();
        }

        public void Create(Flora flora)
        {
            _flora.Add(flora);
        }

        public void Delete(int id)
        {
            int item = _flora.FindIndex( x => x.id == id );
            _flora.RemoveAt(item);
        }

        public Flora Read(int id)
        {
            return _flora.FirstOrDefault(x => x.id == id);
        }

        public void Update(Flora flora)
        {
            int item = _flora.FindIndex( x => x.id == flora.id );
            _flora[item] = flora;
        }
    }
}
