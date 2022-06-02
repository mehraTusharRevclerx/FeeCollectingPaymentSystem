using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeeCollectingPaymentSystem
{
    internal class Program
    {
        public static string userName;
        public static string userNo;
        public static string userAddress;
        public static string userCourse;
        public static string userAmount;
        public static string userId;
        public static string userExitorNot;
        public static int inputExit;
        static void Main()
        { 
            UserInput();
            printInfo();
            Exit();  
        }


        static void UserInput()
        {
            Console.WriteLine("\nFee Collecting Payment System For Student");
            Console.WriteLine("\nPlease Enter Your Full Name: ");
            userName = Console.ReadLine();
            while (!IsValidName(userName))
            {
                userName = Console.ReadLine();
            };

            Console.WriteLine("\nPlease Enter Your Number: ");
            userNo = Console.ReadLine();
            while (!NumberValid(userNo))
            {
                userNo = Console.ReadLine();
            };


            Console.WriteLine("\nPlease Enter Your Address: ");
            userAddress = Console.ReadLine();
            while (!AddressValid(userAddress))
            {
                userAddress = Console.ReadLine();
            };


            Console.WriteLine("\nPlease Enter Your Course Name: ");
            userCourse = Console.ReadLine();
            while (!CourseNameValid(userCourse))
            {
                userCourse = Console.ReadLine();
            };

            Console.WriteLine("\nPlease Enter Your Amount You Want to Pay: ");
            userAmount = Console.ReadLine();
            while (!AmountValid(userAmount))
            {
                userAmount = Console.ReadLine();
            };



            Console.WriteLine("\nPlease Enter Your Student Id: ");
            userId = Console.ReadLine();
            while (!IdValid(userId))
            {
                userId = Console.ReadLine();
            }

        }
        static void printInfo()
        {
            Console.WriteLine($"\n{userName} Your Fee is submitted successfully\n");
            Console.WriteLine($"Payment Date: {PrintDate()}");
            Console.WriteLine($"RefID: {RandNo()}");
            Console.WriteLine($"StudentID: {userId}");
            Console.WriteLine($"Name: {userName}");
            Console.WriteLine($"Address: {userAddress}");
            Console.WriteLine($"Mobile No: {userNo}");
            Console.WriteLine($"Course Name: {userCourse}");
            Console.WriteLine($"Amount Payed: {userAmount}");
            Console.WriteLine($"\nThanks for Using our service");
        }
        static string PrintDate()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            return dateTime.ToString("dd/MM/yyyy");
        }

        static int RandNo()
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            return myRandomNo;
        }



        static void Exit()
        {
            Console.WriteLine($"Do You Wish To Pay Fees For the Another Student\n1.Yes \n2.Exit");
            userExitorNot = Console.ReadLine();

            while (!ExitValid(userExitorNot))

            {
                userExitorNot = Console.ReadLine();
            }


            if (inputExit == 1)
            {
                Main();
            }

            if (inputExit == 2)
            {
                Environment.Exit(0);
            }

        }
        // VALIDATION METHODS
        public static bool IsValidName(string nameInput)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(nameInput))
            {
                Console.WriteLine("Name Input Can't Be Empty!(PLEASE ENTER THE INPUT AGAIN)");
                isValid = false;
            }
            else
            {

                if (nameInput.Length <= 3)
                {
                    Console.WriteLine("Name Input Should Be More Than 2 Character!(PLEASE ENTER THE INPUT AGAIN)");
                    isValid = false;

                }
                else if (nameInput.Length >= 15)
                {
                    Console.WriteLine("Name Input Should Be less Than 15 Character!(PLEASE ENTER THE INPUT AGAIN)");
                    isValid = false;
                }
                else
                {

                    foreach (char c in nameInput)
                    {
                        if (!Char.IsLetter(c))
                        {
                            Console.WriteLine("Name Input Should Only Contains Characters No Special Character or Number Allowed (PLEASE ENTER THE INPUT AGAIN)");
                            isValid = false;
                            return false;
                        }
                    }
                }

            }
            return isValid;
        }


        public static bool NumberValid(string inputString)
        {
            bool isValid = true;

            Console.WriteLine(inputString.Length);

            if (inputString.Length == 10)
            {

                foreach (char c in inputString)
                {
                    if (!Char.IsDigit(c))
                    {
                        Console.WriteLine("Please Provide Only Numbers In the Number Input");
                        isValid = false;
                        return false;
                    }
                }

            }
            else
            {
                Console.WriteLine("Please Provide Correct Length of the Number(LENGTH SHOULD BE NOT MORE THEN OR LESS THAN 10)");
                isValid = false;
            }


            return isValid;
        }

        public static bool AddressValid(string inputAddress)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(inputAddress))
            {
                Console.WriteLine("Address Input Should Not be Empty(PLEASE ENTER THE INPUT AGAIN)");
                isValid = false;
            }
            else
            {

                if (inputAddress.Length < 8)
                {
                    Console.WriteLine("Address Input Should Be More than 8 Character(PLEASE ENTER THE INPUT AGAIN)");
                    isValid = false;
                }
                else if (inputAddress.Length > 50)
                {
                    Console.WriteLine("Address Input Should Be Less Than 50 Character(PLEASE ENTER THE INPUT AGAIN)");
                    isValid = false;
                }
            }
            return isValid;
        }

        public static bool CourseNameValid(string inputAddress)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(inputAddress))
            {
                Console.WriteLine("Course Input Should Not be Empty(PLEASE ENTER THE INPUT AGAIN)");
                isValid = false;
            }
            else
            {

                if (inputAddress.Length < 3)
                {
                    Console.WriteLine("Course Input Should Be More than 8 Character(PLEASE ENTER THE INPUT AGAIN)");
                    isValid = false;
                }
                else if (inputAddress.Length > 50)
                {
                    Console.WriteLine("Address Input Should Be Less Than 50 Character(PLEASE ENTER THE INPUT AGAIN)");
                    isValid = false;
                }
            }
            return isValid;
        }


        public static bool AmountValid(string inputString)
        {
            bool isValid = true;

            if (double.TryParse(inputString, out double amount))
            {


                double minAmount = 1000;
                double maxAmount = 10000;
                if (amount < minAmount)
                {
                    Console.WriteLine("Your Amount is less than 1000 Fees can't be paid(Please Repay)");
                    isValid = false;
                }
                else if (amount > maxAmount)
                {
                    Console.WriteLine("Your Amount is More than 10000 Fees can't be paid(Please Repay)");
                    isValid = false;
                }
            }
            else
            {
                Console.WriteLine("Please Enter Amount In the Correct Format(PLEASE ENTER THE INPUT AGAIN)");
                isValid = false;
            }


            return isValid;
        }


        public static bool IdValid(string inputString)
        {
            bool isValid = true;


            if (inputString.Length < 5) //20201
            {
                Console.WriteLine("Length is small for the Student Id(Please Input Again)");
                isValid = false;

            }
            else if (inputString.Length > 8)
            {
                Console.WriteLine("Length is long for the Student Id(Please Input Again)");
                isValid = false;
            }
            else
            {

                foreach (char c in inputString)
                {
                    if (!Char.IsDigit(c))
                    {
                        Console.WriteLine("Please Provide Only Numbers In the Student id Input");
                        isValid = false;
                        return false;
                    }
                }
            }


            return isValid;
        }

        public static bool ExitValid(string input)
        {
            bool isValid = true;
            if (int.TryParse(input, out inputExit))
            {
                if (inputExit == 1 || inputExit == 2)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Please Provide Correct Info 1 or 2");
                    isValid = false;
                }
            }
            else
            {
                Console.WriteLine("Please Provide Correct Info 1 or 2");
                isValid = false;


            }
            return isValid;
        }



    }
}
