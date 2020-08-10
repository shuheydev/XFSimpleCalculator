using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLogic
{
    public enum OperatorType
    {
        Add,
        Sub,
        Multi,
        Div,
        Mod,
        Equal,
    }

    public class Operator
    {
        public OperatorType Type { get; private set; }
        public bool IsSet { get; private set; }

        public Operator()
        {
        }

        public Operator(OperatorType op)
        {
            SetValue(op);
        }
        public void SetValue(OperatorType op)
        {
            this.Type = op;
            this.IsSet = true;
        }

        public void Clear()
        {
            this.IsSet = false;
        }
    }
}
