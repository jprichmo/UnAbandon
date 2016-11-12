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
    public class Project
    {
        private string addressStreet;
        private string addressCity;
        private string addressState;
        private int addressZipCode;
        private string recordID;
        private string violationType;
        private string dateReported;
        private decimal latitudeX;
        private decimal longitudeY;
        private string recordStatus;
        private string recordStatusDate;


        //constructor
        public Project(string street, string city, string state, int zipCode,
            string id, string vType, string dateReport, decimal latitude,
            decimal longitude, string rStatus, string rStatusDate)
        {
            
            SetProject(latitude, longitude, id, vType, dateReport,
                rStatus, rStatusDate, street,
                city, state, zipCode);
        }

        //set using prop
        public void SetProject(decimal latitude, decimal longitude, string id,
            string vType, string dateReport, string rStatus, string rStatusDate,
            string street, string city, string state, int zipCode)
        {
            AddressStreet = street;
            AddressCity = city;
            AddressState = state;
            AddressZipCode = zipCode;
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
        public string AddressStreet
        {
            get { return addressStreet; }
            set { addressStreet = value; }
        }
        public string AddressCity
        {
            get { return addressCity; }
            set { addressCity = value; }
        }
        public string AddressState
        {
            get { return addressState; }
            set { addressState = value; }
        }
        public int AddressZipCode
        {
            get { return addressZipCode; }
            set { addressZipCode = value; }
        }
        public string RecordID
        {
            get { return recordID; }
            set { recordID = value; }
        }
        public string ViolationType
        {
            get { return violationType; }
            set { violationType = value; }
        }
        public string DateReported
        {
            get { return dateReported; }
            set { dateReported = value; }
        }
        public decimal LatitudeX
        {
            get { return latitudeX; }
            set { latitudeX = value; }
        }
        public decimal LongitudeY
        {
            get { return longitudeY; }
            set { longitudeY = value; }
        }
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }
        public string RecordStatusDate
        {
            get { return recordStatusDate; }
            set { recordStatusDate = value; }
        }
        
        //ToString override to print item contents
        public override string ToString()
        {
            //11 total columns and probably needs reformatting
            //just doing a basic config for testing purposes
            return string.Format("\t 0)Lat: {0}   1)Long: {1}  "+
                "2)RecID: {2}\n\t 3)Violation: {3}   "+
                "4)Reported: {4} \n\t 5)Status: {5}  " +
                "6)Updated: {6}\n\t 7)Address: {7}   "+
                "8)City: {8} \n\t 9)State: {9}   10)Zip: {10}",
                LatitudeX, LongitudeY, RecordID, ViolationType,
                DateReported, RecordStatus, RecordStatusDate,
                AddressStreet, AddressCity, AddressState,
                AddressZipCode);
        }

    }
}

