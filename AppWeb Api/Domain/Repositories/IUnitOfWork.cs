using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task CompleteAsync();
    }
}
