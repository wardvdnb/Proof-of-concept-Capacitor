namespace Api.Models
{
    public interface IEngineerRepository
    {
        Engineer GetBy(string email);
        void Add(Engineer engineer);
        void SaveChanges();
    }
}

