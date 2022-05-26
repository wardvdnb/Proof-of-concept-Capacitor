using System.Collections.Generic;

namespace Api.Models
{
    public interface IEngineerRepository
    {
        Engineer GetBy(string email);
        IEnumerable<Engineer> GetAll();
        void Add(Engineer engineer);
        void SaveChanges();
    }
}

