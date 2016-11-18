///////////////////////////////////////////////////////////////////////////////
//
//  PROJECT CLASS for PROJECT UNABANDON
//
//  AUTHOR:     Derek Blankinship
//  EDITOR:     Jason Richmond
//
//  Project Class defines objects that store data from South Bend Code
//  Enforcement. It inherits from the ParentAddress class that defines
//  how addresses are stored.
//
//  Attributes defined:
//      recordID : string
//          > the record ID of the violation
//      violationType : string
//          > the type of violation reported
//      dateReported : DateTime
//          > the report date of the violation
//      latitudeX : decimal
//          > the geolocation latitude in decimal form
//      longitudeY : decimal
//          > the geolocation longitude in decimal form
//      recordStatus : string
//          > the status as of the current data set
//      recordStatusDate : DateTime
//          > the date of the status
//
//  Methods defined:
//      ToString() : string
//          > Converts all types to string and formats output
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
    public class Project : ParentAddress
    {
        private string recordID;
        private string violationType;
        private DateTime dateReported;
        private decimal latitudeX;
        private decimal longitudeY;
        private string recordStatus;
        private DateTime recordStatusDate;

        //=====================================================================
        //  CONSTRUCTOR
        //=====================================================================
        public Project(string street, string city, string state, int zipCode,
            string id, string vType, DateTime dateReport, decimal latitude,
            decimal longitude, string rStatus, DateTime rStatusDate) 
            : base(street, city, state, zipCode)
        {
            RecordID = id;
            ViolationType = vType;
            DateReported = dateReport;
            LatitudeX = latitude;
            LongitudeY = longitude;
            RecordStatus = rStatus;
            RecordStatusDate = rStatusDate;
        }

        //=====================================================================
        //  PROPERTIES
        //=====================================================================

        //---------------------------------------------------------------------
        //  RECORD ID
        //---------------------------------------------------------------------
        public string RecordID
        {
            get { return recordID; }
            set
            {
                recordID = value;
            }
        }

        //---------------------------------------------------------------------
        //  VIOLATION TYPE
        //---------------------------------------------------------------------
        public string ViolationType
        {
            get { return violationType; }
            set
            {
                try
                {
                    if (value == "Continuous Enforcement") violationType = value;
                    else if (value == "Continuous Enforcement Grass") violationType = value;
                    else if (value == "Graffiti") violationType = value;
                    else if (value == "Grass and Weeds") violationType = value;
                    else if (value == "Litter") violationType = value;
                    else if (value == "Snow") violationType = value;
                    else if (value == "Vegetation") violationType = value;
                    else
                    {
                        throw new ArgumentException("Not a valid Violation Type");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine();

                    string tempViolationType;
                    Console.WriteLine("Enter the Voilation Type of the enforcement case : ");
                    Console.WriteLine("Choices are ");
                    Console.WriteLine("1. Continuous Enforcement");
                    Console.WriteLine("2. Continuous Enforcement Grass");
                    Console.WriteLine("3. Graffiti");
                    Console.WriteLine("4. Grass and Weeds");
                    Console.WriteLine("5. Litter");
                    Console.WriteLine("6. Snow");
                    Console.WriteLine("7. Vegetation");
                    Console.Write("Please enter one of these choices without the number in front : ");
                    tempViolationType = Console.ReadLine();
                    ViolationType = tempViolationType;
                    Console.WriteLine();
                }
            }
        }

//NEED TO FIX EXCEPTION HANDLING FOR DATETIME, RIGHT NOW LIMITED
        //---------------------------------------------------------------------
        //  DATE REPORTED
        //---------------------------------------------------------------------
        public DateTime DateReported
        {
            get { return dateReported; }
            set
            {
                try
                {
                    string temp = value.ToString("yyyy");
                    int x = Convert.ToInt32(temp);
                    if (x > 2016)
                    {
                        throw new ArgumentException("Date not within years 2000 to 2016");
                    }
                    else if (x < 2000)
                    {
                        throw new ArgumentException("Date not within years 2000 to 2016");
                    }
                    else
                    {
                        dateReported = value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine();

                    string temp;
                    Console.WriteLine("Enter the Date the enforcement case was reported");
                    Console.Write("Please use format MM/DD/YYYY    : ");
                    temp = Console.ReadLine();
                    DateTime theDateReported = DateTime.Parse(temp);
                    DateReported = theDateReported;
                    Console.WriteLine();
                }
            }
        }

        //---------------------------------------------------------------------
        //  LATITUDE X
        //---------------------------------------------------------------------
        public decimal LatitudeX
        {
            get { return latitudeX; }
            set
            {
                try
                {
                    if (value > 90)
                        throw new ArgumentException("Latitude has to be between -90 and 90");
                    else if (value < -90)
                        throw new ArgumentException("Latitude has to be between -90 and 90");
                    else
                    {
                        latitudeX = value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine();

                    decimal tempLatitude;
                    Console.Write("Enter the property's latitudinal value (x) : ");
                    tempLatitude = Convert.ToDecimal(Console.ReadLine());
                    LatitudeX = tempLatitude;
                    Console.WriteLine();
                }
            }
        }

        //---------------------------------------------------------------------
        //  LONGITUDE Y
        //---------------------------------------------------------------------
        public decimal LongitudeY
        {
            get { return longitudeY; }
            set
            {
                try
                {
                    if (value > 180)
                        throw new ArgumentException("Longitude has to be between -180 and 180");
                    else if (value < -180)
                        throw new ArgumentException("Longitude has to be between -180 and 180");
                    else
                    {
                        longitudeY = value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine();

                    decimal tempLongitude;
                    Console.Write("Enter the property's longitudinal value (y) : ");
                    tempLongitude = Convert.ToDecimal(Console.ReadLine());
                    LongitudeY = tempLongitude;
                    Console.WriteLine();
                }
            }
        }

        //deciding if i want to list all options. Feel like I should but
        //leaving it till later when i'm less motivated for real coding
        //---------------------------------------------------------------------
        //  RECORD STATUS
        //---------------------------------------------------------------------
        public string RecordStatus
        {
            get { return recordStatus; }
            set
            {
                try
                {
                    if (value.ToLower() == "abatement complete") recordStatus = value;
                    else if (value.ToLower() == "abatement pending") recordStatus = value;
                    else if (value.ToLower() == "billed") recordStatus = value;
                    else if (value.ToLower() == "ce property") recordStatus = value;
                    else if (value.ToLower() == "closed") recordStatus = value;
                    else if (value.ToLower() == "completed by owner") recordStatus = value;
                    else if (value.ToLower() == "crew assigned for clean-Up") recordStatus = value;
                    else if (value.ToLower() == "duplicate") recordStatus = value;
                    else if (value.ToLower() == "extension granted") recordStatus = value;
                    else if (value.ToLower() == "hearing complete") recordStatus = value;
                    else if (value.ToLower() == "hearing order modified") recordStatus = value;
                    else if (value.ToLower() == "hearing recommended") recordStatus = value;
                    else if (value.ToLower() == "hearing rescheduled") recordStatus = value;
                    else if (value.ToLower() == "hearing results pending") recordStatus = value;
                    else if (value.ToLower() == "hearing scheduled") recordStatus = value;
                    else if (value.ToLower() == "inspection pending") recordStatus = value;
                    else if (value.ToLower() == "invoice pending") recordStatus = value;
                    else if (value.ToLower() == "no violation") recordStatus = value;
                    else if (value.ToLower() == "note") recordStatus = value;
                    else if (value.ToLower() == "notice sent to owner") recordStatus = value;
                    else if (value.ToLower() == "open for collections") recordStatus = value;
                    else if (value.ToLower() == "payment plan") recordStatus = value;
                    else if (value.ToLower() == "referred") recordStatus = value;
                    else if (value.ToLower() == "removed from ce") recordStatus = value;
                    else if (value.ToLower() == "sent to collections") recordStatus = value;
                    else if (value.ToLower() == "voluntary compliance") recordStatus = value;
                    else
                    {
                        // THIS STATIC CHECK IS TOO NARROW FOR THE DATA
                        recordStatus = value;
                    //    throw new ArgumentException("Not a valid Record Status Type");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.ToString());
                    string tempRecordStatus;
                    Console.WriteLine();
                    Console.Write("Enter the Current Status of the enforcement case : ");
                    tempRecordStatus = Console.ReadLine();
                    RecordStatus = tempRecordStatus;
                    Console.WriteLine();
                }
            }
        }

//NEED TO FIX EXCEPTION HANDLING FOR DATETIME, RIGHT NOW LIMITED
        //---------------------------------------------------------------------
        //  RECORD STATUS DATE
        //---------------------------------------------------------------------
        public DateTime RecordStatusDate
        {
            get { return recordStatusDate; }
            set
            {
                try
                {
                    string temp = value.ToString("yyyy");
                    int x = Convert.ToInt32(temp);
                    if (x > 2016) {
                        throw new ArgumentException("Date not within years 2000 to 2016");
                    }
                    else if (x < 2000) {
                        throw new ArgumentException("Date not within years 2000 to 2016");
                    }
                    else
                    {
                        recordStatusDate = value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine();

                    string temp;
                    Console.Write("Enter the Current Status of the enforcement case : ");
                    temp = Console.ReadLine();
                    DateTime theRecordStatus = DateTime.Parse(temp);
                    RecordStatusDate = theRecordStatus;
                    Console.WriteLine();
                }
            }
        }

        //=====================================================================
        //  METHODS
        //=====================================================================

        //---------------------------------------------------------------------
        //  TO STRING OVERRIDE : string
        //---------------------------------------------------------------------
        public override string ToString()
        {
            var dateReportedOnlyDate = DateReported.ToShortDateString();
            var dateRecordStatusOnlyDate = DateReported.ToShortDateString();

            return string.Format("\t 0)Lat: {0}   1)Long: {1}  "+
                "2)RecID: {2}\n\t 3)Violation: {3}   "+
                "4)Reported: {4} \n\t 5)Status: {5}  " +
                "6)Updated: {6}\n\t 7)Address: {7}   "+
                "8)City: {8} \n\t 9)State: {9}   10)Zip: {10}",
                LatitudeX, LongitudeY, RecordID, ViolationType,
                dateReportedOnlyDate, RecordStatus, dateRecordStatusOnlyDate,
                AddressStreet, AddressCity, AddressState,
                AddressZipCode);
        }
    }
}
