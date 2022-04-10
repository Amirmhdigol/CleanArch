﻿using CleanArch.Query.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Users
{
    public record GetUserByEmailQuery(string Email) : IRequest<UserReadModel>;
}
