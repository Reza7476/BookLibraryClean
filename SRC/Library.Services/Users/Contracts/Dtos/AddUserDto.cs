﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Users.Contracts.Dtos;
public class AddUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
