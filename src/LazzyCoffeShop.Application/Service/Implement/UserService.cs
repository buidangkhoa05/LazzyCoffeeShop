namespace LazzyCoffeeShop.Application.Service.Implement
{
    internal class UserService : BaseService, IUserService
    {
        public UserService(Lazy<IMapper> mapper) : base(mapper)
        {
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var entity = new User
            {
                FullName = "Baki",
                UserName = "baki_hama",
            };

            var result = await Task.Run(() =>
            {
                return MapperObject.Map<UserDto>(entity);
            });

            return result;
        }
    }
}
