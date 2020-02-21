﻿using Panda.Domain;
using System.Collections.Generic;

namespace Panda.Services
{
    public interface IUsersService
    {
        List<PandaUser> GetAllUsers();

        PandaUser GetUser(string username);
    }
}
