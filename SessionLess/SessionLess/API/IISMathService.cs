using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFContract;

namespace SessionLess.API
{
    public class IISMathService : IMathService
    {
        public double AddNumber(double dblX, double dblY)
        {
            return (dblX + dblY);
        }

        public double SubtractNumber(double dblX, double dblY)
        {
            return (dblX - dblY);
        }

        public double MultiplyNumber(double dblX, double dblY)
        {
            return (dblX * dblY);
        }

        public double DivideNumber(double dblX, double dblY)
        {
            return ((dblY == 0) ? 0 : dblX / dblY);
        }
    }
}