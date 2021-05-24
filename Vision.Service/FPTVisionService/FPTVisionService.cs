using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Service
{
    public class FPTVisionService : IFPTVisionService
    {
        public Task<T> DrivingLicenseRecognition<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> IdentityCardRecognition<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> PassportRecognition<T>()
        {
            throw new NotImplementedException();
        }
    }
}
