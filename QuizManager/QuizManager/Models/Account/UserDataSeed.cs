﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Account
{
    public class UserDataSeed
    {
        public List<ConfigUser> ConfigUsers { get; set; }
    }
    public class ConfigUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
