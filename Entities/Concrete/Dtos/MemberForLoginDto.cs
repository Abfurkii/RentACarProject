﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Dtos
{
    public class MemberForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
