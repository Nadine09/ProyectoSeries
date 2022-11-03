using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.DAO
{
    public interface IGenericDAO<T>
    {
        //T findOne(string command);
        List<T> Select(string command);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}
