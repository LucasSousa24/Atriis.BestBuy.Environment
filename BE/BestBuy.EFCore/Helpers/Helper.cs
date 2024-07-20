using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.EFCore.Helpers
{
    public static class Helper
    {
        public static long IdGenerator()
        {
            // Generate a new GUID
            Guid guid = Guid.NewGuid();

            // Convert the GUID to a byte array
            byte[] bytes = guid.ToByteArray();

            // Use the first 8 bytes to create a long value
            return BitConverter.ToInt64(bytes, 0);
        }
    }
}
