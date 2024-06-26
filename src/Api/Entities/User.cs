﻿using Api.Entities.Common;
using Api.Enums;

namespace Api.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Role Role { get; set; }
    public bool IsActive { get; set; } = false;
}
