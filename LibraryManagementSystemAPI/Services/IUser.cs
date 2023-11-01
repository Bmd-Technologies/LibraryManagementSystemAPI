using LibraryManagementSystemAPI.Dto;
using LibraryManagementSystemAPI.Shared.Response;

namespace LibraryManagementSystemAPI.Services
{
    public interface IUser
    {
        Task<BaseResponse> CreateUser(UserDto user);
        Task<BaseResponse> GetUsers();
        Task<BaseResponse> GetUserById(string Id);
        Task<BaseResponse> UpdateUser(UserDto user);
        Task<BaseResponse> DeleteById(string Id);
        Task<BaseResponse> IsEmailAvailable(string email);
        Task<BaseResponse> AuthenticateUser(string email, string password, out UserDto? user);
        Task<BaseResponse> BlockUser(string Id);
        Task<BaseResponse> UnblockUser(string Id);
        Task<BaseResponse> DeactivateUser(string Id);
        Task<BaseResponse> ActivateUser(string Id);
        Task<bool> SaveChange();
    }
}
