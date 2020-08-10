using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLogic
{

    public class Calculator
    {
        public Register Register1 { get; private set; }
        public Register Register2 { get; private set; }
        public Operator Operator { get; private set; }


        public Calculator()
        {
            Register1 = new Register();
            Register2 = new Register();
            Operator = new Operator();
        }


        public Calculator SetValue(int value)
        {
            if (!Operator.IsSet)
            {
                Register1 = new Register(value);
            }
            else
            {
                Register2 = new Register(value);
            }

            return this;
        }

        public Calculator SetOperator(OperatorType op)
        {
            if(this.Operator.IsSet && this.Register2.Status==RegisterStatus.Set)
            {
                Calc();
                SetOperator(op);
            }

            this.Operator = new Operator(op);
            return this;
        }

        public void Calc()
        {
            switch (this.Operator.Type)
            {
                case OperatorType.Add:
                    {
                        this.Register1 = new Register(Register1.Value + Register2.Value);
                        break;
                    }
                case OperatorType.Sub:
                    {
                        this.Register1 = new Register(Register1.Value - Register2.Value);
                        break;
                    }
                case OperatorType.Multi:
                    {
                        this.Register1 = new Register(Register1.Value * Register2.Value);
                        break;
                    }
                case OperatorType.Div:
                    {
                        //check for null divide error
                        if (Register2.Value == 0)
                            throw new DivideByZeroException();
                        else
                            this.Register1 = new Register(Register1.Value / Register2.Value);

                        break;
                    }
                case OperatorType.Mod:
                    {
                        //check for null divide error
                        if (Register2.Value == 0)
                            throw new DivideByZeroException();
                        else
                            this.Register1 = new Register(Register1.Value % Register2.Value);
                        break;
                    }
                default:
                    throw new InvalidOperationException();
            }

            this.Operator.Clear();
            this.Register2.Clear();
        }

        public void Clear()
        {
            Register1.Clear();
            Register2.Clear();
            Operator.Clear();
        }

        public void ClearEntry()
        {
            if (Register2.Status==RegisterStatus.Set)
            {
                Register2.Clear();
                return;
            }
            if (Operator.IsSet)
            {
                Operator.Clear();
                return;
            }
            if (Register1.Status==RegisterStatus.Set)
            {
                Register1.Clear();
                return;
            }
        }
    }
}
