// File:    Room.cs
// Created: Thursday, March 19, 2020 7:33:59 PM
// Purpose: Definition of Class Room

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Project.Model;

namespace Project.Views.Model
{
    public class RoomDTO : INotifyPropertyChanged
    {
        private long id;
        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private RoomType type;
        public RoomType Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        private string ward;
        public string Ward
        {
            get
            {
                return ward;
            }
            set
            {
                if (value != ward)
                {
                    ward = value;
                    OnPropertyChanged("Ward");
                }
            }
        }
        public string Floor { get; set; }

        public List<EquipmentDTO> Equipment { get; set; }

        private List<AppointmentDTO> appointments;
        public List<AppointmentDTO> Appointments
        {
            get
            {
                return appointments;
            }
            set
            {
                if (value != appointments)
                {
                    appointments = value;
                    OnPropertyChanged("Appointments");
                }
            }
        }

        public RoomDTO() 
        {
            Appointments = new List<AppointmentDTO>(); 
        }
        public RoomDTO(long id)
        {
            Id = id;
            Appointments = new List<AppointmentDTO>();
        }


        public RoomDTO(long id, RoomType type, string ward, string floor)
        {
            Id = id;
            Type = type;
            Ward = ward;
            Floor = floor;
            Appointments = new List<AppointmentDTO>();
            Equipment = new List<EquipmentDTO>();

        }
        public RoomDTO(RoomType type, string ward, string floor)
        {
            Type = type;
            Ward = ward;
            Floor = floor;
            Appointments = new List<AppointmentDTO>();
            Equipment = new List<EquipmentDTO>();
        }


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}