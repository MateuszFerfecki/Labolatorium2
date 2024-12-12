u﻿using Lab2.Lab6;

namespace Lab2.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book, long>
    {

    }

    public interface IPersonRepository : IBaseRepository<Person, int>
    {

    }
}