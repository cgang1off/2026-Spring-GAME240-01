int [] numbers = [1, 2, 3, 4, 5];

int min = numbers[0];
int max = numbers[0];
int i = 0;

while (i < numbers.Length)
{
    if (numbers[i] < min)
    {
        min = numbers[i];
    }

    if (numbers[i] > max)
    {
        max = numbers[i];
    }

    i++;
}
 Console.WriteLine("The smallest number is: " + min);
 Console.WriteLine("The largest number is: " + max);