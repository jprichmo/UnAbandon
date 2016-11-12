using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUnAbandon
{
    public class UserInterface
    {
        //variable to control UI loop
        public static bool exit = false;

        //Loop user interface
        public static void Loop()
        {
            while (!exit)
            {
                SelectOption(MenuOptions());
            }
        }

        //Display the menu
        public static char MenuOptions()
        {
            char option;
            char check;

            Console.WriteLine("\n\tPHASE 3 MENU\n");
            Console.WriteLine("\tOption 0: Load New Data");
            Console.WriteLine("\tOption 1: Add Item");
            Console.WriteLine("\tOption 2: Modify Item");
            Console.WriteLine("\tOption 3: Search and Display Results");
            Console.WriteLine("\tOption 4: Display Number of Items Stored");
            Console.WriteLine("\tOption 5: Exit");
            Console.Write("\n\tPlease select an option from the list: ");

            check = Convert.ToChar(Console.ReadLine().Substring(0, 1));

            while (check < '0' || check > '5')
            {
                Console.Write("\n\tPlease choose 0, 1, 2, 3, 4, or 5: ");
                Console.ReadLine();
                check = Convert.ToChar(Console.ReadLine().Substring(0, 1));
            }

            option = Convert.ToChar(check);
            return option;
        }

        //Control for user selection
        public static void SelectOption(char opt)
        {
            //char sel;
            switch (opt)
            {
                case '0':
                    ClearAllData();
                    LoadData();
                    break;
                case '1':
                    AddItem();
                    DisplayAddedItem();
                    break;
                case '2':
                    DisplayStoredItems();
                    ModifyItem();
                    break;
                case '3':
                    SearchItems();
                    break;
                case '4':
                    DisplayCount();
                    break;
                case '5':
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\n\tThat is not a valid input.\n");
                    break;
            }
        }

        //Clear all data from collection
        public static void ClearAllData()
        {
            //call static method in ProjectCollection Class
            //to use list.clear()
            ProjectCollection.ClearAllData();
        }
        
        //Load data into collection
        public static void LoadData()
        {
            //call static method in ProjectCollection Class to fill the list
            ProjectCollection.FillProjectObjects();
        }

        //Add an item to the collection
        public static void AddItem()
        {
            ProjectCollection.AddProjectToList();
        }

        //Display last added item
        public static void DisplayAddedItem()
        {
            ProjectCollection.DisplayAddedItem();
        }

        //Display all project items and fields
        public static void DisplayStoredItems()
        {
            ProjectCollection.DisplayAll();
        }
        
        //Display the number projects
        public static void DisplayCount()
        {
            int count = ProjectCollection.GetCount();
            Console.WriteLine("The total number of records so far is : {0}",
                count);
        }

        //Modify a project item and field user has selected
        public static void ModifyItem()
        {
            Console.WriteLine("Enter the ITEM NUMBER you wish to modify: ");
            int sel = Convert.ToInt32(Console.ReadLine());
            if (sel < 0 || sel > (ProjectCollection.GetCount() - 1))
            {
                Console.WriteLine("Enter a number from 0 to {0}: ", (ProjectCollection.GetCount()-1));
                sel = Convert.ToInt32(Console.ReadLine());
            }
            //Console.WriteLine(sel);
            ProjectCollection.Modify(sel);
        }

        //Display all projects and search for a field with a user defined value
        public static void SearchItems()
        {
            ProjectCollection.DisplayAll();
            ProjectCollection.Search();
        }

    }
}