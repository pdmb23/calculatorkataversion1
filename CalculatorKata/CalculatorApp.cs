using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorKata
{
    public class CalculatorApp
    {
        #region Fields
        List<string> inputCollection;
        List<double> numberCollection;
        Queue<string> decimalNumberCollection;
        Queue<string> operatorCollection;
        List<string> operationList;
        double runningTotal;
        #endregion

        #region Properties
        #endregion

        #region Constructor

        public CalculatorApp()
        {
            this.inputCollection = new List<string>();
            this.numberCollection = new List<double>();
            this.operatorCollection = new Queue<string>();
            this.decimalNumberCollection = new Queue<string>();
            this.operationList = new List<string>() { "+", "-", "*", "/" };
            this.runningTotal = 0;
        }

        #endregion

        #region Methods

        public void Input(string token)
        {
            this.inputCollection.Add(token);
        }

        public double GetAnswer()
        {
            this.LexicalAnalysis();
            var operatorValue = string.Empty;
            double num = 0;
            for (int i = 0; i < this.numberCollection.Count; i++)
            {
                num = this.numberCollection[i];
                if (i == 0)
                {
                    this.runningTotal = num;
                    continue;
                }
                else
                {
                    if (this.operatorCollection.Count >= 1)
                    {
                        operatorValue = this.operatorCollection.Dequeue();
                    }
                    switch (operatorValue)
                    {
                        case "+": this.runningTotal += num;
                            break;
                        case "-": this.runningTotal -= num;
                            break;
                        case "*": this.runningTotal *= num;
                            break;
                        case "/": this.runningTotal /= num;
                            break;
                    }
                }
            }
            return Math.Round(this.runningTotal, 1);
        }

        private bool IsNumber(string entry)
        {
            int numberValue;
            if (Int32.TryParse(entry, out numberValue))
            {                
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsDecimalSeparator(string entry)
        {
            if (entry == ".")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsOperator(string entry)
        {
            if (this.operationList.Contains(entry))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LexicalAnalysis()
        {
            int index = 0;
            while (index < this.inputCollection.Count)
            {
                var currentToken = this.GetInput(index);
                if (IsNumber(currentToken))
                {
                    string decimalNumberValue = this.DecimalNumberParse(ref index, ref currentToken);
                    this.numberCollection.Add(Convert.ToDouble(decimalNumberValue));
                }                
                else if (IsOperator(currentToken))
                {
                    this.operatorCollection.Enqueue(currentToken);
                    index++;
                }
            }
        }

        private string DecimalNumberParse(ref int index, ref string currentToken)
        {
            string decimalNumberValue = string.Empty;
            this.IntegerNumberParse(ref index, ref currentToken);
            var lookAhead = this.GetInput(index);
            if (IsDecimalSeparator(lookAhead))
            {
                this.decimalNumberCollection.Enqueue(lookAhead);
                index = index + 1;
                currentToken = this.GetInput(index);
                this.IntegerNumberParse(ref index, ref currentToken);
            }            
            while (this.decimalNumberCollection.Count > 0)
            {
                decimalNumberValue = decimalNumberValue + this.decimalNumberCollection.Dequeue();
            }
            return decimalNumberValue;
        }

        private void IntegerNumberParse(ref int index, ref string currentToken)
        {
            while (IsNumber(currentToken))
            {
                this.decimalNumberCollection.Enqueue(currentToken);
                index = index + 1;
                currentToken = this.GetInput(index);
            }
        }

        private string GetInput(int index)
        {
            if (index < this.inputCollection.Count)
            {
                return this.inputCollection[index];
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion
    }
}