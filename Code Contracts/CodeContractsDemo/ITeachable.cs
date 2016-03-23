//using System;
//using System.Diagnostics.Contracts;

//public interface ITeachable
//{
//    void TrapBuilding(int hoursToLearn);
//    void MapReading(int hoursToLearn);
//    void ShelterConstruction(int hoursToLearn);
//}


//abstract class ITeachableContract : ITeachable
//{
//    public void MapReading(int hoursToLearn)
//    {
//        Contract.Requires(hoursToLearn <= 1);
//    }

//    public void ShelterConstruction(int hoursToLearn)
//    {
//        Contract.Requires(hoursToLearn <= 6);
//    }

//    public void TrapBuilding(int hoursToLearn)
//    {
//        Contract.Requires(hoursToLearn <= 2);
//    }
//}