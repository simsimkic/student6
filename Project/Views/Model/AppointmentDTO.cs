// File:    Appoitment.cs
// Created: Thursday, March 19, 2020 7:31:07 PM
// Purpose: Definition of Class Appoitment

using System;
using System.ComponentModel;

namespace Project.Views.Model
{
    public class AppointmentDTO: INotifyPropertyChanged
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
        private DateTime beginning;
        public DateTime Beginning
        {
            get
            {
                return beginning;
            }
            set
            {
                if (value != beginning)
                {
                    beginning = value;
                    OnPropertyChanged("Beginning");
                }
            }
        }
        private DateTime end { get; set; }
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                if (value != end)
                {
                    end = value;
                    OnPropertyChanged("End");
                }
            }
        }

        public RoomDTO Room { get; set; }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AppointmentDTO() { }
        public AppointmentDTO(DateTime beginning, DateTime end, RoomDTO room)
        {
            Beginning = beginning;
            End = end;
            Room = room;
        }
        public AppointmentDTO(long id, DateTime beginning, DateTime end, RoomDTO room)
        {
            Id = id;
            Beginning = beginning;
            End = end;
            Room = room;
        }

    }
}