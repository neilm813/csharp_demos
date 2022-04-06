using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractAndInterface
{
    public abstract class Building
    {
        // not every building has health b/c every building isn't damageable

        // abstract prop means it must implement / be overriden
        public abstract string Name { get; set; }
        // virtual means it CAN be overriden but doen'st need to be
        public virtual int Floors { get; set; }

        public Building()
        {
            // share default
            Floors = 1;
        }
    }
}