using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp2.Models
{
    public class ShoppingList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime creationDate { get => new DateTime(); }

        public PriorityLevel Priority  { get; set; }

        bool _isFinished = false;
        public bool isFinished 
        { 
            get => _isFinished;
            set => _isFinished = value;
        }

        public enum PriorityLevel
        { 
        
            HIGH,
            MEDIUM,
            LOW
        }
    }
}
