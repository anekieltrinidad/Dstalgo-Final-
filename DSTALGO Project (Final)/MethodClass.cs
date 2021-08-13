using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSTALGO_Project
{
    class MethodClass
    {
        Dictionary<string, string> dSongs = new Dictionary<string, string>();
        private int nTop, qTop, nCurrent;
        private bool queueEmpty;


        private string[] nQueue;
        private int qCount, qFront, qRear;

        public MethodClass()
        {
            qCount = 0; qFront = 0; qRear = -1;
            nTop = -1; qTop = -1;
            queueEmpty = true;
            nQueue = new string[5];
        }

        public int TopIndex { get { return nTop; } }
        public int QueueIndex { get { return qTop; } }
        public bool QueueEmpty { get { return queueEmpty; } }

        private void increaseSize()
        {
            string[] newArray = new string[nQueue.Length * 2];
            for (int i = 0; i < nQueue.Length; i++)
            {
                newArray[i] = nQueue[i];
            }

            nQueue = newArray;
        }

        public void ViewMenu()
        {
            Console.WriteLine("\t\t\t\t\t\t ----- Media Manager ----- \n");
            Console.WriteLine("[1] - Add Song \t\t\t [4] - View Current Song \t\t [7] - Add Song to Queue \t [x] - Exit");
            Console.WriteLine("[2] - View Songs \t\t [5] - Next Song \t\t\t [8] - View Queue");
            Console.WriteLine("[3] - Find Song \t\t [6] - Previous Song \t\t\t [9] - Delete Song");
            Console.WriteLine("");
        }

        public void AddSong(string itemID, string itemName)
        {
            if (dSongs.ContainsKey(itemID)  && !(dSongs.ContainsValue(itemName)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\nID already exists! Please choose a different Song ID"); Console.ResetColor();
                Console.WriteLine("Press <enter> to go back to main menu.");
            }

            else if (dSongs.ContainsKey(itemID) && dSongs.ContainsValue(itemName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\nSong has already been added!"); Console.ResetColor();
                Console.WriteLine("Press <enter> to go back to main menu.");
            }

            else
            {
                dSongs.TryAdd(itemID, itemName);
                nTop++;
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\nNew song successfully added!"); Console.ResetColor();
                Console.WriteLine("Press <enter> to go back to main menu.");
            }
        }

        public void ViewAll()
        {
            if (dSongs.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSong list is empty!"); Console.ResetColor();
            }

            else
            {
                Console.WriteLine("\nAdded Songs: \n");

                foreach (KeyValuePair<string, string> item in dSongs)
                {
                    Console.ForegroundColor = ConsoleColor.Green; Console.Write(item.Key); Console.ResetColor();
                    Console.Write(": ");
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(item.Value + "\n"); Console.ResetColor();
                }
            }
        }

        public void FindSong(string item)
        {
            if (dSongs.ContainsValue(item))
            {
                Console.Write("\nOne record found: ");
                foreach (KeyValuePair<string, string> song in dSongs)
                {
                    if (song.Value == item)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; Console.Write(song.Key); Console.ResetColor();
                        Console.Write(" - ");
                        Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(song.Value + "\n"); Console.ResetColor();
                    }
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n" + item); Console.ResetColor();
                Console.Write(" does not exist.");
            }
        }
        
        public object currentSong()
        {
            if (nTop > -1)
            {
                string item = nQueue[nCurrent];
                return item;
            }

            else
                throw new Exception("Track List is Empty");
        }

        public object nextSong()
        {
            List<string> listQueue = nQueue.ToList();
            for (int i = listQueue.Count - 1; i >= 0; i--)
            {
                if (listQueue[i] == null)
                {
                    listQueue.RemoveAt(i);
                }
            }

            if (nTop > - 1)
            {
                if (nCurrent == listQueue.Count- 1)
                {
                    nCurrent = 0;
                    string item = listQueue[nCurrent];
                    return item;
                }

                else
                {
                    nCurrent++;
                    string item = listQueue[nCurrent];
                    return item;
                }
            }

            else
                throw new Exception("Track List is Empty");
        }

        public object prevSong() 
        {
            List<string> listQueue = nQueue.ToList();
            for (int i = listQueue.Count - 1; i >= 0; i--)
            {
                if (listQueue[i] == null)
                {
                    listQueue.RemoveAt(i);
                }
            }

            if (nTop > -1)
            {
                if ((nCurrent - 1) == -1)
                {
                    nCurrent = listQueue.Count - 1;
                    string item = listQueue[nCurrent];
                    return item;
                }

                else
                {
                    nCurrent--;
                    string item = listQueue[nCurrent];
                    return item;
                }
            }

            else
                throw new Exception("Track List is Empty");
        }

        public void Enqueue(string item) // Duplicates are okay. Music players allow you to queue the same song multiple times. 
        {
            if (dSongs.ContainsKey(item))
            {
                foreach (KeyValuePair<string, string> songs in dSongs)
                {
                    if (songs.Key == item)
                    {
                        if (qCount < nQueue.Length)
                        {
                            qRear = (qRear + 1) % nQueue.Length;
                            nQueue[qRear] = songs.Value;
                            qCount++;
                            qTop++;

                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Song has been added to queue.\n"); Console.ResetColor();
                        }

                        else
                        {
                            increaseSize();
                            qRear = (qRear + 1) % nQueue.Length;
                            nQueue[qRear] = songs.Value;
                            qCount++;
                            qTop++;

                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Song has been added to queue.\n"); Console.ResetColor();
                        }
                    }
                }

                queueEmpty = false;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nID does not exist."); Console.ResetColor();
            }
        }
        
        public void printQueue() // Fix (Delete only works if one input is placed)
        {
            int counter = qCount; int index = qFront; int nNum = 0;
            while (counter > 0)
            {
                Console.Write((nNum + 1) + ". ");
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(nQueue[index]); Console.ResetColor();
                index = (index + 1) % nQueue.Length;
                counter--;
                nNum++;
            }
        }

        public void DeleteSong(string item) // *Fix* If song is deleted from the master list, it is also deleted in the queue.
        {
            string deletedSong; string deletedID;

            if (dSongs.ContainsKey(item))
            {
                Console.ForegroundColor = ConsoleColor.Green; Console.Write("\n" + dSongs[item]); Console.ResetColor();
                Console.Write(" will be deleted. Are you sure you want to delete?");

                string deleteChoice = "0";
                while ((deleteChoice != "Y") && (deleteChoice != "N") && (deleteChoice != "y") && (deleteChoice != "n"))
                {
                    Console.Write("\n[Y] - Yes \n[N] - No");
                    Console.Write("\n\nEnter choice: ");
                    deleteChoice = Console.ReadLine();

                    switch (deleteChoice)
                    {
                        case "Y":
                            deletedSong = dSongs[item];
                            deletedID = item;
                            dSongs.Remove(item);
                            
                            for(int i = 0; i < nQueue.Length; i++)
                            {
                                if (nQueue[i] == deletedSong)
                                {
                                    nQueue = nQueue.Where((source, index) => index != i).ToArray();
                                }
                            }

                            nTop--;
                            qTop--;

                            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("\n" + deletedID); Console.ResetColor();
                            Console.Write(" - ");
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(deletedSong); Console.ResetColor();
                            Console.Write(" has been deleted!");
                            Console.WriteLine("\nPress <enter> to go back to main menu.");
                            Console.ReadLine();
                            break;

                        case "N":
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid input. Please try again"); Console.ResetColor();
                            break;
                    }
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSong does not exist!"); Console.ResetColor();
                Console.WriteLine("Press <enter> to go back to main menu.");
                Console.ReadLine();
            }

        }
    }
}
