// File:    TimeInterval.cs
// Created: Tuesday, April 14, 2020 5:18:01 PM
// Purpose: Definition of Class TimeInterval

using System;

namespace Project.Model
{
   public class TimeInterval
   {
      public DateTime Start { get; set; }
      public DateTime End { get; set; }

      public TimeInterval() {}
      public TimeInterval(DateTime start, DateTime end){
         this.Start = start;
         this.End = end;
      }
   
   }
}