using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapnetGT.Infrastructure.Utilities
{
    public static class Extensions
    {
        public static bool IsValidUrl(this string url)
        {
            if (string.IsNullOrEmpty(url)) return false;
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}
