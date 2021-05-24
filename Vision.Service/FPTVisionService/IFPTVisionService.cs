using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Service
{
    public interface IFPTVisionService
    {
        Task<T> DrivingLicenseRecognition<T>();

        Task<T> IdentityCardRecognition<T>();

        Task<T> PassportRecognition<T>();
    }
}
