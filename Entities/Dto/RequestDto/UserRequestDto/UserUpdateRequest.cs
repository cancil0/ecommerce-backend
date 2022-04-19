namespace Entities.Dto.RequestDto.UserRequestDto
{
    public class UserUpdateRequest
    {
        public UpdateUserRequest UpdateUserRequest { get; set; }

        /// <summary>
        /// If user change username, mobile no or email,
        /// we have to find user in db somehow during update
        /// so we hold username in OldUserName to find user.
        /// </summary>
        public string OldUserName { get; set; }
    }
}
