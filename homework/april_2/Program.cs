
while (true)
{
    Console.WriteLine("Please type a mathematical expression, or type 'quit' to shut down the calculator.");
    
    double a, b;
    double result = 0;
    char operation;
    string input;
    input = Console.ReadLine();

    if (input.ToLower() == "quit")
    {
        break;
    }

    int opIndex = input.IndexOfAny(['+', '-', '/', '*', '%']);
    
    a = double.Parse(input.Substring(0, opIndex));
    b = double.Parse(input.Substring(opIndex + 1));
    operation = input[opIndex];

    
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
                    }
                    result = a / b;
                    break;
                case '%':
                    if (b == 0)
                    {
                        Console.WriteLine("You can't divide by zero.");
                    }
                    result = a % b;
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }
        Console.WriteLine(input + " is " + result);
    }

Console.WriteLine("Goodbye!");
