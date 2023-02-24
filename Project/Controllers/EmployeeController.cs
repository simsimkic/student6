// File:    EmployeeController.cs
// Created: Thursday, April 30, 2020 10:17:54 PM
// Purpose: Definition of Class EmployeeController

using Project.Model;
using System;

namespace Controller
{
   public class EmployeeController
   {
      public Employee RegisterEmployee(string firstName, string lastName, string jmbg, string telephoneNumber, Sex gender, string email, string password, string role, string number, string street, string city, string country, string postCode)
      {
         throw new NotImplementedException();
      }
      
      public void SetSalary(double salary, String jmbg)
      {
         throw new NotImplementedException();
      }
      
      public void SetAnnualLeave(TimeInterval period)
      {
         throw new NotImplementedException();
      }
      
      public void SetWorkingHours(TimeInterval hours)
      {
         throw new NotImplementedException();
      }
      
      public Employee UpdateEmployee(Employee employee)
      {
         throw new NotImplementedException();
      }
      
      public Employee DeleteEmployee(Employee employee)
      {
         throw new NotImplementedException();
      }
   
   }
}