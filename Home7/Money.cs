using System;
using System.Collections.Generic;
using System.Text;

namespace Home7
{
    public class Money
    {
        private int wholePart;
        private int coinPart;
        
        public Money() {}
        public Money(int wholePart, int coinPart)
        {
            WholePart = wholePart;
            CoinPart = coinPart;
        }
        public int WholePart
        {
            get { return wholePart; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Whole part cannot be negative");
                }
                wholePart = value;
            }
        }
        public int CoinPart
        {
            get { return coinPart; }
            set
            {
                if (value < 0 || value > 99)
                {
                    throw new ArgumentException("Coins must be between 0 and 99");
                }
                coinPart = value;
            }
        }
        public virtual void Display()
        {
            Console.WriteLine(WholePart + "." + CoinPart);
        }
        public void SetMoney(int wholePart, int coinPart)
        {
            WholePart = wholePart;
            CoinPart = coinPart;
        }
    }
}
