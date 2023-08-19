namespace LazzyCoffeeShop.Domain.Dto
{
    public class UserDto : BaseDto<UserDto, User>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
