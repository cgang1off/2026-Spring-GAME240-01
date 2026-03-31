
double a, b;
char operation; 

Console.WriteLine("Enter your equation (ex. 12+34):");
string input =  Console.ReadLine();

int opIndex = input.IndexOfAny(['+', '-', '/', '*', '%']);

if (opIndex == -1) 
{
    Console.WriteLine("Invalid input format.");
return;
}


a = double.Parse(input.Substring(0, opIndex));

operation = input[opIndex];

b = double.Parse(input.Substring(opIndex + 1));

double result = 0;

switch (operation) 
{
    case '+':
        result = a + b;
        break;
    case '-':
        result = a - b;
        break;
    case '*':
        result = a * b;
        break;
    case '/':
        if (b == 0)
        {
            Console.WriteLine("You can't divide by zero.");
            return; 
        }
        result = a / b;
        break;
    case '%':
        result = a % b;
        break;
    default:
        Console.WriteLine("Invalid operation.");
        return;
}

Console.WriteLine("Result: " + result);
