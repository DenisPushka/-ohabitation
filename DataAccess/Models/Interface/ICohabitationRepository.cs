using Domain.Models;
using System.Threading.Tasks;

namespace DataAccess.Models.Interface
{
    public interface ICohabitationRepository
    {
        Task<Cohabitation[]> AddCohabitation(Cohabitation cohabitation); 
        Task<Cohabitation[]> Delete(string FIO); 
        Task<Cohabitation[]> Insert(Cohabitation cohabitation); 
        Task<Cohabitation[]> GetCohabitations(Filter filter);
        Task<Cohabitation[]> GetArrayCohabitations ();
    }
}
