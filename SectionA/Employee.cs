
using System;
using System.Collections.Generic;
using System.IO;

namespace SectionA
{
    
    public class Employee{
        private DateTime startDate;
        public string NRIC {get;set;}
        public string FullName {get;set;}
        public string Salutation {get;set;}
        public string StartDate {
            get => startDate.ToString("dd/mm/yyyy");
            set => startDate = DateTime.ParseExact(value, "dd/mm/yyyy",System.Globalization.CultureInfo.InvariantCulture);
            }
        public string Designation {get;set;}
        public string Department {get;set;}
        public string MobileNo {get;set;}
        public string HireType {get;set;}
        public double Salary {get;set;}
        public double MonthlyPayout {get;set;} = 0.0;

        public Employee(string NRIC, string FullName, string Salutation, string StartDate, string Designation,
        string Department, string MobileNo, string HireType, double Salary){
            NRIC = this.NRIC;
            FullName = this.FullName;
            Salutation = this.Salutation;
            StartDate = this.StartDate;
            Designation = this.Designation;
            Department = this.Department;
            MobileNo = this.MobileNo;
            HireType = this.HireType;
            Salary = this.Salary;
            MonthlyPayout = 0.0;
        }

        /// Returns string of Employee data
        /// Returns FullName, Designation and Department for Corporate_Admin_Department
        public string Corporate_Admin_Department(){
            return $"{this.FullName}, {this.Designation}, {this.Department}";
        }

        /// Returns string of Employee data
        /// Returns Salutation, FullName, MobileNo, Designation and Department of Procurement_Department
        public string Procurement_Department(){
            return $"{this.Salutation}, {this.FullName}, {this.MobileNo}, {this.Designation}, {this.Department}";
        }

        /// Returns string of Employee data
        /// Returns NRIC, FullName, StartDate, MobileNo and Department of IT_Department
        public string IT_Department(){
            return $"{this.NRIC}, {this.FullName}, {StartDate}, {this.MobileNo}, {this.Department}";
        }

    }
}