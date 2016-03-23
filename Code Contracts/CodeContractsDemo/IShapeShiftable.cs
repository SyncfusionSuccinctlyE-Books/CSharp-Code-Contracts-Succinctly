//using System.Diagnostics.Contracts;

//[ContractClass(typeof(IShapeShiftableContract))]
//public interface IShapeShiftable
//{
//    void Man(int shapeDuration);
//    void Woman(int shapeDuration);
//    void InanimateObject(int shapeDuration);
//}

//[ContractClassFor(typeof(IShapeShiftable))]
//abstract class IShapeShiftableContract : IShapeShiftable
//{
//    void IShapeShiftable.InanimateObject(int shapeDuration)
//    {
//        Contract.Requires(shapeDuration <= 12);
//    }

//    void IShapeShiftable.Man(int shapeDuration)
//    {
//        Contract.Requires(shapeDuration <= 4);
//    }

//    void IShapeShiftable.Woman(int shapeDuration)
//    {
//        Contract.Requires(shapeDuration <= 4);
//    }
//}
