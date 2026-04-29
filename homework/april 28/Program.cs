//If a file doesn't exist, keep asking the user for a new file path until one works.
//works if done correctly but doesn't do this^



string specialFish = "anything";
string fish;

bool isFilePathValid = false;
Console.WriteLine("Hey you! Where is the file for the special?"); //C:\Users\ChloeGangloff\documents\Rider files\week 10\Fish Monger HW\sample_files\specials\1.txt
    string filepath = Console.ReadLine();

    while (isFilePathValid == false)
    {
        try
        {
            StreamReader reader = new StreamReader(filepath);
            string firstLine = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(firstLine) || !firstLine.Contains("special"))
            {
                throw new Exception("Invalid specials file format.");
            }
            Console.WriteLine(firstLine);
            string[] specialparts = firstLine.Split(' ');
            specialFish = specialparts[specialparts.Length - 1].Trim('.');
            isFilePathValid = true;
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("I think you misspelled the file name.");
            Console.WriteLine("Where is the file for the special?");
            filepath = Console.ReadLine();
        }
        
    }

int specialCount = 0;
int totalCount = 0;

bool isFilePathValid2 = false;
Console.WriteLine("How about the file for the log?"); //C:\Users\ChloeGangloff\documents\Rider files\week 10\Fish Monger HW\sample_files\logs\1.txt
string filepath2 = Console.ReadLine();

            while (isFilePathValid2 == false)
            {
                try
                {
                    string[] lines = File.ReadAllLines(filepath2);
                    
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(' ');
                        int count = int.Parse(parts[0]);
                        fish = parts[1];

                        totalCount += count;

                        if (fish == specialFish)
                        {
                            specialCount += count;
                        }
                    }
                    isFilePathValid2 = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("I think you misspelled the file name.");
                    Console.WriteLine("Where is the file for the log?");
                    filepath2 = Console.ReadLine();
                }
            }

            StreamWriter writer = new StreamWriter("Chloe's results.txt");
                writer.WriteLine("The special today is " + specialFish);
                writer.WriteLine("The total fish caught today is " + totalCount);
                writer.WriteLine("The total number of the special caught today is " + specialCount);
                writer.Close();

                Console.WriteLine("Result saved in Chloe's result.txt");
                
                
        
                
                
                
              /*  
//class notes 4/28/26
//need to have declared and variable and given it some scope but those dont have to happen next to each other

                string log; //how to change scope of a variable -- don't need to declare a variable the same place you use it.
                string specialName;

                try
                {
                    StreamReader logFile = new StreamReader("log.txt");
\                        log = logFile.ReadToEnd();

                }
                catch (Exception e)
                {
                    
                }

                try
                {
                    StreamReader specialFile = new StreamReader("special.txt");
                    specialName = specialFile.ReadLine();
                }
                catch (Exception e)
                {
                    specialName = "";
                }

Console.WriteLine(specialName);
Console.WriteLine(log);
*/