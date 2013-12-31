using ReverseStringContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringServiceimplement
{
    public class ReverseStringServiceImplement : IReverseStringService
    {
        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);

            return new string(arr);
        }
    }
}
