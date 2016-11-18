///////////////////////////////////////////////////////////////////////////////
//
//  PROJECT COLLECTION CLASS for PROJECT UNABANDON
//
//  AUTHOR:     Derek Blankinship
//  EDITOR:     Jason Richmond
//
//  This is a container class that holds a List of Project Objects called 
//  JobCollection allowing for the manipulation of South Bend Code Enforcement
//  data loaded from a CSV.
//
//  Methods defined:
//      FillProjectObjects() : void
//          > imports data from the CSV, adding each row as a Project
//      ClearAllData() : void
//          > removes all Projects from JobCollection
//      AddProjectToList() : void
//          > adds a Project to the end of JobCollection
//      DisplayAddedItem() : void
//          > prints the last Project in JobCollection
//      GetCount() : int
//          > returns the number of Projects in JobCollection
//      DisplayAll() : void
//          > prints the entire JobCollection to the console
//      DisplaySelected() : void
//          > prints the JobCollection subset to the console
//      Modify(int) : void
//          > allows user to change a Project field
//      Search() : void
//          > allows user to search for specific values in Project fields
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectUnAbandon
{
    //Project Collection holds the List of Project Objects
    public class ProjectCollection
    {
        static List<Project> JobCollection = new List<Project>();

        //Fill Objects with data
        static public void FillProjectObjects()
        {
            string source;
            Console.WriteLine("Enter the file path for the csv to load data from");
            source = Console.ReadLine();
            String[] lines = File.ReadAllLines(source);
            var query = from line in lines
                        let data = line.Split(',')
                        select new
                        {
                            latitude = data[0],
                            longitude = data[1],
                            //objectID = data[2],
                            recordID = data[3],
                            //violationCatagory = data[4],
                            violationType = data[5],
                            reportDate = data[6],
                            recordStatus = data[7],
                            recordStatusDate = data[8],
                            //parcelNumber = data[9],
                            addressStreetNumber = data[10],
                            addressStreetDirection = data[11],
                            addressStreet = data[12],
                            addressStreetType = data[13],
                            //addressLine = data[14],
                            addressCity = data[15],
                            addressState = data[16],
                            addressZipCode = data[17]
                        };

            decimal tempLongitude, tempLatitude;
            string tempRecordID, /*tempViolationCatagory,*/ tempViolationType;
            string tempReportDate, tempRecordStatus, tempRecordStatusDate;
            string tempAddressStreetNumber, tempAddressStreetDirection;
            string tempAddressStreet, tempAddressStreetType;
            string tempAddressCity, tempAddressState;
            string tempFullStreetAddress;
            int tempAddressZipCode;
            

            foreach (var element in query)
            {
                //Console.WriteLine(element);
                tempLatitude = Convert.ToDecimal(element.latitude);
                tempLongitude = Convert.ToDecimal(element.longitude);
                tempRecordID = element.recordID;
                //tempViolationCatagory = element.violationCatagory;
                tempViolationType = element.violationType;
                tempReportDate = element.reportDate;
                tempRecordStatus = element.recordStatus;
                tempRecordStatusDate = element.recordStatusDate;
                tempAddressStreetNumber = element.addressStreetNumber;
                tempAddressStreetDirection = element.addressStreetDirection;
                tempAddressStreet = element.addressStreet;
                tempAddressStreetType = element.addressStreetType;
                tempAddressCity = element.addressCity;
                tempAddressState = element.addressState;
                tempAddressZipCode = Convert.ToInt32(element.addressZipCode);

                DateTime theReportDate = DateTime.Parse(tempReportDate);
                                       
                DateTime theRecordStatusDate = DateTime.Parse(tempRecordStatusDate);

                tempFullStreetAddress = tempAddressStreetNumber +
                    tempAddressStreetDirection + tempAddressStreet +
                    tempAddressStreetType;

                JobCollection.Add(new Project(tempFullStreetAddress,
                    tempAddressCity, tempAddressState, tempAddressZipCode,
                    tempRecordID, tempViolationType, theReportDate,
                    tempLatitude, tempLongitude, tempRecordStatus, theRecordStatusDate));
            }
        }

        //Clear all data
        public static void ClearAllData()
        {
            JobCollection.Clear();
        }

        //Add project to a collection
        public static void AddProjectToList()
        {
            decimal tempLatitude, tempLongitude;
            string tempRecordID, /*tempViolationCatagory,*/ tempViolationType;
            string tempReportDate, tempRecordStatus, tempRecordStatusDate;
            //string tempAddressStreetNumber, tempAddressStreetDirection;
            //string tempAddressStreet, tempAddressStreetType;
            string tempAddressCity, tempAddressState;
            string tempFullStreetAddress;
            int tempAddressZipCode;

            Console.Write("Enter the property's latitudinal value (x) : ");
            tempLatitude = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the property's longitudinal value (y) : ");
            tempLongitude = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the Record ID of the enforcement case : ");
            tempRecordID = Console.ReadLine();
// ADD OPTIONS FOR VIOLATION TYPE
            Console.Write("Enter the Violation Type of the enforcement case : ");
            tempViolationType = Console.ReadLine();
            Console.WriteLine("Enter the Date the enforcement case was reported");
            Console.Write("Please use format MM/DD/YYYY : ");
            tempReportDate = Console.ReadLine();
            Console.Write("Enter the Current Status of the enforcement case : ");
            tempRecordStatus = Console.ReadLine();
            Console.WriteLine("Enter the date the Current Status was updated");
            Console.Write("Please use format MM/DD/YYYY : ");
            tempRecordStatusDate = Console.ReadLine();
            Console.WriteLine("Enter the full address of the enforcement case");
            Console.WriteLine("For the first part add the Street Number (123), "
                + "Direction (W), ");
            Console.WriteLine("Street Name, and then Street Type (Ave)");
            tempFullStreetAddress = Console.ReadLine();
            Console.Write("Enter the City of the enforcement case : ");
            tempAddressCity = Console.ReadLine();
            Console.Write("Enter the State of the enforcement case : ");
            tempAddressState = Console.ReadLine();
            Console.Write("Enter the Zip Code of the enforcement case : ");
            tempAddressZipCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
// CHECK EXCEPTION HANDLING WITH PARSE
            DateTime theReportDate = DateTime.Parse(tempReportDate);
            DateTime theRecordStatusDate = DateTime.Parse(tempRecordStatusDate);

            JobCollection.Add(new Project(tempFullStreetAddress,
                    tempAddressCity, tempAddressState, tempAddressZipCode,
                    tempRecordID, tempViolationType, theReportDate,
                    tempLatitude, tempLongitude, tempRecordStatus, theRecordStatusDate));
        }

        //Display last added item to the user
        public static void DisplayAddedItem()
        {
            Console.WriteLine(JobCollection.Last());
        }

        //Get the number of Projects in collection
        public static int GetCount()
        {
            return JobCollection.Count();
        }

        //Display all items and print to console
        public static void DisplayAll()
        {
            Console.WriteLine("\nDISPLAYING ALL RECORDS, {0} FOUND: ", JobCollection.Count());
            for (int i = 0; i < JobCollection.Count(); ++i)
            {
                Console.WriteLine("\nITEM {0}: \n" + JobCollection[i].ToString(), i);
                Console.WriteLine();
            }
        }

// ADDED BUT NOT YET IMPLEMENTED PROPERLY
        //Display selected items and print to console
        public static void DisplaySelected()
        {
            Console.WriteLine("\nDISPLAYING SELECTED RECORDS, {0} FOUND: ", JobCollection.Count());
            for (int i = 0; i < JobCollection.Count(); ++i)
            {
                Console.WriteLine("\nITEM {0}: \n" + JobCollection[i].ToString(), i);
                Console.WriteLine();
            }
        }

        //Modify a user selected field in a user selected item
        public static void Modify(int sel)
        {
            Console.WriteLine("Enter the FIELD NUMBER you wish to modify: ");
            int s = Convert.ToInt32(Console.ReadLine());
            while (s < 0 || s > 10)
            {
                Console.WriteLine("Enter a number from 0 to 10: ");
                s = Convert.ToInt32(Console.ReadLine());
            }

            decimal val = 0;
            int zip = 0;
            string str = "";

            //this switch handles the setting one of 11 fields for a given item
            switch (s)
            {
                case 0:
                    Console.WriteLine("Enter X (latitudinal) value: ");
                    val = Convert.ToDecimal(Console.ReadLine());
                    JobCollection[sel].LatitudeX = val;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                case 1:
                    Console.WriteLine("Enter Y (longitudinal) value: ");
                    val = Convert.ToDecimal(Console.ReadLine());
                    JobCollection[sel].LongitudeY = val;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                case 2:
                    Console.WriteLine("Enter Record ID: ");
                    str = Console.ReadLine();
                    JobCollection[sel].RecordID = str;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                case 3:
                    Console.WriteLine("Enter Violation type: ");
                    str = Console.ReadLine();
                    JobCollection[sel].ViolationType = str;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                case 4:
                    Console.WriteLine("Enter Date Reported: ");
                    str = Console.ReadLine();
                    DateTime theReportDate = DateTime.Parse(str);
                    JobCollection[sel].DateReported = theReportDate;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                case 5:
                    Console.WriteLine("Enter Record Status: ");
                    str = Console.ReadLine();
                    JobCollection[sel].RecordStatus = str;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                case 6:
                    Console.WriteLine("Enter Record Status Date: ");
                    str = Console.ReadLine();
                    DateTime theRecordStatusDate = DateTime.Parse(str);
                    JobCollection[sel].RecordStatusDate = theRecordStatusDate;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                case 7:
                    Console.WriteLine("Enter Street: ");
                    str = Console.ReadLine();
                    JobCollection[sel].AddressStreet = str;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                case 8:
                    Console.WriteLine("Enter City: ");
                    str = Console.ReadLine();
                    JobCollection[sel].AddressCity = str;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                case 9:
                    Console.WriteLine("Enter State: ");
                    str = Console.ReadLine();
                    JobCollection[sel].AddressState = str;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                case 10:
                    Console.WriteLine("Enter the zip code: ");
                    zip = Convert.ToInt32(Console.ReadLine());
                    JobCollection[sel].AddressZipCode = zip;
                    Console.WriteLine(JobCollection[sel]);
                    break;
                default:
                    Console.WriteLine("Number must be 0 to 10.");
                    break;
            }
        }

        //Search for a user-defined field value using LINQ
        public static void Search()
        {
            Console.WriteLine("\n\tChoose from this list which field you wish to search by");
            Console.WriteLine("\tOption 0: Latitude");
            Console.WriteLine("\tOption 1: Longitude");
            Console.WriteLine("\tOption 2: Record ID");
            Console.WriteLine("\tOption 3: Violation Type");
            Console.WriteLine("\tOption 4: Date Reported");
            Console.WriteLine("\tOption 5: Record Status");
            Console.WriteLine("\tOption 6: Record Status Date");
            Console.WriteLine("\tOption 7: Street");
            Console.WriteLine("\tOption 8: City");
            Console.WriteLine("\tOption 9: State");
            Console.WriteLine("\tOption 10: Zip Code");

            Console.WriteLine("Enter the FIELD NUMBER you wish to search with: ");
            int s = Convert.ToInt32(Console.ReadLine());
            while (s < 0 || s > 10)
            {
                Console.WriteLine("Enter a number from 0 to 10: ");
                s = Convert.ToInt32(Console.ReadLine());
            }
          
            string str = "";

            //this switch handles searching for one of 11 fields
            switch (s)
            {
                case 0:
                    Console.WriteLine("Enter X (latitudinal) value: ");
                    str = Console.ReadLine();

                    var filtered =
                        from element in JobCollection
                        where element.LatitudeX.ToString().Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case 1:
                    Console.WriteLine("Enter Y (longitudinal) value: ");
                    str = Console.ReadLine();

                    filtered =
                        from element in JobCollection
                        where element.LongitudeY.ToString().Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter Record ID: ");
                    str = Console.ReadLine();

                    filtered =
                        from element in JobCollection
                        where element.RecordID.Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter Violation type: ");
                    str = Console.ReadLine();

                    filtered =
                        from element in JobCollection
                        where element.ViolationType.Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter Date Reported: ");
                    str = Console.ReadLine();

                    filtered =
                        from element in JobCollection
                        where element.DateReported.ToShortDateString().Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter Record Status: ");
                    str = Console.ReadLine();

                    filtered =
                        from element in JobCollection
                        where element.RecordStatus.Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case 6:
                    Console.WriteLine("Enter Record Status Date: ");
                    str = Console.ReadLine();
                    
                    filtered =
                        from element in JobCollection
                        where element.RecordStatusDate.ToShortDateString().Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case 7:
                    Console.WriteLine("Enter Street: ");
                    str = Console.ReadLine();

                    filtered =
                        from element in JobCollection
                        where element.AddressStreet.Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case 8:
                    Console.WriteLine("Enter City: ");
                    str = Console.ReadLine();

                    filtered =
                        from element in JobCollection
                        where element.AddressCity.Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case 9:
                    Console.WriteLine("Enter State: ");
                    str = Console.ReadLine();

                    filtered =
                        from element in JobCollection
                        where element.AddressState.Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case 10:
                    Console.WriteLine("Enter the zip code: ");
                    str = Console.ReadLine();

                    filtered =
                        from element in JobCollection
                        where element.AddressZipCode.ToString().Contains(str)
                        select element;

                    foreach (var element in filtered)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                default:
                    Console.WriteLine("Number must be 0 to 10.");
                    break;
            }
        }
    }
}
