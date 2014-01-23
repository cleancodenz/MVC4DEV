using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace WCFServices
{
    public class MathService :IMathService
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
