﻿namespace CrudApplication.Models
{
    public record LoginModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
