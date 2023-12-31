﻿namespace CrudApplication.Models
{
    public record UserProfileRecord
    {
        public int UserProfileId { get; init; }
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string PersonalNumber { get; init; } = null!;
    }
}
