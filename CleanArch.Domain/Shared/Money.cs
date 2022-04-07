using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Shared
{
    public class Money : BaseValueObject
    {
        public Money()
        {

        }
        public int Value { get; private set; }

        public Money(int rialValue)
        {
            if (rialValue < 0 )
            {
                throw new InvalidDataException();
            }
            Value = rialValue;
        }
        public static Money FromRial(int value)
        {
            return new Money(value);
        }
        public static Money FromTooman(int value)
        {
            return new Money(value*10);
        }
        public static Money operator +(Money firstMoney, Money Money2)
        {
            return new Money(firstMoney.Value + Money2.Value);
        }

        public override string ToString()
        {
            return Value.ToString("#,0");
        }

        public static Money operator -(Money firstMoney, Money Money2)
        {
            return new Money(firstMoney.Value - Money2.Value);
        }
    }
}

