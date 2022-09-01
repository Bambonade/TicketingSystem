using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file="Tickets.csv";
            string choice;

            do{
                // ask user a question
                Console.WriteLine("1) Read ticket information.");
                Console.WriteLine("2) Add ticket information.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();
                
                if(choice == "1"){
                    if(File.Exists(file)){
                        StreamReader sr = new StreamReader(file);
                        while(!sr.EndOfStream){
                            Console.WriteLine(sr.ReadLine());
                        }
                    }~
                    else{
                        Console.WriteLine("File does not exist");
                    }
                }
                else if(choice == "2"){
                    // create file from data
                    StreamWriter sw = new StreamWriter(file);
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("Enter ticket information (Y/N)?");
                        string ticketEntryChoice = Console.ReadLine().ToUpper();
                        if (ticketEntryChoice != "Y") {break;}
                        Console.WriteLine("Enter Ticket ID");
                        String ticketID = Console.ReadLine();
                        Console.WriteLine("Enter Ticket Summary");
                        String summary = Console.ReadLine();
                        Console.WriteLine("Enter Ticket Status");
                        String status = Console.ReadLine();
                        Console.WriteLine("Enter Ticket Priority");
                        String priority = Console.ReadLine();
                        Console.WriteLine("Enter the Ticket Submitter");
                        String submitter = Console.ReadLine();
                        Console.WriteLine("Enter Person Assigned");
                        String assigned = Console.ReadLine();
                        List<string> people = new List<string>();
                        string watchChoice;
                        do
                        {
                            Console.WriteLine("Enter person watching (Y/N)?");
                            watchChoice = Console.ReadLine().ToUpper();
                            if (watchChoice != "Y") {break;}
                            Console.WriteLine("Enter the person that is watching");
                            people.Add(Console.ReadLine());
                        } while (watchChoice == "Y");
                        sw.Write("{0},{1},{2},{3},{4},{5},", ticketID, summary, status, priority, submitter, assigned);
                        string lastPerson = people.LastOrDefault();
                        foreach(string person in people)
                        {
                            if (person.Equals(lastPerson))
                            {
                                sw.Write(person + "\n");
                            }
                            else
                            {
                                sw.Write(person + "|");
                            }
                        }
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
