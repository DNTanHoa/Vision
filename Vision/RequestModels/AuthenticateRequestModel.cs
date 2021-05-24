using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vision.RequestModels
{
    public class AuthenticateRequestModel
    {
        [Required(ErrorMessage = "username can not be null")]
        public string username { get; set; }
        [Required(ErrorMessage = "password can not be null")]
        public string password { get; set; }
    }
}
