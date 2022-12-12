using Microsoft.Data.SqlClient;
using SeriesApp_Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.DAO
{
    public class GenreDAO : GenericDAO<ClsGenre>
    {
        public const string TABLE_NAME = "NAD_Genres";
        public const string TABLE_NAME_SERIES_GENRES = "NAD_SeriesGenres";

        public const string SELECT_ALL = $"SELECT [id], [name] FROM {TABLE_NAME}";
        public const string SELECT_BY_SERIES = $"SELECT [id], [name] FROM {TABLE_NAME_SERIES_GENRES} AS SG INNER JOIN {TABLE_NAME} AS G ON SG.genreId = G.id WHERE SG.serieId = @id";

        public GenreDAO()
        {
            cmdSelectAll = SELECT_ALL;
        }

        /// <summary>
        /// Este método obtiene los géneros a los que pertenece una serie por su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ClsGenre> GetBySeries(long id)
        {
            List<ClsGenre> genres = null;
            genres = ExecuteQuery(SELECT_BY_SERIES.Replace("@id", id.ToString()));
            return genres;
        }

        public override ClsGenre BuildObject(SqlDataReader sqlDataReader)
        {
            ClsGenre genre = new ClsGenre()
            {
                Id = (int)sqlDataReader["id"],
                Name = (string)sqlDataReader["name"]
            };
            return genre;
        }
    }
}
