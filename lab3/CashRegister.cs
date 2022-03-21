using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class CashRegister
    {
        private readonly int[] _coins = new int[3];

        private static int ONE = 0;
        private static int TWO = 1;
        private static int FIVE = 2;

        public CashRegister(int[] coins)
        {
            _coins = coins;
        }

        public CashRegister(int one, int two, int five)
        {
            _coins[0] = one;
            _coins[1] = two;
            _coins[2] = five;
        }

        private int getAmount(int[] coins)
        {
            return (coins[ONE] * 1) + (coins[TWO] * 2) + (coins[FIVE] * 5);
        }

        private int getRemainder(int[] income, int amount)
        {
            return getAmount(income) - amount;
        }

        private void registerCash(int[] income)
        {
            _coins[ONE] += income[ONE];
            _coins[TWO] += income[TWO];
            _coins[FIVE] += income[FIVE];
        }

        private int[] calculateRest(int amount)
        {
            int[] rest = new int[3] { 0, 0, 0 };

            while (_coins[FIVE] > 0 && amount >= 5)
            {
                rest[FIVE]++;
                amount -= 5;
            }

            while (_coins[TWO] > 0 && amount >= 2)
            {
                rest[TWO]++;
                amount -= 2;
            }

            while (_coins[ONE] > 0 && amount >= 1)
            {
                rest[ONE]++;
                amount -= 2;
            }

            if (amount > 0) return new int[] {};
            else
            {
                _coins[ONE] -= rest[ONE];
                _coins[TWO] -= rest[TWO];
                _coins[FIVE] -= rest[FIVE];
                return rest;
            }
        }

        public int[] Payment(int[] income, int amount)
        {
            if (getAmount(income) < amount) return new int[] { };
            int[] rest = calculateRest(getRemainder(income, amount));
            if (rest != new int[] {}) registerCash(income);
            return rest;
        }


        public override string ToString()
        {
            return $"##### Kasa fiskalna: #####" +
                $"\n Monety:" +
                $"\n 1zł - {_coins[ONE]} szt." +
                $"\n 2zł - {_coins[TWO]} szt." +
                $"\n 5zł - {_coins[FIVE]} szt." +
                $"\n### WYDRUK NIEFISKALNY ###";
        }
    }
}
