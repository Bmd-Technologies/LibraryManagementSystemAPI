﻿using LibraryManagementSystemAPI.Models.Enum;

namespace LibraryManagementSystemAPI.Dto
{
    public class UserDto
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public bool Blocked { get; set; } = false;
        public bool Active { get; set; } = true;
        public float Fine { get; set; } = 0;
        public UserType UserType { get; set; }
       
    }
}
