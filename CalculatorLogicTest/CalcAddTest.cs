using CalculatorLogic;
using System;
using Xunit;

namespace CalculatorLogicTest
{
    public class CalcAddTest
    {
        private readonly CalcAdd _calc;

        public CalcAddTest()
        {
            this._calc = new CalcAdd();
        }

        [Fact(DisplayName = "1+1=2")]
        public void Test1()
        {
            int answer = this._calc.Calc(1, 2);

            Assert.Equal(3, answer);
        }
    }
}
