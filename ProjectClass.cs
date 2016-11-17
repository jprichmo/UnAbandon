using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectUnAbandon
{
    //Object to hold a project
    public class Project : ParentAddress
    {
        private string recordID;
        private string violationType;
        private DateTime dateReported;
        private decimal latitudeX;
        private decimal longitudeY;
        private string recordStatus;
        private DateTime recordStatusDate;

        //constructor
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

        //properties
        //properties still each need checks to see if
        //valid when sent as value to be set{}
        //could use error catching still considering how

        public string RecordID
        {
            get { return recordID; }
            set
            {
                recordID = value;
            }
        }
        //done
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

        //done
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

        //done
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

        //done
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
        public string RecordStatus
        {
            get { return recordStatus; }
            set
            {
                try
                {
                    if (value == "Abatement Complete") recordStatus = value;
                    else if (value == "Abatement Pending") recordStatus = value;
                    else if (value == "Billed") recordStatus = value;
                    else if (value == "CE Property") recordStatus = value;
                    else if (value == "Closed") recordStatus = value;
                    else if (value == "Completed By Owner") recordStatus = value;
                    else if (value == "Crew Assigned for Clean-Up") recordStatus = value;
                    else if (value == "Crew Assigned for Clean-up") recordStatus = value;
                    else if (value == "Duplicate") recordStatus = value;
                    else if (value == "Extension Granted") recordStatus = value;
                    else if (value == "Hearing Complete") recordStatus = value;
                    else if (value == "Hearing Order Modified") recordStatus = value;
                    else if (value == "Hearing Recommended") recordStatus = value;
                    else if (value == "Hearing Rescheduled") recordStatus = value;
                    else if (value == "Hearing Results Pending") recordStatus = value;
                    else if (value == "Hearing Scheduled") recordStatus = value;
                    else if (value == "Inspection Pending") recordStatus = value;
                    else if (value == "Invoice Pending") recordStatus = value;
                    else if (value == "No Violation") recordStatus = value;
                    else if (value == "Note") recordStatus = value;
                    else if (value == "Notice Sent to Owner") recordStatus = value;
                    else if (value == "Open for Collections") recordStatus = value;
                    else if (value == "Payment Plan") recordStatus = value;
                    else if (value == "Referred") recordStatus = value;
                    else if (value == "Removed from CE") recordStatus = value;
                    else if (value == "Sent to Collections") recordStatus = value;
                    else if (value == "Voluntary Compliance") recordStatus = value;
                    else
                    {
                        throw new ArgumentException("Not a valid Record Status Type");
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

        //done
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
        
        //ToString override to print item contents
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
