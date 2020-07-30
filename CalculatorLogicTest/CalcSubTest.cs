using CalculatorLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorLogicTest
{
    public class CalcSubTest
    {
        private readonly CalcSub _calc;

        public CalcSubTest()
        {
            this._calc = new CalcSub();
        }
        [Fact(DisplayName = "2-1=1")]
        public void Test1()
        {
            var answer = this._calc.Calc(2, 1);

            Assert.Equal(1, answer);
        }

    }
}
