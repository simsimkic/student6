// File:    Renovation.cs
// Created: Friday, April 17, 2020 4:26:32 PM
// Purpose: Definition of Class Renovation

using Project.Views.Model;
using System;

namespace Project.Model
{
    public class Renovation : Appointment
    {
        public string Type { get; set; }

        public RoomType NewType { get; set; }

        public Renovation(string type,RoomType newType)
        {
            Type = type;
            NewType = newType;
        }

        public Renovation(long id, DateTime beginning, DateTime end, Room room, string type,RoomType newType) :
           base(id, beginning, end, room)
        {
            this.Type = type;
            NewType = newType;
        }
    }
}