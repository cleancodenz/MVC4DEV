using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubProject
{
    public interface ICalculator
    {
        double Add(double firstNumber, double lastNumber);
    }

    public class Mathematics
    {
        private ICalculator calculator;
        public Mathematics(ICalculator calc)
        {
            calculator = calc;
        }
        public double AddNumbers()
        {
            return calculator.Add(1, 1);
        }

        public int GetTheCurrentYear()
        {
            return DateTime.Now.Year;
        }
    }
}
