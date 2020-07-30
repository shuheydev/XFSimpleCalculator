using CalculatorLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorLogicTest
{
    public class CalcDivTest
    {
        private readonly CalcDiv _calc;

        public CalcDivTest()
        {
            this._calc = new CalcDiv();
        }

        [Fact(DisplayName ="4/2=2")]
        public void Test1()
        {
            var answer = this._calc.Calc(4, 2);

            Assert.Equal(2, answer);
        }
    }
}
