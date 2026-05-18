
using System.ComponentModel.Design;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

//TO WIN:
//go into hallway (E,E,S) and go east until you reach another bedroom
//(E,E,S) take the book from the bookshelf and go to attic -- (N,W) take sword
//go back to hallway and go downstairs to living room. Go east (E,E,S) until you reach the garden 
//take branch - use sword to make a wooden stake
//go back to living room, go west (W,W,W,W,N)until you get to the dungeon
//(N,N) open the lid of the crypt, fight the vampire using ONLY the sword until she's at 1 HP
//at 1 HP DO NOT grab the key. Use the wooden stake to finish her
//THEN grab the key and go to living room
//Go south (S,S,W,W) until you find double doors, use key to open


void TypeText(string text)
{
    foreach (char c in text)
    {
        Console.Write(c);
        Thread.Sleep(50);
    }
    Console.WriteLine();
}



TypeText("Text Adventure 2026");
TypeText("Press any key to start the game...");
Console.ReadKey();
Console.Clear();
TypeText("You wake up in a dimly lit room with stone walls. You notice that you are in a bed and you have no items in your possession.");
Thread.Sleep(millisecondsTimeout: 500);
TypeText("To check your inventory type 'inventory' or 'i'");
Thread.Sleep(millisecondsTimeout: 500);
TypeText("You remember being lost in a blizzard and happening upon a gothic castle.");
Thread.Sleep(millisecondsTimeout: 500);
TypeText("Inside it was warm but there was no one to be found...");
Thread.Sleep(millisecondsTimeout: 2000);
TypeText("You rack your brain trying to remember how you got into this bed but...");
Thread.Sleep(millisecondsTimeout: 3000);
TypeText("you can't.");
Thread.Sleep(millisecondsTimeout: 2000);




    (int x, int y, string location) MoveInDirection(string additional, int x, int y, string location, ref bool Bed2Visited, ref bool KeyTaken, ref bool VampireDead, ref bool BookTaken, ref bool DoorHandleTaken, List <string> inventory, List <string> RoomsVisited, bool InChair)
    {
        int NewX = x;
        int NewY = y;
        int minX, maxX, minY, maxY;
        
        if (location == "bedroom1")
        {
            minX = 0; maxX = 2;
            minY = -2; maxY = 0;
        }
        else if (location == "hallway")
        {
            minX = 0; maxX = 4;
            minY = 0; maxY = 0;
        }
        else if (location == "bedroom2")
        {
            minX = 0; maxX = 2;
            minY = -1; maxY = 1;
        }
        else if (location == "living room")
        {
            minX = -2; maxX = 2;
            minY = -2; maxY = 0;
        }
        else if (location == "attic")
        {
            minX = -1; maxX = 0;
            minY = 0; maxY = 1;
        }
        else if (location == "dungeon")
        {
            minX = -2; maxX = 0;
            minY = 0; maxY = 2;
        }
        else if (location == "garden")
        {
            minX = 0; maxX = 1;
            minY = -1; maxY = 0;
        }
        else // fallback
        {
            minX = 0; maxX = 2;
            minY = -2; maxY = 0;
        }
        
            if (additional == "west")
           {
               NewX--;
           }
           else if (additional == "east")
           {
                NewX++;
           }
           else if (additional == "north")
           {
               NewY++;
           }
           else if (additional == "south")
           {
               NewY--;
           }
           else if ((additional == "through door" || additional == "east") && location == "bedroom1" && x==2 && y==-1)
           {
               TypeText("As you go to grab the handle, you notice the beautiful intricate designs carved into the door.");
               Thread.Sleep(500);
               TypeText("You can't tell what they mean though.");
               Thread.Sleep(500);
               TypeText("The door opens easily and you step into a hallway lit by dying candles. You can hardly see what lies at the other end.");
               location = "hallway";
               if (!RoomsVisited.Contains(location))
               {
                   RoomsVisited.Add(location);
               }
               return (0, 0, location);
           }
            else if ((additional == "through door" || additional == "east") && location == "hallway" && x==4)
            {
                TypeText("The door opens and you enter a bedroom almost identical to the one you woke up in.");
                location = "bedroom2";
                if (!RoomsVisited.Contains(location))
                {
                    RoomsVisited.Add(location);
                }
                return (0, 0, location);
            }
            else if ((additional == "downstairs" || additional == "down stairs"|| additional == "down stair" || additional == "south") && RoomsVisited.Contains("hallway") && x == 2)
           {
               TypeText("Your footsteps echo throughout the stairwell as you walk. You hear a skittering noise but it's too dark to tell what it was.");
               Thread.Sleep(500);
               TypeText("You see the light of the next room getting bigger and bigger.");              
               Thread.Sleep(500);
               TypeText("As you emerge, you find yourself in a living room.");
               location = "living room";
               if (!RoomsVisited.Contains(location))
               {
                   RoomsVisited.Add(location);
               }
               return (0, 0, location);
           }
            else if ((additional == "downstairs" || additional == "down stairs"|| additional == "down stair" || additional == "south") && location=="attic" && x == 0 && y == 0)
            {
                TypeText("You are back in the bedroom.");
                location = "bedroom2";
                x = 2;
                y = -1;
                return (x, y, location);
            }
            else if ((additional == "upstairs" || additional == "north" || additional == "up stairs" || additional == "up stair") && RoomsVisited.Contains("living room") && location == "living room" && x==0 && y==0)
            {
                TypeText("You go back up the creepy staircase.");
                location = "hallway";
                if (!RoomsVisited.Contains(location))
                {
                    RoomsVisited.Add(location);
                }
                return(2, 0, location);
            }
           else if (location == "bedroom2" && BookTaken && x==2 && y == -1 && (additional == "up stairs" || additional == "upstairs" || additional == "up stair" || additional == "east"))
           {
               TypeText("You have to crouch as you climb the stairs.");
               Thread.Sleep(500);
               TypeText("You arrive in a tiny attic filled with colorful light, let in by a stained glass window.");
               location = "attic";
               if (!RoomsVisited.Contains(location))
               {
                   RoomsVisited.Add(location);
               }
               return (0, 0, location);
           }
            else if (additional == "to bed" && location == "bedroom2" && x == 2 && y == 1 && Bed2Visited == false)
            {
                TypeText("You are not tired.");
                Bed2Visited = true;
            }
           else
           {
               TypeText("I don't know how to move in that direction.");
               return (x, y, location);
           }
            
           if (location == "garden" && additional == "west" && NewX == -1)
           {
               TypeText("You are glad to be back inside where it's warm.");
               location = "living room";
               return (2, -1, location);
           }
           
           if ((additional == "up" || additional == "out" || additional == "out of chair") && location == "living room" && x==2 && y==0 && InChair)
           {
               TypeText("You get out of the chair.");
               location = "living room";
               if (!RoomsVisited.Contains(location))
               {
                   RoomsVisited.Add(location);
               }
               x = 2;
               y = 0;
           }
           
           if (location == "bedroom2" && additional == "west" && NewX == -1)
           {
               TypeText("You are now in the hallway.");
               location = "hallway";
               return (4, 0, location);
           }

           if (location == "attic" && NewY == -1)
           {
               TypeText("You descend the spiral staircase.");
               location = "bedroom2";
               if (!RoomsVisited.Contains(location))
               {
                   RoomsVisited.Add(location);
               }
               return (2, -1, location);
           }
           if (location == "hallway" && NewX == -1 && DoorHandleTaken == false)
           {
               TypeText("The door handle breaks clean off.");
               inventory.Add("door handle");
               DoorHandleTaken = true;
           }
           else if (location == "hallway" && NewX == -1 && DoorHandleTaken == true)
           {
               TypeText("The door is broken, you can't go through.");
           }
           if (location == "bedroom1" && NewX == 3 && y == -1)
           {
               TypeText("As you go to grab the handle, you notice the beautiful intricate designs carved into the door.");
               Thread.Sleep(500);
               TypeText("You can't tell what they mean though.");
               Thread.Sleep(500);
               TypeText("The door opens easily and you step into a hallway lit by dying candles. You can hardly see what lies at the other end.");
               location = "hallway";
               if (!RoomsVisited.Contains(location))
               {
                   RoomsVisited.Add(location);
               }
               return (0, 0, location);
           }
           if (location == "hallway" && NewX == 5)  // east out of hallway
           {
               TypeText("The door opens and you enter a bedroom almost identical to the one you woke up in.");
               location = "bedroom2";
               if (!RoomsVisited.Contains(location))
               {
                   RoomsVisited.Add(location);
               }
               return (0, 0, location);
           }

           if ((location == "hallway" && NewY == -1 && x == 2) ||  // south at stairwell
               additional == "downstairs" || additional == "down stairs")
           {
               TypeText("Your footsteps echo throughout the stairwell...");
               Thread.Sleep(500);
               TypeText("As you emerge from the stairwell you find yourself in a living room.");
               location = "living room";
               if (!RoomsVisited.Contains(location))
               {
                   RoomsVisited.Add(location);
               }
               return (0, 0, location);
           }

           if (location == "dungeon" && additional == "east" && x == 0 && y == 0)
           {
               TypeText("You are glad to be out of the dungeon. It was too dark for your liking.");
               location = "living room";
               x = -2;
               y = 0;
           }
           
           if ((location == "bedroom2" && BookTaken && x == 2 && y == -1) && (additional == "upstairs" || additional == "up stairs"))
           {
               TypeText("You have to crouch as you climb the stairs.");
               Thread.Sleep(500);
               TypeText("You arrive in a tiny attic filled with colorful light.");
               location = "attic";
               if (!RoomsVisited.Contains(location))
               {
                   RoomsVisited.Add(location);
               }
               return (0, 0, location);
           }

           if (NewX > maxX || NewX < minX || NewY > maxY || NewY < minY)
           {
               TypeText("You hit a wall.");
               return (x, y, location);
           }
           TypeText("You moved " + additional + ".");
           return (NewX, NewY, location);
    }


    


    (string location, int x, int y, bool GameRunning) OpenSomething(string additional, int x, int y, string location, ref bool InFight, ref bool DoorHandleTaken, ref bool GameRunning, bool PaintingVisited, ref bool VampireAwake, List <string> inventory, List <string> RoomsVisited)
    {
        if (additional == "coffin" || additional== "crypt" || additional == "lid")
        {
            TypeText("You slowly slide the heavy stone to the side and peak in.");
            Thread.Sleep(500);
            TypeText("The blood rushes from your face and your heart rate speeds up.");
            Thread.Sleep(1000);
            if (PaintingVisited == false)
            {
                TypeText("There's a person in there...");
                Thread.Sleep(500);
                TypeText("and she looks far from dead.");
            }
            else
            {
                TypeText("You recognize her...");
                Thread.Sleep(2000);
                TypeText("The woman from the painting.");
            }
            TypeText("Her eyes fly open and meet yours.");
            Thread.Sleep(300);
            TypeText("You jump back in terror.");
            Thread.Sleep(300);
            TypeText("'You!?' she says lunging at you.");
            Thread.Sleep(500);
            TypeText("You dodge, narrowly missing her sharp nails. She now stands between you and the exit...");
            Thread.Sleep(1300);
            TypeText("You're trapped.");
            Thread.Sleep(500);
            VampireAwake = true;
            InFight = true;
        }
        else if (additional == "door" && location == "bedroom1" && x==2 && y==-1)
        {
            TypeText("As you go to grab the handle, you notice the beautiful intricate designs carved into the door.");
            Thread.Sleep(500);
            TypeText("You can't tell what they mean though.");
            Thread.Sleep(500);
            TypeText("The door opens easily and you step into a hallway lit by dying candles. You can hardly see what lies at the other end.");
            location = "hallway";
            if (!RoomsVisited.Contains(location))
            {
                RoomsVisited.Add(location);
            }
            return (location, 0, 0, GameRunning);
        }
        else if (additional == "door" && location == "bedroom2" && x == 0 && y == 0)
        {
            TypeText("You are now in the hallway.");
            location = "hallway";
            x = 4;
            y = 0;
        }
        else if (additional == "door" && location == "hallway" && x == 0 && y==0 && DoorHandleTaken==false)
        {
                TypeText("The door handle breaks clean off.");
                inventory.Add("door handle");
                DoorHandleTaken = true;
        }
        else if (additional == "door" && location == "hallway" && x == 0 && y == 0 && DoorHandleTaken == true)
        {
            TypeText("The door is broken, you can't open it.");
        }
        else if (additional == "door" && location == "hallway" && x == 4)
        {
            TypeText("The door opens and you enter a bedroom almost identical to the one you woke up in.");
            location = "bedroom2";
            if (!RoomsVisited.Contains(location))
            {
                RoomsVisited.Add(location);
            }
            return (location, 0, 0, GameRunning);
        }
        else if (additional == "door" && location == "living room" && x == -2 && y == 0)
        {
            TypeText("You pull open the door with some difficulty and it makes a loud screeching sound.");
            Thread.Sleep(500);
            TypeText("The ceiling drips and rats scuttle about as you descend deeper into the castle...");
            location = "dungeon";
            if (!RoomsVisited.Contains(location))
            {
                RoomsVisited.Add(location);
            }
            return (location, 0, 0, GameRunning);
        }
        else if (additional == "door" && location == "living room" && x == 2 && y == -1)
        {
            TypeText("You step out into a humble garden. Not much is growing.");
            location = "garden";
            if (!RoomsVisited.Contains(location))
            {
                RoomsVisited.Add(location);
            }
            return (location, 0, 0, GameRunning);
        }
        else if ((additional == "door" || additional == "doors") && location == "living room" && x == 0 && y == -2)
        {
            if (inventory.Contains("key"))
            {
                TypeText("You use the key to unlock the doors and push them open.");
                Thread.Sleep(500);
                TypeText("The cold winter air hits your face but you don't care. You're just glad to be out of this castle.");
                TypeText("You Win!");
                GameRunning = false;
            }
            else
            {
                TypeText("The door is locked.");
                location = "living room";
                if (!RoomsVisited.Contains(location))
                {
                    RoomsVisited.Add(location);
                }
                x = 0;
                y = -2;
            }
        }
        else if ((additional == "door" || additional == "west") && location == "garden" && x == 0 & y == 0)
        {
            TypeText("You leave the garden and are glad to be back in the warmth of the living room.");
            location = "living room";
            if (!RoomsVisited.Contains(location))
            {
                RoomsVisited.Add(location);
            }
            x = 2;
            y = -1;
        }
        else if (additional == "door" && location == "dungeon" && x == 0 && y == 0)
        {
            TypeText("You're glad to be out of the dungeon. It was too dark for your liking.");
            location = "living room";
            if (!RoomsVisited.Contains(location))
            {
                RoomsVisited.Add(location);
            }
            x = -2;
            y = 0;
        }
        else
        {
            TypeText("I don't know how to open " + additional + ".");
        }

        return (location, x, y, GameRunning);
    }



    bool TakeItem(string additional, int x, int y, string location, ref bool MarbleTaken, ref bool Bed2Visited, ref bool CandleTaken, ref bool KeyExists, ref bool BookTaken, List <string> inventory, bool WindowBroken, ref bool VampireDead, bool AddItem, ref bool SwordTaken, ref bool BranchTaken, ref bool NoteTaken, ref bool GobletTaken, ref bool KeyTaken)
    {
        if (additional == "sword" && x==-1 && y==1 && location=="attic" && SwordTaken == false) 
        {
            if (inventory.Count >= 3)
            {
                TypeText("Your inventory is full.");
                return false;
            }
            TypeText("You gingerly lift the sword from it's mount and wave it around a few times.");
            Thread.Sleep(700);
            if (WindowBroken == false)
            {
                TypeText("It glimmers in the morning light streaming through the stained glass window.");
            }
            inventory.Add("sword");
            SwordTaken = true;
        }
        else if (additional == "sword" && x == -1 && y == 1 && location == "attic" && SwordTaken)
        {
           TypeText("You have already taken the sword."); 
        }
        else if (additional == "marble" && location == "living room" && x==-1 & y==0 && !MarbleTaken)
        {
            TypeText("You take a piece of marble. It's heavy.");
            inventory.Add("marble");
        }
        else if (additional == "marble" && location == "living room" && x == -1 & y == 0 && MarbleTaken)
        {
            TypeText("The marble is too heavy for you to carry another piece.");
        }
        else if (additional == "candle" && location == "hallway" && CandleTaken == false)
        {
            TypeText("You take a candle. It doesn't give much light.");
            inventory.Add("candle");
            CandleTaken = true;
        }
        else if ((additional == "branches" || additional == "branch") && x==1 && y==0 && location=="garden" && !BranchTaken) 
        {
            if (inventory.Count >= 3)
            {
                TypeText("Your inventory is full.");
                return false;
            }
        
            TypeText("You tug at a branch and it breaks free with a snap.");
            inventory.Add("branch");
            BranchTaken = true;
        }
        else if ((additional == "branches" || additional == "branch") && x == 1 && y == 0 && location == "garden" &&
                 BranchTaken == true)
        {
            TypeText("There are no more branches.");
        }
        else if ((additional == "note") && x==-2 && y==0 && location=="dungeon" && NoteTaken == false) 
        {
            if (inventory.Count >= 3)
            {
                TypeText("Your inventory is full.");
                return false;
            }
            TypeText("You take the note.");
            Thread.Sleep(450);
            TypeText("It reads: The Lady of the house is cruel. I have been down here for what I think is a week. I have not seen the sun in what I think is four.");
            Thread.Sleep(300);
            TypeText("If you are reading this, the Lady keeps the key on her at all times. Good luck.");
            inventory.Add("note");
            NoteTaken = true;
        }
        else if ((additional == "note") && x == -2 && y == 0 && location == "dungeon" && NoteTaken)
        {
            TypeText("You have already taken the note.");
        }
        else if (additional == "key" && location =="dungeon" && VampireDead && KeyTaken == false) 
        {
            if (inventory.Count >= 3)
            {
                TypeText("Your inventory is full.");
                return false;
            }
                TypeText("You take the key from the pile of ash and dust it off. It's heavy and embedded with a dark Ruby.");
                inventory.Add("key");
                KeyTaken = true;
            
        }
        else if (additional == "key" && location == "dungeon" && VampireDead && KeyTaken) 
        {
            TypeText("You have already taken the key.");
        }
        else if (additional == "goblet" && x==1 && y==0 && location=="living room" && GobletTaken == false)
        {
            if (inventory.Count >= 3)
            {
                TypeText("Your inventory is full.");
                return false;
            }
            TypeText("You take the goblet.");
            Thread.Sleep(700);
            TypeText("Inside is a dark rust colored water line. Your nose wrinkles at the metallic smell.");
            inventory.Add("goblet");
            GobletTaken = true;
        }
        else if (additional == "goblet" && x == 1 && y == 0 && location == "living room" && GobletTaken == true)
        {
            TypeText("You have already taken the goblet.");
        }
        else if (additional == "painting" && location == "bedroom1")
        {
            TypeText("It won't budge.");
        }
        else if (additional == "book" && location == "bedroom2" && x == 2 && y == -1)
        {
            TypeText("You try to pull the book off the shelf but something holds it in place. You hear the groan of machinery as the bookshelf descends into the floor, revealing a cramped spiral staircase leading upwards.");
            BookTaken = true;
        }
        else if (additional == "in bed" && location == "bedroom2" && x == 2 && y == 1 && Bed2Visited == false)
        {
            TypeText("You're not tired.");
            Bed2Visited = true;
        }
        else
        {
            TypeText("There is no " + additional + ".");
        }

        return (AddItem);
    }


    void UseItem(string additional, ref int x, ref int y, ref string location, ref string command, ref bool GameRunning, List<string> inventory, List <string> RoomsVisited)
    {
        //use sword on branch 
        string item = additional;
        string item2 = "";

        if (additional.Contains(" on "))
        {
            string[] killSplit = additional.Split(new string[] { " on " }, StringSplitOptions.None);
            item = killSplit[0]; // "sword"
            item2 = killSplit[1]; // "branch" 
        }

        if (item == "")
        {
            TypeText("On what?");
            item = Console.ReadLine().ToLower();
        }

        if (item == "sword" && item2 == "branch"  && inventory.Contains("sword") &&
            inventory.Contains("branch"))
        {
            TypeText("You sharpen the branch into a wooden stake.");
            inventory.Remove("branch");
            inventory.Remove("branches");
            inventory.Add("wooden stake");
            return;
        }
        
        if (item == "sword" && item2 == "branch" && !inventory.Contains("sword") &&
                 inventory.Contains("branch"))
        {
            TypeText("You need something sharp to make a wooden stake.");
        }
        else if (item == "sword" && item2 == "branch" && inventory.Contains("sword") &&
                 !inventory.Contains("branch"))
        {
            TypeText("You need wood to make a wooden stake.");
        }
        else
        {
            TypeText("You can't do that.");
            return;
        }

    if (item == "sword")
        {
            if (inventory.Contains("sword"))
            {
                TypeText("You swing your sword."); //vampire fight....
            }
            else
            {
                TypeText("You don't have a sword.");
            }
        }
        else if (item == "wooden stake") 
        {
            if (inventory.Contains("wooden stake"))
            {
                TypeText("You used the wooden stake.");
            }
            else
            {
                TypeText("You don't have a wooden stake.");
            }
        }
        
    if (item == "key")
        {
            if (location == "living room" && x==0 && y==-2 && inventory.Contains("key"))
            {
                TypeText("You use the key to unlock the doors and you push them open with a small struggle.");
                Thread.Sleep(500);
                TypeText("The cold winter air hits your face but you don't care. You're just glad to be out of this castle.");
                Thread.Sleep(3000);
                TypeText("You Win!");
                GameRunning = false;
            }
            else if (inventory.Contains("key"))
            {
                TypeText("You can't use the key here.");
            }
            else
            {
                TypeText("You don't have a key.");
            }
        }
        
    if (item == "door handle") 
        {
            if (inventory.Contains("door handle"))
            {
                TypeText("It does nothing.");
            }
            else
            {
                TypeText("You don't have a door handle.");
            }
        }
    
    if (item == "branch" || item == "branches")
        {
            if (inventory.Contains("branch") || inventory.Contains("branches"))
            {
                TypeText("It does nothing");
            }
            else
            {
                TypeText("You don't have any branches.");
            }
        }
        
    if (item == "note")
        {
           if (inventory.Contains("note"))
           {
               TypeText("The paper crumples even more. It does nothing.");
           }
           else
           {
               TypeText("Are you seeing things? You don't have a note.");
           }
        }
        else if (item == "stairs" && location == "hallway" && x == 2 && y==0)
            {
                TypeText("Your footsteps echo throughout the stairwell as you walk. You hear a skittering noise but it's too dark to tell what it was.");
                Thread.Sleep(1000);
                TypeText("You see the light of the next room getting bigger and bigger.");              
                Thread.Sleep(500);
                TypeText("As you emerge, you find yourself in a living room.");
                location = "living room";
                if (!RoomsVisited.Contains(location))
                {
                    RoomsVisited.Add(location);
                }
                x = 0; 
                y = 0;
            }
        else if (item == "stairs" && location == "bedroom2" && x == 2 && y == -1)
        {
            TypeText("You have to crowch as you climb the stairs.");
            Thread.Sleep(500);
            TypeText("You arrive in a tiny attic filled with colorful light. A stained glass window lets the morning light in.");
            location = "attic";
            if (!RoomsVisited.Contains(location))
            {
                RoomsVisited.Add(location);
            }
            x = 0;
            y = 0;
        }
        else
        {
            TypeText("You don't have a " + item + " to use.");
        }
    }

    bool BreakSomething(string additional, int x, int y, string location, ref bool StatueBroken, List<string> inventory, bool WindowBroken)
    {
        if (additional == "window" && x == -1 && y == 1 && location == "attic")
        {
            if (WindowBroken != true)
            {
                if (inventory.Contains("sword"))
                {
                    TypeText("You hate joy and whimsy, huh? You smash the window with your sword. The attic is now devoid of color.");
                    WindowBroken = true;
                }
                else if (!inventory.Contains("sword") && inventory.Contains("door handle"))
                {
                    TypeText("You hate joy and whimsy, huh? You smash the window with the door handle. The glass scratches you.");
                    Thread.Sleep(700);
                    TypeText("The attic is now devoid of color.");
                    WindowBroken = true;
                }
                else if (!inventory.Contains("sword") && !inventory.Contains("door handle"))
                {
                    TypeText("You hate joy and whimsy, huh? You smash the window with your hands. They drip with blood.");
                    WindowBroken = true;
                }
            }
            else if (WindowBroken)
            {
                TypeText("You can't do that the window is already broken.");
            }
        }
        else if (additional == "statue" && location == "living room" && x==-1 && y==0 && !StatueBroken)
        {
            TypeText("You push the statue and it falls over with a great crash. Chunks of marble scatter everywhere.");
            StatueBroken = true;
        }
        else if (additional == "window")
        {
            TypeText("There's no window here.");
        }
        else
        {
            TypeText("You can't break " + additional + ".");
        }

        return (WindowBroken);
    }

    void MakeItem(string additional, List<string> inventory)
    {
        //make wooden stake.    
        if (additional == "wooden stake" && inventory.Contains("sword") && inventory.Contains("branch"))
        {
            TypeText("You sharpen the branch into a wooden stake.");
            inventory.Remove("branch");
            inventory.Remove("branches");
            inventory.Add("wooden stake");
        }
        else if (additional == "wooden stake" && inventory.Contains("sword") && !inventory.Contains("branch"))
        {
            TypeText("You need wood to make a wooden stake.");
        }
        else if (additional == "wooden stake" && !inventory.Contains("sword") && inventory.Contains("branch"))
        {
            TypeText("You need something to sharpen the branch with.");
        }
        else 
        {
            TypeText("You can't do that.");
        }
    }


   (bool VampireDead, bool GameRunning) KillSomething(string additional, ref bool VampireAwake, string location, int VampireHP, ref bool WasInFight, ref bool KeyExists, List<string> inventory, ref bool VampireDead, bool PaintingVisited, ref bool GameRunning)
    { 
       string target = additional;
       string weapon = "";

        if (additional.Contains(" with "))
        {
            string[] killSplit = additional.Split(new string[]{" with "}, StringSplitOptions.None);
            target = killSplit[0];   // "vampire"
            weapon = killSplit[1];   // "wooden stake" or "sword"
        }
        if (weapon == "")
        {
            if (target == "vampire" && !VampireAwake)
            {
                TypeText("There is no vampire.");
            }
            else
            {
                TypeText("With what?");
                weapon = Console.ReadLine().ToLower();
            }
        }
        if (target == "self")
        {
            TypeText("Your will to live is stronger, you decide against it.");
        }
        else if (target == "vampire" && VampireDead)
        {
            TypeText("Nothing happens but the ash flies up and makes you cough.");
            Thread.Sleep(500);
            TypeText("Did you really think you could kill a pile of ash?");
        }
        else
        {
            TypeText("You can't do that.");
        }

        return (VampireDead, GameRunning);
    }

    void DropSomething(string additional, List<string> inventory)
    {
        if (additional == "sword")
        {
            TypeText("You dropped sword.");
            inventory.Remove("sword");
        }
        else if (additional == "marble")

        {
            TypeText("You dropped the piece of marble with a thud");
            inventory.Remove("marble");
        }
        else if (additional == "wooden stake")
        {
            TypeText("You dropped the wooden stake.");
            inventory.Remove("wooden stake");
        }
        else if  (additional == "key")
        {
            TypeText("You dropped the key.");
            inventory.Remove("key");
        }
        else if (additional == "goblet")
        {
            TypeText("You dropped the goblet.");
            inventory.Remove("goblet");
        }
        else if (additional == "note")
        {
            TypeText("You dropped the note.");
            inventory.Remove("note");
        }
        else if (additional == "branch")
        { 
            TypeText("You dropped the branch.");
            inventory.Remove("branch");
        }
        else if (additional == "candle" && inventory.Contains("candle"))
        {
            TypeText("You dropped the candle.");
            inventory.Remove("candle");
        }
        else if (additional == "door handle" && inventory.Contains("door handle"))
        {
            TypeText("You dropped the door handle.");
            inventory.Remove("door handle");
        }
        else if (!inventory.Contains(additional))
        {
            TypeText("You don't have a " + additional + ".");
        }
    }

    void SitDown(string additional, string location, int x, int y, ref bool InChair)
    {
        if (additional == "chair" && location == "living room" && x == 2 && y == 0 && InChair == false)
        {
            TypeText("You sit in the chair. It's very nice.");
            InChair = true;
        }
        else if (additional == "in chair" && location == "living room" && x == 2 && y == 0 && InChair == true)
        {
            TypeText("You're already sitting down.");
        }
        else
        {
            TypeText("You don't feel like sitting down.");
        }
    }
    

TypeText("What would you like to do?");
string input;
string command;
string additional;
string location = "bedroom1";
string item = "None";
bool VampireDead = false;
bool WindowBroken = false;
bool StatueBroken = false;
bool BigDoorsVisited = false;
bool PaintingVisited = false;
bool VampireAwake = false;
bool DoorHandleTaken = false;
bool GobletTaken = false;
bool MarbleTaken = false;
bool SwordTaken = false;
bool NoteTaken = false;
bool BranchTaken = false; 
bool KeyTaken = false;
bool BookTaken = false;
bool KeyExists = false;
bool CandleTaken = false;
bool InChair = false;
bool InFight = false;
bool FinalPhaseStarted = false;
bool WasInFight = false;
bool AddItem = true;
bool Bed2Visited = false;
int VampireHP = 4;
int PlayerHP = 4;
int PlayerTurns = 3;
int VampireTurns = 3;
int x = 0;
int y = 0;
bool GameRunning = true;
List<string> inventory = new List<string>();
List<string> RoomsVisited = new List<string>();
RoomsVisited.Add(location);


while (GameRunning)
{
    int NewX = 0;
    int NewY = 0;
    input = Console.ReadLine()?.ToLower();

    if (string.IsNullOrWhiteSpace(input))
    {
        TypeText("Type a command.");
        continue;
    }

    string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    command = splitInput[0];
    additional = splitInput.Length > 1 ? string.Join(" ", splitInput.Skip(1)): "";
    
    if (command == "inventory" || command == "i")
    {
        if (inventory.Count == 0)
        {
            TypeText("You aren't carrying anything.");
        }
        else
        {
            TypeText("You are carrying: " + string.Join(", ", inventory));
        }
    }
    else
    {
        try
        {
            if (command == "go" || command == "move")
            {
                if (string.IsNullOrWhiteSpace(additional))
                {
                    TypeText("Where do you want to go?");
                    additional = Console.ReadLine().ToLower();
                }
                (x, y, location) = MoveInDirection(additional, x, y, location, ref Bed2Visited, ref KeyTaken,
                    ref VampireDead, ref BookTaken, ref DoorHandleTaken, inventory, RoomsVisited, InChair);

                // TypeText($"DEBUG POSITION: x={x}, y={y}");
                //TypeText($"DEBUG: location={location}, vampireDead={VampireDead}, keyTaken={KeyTaken}");

                if (location == "bedroom1" && x == 2 && y == -1)
                {
                    TypeText("You've reached a door.");
                }
                else if (location == "bedroom1" && x == 1 && y == -2)
                {
                    TypeText("On the wall in front of you is a painting of a Victorian woman with dark pinned up hair.");
                    Thread.Sleep(1500);
                    TypeText("She is beautiful.");
                    Thread.Sleep(700);
                    TypeText("You wonder if she is the owner of the castle.");
                    PaintingVisited = true;
                }
                else if (location == "hallway" && x == 2)
                {
                    TypeText("A stairwell descends to the South.");
                }
                else if (location == "hallway" && x == 4 && !RoomsVisited.Contains("bedroom2"))
                {
                    TypeText("You reach a similar door to the one in your bedroom.");
                }
                else if (location == "bedroom2" && x == 2 && y == -1 && !RoomsVisited.Contains("attic"))
                {
                    TypeText(
                        "In front of you is a bookshelf full of classics. You admire the decorated spine of a book of Shakespearean plays.");
                }
                else if (location == "bedroom2" && x == 2 && y == -1 && RoomsVisited.Contains("attic"))
                {
                    TypeText("The bookshelf looks like it never even moved.");
                }
                else if (location == "bedroom2" && x == 2 && y == 1)
                {
                    TypeText("You find a bed identical to the one you woke up in.");
                }
                else if (location == "living room" && x == -2 && y == 0 && !RoomsVisited.Contains("dungeon"))
                {
                    TypeText(
                        "You reach a scary looking cellar door. Nothing about it stands out, but it makes you uncomfortable nevertheless.");
                }
                else if (location == "living room" && x == 0 && y == -2)
                {
                    if (BigDoorsVisited == false)
                    {
                        TypeText(
                            "You reach a big set of double doors. Seeing them again, it hits you that these were the doors you entered the castle through.");
                        BigDoorsVisited = true;
                    }
                    else if (BigDoorsVisited && KeyTaken)
                    {
                        TypeText("You reach the double doors.");
                    }
                }
                else if (location == "living room" && x == 2 && y == -1 && !RoomsVisited.Contains("garden"))
                {
                    TypeText("You reach a door.");
                }
                else if (location == "living room" && x == 1 && y == 0)
                {
                    if (!inventory.Contains("goblet"))
                    {
                        TypeText("You find a coffee table. On top of it is a goblet encrusted with jewels.");
                    }
                    else
                    {
                        TypeText("You find a coffee table.");
                    }
                }
                else if (location == "living room" && x == 2 && y == 0)
                {
                    TypeText("There is a fancy cushioned chair.");
                }
                else if (location == "living room" && x == -1 && y == 0)
                {
                    TypeText("A magnificent marble statue of a Greek goddess stands in front of you.");
                }
                else if (location == "garden" && x == 1 && y == 0)
                {
                    TypeText(
                        "A fallen tree branch lays at your feet. You look up at the tree it came from and notice that it's snowing.");
                }
                else if (location == "dungeon" && x == 0 && y == 2)
                {
                    TypeText(
                        "You come upon a crypt made of smooth stone. The carvings on the lid are unlike anything you've ever seen.");
                }
                else if (location == "dungeon" && x == -2 && y == 0)
                {
                    if (!inventory.Contains("note"))
                    {
                        TypeText("You step on a crumpled note.");
                    }
                }
                else if (location == "attic" && x == -1 && y == 1)
                {
                    if (!inventory.Contains("sword") && WindowBroken == false)
                    {
                        TypeText(
                            "A magnificent sword is mounted on the North facing wall. The wall to the West has a colorful stained glass window.");
                    }
                    else if ((!inventory.Contains("sword")) && RoomsVisited.Contains("attic"))
                    {
                        TypeText("The sword doesn't look as good without the colorful light.");
                    }
                }
            }
            else if (command == "take" || command == "pick" || command == "pull" || command == "get" ||
                     command == "grab" || command == "steal")
            {
                if (command == "pick" && additional.StartsWith("up "))
                {
                    if (string.IsNullOrWhiteSpace(additional))
                    {
                        TypeText("What do you want to pick up?");
                        additional = Console.ReadLine().ToLower();
                    }
                    additional = additional.Substring(3);
                    TakeItem(additional, x, y, location, ref MarbleTaken, ref Bed2Visited, ref CandleTaken,
                        ref KeyExists, ref BookTaken, inventory, WindowBroken, ref VampireDead, AddItem, ref SwordTaken,
                        ref BranchTaken, ref NoteTaken, ref GobletTaken, ref KeyTaken);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(additional))
                    {
                        TypeText("What do you want to take?");
                        additional = Console.ReadLine().ToLower();
                    }
                    TakeItem(additional, x, y, location, ref MarbleTaken, ref Bed2Visited, ref CandleTaken,
                        ref KeyExists, ref BookTaken, inventory, WindowBroken, ref VampireDead, AddItem, ref SwordTaken,
                        ref BranchTaken, ref NoteTaken, ref GobletTaken, ref KeyTaken);
                }
            }
            else if (command == "break" || command == "destroy")
            {
                if (string.IsNullOrWhiteSpace(additional))
                {
                    TypeText("What do you want to break?");
                    additional = Console.ReadLine().ToLower();
                }
                WindowBroken = BreakSomething(additional, x, y, location, ref StatueBroken, inventory, WindowBroken);
            }
            else if (command == "kill")
            {
                if (string.IsNullOrWhiteSpace(additional))
                {
                    TypeText("What do you want to kill?");
                    additional = Console.ReadLine().ToLower();
                }
                (VampireDead, GameRunning) = KillSomething(additional, ref VampireAwake, location, VampireHP, ref WasInFight,
                    ref KeyExists, inventory, ref VampireDead, PaintingVisited, ref GameRunning);
            }
            else if (command == "use")
            {
                if (string.IsNullOrWhiteSpace(additional))
                {
                    TypeText("What do you want to use?");
                    additional = Console.ReadLine().ToLower();
                }
                UseItem(additional, ref x, ref y, ref location, ref command, ref GameRunning, inventory, RoomsVisited);
            }
            else if (command == "make")
            {
                if (string.IsNullOrWhiteSpace(additional))
                {
                    TypeText("What do you want to make?");
                    additional = Console.ReadLine().ToLower();
                }
                MakeItem(additional, inventory);
            }
            else if (command == "open")
            {
                if (string.IsNullOrWhiteSpace(additional))
                {
                    TypeText("What do you want to open?");
                    additional = Console.ReadLine().ToLower();
                }
                (location, x, y, GameRunning) = OpenSomething(additional, x, y, location, ref InFight,ref DoorHandleTaken, ref GameRunning, PaintingVisited, ref VampireAwake, inventory, RoomsVisited);
            }
            else if (command == "drop")
            {
                if (string.IsNullOrWhiteSpace(additional))
                {
                    TypeText("What do you want to drop?");
                    additional = Console.ReadLine().ToLower();
                }
                DropSomething(additional, inventory);
            }
            else if (command == "sit")
            {
                if (string.IsNullOrWhiteSpace(additional))
                {
                    TypeText("Where do you want to sit?");
                    additional = Console.ReadLine().ToLower();
                }
                SitDown(additional, location, x, y, ref InChair);
            }

            while (InFight && PlayerHP > 0 && VampireHP > 0)
            {
                TypeText($"HP: You={PlayerHP} Vampire={VampireHP}");
                Thread.Sleep(200);
                TypeText($"Turns left: {PlayerTurns}");
                Thread.Sleep(200);

                if (PlayerTurns <= 0)
                {
                    TypeText("You are too exhausted to continue fighting...");
                    Thread.Sleep(500);
                    TypeText("The vampire attacks!");
                    GameRunning = false;
                    break;
                }

                TypeText("What do you do?");
                string action = Console.ReadLine().ToLower();

                PlayerTurns--; // THIS is what enforces 3 decisions

                string[] parts = action.Split(' ');
                string verb = parts[0];
                string target = parts.Length > 1 ? string.Join(" ", parts.Skip(1)) : "";

                if (verb == "attack" || verb == "kill" || verb == "hit")
                {
                    if (target == "")
                    {
                        TypeText("With what?");
                        PlayerTurns++; // give turn back if unclear input
                        target = Console.ReadLine().ToLower().Trim();
                    }
                    
                    if (target.Contains("sword") && inventory.Contains("sword"))
                    {
                        switch (VampireHP)
                        {
                            case 4:
                            {
                                TypeText("You slash the vampire with your sword!");
                                VampireHP--;
                                break;
                            }
                            case 3:
                            {
                                TypeText("You slash the vampire with your sword! It cuts her arm.");
                                VampireHP--;
                                break;
                            }
                            case 2:
                            {
                                TypeText("You swing your sword and the vampire falls to the ground.");
                                VampireHP--; //she gets to 1HP and its saying the lines how do i fix that
                                PlayerHP = 1;
                                FinalPhaseStarted = true;
                                break;
                            }
                        }
                    }
                    else if (target.Contains("wooden stake") && inventory.Contains("wooden stake"))
                    {
                        TypeText("She's too fast, you can't get close enough to use it.");
                        PlayerTurns++;
                    }
                    else if (target.Contains("wooden stake") && !inventory.Contains("wooden stake"))
                    {
                        TypeText("You do not have a wooden stake.");
                    }
                    else if (target.Contains("door handle") && inventory.Contains("door handle"))
                    {
                        TypeText("You hit her across the head with the door handle.");
                        Thread.Sleep(500);
                        TypeText("It does nothing.");
                    }
                    else if (target.Contains("sword") && !inventory.Contains("sword"))
                    {
                        TypeText("You don't have a sword.");
                    }
                    else
                    {
                        TypeText("While you fumble around in your inventory...");
                        PlayerHP--;
                    }
                }
                else if (verb == "run" || verb == "move")
                {
                    TypeText("You try to run but...");
                    Thread.Sleep(500);
                    TypeText("The vampire slashes your back before you can escape.");
                    PlayerHP--;
                }
                else if (verb == "grab")
                {
                    TypeText("You reach for something...anything...but the vampire gets you first.");
                    Thread.Sleep(500);
                    TypeText("You take damage.");
                    PlayerHP--;
                }
                else
                {
                    TypeText("You hesitate...");
                    PlayerHP--;
                }

                // vampire turn 
                if (VampireHP > 1)
                {
                    if (target.Contains("wooden stake") && VampireHP != 1 && inventory.Contains("wooden stake"))
                    {
                        TypeText("The vampire hesitates, scared of the stake in your hand.");
                        VampireTurns++;
                    }
                    else
                    {
                        TypeText("The vampire attacks!");
                        PlayerHP--;
                    }
                }
                else if (VampireHP > 1 && PlayerHP == 1)
                {
                    TypeText("The vampire grabbed you and sunk her teeth into your neck.");
                    Thread.Sleep(500);
                    TypeText("The last thing you feel before your vision goes dark is pain...");
                    Thread.Sleep(500);
                }

                if (VampireHP == 1 && FinalPhaseStarted)
                {
                    TypeText("She struggles to get up, weakened by your attacks.");
                    Thread.Sleep(500);
                    TypeText("Your sword broke the chain keeping the key around her neck.");
                    Thread.Sleep(500);
                    TypeText("It clatters to the floor by your feet.");
                    TypeText($"HP: You={PlayerHP} Vampire={VampireHP}");
                    KeyExists = true;
                    action = Console.ReadLine().ToLower();
                    parts = action.Split(' ');
                    verb = parts[0];
                    target = parts.Length > 1 ? string.Join(" ", parts.Skip(1)) : "";

                    if (verb == "attack" || verb == "kill" || verb == "use")

                    {
                        if (inventory.Contains("wooden stake") && target.Contains("wooden stake"))
                        {
                            TypeText("You drive the wooden stake into the vampire's chest!");
                            Thread.Sleep(700);
                            TypeText("She lets out an awful scream as her body crumbles into ash.");
                            Thread.Sleep(500);
                            VampireDead = true;
                            VampireHP = 0;
                            InFight = false;
                        }
                        else if (target.Contains("wooden stake") && !inventory.Contains("wooden stake"))
                        {
                            TypeText("You do not have a wooden stake.");
                            Thread.Sleep(500);
                            TypeText("While you were wishing you had one, the vampire lunged at you.");
                            Thread.Sleep(1000);
                            TypeText("You died...");
                            PlayerHP = 0;
                        }
                        else if (target.Contains("sword") && inventory.Contains("sword"))
                        {
                            TypeText(
                                "You stab the vampire with your sword and she lets out a guttural scream of pain before going silent.");
                            Thread.Sleep(1000);
                            TypeText("...");
                            Thread.Sleep(1000);
                            TypeText(
                                "She stands up pulling the sword from your grasp and further into her abdomen. You stumble back in fear as she pulls the sword out of her and throws it to the ground.");
                            Thread.Sleep(500);
                            if (PaintingVisited)
                            {
                                TypeText(
                                    "The Lady of the house lunges at you and the last thing you feel is a ripping, piercing pain in your neck. Then...");
                            }
                            else
                            {
                                TypeText(
                                    "The vampire lunges at you and the last thing you feel is a ripping, piercing pain in your neck. Then...");
                                Thread.Sleep(1000);
                                TypeText("nothing.");
                                Thread.Sleep(2500);
                                TypeText("Can't kill vampires with swords, stupid.");
                                Thread.Sleep(2000);
                                TypeText("Game Over.");
                                PlayerHP = 0;
                            }
                        }
                        else if (target.Contains("sword") && !inventory.Contains("sword"))
                        {
                            TypeText("You don't have a sword.");
                            Thread.Sleep(500);
                            TypeText("The vampire lunges at you and you feel a sharp pain in your neck.");
                            Thread.Sleep(500);
                            TypeText("The last thing you feel is pain.");
                            PlayerHP = 0;
                            Thread.Sleep(500);
                            TypeText("You died...");
                        }
                    }
                    else if (verb == "grab" || verb == "take" || verb == "pick up")
                    {
                        TypeText("You reach for the key...");
                        Thread.Sleep(1000);
                        TypeText("The vampire suddenly grabs your throat and bites it.");
                        Thread.Sleep(700);
                        TypeText("You were too greedy. While you were picking up the key, she recovered from your attacks.");
                        Thread.Sleep(1000);
                        TypeText("You died.");
                        PlayerHP = 0;
                        GameRunning = false;
                    }
                }
                
                if (PlayerHP <= 0)
                {
                    TypeText("Game Over.");
                    InFight = false;
                    GameRunning = false;
                }
                
                if (VampireHP <= 0)
                {
                    TypeText("You defeated the vampire!");
                    InFight = false;
                }
            }
        }
        catch (Exception e)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                TypeText("Type a command.");
                continue;
            }
        }
    }
}

















//if the error you get is "unhandled exception" -- use a catch statement
