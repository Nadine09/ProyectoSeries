using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.DAO
{
    public interface IGenericDAO<T>
    {
        T findById(int id);
        List<T> findAll();
        void insert(T item);
        void update(T item);
        void delete(T item);

    }
}
