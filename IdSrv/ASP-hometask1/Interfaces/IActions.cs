using ASP_hometask1.Entity;

namespace ASP_hometask1.Interfaces
{
    public interface IActions
    {
        void Create(Flora flora);

        Flora Read(int id);

        void Update(Flora flora);

        void Delete(int id);
    }
}
