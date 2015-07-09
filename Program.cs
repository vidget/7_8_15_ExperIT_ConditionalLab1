using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Gregory Scott Norris
//7-8-2015
//7_8_15_ExperIT_ConditionalLab1

namespace _7_8_15_ExperIT_ConditionalLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //sets the tempIncome
            decimal tempIncome = 0.0M;
            //accumlativeTax holds the tax as it's added together
            decimal accumulativeTax = 0.0M;
            //the variable income will holds the income sent in from the commandline argument
            decimal income;
            //holds the final calculated NET INCOME;
            decimal netIncome;

            
            bool isNumber = false; //Boolean used to determine if a number is being sent in the Command line
            //If the command argument isn't a decimal then the isNumber boolean is set to false and if true it sets the variable income to the number in sent from the command line parameter
            isNumber = decimal.TryParse(args[0], out income);

           //checks to make sure there is a number and and that income is greater than 0
         if(isNumber && income >0)
         
         {
             //sets the tempIncome to the income in order to reduce the tempIncome in the do-while loop while the tax is applied
             tempIncome = income;
             //this decimal holds the difference between the tempIncome and the the value of the tax bracket 
             decimal difference = 0M;

             //Loops through the do-while until the tempIncome=0; 
             do
             {
                 if (tempIncome > 75000)
                 {
                     difference = tempIncome - 75000; //finds the amount to be taxed above 75000
                     accumulativeTax = (difference * 0.35M); //computes the taxes only the amount above 75000 and stores it here
                     tempIncome = tempIncome - difference;
                     //subtracts the difference from the income and continues the do-while until the tempIncome = 0;
                 }
                 else if (tempIncome <= 75000 && tempIncome > 50000)//finds the amount to be taxed between 75000 and 50000
                 {
                     difference = tempIncome - 50000;//finds the amount to be taxed above 50000
                     accumulativeTax = accumulativeTax + (difference * 0.20M); //computes the taxes only the amount above 50000 and stores it here
                     tempIncome = tempIncome - difference;
                     //subtracts the difference from the income and continues the do-while until the tempIncome = 0;
                 }
                 else if (tempIncome <= 50000 && tempIncome > 20000)
                 {
                     difference = tempIncome - 20000;
                     accumulativeTax = accumulativeTax + (difference * 0.10M);
                     tempIncome = tempIncome - difference;
                     //subtracts the difference from the income and continues the do-while until the tempIncome = 0;
                 }
                 else if (tempIncome <= 20000)
                 {
                     accumulativeTax = accumulativeTax + (tempIncome * 0.05M);
                     tempIncome = 0;//sets the tempIncome to 0 ending the do-while loop because the final tax has been computed
                 }

             } while (tempIncome > 0);

             //Prints to screen the income and total tax formating the variables as strings in the currency format
             Console.WriteLine("Your total tax on " +income.ToString("C2")+" is "+ accumulativeTax.ToString("C2"));
             //calculates the netIncome by taking the original income minus the accumlative tax
             netIncome=income-accumulativeTax;
             //Prints to the netIncome as a string formated for currency
             Console.WriteLine("Leaving you with a Net Income of " + netIncome.ToString("C2"));
             Console.ReadLine();//pauses the console output

         
         }else 
         { 
             //Prints to screen when the input sent in the commandline args is not a correct value or empty. 
             Console.WriteLine("Invalid Input");
             Console.ReadLine();//pauses the console output
         
         }

            
        }
    }
}
