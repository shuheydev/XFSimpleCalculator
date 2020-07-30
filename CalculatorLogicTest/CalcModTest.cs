using CalculatorLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorLogicTest
{
    public class CalcModTest
    {
        private readonly CalcMod _calc;

        public CalcModTest()
        {
            this._calc = new CalcMod();
        }

        [Fact(DisplayName ="2/3=2")]
        public void Test1()
        {
            var answer = this._calc.Calc(2, 3);

            Assert.Equal(2, answer);
        }
    }
}
