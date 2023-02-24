// File:    Room.cs
// Created: Thursday, March 19, 2020 7:33:59 PM
// Purpose: Definition of Class Room

using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class Room : IIdentifiable<long>
    {
        public long Id { get; set; }
        public RoomType Type { get; set; }
        public string Ward { get; set; }
        public string Floor { get; set; }

        public List<Equipment> Equipment { get; set; }
        public List<Appointment> Appointments { get; set; }
        public Room() { }

        public Room(long id) 
        {
            Id = id;        
        }
        public Room(long id, RoomType type, string ward, string floor)
        {
            Id = id;
            Type = type;
            Ward = ward;
            Floor = floor;

        }
        public Room(RoomType type, string ward, string floor)
        {
            Type = type;
            Ward = ward;
            Floor = floor;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }

}