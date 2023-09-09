using System;
using System.Collections.Generic;
using System.IO;

namespace SectionA
{
    public class generating{
        /// Reading of HrMasterList and make it into a list Employee
        public static List<Employee> readHRMasterList(){
            var EmployeeList = new List<Employee>();
            using(StreamReader sr = File.OpenText(@"..\HRMasterList.txt")){
                string line;
                while ((line = sr.ReadLine()) != null){
                    string [] items = line.Split('|');

                    Employee employee = new Employee(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], Convert.ToDouble(items[8]));
                    employee.NRIC = items[0];
                    employee.FullName = items[1];
                    employee.Salutation = items[2];
                    employee.StartDate = items[3];
                    employee.Designation = items[4];
                    employee.Department = items[5];
                    employee.MobileNo = items[6];
                    employee.HireType = items[7];
                    employee.Salary = Convert.ToDouble(items[8]);
                    EmployeeList.Add(employee);
                }
            }
            return EmployeeList;
        }

        /// Create a text file with FullName, Designation and Department for Corporate_Admin_Department 
        public static void generateInfoForCorpAdmin(){
            string path = @"CorporateAdminDepartment.txt";
            if (!File.Exists(path)){
                using(StreamWriter sw = File.CreateText(path)){
                    foreach(var item in readHRMasterList()){
                        sw.WriteLine(item.Corporate_Admin_Department());
                    }
                }
            }
        }

        /// Create a text file with Salutation, FullName, MobileNo, Designation and Department of Procurement_Department
        public static void generateInfoForProcurement(){
            string path = @"ProcurementDepartment.txt";

            if (!File.Exists(path)){
                using(StreamWriter sw = File.CreateText(path)){
                    foreach(var item in readHRMasterList()){
                        sw.WriteLine(item.Procurement_Department());
                    }
                }
            }
        }

        /// Create a text file with NRIC, FullName, StartDate, MobileNo and Department of IT_Department
        public static void generateInfoForITDepartment(){
            string path = @"ITDepartment.txt";

            if (!File.Exists(path)){
                using(StreamWriter sw = File.CreateText(path)){
                    foreach(var item in readHRMasterList()){
                        sw.WriteLine(item.IT_Department());
                    }
                }
            }
        }


        public delegate void generateinfo();

        static void InvokeDelegate(generateinfo del){
            del.Invoke();
        }
        class Program
        {
            static void Main(string[] args)
            {

                /// When Program start run, the program will read a list of employees from HRMasterlist.txt
                /// and generate text files for Corporate Admin, IT Department and Procurement in
                /// their respective format based on the requirement.

                readHRMasterList();
                // Generate info for following departments: 
                // 1. CorporateAdmin
                // 2. Procurement
                // 3. ITDepartment
                generateinfo CorpAdmin = generating.generateInfoForCorpAdmin;
                generateinfo Procurement = generating.generateInfoForProcurement;
                generateinfo ITDepartment = generating.generateInfoForITDepartment;

                generateinfo All = CorpAdmin + Procurement + ITDepartment;

                InvokeDelegate(All);

            }
        }
    
    }


}
        
