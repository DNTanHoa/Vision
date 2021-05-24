using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.SharedModels.Authenticate
{
    public class AuthenticatedUser
    {
        public string username { get; set; }
        public string token { get; set; }
    }
}
