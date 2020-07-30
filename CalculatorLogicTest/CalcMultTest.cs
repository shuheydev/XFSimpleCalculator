using CalculatorLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorLogicTest
{
    public class CalcMultTest
    {
        private readonly CalcMulti _calc;

        public CalcMultTest()
        {
            this._calc = new CalcMulti();
        }
        [Fact(DisplayName ="3*4=12")]
        public void Test1()
        {
            var answer = this._calc.Calc(3, 4);

            Assert.Equal(12, answer);
        }
    }
}
