using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class ServiceResult
    {
        #region Declare
        public object Data { get; set; }

        public string DevMsg { get; set; }

        public string UserMessage { get; set; }

        public int ErrorCode { get; set; }
        #endregion
    }
}
