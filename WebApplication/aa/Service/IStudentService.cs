using System.Collections.Generic;
using Project.Model;

namespace Project.Service
{
    public interface IStudentService<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T Add(T one);
    }
}
