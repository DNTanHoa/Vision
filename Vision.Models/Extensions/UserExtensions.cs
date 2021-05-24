using System;
using System.Collections.Generic;
using System.Text;
using Vision.SharedUltilities.Helpers;

namespace Vision.Models.Extensions
{
    public static class UserExtensions
    {
        public static void SetPassword(this User user)
        {
            if (string.IsNullOrEmpty(user.hashKey))
            {
                user.hashKey = Guid.NewGuid().ToString();
            }

            user.password = SecurityHelper.Encrypt(user.hashKey, user.password);
        }
    }
}
