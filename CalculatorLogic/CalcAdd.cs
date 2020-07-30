using System;

namespace CalculatorLogic
{
    public class CalcAdd : ICalc
    { 
        public int Calc(int v1, int v2)
        {
            return v1 + v2;
        }
    }
}
