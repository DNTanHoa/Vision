using System;
using System.Collections.Generic;
using System.Text;

namespace Vision.SharedModels.Common
{
    public class CommonApiResponeModel
    {
        public CommonApiResult result { get; set; }
        public Object data { get; set; }
        
        public CommonApiResponeModel SetResult(CommonApiResult Result)
        {
            this.result = Result;
            return this;
        }

        public CommonApiResponeModel SetData(Object Data)
        {
            this.data = Data;
            return this;
        }
    }
}
