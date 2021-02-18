﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        //Member Variables (Has A)
        private List<Coin> _register;
        private List<Can> _inventory;

        //Constructor (Spawner)
        public SodaMachine()
        {
            _register = new List<Coin>();
            _inventory = new List<Can>();
            FillInventory();
            FillRegister();
        }

        //Member Methods (Can Do)

        //A method to fill the sodamachines register with coin objects.
        public void FillRegister()
        {
            while (_register.Count < 20)
            {
                _register.Add(new Quarter());
            }
            while (_register.Count < 30)
            {
                _register.Add(new Dime());
            }
            while (_register.Count < 50)
            {
                _register.Add(new Nickel());
            }
            while (_register.Count < 100)
            {
                _register.Add(new Penny());
            }
           
        }
        //A method to fill the sodamachines inventory with soda can objects.
        public void FillInventory()
        {
            while (_inventory.Count < 5)
            {
                _inventory.Add(new RootBeer());
            }
            while (_inventory.Count < 10)
            {
                _inventory.Add(new Cola());
            }
            while (_inventory.Count < 15)
            {
                _inventory.Add(new OrangeSoda());
            }
        }
        //Method to be called to start a transaction.
        //Takes in a customer which can be passed freely to which ever method needs it.
        public void BeginTransaction(Customer customer)
        {
            bool willProceed = UserInterface.DisplayWelcomeInstructions(_inventory);
            if (willProceed)
            {
                Transaction(customer);
            }
        }
        
        //This is the main transaction logic think of it like "runGame".  This is where the user will be prompted for the desired soda.
        //grab the desired soda from the inventory.
        //get payment from the user.
        //pass payment to the calculate transaction method to finish up the transaction based on the results.
        private void Transaction(Customer customer)
        {
           
        }
        //Gets a soda from the inventory based on the name of the soda.
        private Can GetSodaFromInventory(string nameOfSoda)
        {
            nameOfSoda = UserInterface.SodaSelection(_inventory);
            foreach (Can Can in _inventory)
            {
                if (nameOfSoda.Equals(Can.Name))
                {
                    return Can;
                }
                
               
            }
        }

        //This is the main method for calculating the result of the transaction.
        //It takes in the payment from the customer, the soda object they selected, and the customer who is purchasing the soda.
        //This is the method that will determine the following:
        //If the payment is greater than the price of the soda, and if the sodamachine has enough change to return: Despense soda, and change to the customer.
        //If the payment is greater than the cost of the soda, but the machine does not have ample change: Despense payment back to the customer.
        //If the payment is exact to the cost of the soda:  Despense soda.
        //If the payment does not meet the cost of the soda: despense payment back to the customer.
        private void CalculateTransaction(List<Coin> payment, Can chosenSoda, Customer customer)
        {
            double totalValue = TotalCoinValue(payment);
            
            if (totalValue >= chosenSoda.Price)
            {
                double difference = DetermineChange(totalValue, chosenSoda.Price);

                double registerValue = 0;
                foreach (Coin coin in _register)
                {
                    registerValue += coin.Value;
                }
                if (difference <= registerValue)
                {
                    DepositCoinsIntoRegister(payment);
                    GetSodaFromInventory(chosenSoda.Name);
                    List<Coin> change = GatherChange(difference);
                    customer.AddCoinsIntoWallet(change);
                    customer.AddCanToBackpack(chosenSoda);
                    UserInterface.EndMessage(chosenSoda.Name, difference);
                }
                else if (difference > registerValue)
                {
                    Console.WriteLine("Not enough change in machine to complete transaction");
                    Console.WriteLine("Please make another selection");
                }
            }
            else
            {
                Console.WriteLine("You do not have the correct amount of change for this transaction");
            }


        }
        //Takes in the value of the amount of change needed.
        //Attempts to gather all the required coins from the sodamachine's register to make change.
        //Returns the list of coins as change to despense.
        //If the change cannot be made, return null.
        private List<Coin> GatherChange(double changeValue)
        {
            
        }
        //Reusable method to check if the register has a coin of that name.
        //If it does have one, return true.  Else, false.
        private bool RegisterHasCoin(string name)
        {
            if (_register.Count > 0)
            {
                foreach (Coin coin in _register)
                {
                    if (name == coin.Name)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            
        }
        //Reusable method to return a coin from the register.
        //Returns null if no coin can be found of that name.
        private Coin GetCoinFromRegister(string name)
        {
            if (RegisterHasCoin(name) == true)
            {
                
            }
        }
        //Takes in the total payment amount and the price of can to return the change amount.
        private double DetermineChange(double totalPayment, double canPrice)
        {
            double change = totalPayment - canPrice;
            return change;
        }
        //Takes in a list of coins to returnt he total value of the coins as a double.
        private double TotalCoinValue(List<Coin> payment)
        {
            double totalValue = 0;
            foreach (Coin coin in payment)
            {
                totalValue += coin.Value;
            }
            return totalValue;
        }
        //Puts a list of coins into the soda machines register.
        private void DepositCoinsIntoRegister(List<Coin> coins)
        {
            _register.AddRange(coins);
        }
    }
}
