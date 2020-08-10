using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLogic
{
    public enum RegisterStatus
    {
        Set,
        NotSet,
        ZeroDivideError,
    }
    public class Register
    {
        public int Value { get; private set; }
        public RegisterStatus Status { get; private set; }

        public Register()
        {
            this.Status = RegisterStatus.NotSet;
        }
        public Register(int value)
        {
            SetValue(value);
        }

        public void SetValue (int value)
        {
            this.Value = value;
            this.Status = RegisterStatus.Set;
        }

        public void Clear()
        {
            this.Value = 0;
            this.Status = RegisterStatus.NotSet;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
