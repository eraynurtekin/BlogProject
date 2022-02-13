using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        // T bir class a ait tüm özellikleri kullanacak.

        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetListAll();
        T GetByID(int id);

    }
}
