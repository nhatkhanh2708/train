using Application.DTOs;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISignInManager
    {
        bool PasswordSignInAsync(string username, string password);
    }
}
