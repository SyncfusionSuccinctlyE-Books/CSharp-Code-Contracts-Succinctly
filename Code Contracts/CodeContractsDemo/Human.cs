//using System;
//using System.Diagnostics.Contracts;

///// <summary>
///// Human Abstract Class
///// </summary>
//[ContractClass(typeof(HumanContract))]
//public abstract class Human : ITeachable
//{
//    public void MapReading(int hoursToLearn)
//    {
//        Console.Write("Hours taken to learn Map Reading = " + hoursToLearn);
//        Console.ReadLine();
//    }

//    public abstract void Run(int distance);

//    public void ShelterConstruction(int hoursToLearn)
//    {
//        Console.Write("Hours taken to learn Shelter Construction = " + hoursToLearn);
//    }

//    public abstract void Sleep(int hours);

//    public void TrapBuilding(int hoursToLearn)
//    {
//        Console.Write("Hours taken to learn Trap Building = " + hoursToLearn);
//    }
//}

///// <summary>
///// Human Contract Class
///// </summary>
//[ContractClassFor(typeof(Human))]
//public abstract class HumanContract : Human
//{
//    public override void Sleep(int hours)
//    {
//        Contract.Requires(hours >= 8, 
//            "You need more than 8 hours of sleep each night.");
//    }
//}
