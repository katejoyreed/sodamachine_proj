using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        //Member Variables (Has A)
        public List<Coin> Coins;
        //Constructor (Spawner)
        public Wallet()
        {
            Coins = new List<Coin>();
            FillRegister();
        }
        //Member Methods (Can Do)
        //Fills wallet with starting money
        private void FillRegister()
        {
            while (Coins.Count < 13)
            {
                Coins.Add(new Quarter());
            }
            while (Coins.Count < 24)
            {
                Coins.Add(new Dime());
            }
            while (Coins.Count < 33)
            {
                Coins.Add(new Nickel());
            }
            while (Coins.Count < 43)
            {
                Coins.Add(new Penny());
            }
            

        }
    }
}
