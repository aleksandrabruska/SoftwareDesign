﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeletubbiesExercise
{
    internal abstract class Subject
    {
        protected LinkedList<IObserver> observers;
        public Subject() { 
            observers = new LinkedList<IObserver>();
        }
        public void Attach(IObserver observer)
        {
            observers.AddFirst(observer);
        }
        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }
        public abstract void Notify();
    }
}