using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Vision.SharedUltilities.Extensions
{
    public static class ObjectExtensions
    {
        public static Dictionary<string, string> ToDictionaryStringString(this object obj)
        {
            if (obj != null)
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                PropertyInfo[] props = obj.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (string.IsNullOrEmpty(prop.GetValue(obj)?.ToString()))
                    {
                        result.Add(prop.Name, string.Empty);
                    }
                    else
                    {
                        result.Add(prop.Name, prop.GetValue(obj)?.ToString());
                    }
                }
                return result;
            }
            return null;
        }
    }
}
