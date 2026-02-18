Console.WriteLine("What is your first name?");
string firstName;
string lastName; 

firstName = Console.ReadLine();

Console.WriteLine("What is your last name?");
lastName = Console.ReadLine();

string message = "We share a name.";

if (firstName == "Chloe")
{
    Console.WriteLine(message);
}

if (lastName == "Gangloff")
{
    Console.WriteLine(message);
}