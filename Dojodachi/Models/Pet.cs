using System;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Models
{
    public class Pet
    {
        public int Happiness { get; set; }
        public int Fullness { get; set; }
        public int Energy { get; set; }
        public int Meals { get; set; }

        public string State
        {
            get
            {
                if (Energy >= 100 && Fullness >= 100 && Happiness >= 100)
                {
                    return "Win";
                }

                if (Fullness < 0 || Happiness < 0)
                {
                    return "Lose";
                }

                return "Playing";
            }
            set { }
        }

        public Pet()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            State = "Playing";
        }

        public void Feed(ISession session)
        {
            if (Meals > 0)
            {
                Meals -= 1;

                Fullness += new Random().Next(5, 11);
            }

            UpdateSession(session);
        }

        public void Play(ISession session)
        {
            Energy -= 5;
            Happiness += new Random().Next(5, 11);
            UpdateSession(session);
        }

        public void UpdateSession(ISession session)
        {
            session.SetObjectAsJson("Pet", this);
        }
    }
}