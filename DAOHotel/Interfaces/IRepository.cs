using System;
using System.Collections.Generic;
using System.Text;

namespace DAOHotel.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T element);
        bool Update(T element);
        bool Delete(T element);
        List<T> FindAll();
        T FindById(int id);
    }
}
