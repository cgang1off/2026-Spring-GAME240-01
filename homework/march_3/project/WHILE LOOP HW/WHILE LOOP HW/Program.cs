// 1) a while loop that loops from 1 to 5 (5total) and writes each number on the console.
/*
int index = 0;
index = 0;

string[] number;
number = new string[] { "1", "2", "3", "4", "5"};

while (index < number.Length)
{
    Console.WriteLine(number[index]);
    index = index + 1;
}
*/
   

//2) write one that counts from 100 to 150
/*
int number;
number = 100;
while (number <= 150)
{
    Console.WriteLine(number);
    number++;
}
*/


//3) one that counts even numbers 0 to 100
/*
int number;
number = 0;
while (number <= 100)
{
    Console.WriteLine(number);
    number = number + 2;
}
*/


//4) counts down from 20 to -20
/*
int number;
number = 20;
while (number > -20)
{
    Console.WriteLine(number);
    number = number - 1;
}
*/



//5) counts 1 to 100 by 3's
/*
int number;
number = 1;
while (number <= 100)
{
    Console.WriteLine(number);
    number = number + 3;
}
*/


//6) counts 1 to 1024 going up by powers of 2
/*
int number;
number = 1;
while (number <= 1024)
{
    Console.WriteLine(number);
    number = number + 2;
}
*/


//7) Write a do-while loop that asks the user each time if they want the loop to stop, and keeps running until the user responds "yes"
/*
Console.Write("The loop has started. ");
Console.WriteLine("Do you want the loop to stop?");
string response;
response = Console.ReadLine();
do
{
    Console.WriteLine("Do you want the loop to stop?");
    
    if (Console.ReadLine() == "yes")
    {
        Console.Write("The loop has stopped.");
        break;
    }
} while (response == "no");
*/

//8) Write a while loop that alternates forever between writing True and False
/*
 while (true)
{
    Console.WriteLine("true");
    Console.WriteLine("false");
}
*/


//9) Write a while loop counts from 1 to 20 and have it write whether a number is even or odd
/*
int number;
number = 0;
while (number < 20)
{
    number++;
    if (number % 2 == 0)
    {
        Console.WriteLine(number + " is odd");
    }
    else
    {
        Console.WriteLine(number + " is even");
    }
}
*/


/* 10) Create an array of strings with the values ["once", "upon", "a", "midnight", "dreary"].
Create a while loop that writes one word at a time to the console*/
/*
string once = "once";
string upon = "upon";
string a = "a";
string midnight = "midnight";
string dreary = "dreary";

while (true)
{
    Console.WriteLine(once);
    Console.WriteLine(upon);
    Console.WriteLine(a);
    Console.WriteLine(midnight);
    Console.WriteLine(dreary);
}
*/


/* 11) Create a while loop that counts from 1 to 45.
Every time a number is a multiple of 3, write "fizz".
    Every time a number is a multiple of 5, write "buzz".
    If a number is a multiple of both 3 and 5, write "fizzbuzz".
    For all other numbers, write the number itself.*/


int number;
number = 0;

while (number < 45)
{
    number++;
    if (number % 3 == 0)
    {
        Console.WriteLine("fizz");
        if (number % 5 == 0)
            {
            Console.WriteLine("fizzbuzz");
            }
        else if (number % 5 == 0)
        {
            Console.WriteLine("buzz");
        }
    }
    else
    {
        Console.WriteLine(number);
    }
}
