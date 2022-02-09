namespace AbstractAndInterface
{
    public abstract class Building
    {

        // Not every building can be damaged in our video game, so the abstract build class won't have a Health property.

        // an abstract prop means classes that inherit this class MUST implement or overide this prop.
        public abstract string Name { get; set; }

        // Virtual means it CAN be overriden but DOESN'T NEED to be.
        public virtual int Floors { get; set; }

        /* 
        Abstract classes cannot be instantiated directly, however, we can share
        constructor logic to all classes that inherit from this abstract class
        so when they are constructed they have this shared logic.
        */
        public Building()
        {
            // share default
            Floors = 1;
        }
    }
}