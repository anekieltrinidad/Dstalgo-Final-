using System;
using System.Collections.Generic;

namespace DSTALGO_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodClass func = new MethodClass();
            var nOpt = "0";
            string songQueue;
            
            while (nOpt != "x")
            {
                func.ViewMenu();
                Console.Write("Enter your choice: ");
                nOpt = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(nOpt))
                {
                    Console.Clear();
                    func.ViewMenu();
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nInput cannot be empty. Please enter a valid option."); Console.ResetColor();
                    Console.Write("Enter your choice: ");
                    Console.ForegroundColor = ConsoleColor.Yellow; nOpt = Console.ReadLine(); Console.ResetColor();
                }

                switch (nOpt)
                {
                    case "1": // Add song
                        string songID, songName;

                        Console.Write("Enter Song ID: ");
                        Console.ForegroundColor = ConsoleColor.Yellow; songID = Convert.ToString(Console.ReadLine()); Console.ResetColor();

                        while (string.IsNullOrWhiteSpace(songID))
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nInput cannot be empty. Please enter a valid song ID."); Console.ResetColor();
                            Console.Write("Enter song ID: ");
                            Console.ForegroundColor = ConsoleColor.Yellow; songID = Console.ReadLine(); Console.ResetColor();
                        }

                        Console.Write("Enter song: ");
                        Console.ForegroundColor = ConsoleColor.Yellow; songName = Console.ReadLine(); Console.ResetColor();

                        while (string.IsNullOrWhiteSpace(songName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nInput cannot be empty. Please enter a valid name."); Console.ResetColor();
                            Console.Write("Enter song: ");
                            Console.ForegroundColor = ConsoleColor.Yellow; songName = Console.ReadLine(); Console.ResetColor();
                        }

                        func.AddSong(songID, songName);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2": // View all songs
                        if (func.TopIndex == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSong list is empty."); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        else
                        {
                            func.ViewAll();
                            Console.WriteLine("\nPress <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        
                        break;

                    case "3": // Find song
                        if (func.TopIndex == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSong list is empty."); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        else
                        {
                            string searchItem;

                            Console.Write("Search song title: ");
                            Console.ForegroundColor = ConsoleColor.Yellow; searchItem = Console.ReadLine(); Console.ResetColor();

                            while (string.IsNullOrWhiteSpace(searchItem))
                            {
                                Console.Clear();
                                func.ViewMenu();
                                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nInput cannot be empty. Please enter a valid name."); Console.ResetColor();
                                Console.Write("Search song title: ");
                                Console.ForegroundColor = ConsoleColor.Yellow; searchItem = Console.ReadLine(); Console.ResetColor();
                            }

                            func.FindSong(searchItem);
                            Console.WriteLine("\nPress <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                       
                        break;

                    case "4": // View current song
                        if (func.QueueEmpty == true || func.QueueIndex == -1 || func.TopIndex == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSong queue or Track List is empty."); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        else
                        {
                            Console.Write("\nNow Playing: ");
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(func.currentSong()); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        
                        break;

                    case "5": // Next song
                        if (func.QueueEmpty == true || func.QueueIndex == -1 || func.TopIndex == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSong queue or Track List is empty."); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        else
                        {
                            Console.Write("\nNow Playing: ");
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(func.nextSong()); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                       
                        break;

                    case "6": // Previous song
                        if (func.QueueEmpty == true || func.QueueIndex == -1 || func.TopIndex == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSong queue or Track List is empty."); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        else
                        {
                            Console.Write("\nNow Playing: ");
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(func.prevSong()); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                       
                        break;

                    case "7": // Add song to queue
                        if (func.TopIndex == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSong list is empty."); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu."); 
                            Console.ReadLine();
                            Console.Clear();
                        }

                        else
                        {
                            Console.WriteLine(" ");
                            func.ViewAll();
                            Console.Write("\nPlease enter the ID of the song to be added to queue: ");
                            Console.ForegroundColor = ConsoleColor.Yellow; songQueue = Console.ReadLine(); Console.ResetColor();

                            while (string.IsNullOrWhiteSpace(songQueue))
                            {
                                Console.Clear();
                                func.ViewMenu();
                                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nInput cannot be empty. Please enter a valid option.\n"); Console.ResetColor();
                                func.ViewAll();
                                Console.WriteLine(" ");
                                Console.Write("\nPlease enter the ID of the song to be added to queue: ");
                                Console.ForegroundColor = ConsoleColor.Yellow; songQueue = Console.ReadLine(); Console.ResetColor();
                            }

                            

                            func.Enqueue(songQueue);
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        break;

                    case "8": // View songs in queue
                        if (func.QueueEmpty == true || func.QueueIndex == -1 || func.TopIndex == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSong queue is empty."); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        else
                        {
                            func.printQueue();
                            Console.WriteLine("\nPress <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                       
                        break;

                    case "9": // Delete a song
                        if (func.TopIndex == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nSong list is empty."); Console.ResetColor();
                            Console.WriteLine("Press <enter> to go back to main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        else
                        {
                            string deleteID;

                            Console.Write("Enter Song ID: ");
                            Console.ForegroundColor = ConsoleColor.Green; Console.ResetColor();
                            deleteID = Console.ReadLine();

                            while (string.IsNullOrWhiteSpace(deleteID))
                            {
                                Console.Clear();
                                func.ViewMenu();
                                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nInput cannot be empty. Please enter a valid ID."); Console.ResetColor();
                                Console.Write("Enter Song ID: ");
                                Console.ForegroundColor = ConsoleColor.Yellow; deleteID = Console.ReadLine(); Console.ResetColor();
                            }

                            func.DeleteSong(deleteID);
                            Console.Clear();
                        }
                      
                        break;

                    case "x": // Exit
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Terminating program. Press <Enter> to continue.");
                        Console.ResetColor();
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
