using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Service
{
    public interface IVNPTeKYCService
    {
        Task<T> UploadImage<T>();
        Task<T> DocumentRecognition<T>();
        Task<T> CheckValidDocument<T>();
        Task<T> GetFrontDocumentData<T>();

    }
}
