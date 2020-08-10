using CalculatorLogic;
using Microsoft.Extensions.Logging;
using MvvmHelpers;
using MvvmHelpers.Exceptions;
using Sharpnado.Presentation.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFSimpleCalculator.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly ILogger<MainPageViewModel> _logger;
        private readonly Calculator _calc;

        public MainPageViewModel(ILogger<MainPageViewModel> logger, Calculator calc)
        {
            this._logger = logger;
            this._calc = calc;
        }

        private string _register1 = "0";
        public string Register1
        {
            get => _register1;
            set => SetProperty(ref _register1, value);
        }

        private bool isNewInput;

        public ICommand NumberPressedCommand => new Command<string>((param) =>
        {
            this._logger?.LogInformation($"{param} pressed.");

            if (isNewInput)
            {
                Register1 = string.Empty;
                isNewInput = false;
            }

            if (Register1 == "0")
            {
                Register1 = param;
            }
            else
            {
                Register1 += param;
            }
        });

        public ICommand OperatorPressedCommand => new Command<string>((param) =>
        {
            this._logger?.LogInformation($"{param} pressed.");

            isNewInput = true;

            var op = param switch
            {
                "+" => OperatorType.Add,
                "-" => OperatorType.Sub,
                "*" => OperatorType.Multi,
                "/" => OperatorType.Div,
                "%" => OperatorType.Mod,
                "=" => OperatorType.Equal,
                _ => throw new InvalidOperationException(),
            };

            if (int.TryParse(this.Register1, out int register1))
            {
                _calc.SetValue(register1);
                if (op == OperatorType.Equal)
                {
                    _calc.Calc();
                }
                else
                {
                    _calc.SetOperator(op);
                }

                this.Register1 = _calc.Register1.Value.ToString();
            }
        });

        public ICommand CalculatorFunctionPressedCommand => new Command<string>((param) =>
        {
            this._logger?.LogInformation($"{param} pressed.");

            switch (param)
            {
                case "CE":
                    {
                        _calc.ClearEntry();
                        break;
                    }
                case "C":
                    {
                        _calc.Clear();
                        break;
                    }
                default:
                    throw new InvalidOperationException();
            }

            Register1 = _calc.Register1.Value.ToString();
        });
    }
}
