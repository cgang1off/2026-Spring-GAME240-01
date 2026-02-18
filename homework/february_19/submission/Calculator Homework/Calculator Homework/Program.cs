using System.ComponentModel.Design;

double a, b;
string operation;
string userA, userB;
    
    
Console.WriteLine("Enter your first number");
userA = Console.ReadLine();
a = double.Parse(userA);


Console.WriteLine("Enter your second number");
userB = Console.ReadLine();
b = double.Parse(userB);



Console.WriteLine("What operation do you want to do?");
operation = Console.ReadLine();

double result; 

if (operation == "addition")
{
    result = a + b;
}
    
else if (operation == "subtraction")
{
    result = a - b;
}
else if (operation == "multiplication")
{
    result = a * b;
}
else if (operation == "division")
{
    result = a / b;
    if (b == 0)
    {
        result = 0;
        Console.WriteLine("You can't divide by zero");
    }
}
else 
{
    Console.WriteLine("Sorry, you can't do that.");
    result = 0;
}



Console.WriteLine(result);
Console.WriteLine(operation);