///////////////////////////////////////////////////////////////////////////////
//
//  CONSOLE USER INTERFACE for PROJECT UNABANDON
//
//  AUTHOR:     Jason Richmond
//  EDITOR:     Derek Blankinship
//
//  This class defines the console user interface for manipulating data from
//  South Bend Code Enforcement for a civic hacking app tentatively called
//  Project UnAbandon.
//
//  Functions defined:
//      Loop() : void
//          > starts user interface loop until exit is selected
//      MenuOptions() : char
//          > displays menu of options and gets user input
//      SelectOption(char) : void
//          > executes user selection
//      ClearAllData() : void
//          > clears all items from colleciton
//      LoadData() : void
//          > loads data from a properly formatted CSV
//      AddItem() : void
//          > adds an item to the collection
//      DisplayAddedItem() : void
//          > displays last added item
//      DisplayAllItems() : void
//          > displays all items in collection
//      DisplaySelectedItems() : void
//          > displays selected items in collection
//      DisplayCount() : void
//          > gets the number of items in collection
//      ModifyItem() : void
//          > changes selected item fields in collection
//      SearchItems() : void
//          > returns items with fields matching specified values
//      DisplayLINQChoices() : char
//          > displays the menu of predefined queries and gets user input
//      ExecuteLINQ(char) : void
//          > executes user selection
//
///////////////////////////////////////////////////////////////////////////////

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

        //=====================================================================
        //  FUNCTIONS
        //=====================================================================

        //---------------------------------------------------------------------
        //  LOOP USER INTERFACE : void
        //---------------------------------------------------------------------
        public static void Loop()
        {
            while (!exit)
            {
                SelectOption(MenuOptions());
            }
        }

        //---------------------------------------------------------------------
        //  DISPLAY MENU OPTIONS : char
        //---------------------------------------------------------------------
        public static char MenuOptions()
        {
            char option;
            char check;

            Console.WriteLine("\n\tPHASE 4 MENU\n");
            Console.WriteLine("\tOption 0: Load New Data");
            Console.WriteLine("\tOption 1: Add Item");
            Console.WriteLine("\tOption 2: Modify Item");
            Console.WriteLine("\tOption 3: Search and Display Results");
            Console.WriteLine("\tOption 4: Display Number of Items Stored");
            Console.WriteLine("\tOption 5: Choose a Predefined Query");
            Console.WriteLine("\tOption 6: Exit");
            Console.Write("\n\tPlease select an option from the list: ");

            check = Convert.ToChar(Console.ReadLine().Substring(0, 1));

            while (check < '0' || check > '6')
            {
                Console.Write("\n\tPlease choose 0, 1, 2, 3, 4, 5, or 6: ");
                Console.ReadLine();
                check = Convert.ToChar(Console.ReadLine().Substring(0, 1));
            }

            option = Convert.ToChar(check);
            return option;
        }

        //---------------------------------------------------------------------
        //  CONTROL FOR USER SELECTION : void
        //---------------------------------------------------------------------
        public static void SelectOption(char opt)
        {
            char optionLINQ;
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
                    DisplaySelectedItems();
                    ModifyItem();
                    break;
                case '3':
                    SearchItems();
                    break;
                case '4':
                    DisplayCount();
                    break;
                case '5':
                    optionLINQ = DisplayLINQChoices();
                    ExecuteLINQ(optionLINQ);
                    break;
                case '6':
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\n\tThat is not a valid input.\n");
                    break;
            }
        }

        //---------------------------------------------------------------------
        //  CLEAR ALL DATA FROM COLLECTION : void
        //---------------------------------------------------------------------
        public static void ClearAllData()
        {
            //call static method in ProjectCollection Class
            //to use list.clear()
            ProjectCollection.ClearAllData();
        }

        //---------------------------------------------------------------------
        //  LOAD DATA INTO COLLECTION : void
        //---------------------------------------------------------------------
        public static void LoadData()
        {
            //call static method in ProjectCollection Class to fill the list
            ProjectCollection.FillProjectObjects();
        }

        //---------------------------------------------------------------------
        //  ADD ITEM TO COLLECTION : void
        //---------------------------------------------------------------------
        public static void AddItem()
        {
            ProjectCollection.AddProjectToList();
        }

        //---------------------------------------------------------------------
        //  DISPLAY LAST ITEM ADDED : void
        //---------------------------------------------------------------------
        public static void DisplayAddedItem()
        {
            ProjectCollection.DisplayAddedItem();
        }

        //---------------------------------------------------------------------
        //  DISPLAY ALL ITEMS AND FIELDS : void
        //---------------------------------------------------------------------
        public static void DisplayAllItems()
        {
            ProjectCollection.DisplayAll();
        }

        //---------------------------------------------------------------------
        //  DISPLAY SELECTED ITEMS AND FIELDS : void
        //---------------------------------------------------------------------
        public static void DisplaySelectedItems()
        {
            ProjectCollection.DisplayAll();
        }

        //---------------------------------------------------------------------
        //  DISPLAY NUMBER OF PROJECTS : void
        //---------------------------------------------------------------------
        public static void DisplayCount()
        {
            int count = ProjectCollection.GetCount();
            Console.WriteLine("The total number of records so far is : {0}",
                count);
        }

        //---------------------------------------------------------------------
        //  MODIFY SELECTED ITEM FIELD : void
        //---------------------------------------------------------------------
        public static void ModifyItem()
        {
            Console.WriteLine("Enter the ITEM NUMBER you wish to modify: ");
            int sel = Convert.ToInt32(Console.ReadLine());
            if (sel < 0 || sel > (ProjectCollection.GetCount() - 1))
            {
                Console.WriteLine("Enter a number from 0 to {0}: ", (ProjectCollection.GetCount() - 1));
                sel = Convert.ToInt32(Console.ReadLine());
            }
            //Console.WriteLine(sel);
            ProjectCollection.Modify(sel);
        }

        //---------------------------------------------------------------------
        //  SEARCH FOR VALUE IN FIELD : void
        //---------------------------------------------------------------------
        //Search for a field with a user defined value
        public static void SearchItems()
        {
            //ProjectCollection.DisplayAll();
            ProjectCollection.Search();
        }

        //---------------------------------------------------------------------
        //  DISPLAY LINQ CHOICES : char
        //---------------------------------------------------------------------
        public static char DisplayLINQChoices()
        {
            char option;
            char check;

            Console.WriteLine("\n\tPredefined Query Menu\n");
            Console.WriteLine("\tOption 0: List Duplicates");
            Console.WriteLine("\tOption 1: Count Number of Cases per Zip Code");
            Console.WriteLine("\tOption 2: Most Recently Reported Cases");
            Console.WriteLine("\tOption 3: Most Recently Reported Cases by Zip Code");
            Console.WriteLine("\tOption 4: Number of Violations by Type");
            Console.WriteLine("\tOption 5: Number of Open Cases");
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

        //---------------------------------------------------------------------
        //  EXECUTE SELECTED LINQ : void
        //---------------------------------------------------------------------
        public static void ExecuteLINQ(char option)
        {
            switch (option)
            {
                case '0':
                    ProjectCollection.GetRepeatOffenderAddress();
                    break;
                case '1':
                    ProjectCollection.GetCountPerZip();
                    break;
                case '2':
                    ProjectCollection.TenMostRecentlyReported();
                    break;
                case '3':
                    ProjectCollection.TenMostRecentlyReportedByZip();
                    break;
                case '4':
                    ProjectCollection.NumberOfViolationsByType();
                    break;
                case '5':
                    ProjectCollection.NumberOfOpenCases();
                    break;
                default:
                    Console.WriteLine("\n\tThat is not a valid input.\n");
                    break;
            }
        }
    }
}
