using System;

namespace LABOLATORIUM_7
{
    public interface IBookRepository : IBaseRepository<Book, long>
    {
    }

    public interface IPersonRepository : IBaseRepository<Person, int>
    {

    }
}