﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AuthorRepositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetBookAuthors();
    }
}
