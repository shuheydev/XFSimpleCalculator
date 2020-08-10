using CalculatorLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xunit;

namespace CalculatorLogicTest
{
    public class CalculatorTest
    {
        private readonly Calculator _calc;

        public CalculatorTest()
        {
            this._calc = new Calculator();
        }

        [Fact(DisplayName = "Initialize Check")]
        public void Test1()
        {
            Assert.NotNull(_calc.Register1);
            Assert.NotNull(_calc.Register2);
            Assert.NotNull(_calc.Operator);
        }



        [Fact(DisplayName = "SetValue Success")]
        public void Test2()
        {
            _calc.SetValue(1);
            Assert.Equal(1, _calc.Register1.Value);
            Assert.Equal(RegisterStatus.Set, _calc.Register1.Status);
        }

        [Fact(DisplayName = "SetOperator Success")]
        public void Test3()
        {
            _calc.SetOperator(OperatorType.Add);
            Assert.Equal(OperatorType.Add, _calc.Operator.Type);
            Assert.True(_calc.Operator.IsSet);
        }

        [Fact(DisplayName = "1+1=2")]
        public void Test4()
        {
            _calc.SetValue(1)
                 .SetOperator(OperatorType.Add)
                 .SetValue(1)
                 .Calc();

            Assert.Equal(2, _calc.Register1.Value);
            Assert.Equal(RegisterStatus.NotSet, _calc.Register2.Status);
            Assert.False(_calc.Operator.IsSet);
        }

        [Fact(DisplayName = "1+1+1=3")]
        public void Test5()
        {
            _calc.SetValue(1)
                 .SetOperator(OperatorType.Add)
                 .SetValue(1)
                 .SetOperator(OperatorType.Add)
                 .SetValue(1)
                 .Calc();

            Assert.Equal(3, _calc.Register1.Value);
            Assert.Equal(RegisterStatus.NotSet, _calc.Register2.Status);
            Assert.False(_calc.Operator.IsSet);
        }

        [Fact(DisplayName = "(1+1)*3=6")]
        public void Test6()
        {
            _calc.SetValue(1)
                 .SetOperator(OperatorType.Add)
                 .SetValue(1)
                 .SetOperator(OperatorType.Multi)
                 .SetValue(3)
                 .Calc();

            Assert.Equal(6, _calc.Register1.Value);
            Assert.Equal(RegisterStatus.NotSet, _calc.Register2.Status);
            Assert.False(_calc.Operator.IsSet);
        }

        [Fact(DisplayName = "Clear Entry")]
        public void Test7()
        {
            _calc.SetValue(1)
                .SetOperator(OperatorType.Add)
                .SetValue(1);

            Assert.Equal(RegisterStatus.Set, _calc.Register1.Status);
            Assert.True(_calc.Operator.IsSet);
            Assert.Equal(RegisterStatus.Set, _calc.Register2.Status);

            _calc.ClearEntry();

            Assert.Equal(RegisterStatus.Set, _calc.Register1.Status);
            Assert.True(_calc.Operator.IsSet);
            Assert.Equal(RegisterStatus.NotSet, _calc.Register2.Status);

            _calc.ClearEntry();

            Assert.Equal(RegisterStatus.Set, _calc.Register1.Status);
            Assert.False(_calc.Operator.IsSet);
            Assert.Equal(RegisterStatus.NotSet, _calc.Register2.Status);

            _calc.ClearEntry();

            Assert.Equal(RegisterStatus.NotSet, _calc.Register1.Status);
            Assert.False(_calc.Operator.IsSet);
            Assert.Equal(RegisterStatus.NotSet, _calc.Register2.Status);

        }

        [Fact(DisplayName = "Clear")]
        public void Test8()
        {
            _calc.SetValue(1)
                .SetOperator(OperatorType.Add)
                .SetValue(1);

            Assert.Equal(RegisterStatus.Set, _calc.Register1.Status);
            Assert.True(_calc.Operator.IsSet);
            Assert.Equal(RegisterStatus.Set, _calc.Register2.Status);

            _calc.Clear();

            Assert.Equal(RegisterStatus.NotSet, _calc.Register1.Status);
            Assert.False(_calc.Operator.IsSet);
            Assert.Equal(RegisterStatus.NotSet, _calc.Register2.Status);
        }

        [Fact(DisplayName = "Divided by zero check")]
        public void Test9()
        {
            Assert.Throws<DivideByZeroException>(() =>
            {
                _calc.SetValue(1)
                     .SetOperator(OperatorType.Div)
                     .SetValue(0)
                     .Calc();
            });
        }

        [Fact(DisplayName = "Divided by zero check")]
        public void Test10()
        {
            Assert.Throws<DivideByZeroException>(() =>
            {
                _calc.SetValue(1)
                     .SetOperator(OperatorType.Mod)
                     .SetValue(0)
                     .Calc();
            });
        }

        [Fact(DisplayName = "")]
        public void TestBase()
        {

        }
    }
}
