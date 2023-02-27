using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La.Infra.Extensions
{
    /// <summary>
    /// 异常
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception GetOriginalException(this Exception ex)
        {
            if (ex.InnerException == null) return ex;

            return ex.InnerException.GetOriginalException();
        }
    }
}
