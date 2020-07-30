using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLogic
{
    public class CalcSub : ICalc
    {
        public int Calc(int v1, int v2)
        {
            return v1 - v2;
        }
    }
}
