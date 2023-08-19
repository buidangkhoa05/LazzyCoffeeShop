using LazzyCoffeeShop.Domain.Entities;

namespace LazzyCoffeeShop.Application.Service.Interface
{
    public interface IUserService : IDisposable
    {
        Task<UserDto> GetUserByIdAsync(int id);
    }
}
