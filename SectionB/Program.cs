using System;
using System.Collections.Generic;
using System.IO;
using SectionA;
using System.Threading.Tasks;

namespace SectionB
{
    class Program
    {   
        public enum hiretype{
            FullTime,
            PartTime,
            Hourly,
        }

        public static async Task Main(string[] args){
            List<Employee> employeeinfo = SectionA.generating.readHRMasterList();
            await processPayroll(employeeinfo);
            updateMonthlyPayoutToMasterlist(employeeinfo);
        }


        public static async Task processPayroll(List<Employee> employeeinfo){
            double  total = 0;
            int count = 0;
            await Task.Run(() => 
            {
                foreach (var e in employeeinfo){
                /** FullTime index 0 **/
                if (e.HireType == hiretype.GetName(typeof(hiretype),0)){

                    double fulltime = e.Salary;
                    Console.WriteLine(e.FullName + "(" + e.NRIC + ")");
                    Console.WriteLine(e.Designation);
                    Console.WriteLine("FullTime Payout: $" + fulltime);
                    Console.WriteLine("--------------------------------------");
                    total += fulltime;
                    e.MonthlyPayout = fulltime;
                }
                /** PartTime index 1 **/
                else if (e.HireType == hiretype.GetName(typeof(hiretype),1)){
                    double parttime = 0.5 * e.Salary;
                    Console.WriteLine(e.FullName + "(" + e.NRIC + ")");
                    Console.WriteLine(e.Designation);
                    Console.WriteLine("PartTime Payout: $" + parttime);
                    Console.WriteLine("--------------------------------------");
                    total += parttime;
                    e.MonthlyPayout = parttime;
                }
                /** Hourly **/
                else{
                    double hourly = 0.25 * e.Salary;
                    Console.WriteLine(e.FullName + "(" + e.NRIC + ")");
                    Console.WriteLine(e.Designation);
                    Console.WriteLine("Hourly Payout: $" + hourly);
                    Console.WriteLine("--------------------------------------");
                    total += hourly;
                    e.MonthlyPayout = hourly;
                }

                count += 1;

                }
                
            });

            Console.WriteLine("Total PayRoll Amount: $" + total + " to be paid to " + count + " employees");
        }

        public static void updateMonthlyPayoutToMasterlist(List<Employee> employeeinfo){
            /// Generate HRMasterlistB.txt
            string path = @"..\HRMasterlistB.txt";
            
            using (StreamWriter sw = File.CreateText(path)){

                foreach (var item in employeeinfo){
                    sw.WriteLine(item.NRIC + "|" + item.FullName + "|" + item.Salutation + "|" + item.StartDate  + "|" + item.Designation + "|" + item.Department + "|" + item.MobileNo + "|" + item.HireType + "|" + item.Salary + "|" + item.MonthlyPayout);
                }
            }
            
        }
    }
}
