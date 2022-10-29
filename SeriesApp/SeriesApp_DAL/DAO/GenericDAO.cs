using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.DAO
{
    public class GenericDAO<T> : IGenericDAO<T>
    {
        #region Constants
        
        #endregion


        #region Properties
        public string Table;


        #endregion

        #region Constructors
        public GenericDAO()
        {
        }

        public GenericDAO(string table)
        {
            Table = table;
        }

        #endregion

        public List<T> findAll()
        {
            List<T> list = new List<T>();


            throw new NotImplementedException();
        }

        public T findById(int id)
        {
            throw new NotImplementedException();
        }

        public void insert(T item)
        {
            throw new NotImplementedException();
        }

        public void update(T item)
        {
            throw new NotImplementedException();
        }
        public void delete(T item)
        {
            throw new NotImplementedException();
        }
    }
}
