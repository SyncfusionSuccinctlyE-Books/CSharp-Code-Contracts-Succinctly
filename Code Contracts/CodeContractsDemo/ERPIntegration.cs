using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

namespace CodeContractsDemoProject
{
    /// <summary>
    /// ERP Warehouse Integration Class to manage the cutting of steel volume and available bin quantities
    /// </summary>
    public class ERPWarehouseIntegration
    {
        public ERPWarehouseIntegration()
        {
            //CalculatedCuttingFactor = factor;
        }
        /// <summary>
        /// The maximum bin quantity for bins
        /// </summary>
        public int MaxBinQuantity { get; private set; }
        /// <summary>
        /// The current bin quantity available
        /// </summary>
        public int CurrentBinQuantity { get; private set; }
        /// <summary>
        /// The new valid cutting factor calculated by ProductionVolumePerBin
        /// </summary>
        public int CalculatedCuttingFactor { get; private set; } = 0;

        /*
        public int QuantityRequired { get; private set; }
        public int BinCount { get; private set; }

        public void CompleteBinPreparation(int quantityRequired)
        {
            QuantityRequired = quantityRequired;
            int available = BinQtyAvailable();
            Contract.Assume(QuantityRequired <= available, "Quantity required exceeds available bin quantity");
        }

        public void ProcessBin(string bin)
        {
            Contract.Requires(bin != null);
            Contract.Assert(!Contract.Exists(ProcessedBins(),
                x => string.Compare(x, bin, true) == 0),
                "Bin " + bin + " already processed");

            // Process bin and add to Processed Bins colection        
        }

        private List<string> ProcessedBins()
        {
            List<string> oBinsProcessed = new List<string>();
            oBinsProcessed.Add("A12");
            oBinsProcessed.Add("CD25");
            oBinsProcessed.Add("ZX4R");
            oBinsProcessed.Add("A11");

            return oBinsProcessed;
        }


        public void CutSteelNoScrap(int volumeSteel, int factor)
        {
            Contract.Ensures(volumeSteel != 0, "The volume of steel can't be zero");
            Contract.Ensures(Contract.OldValue<int>(volumeSteel)
                == CutSteel(volumeSteel, factor) + volumeSteel,
                "The factor used will result in scrap. Please modify the cutting factor.");

            // Process steel to cut
        }
        */

        /// <summary>
        /// Calculate the production volume of steel per bin
        /// </summary>
        /// <param name="binVolume"></param>
        /// <param name="factor"></param>
        /// <returns>Bin Volume less Remainder</returns>
        public int ProductionVolumePerBin(int binVolume, int factor)
        {
            Contract.Requires(IsEven(binVolume), 
                "Invalid bin volume entered");
            Contract.Requires(factor > 1, 
                "The supplied cutting factor must be more than the value 1.");
            Contract.Requires(binVolume > factor, 
                "The cutting factor cannot be greater than the bin volume");
            Contract.Ensures(Contract.Result<int>() == binVolume,
                "The factor used will result in scrap. Please modify the cutting factor.");

            int remainder = CutSteel(binVolume, factor);
            while ((binVolume - remainder) != binVolume)
            {
                CalculatedCuttingFactor = CalculateNewCutFactor(binVolume);
                remainder = CutSteel(binVolume, CalculatedCuttingFactor);
            }
            
            return binVolume - remainder;
        }

        /// <summary>
        /// Calculate any remainder after the modulus operation between volume and factor
        /// </summary>
        /// <param name="volumeToCut"></param>
        /// <param name="factor"></param>
        /// <returns>Remainder after cutting</returns>
        private int CutSteel(int volumeToCut, int factor)
        {
            // Use modulus to determine if the factor produces any scrap
            return volumeToCut % factor;
        }

        /// <summary>
        /// Calculate a new cutting factor 
        /// r.Next(1, 7); returns a random number between 1 and 7
        /// </summary>
        /// <param name="binVol">Upper range value of random (bin volume + 1)</param>
        /// <returns>
        /// A new cutting factor greater than 1 and equal to the bin volume
        /// </returns>
        private int CalculateNewCutFactor(int binVol)
        {
            return GetRandom(1, binVol + 1);            
        }

        /// <summary>
        /// Get a random number
        /// </summary>
        /// <param name="minValue">Value not less than 2</param>
        /// <param name="maxValue">Upper range value of the random number to generate</param>
        /// <returns>A random Integer</returns>        
        static int GetRandom(int minValue, int maxValue)
        {
            Contract.Requires(minValue >= 2, 
                "minValue cannot be less than 2");
            Random r = new Random();
            return r.Next(minValue, maxValue);
        }




        



        /// <summary>
        /// Ensure that the passed volume is even
        /// </summary>
        /// <param name="volume">The volume to verify</param>
        /// <returns>boolean</returns>
        public bool IsEven(int volume)
        {
            return volume % 2 == 0;
        }








        //Random r = new Random();
        //return r.Next(2, binVol + 1);

        /// <summary>
        /// Ensure that a non-negative value is returned for available bin quantity
        /// </summary>
        /// <returns>Available bin quantity</returns>
        public int BinQtyAvailable()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            MaxBinQuantity = 75;
            CurrentBinQuantity = 50;
            int QtyAvailable = MaxBinQuantity - CurrentBinQuantity;
            return QtyAvailable;
        }

        /// <summary>
        /// Ensure that all bins are filled and that the steel volume does not exceed the maximum bin volume
        /// </summary>
        /// <param name="binOverCount"></param>
        /// <param name="binVol"></param>
        /// <param name="steelVol"></param>
        public void EnsureAllBinsFilled(out int binOverCount, int binVol, int steelVol)
        {
            Contract.Ensures(Contract.ValueAtReturn<int>(out binOverCount) == 0,
                "The steel volume exceeds the bin volume");

            binOverCount = steelVol % binVol;
        }

    }


    

    //public class Male : Human
    //{
    //    public override void Run(int distance)
    //    {
    //        Console.Write("The distance run is " + distance);
    //        Console.ReadLine();
    //    }

    //    public override void Sleep(int hours)
    //    {
    //        Console.Write("The hours slept were " + hours);
    //        Console.ReadLine();
    //    }
    //}



    //public class Alien : Human, IShapeShiftable
    //{
    //    public override void Run(int distance)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void Sleep(int hours)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void InanimateObject(int shapeDuration)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Man(int shapeDuration)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Woman(int shapeDuration)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}




    public class DemoPurity
    {
        /// <summary>
        /// Property for cutting factor
        /// </summary>
        public int CutFactor { get; private set; }

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="cutFactor"></param>
        public DemoPurity(int cutFactor)
        {
            CutFactor = cutFactor;
        }

        /// <summary>
        /// Calculate the volume cut
        /// </summary>
        /// <param name="volumeSteel"></param>
        /// <param name="factorModifier"></param>
        /// <returns></returns>
        public int VolumeCut(int volumeSteel, int factorModifier)
        {
            Contract.Requires(CalculatedCutFactor(factorModifier) >= 0);

            return volumeSteel / (CutFactor * factorModifier);
        }

        /// <summary>
        /// This is not a pure method
        /// </summary>
        /// <param name="factorModifier"></param>
        /// <returns></returns>
        [Pure]
        public int CalculatedCutFactor(int factorModifier)
        {
            return CutFactor * factorModifier;
        }
    }




    public class AbbreviatorDemo
    {
        /// <summary>
        /// The factor for the cutting volume
        /// </summary>
        public int Factor { get; private set; }
        /// <summary>
        /// The maximum volume a bin can contain
        /// </summary>
        public int MaxVolume { get; private set; }

        /// <summary>
        /// Fill the bin with the volume of steel
        /// </summary>
        /// <param name="steelVolume"></param>
        public void FillBin(int steelVolume)
        {
            ValidSteelAndMaxVolume(steelVolume);
        }

        /// <summary>
        /// Empty the bin of all steel contained
        /// </summary>
        /// <param name="steelVolume"></param>
        /// <returns></returns>
        public bool PurgeBin(int steelVolume)
        {
            ValidSteelAndMaxVolume(steelVolume);
            EnsurePositiveResult();

            // Purge Bin and return successful result
            return true;
        }

        /// <summary>
        /// Perform a partial bin fill
        /// </summary>
        /// <param name="steelVolume"></param>
        /// <returns></returns>
        public bool FillBinPartially(int steelVolume)
        {
            ValidSteelAndMaxVolume(steelVolume);
            EnsurePositiveResult();

            return true;
        }

        /// <summary>
        /// Abbreviator Method for steel and max volume
        /// </summary>
        /// <param name="steelVolume"></param>
        [ContractAbbreviator]
        private void ValidSteelAndMaxVolume(int steelVolume)
        {
            Contract.Requires(steelVolume > 0);
            Contract.Ensures(steelVolume <= this.MaxVolume);
        }

        /// <summary>
        ///  Abbreviator Method for successful result
        /// </summary>
        [ContractAbbreviator]
        private void EnsurePositiveResult()
        {
            Contract.Ensures(Contract.Result<bool>() == true);
        }
    }


    public class Visibility
    {
        //[ContractPublicPropertyName("GetFactor")]
        private int _internalFactor;

        public int GetFactor
        {
            get { return _internalFactor; }
            set { _internalFactor = value; }
        }

        public Visibility(int factor)
        {
            Contract.Requires(factor != 0);
            _internalFactor = factor;
        }

        //public void DetermineFactor()
        //{
        //    Contract.Requires(_internalFactor > 0);
        //}
    }


    /*
    public static class ERPIntegration
    {
        public static string ProductCode { get; private set;}
        public static int SerialNumber { get; private set; }
        public static int Quantity { get; private set; }

        public static Warehouse AddSerializedItem(string productCode, int serialNumber, int qty)
        {        
            Contract.Requires<SerialNumberException>
                (serialNumber >= 100000001, "Invalid Serial number");
            Contract.Ensures(Contract.Result<Warehouse>() != null);

            ProductCode = productCode;
            SerialNumber = serialNumber;
            Quantity = qty;

            return CreateItem();
        }

        public static void GetSerializedItem(string serialNumber)
        {
            //Contract.Assert
            //Contract.Assume
            //Contract.ContractFailed
            //Contract.EndContractBlock
            //Contract.EnsuresOnThrow
            //Contract.Equals
            //Contract.Exists
            //Contract.ForAll
            //Contract.OldValue<>
            //Contract.Result<>
            //Contract.ValueAtReturn<>
        }


        private static Warehouse CreateItem()
        {
            // Add Stocked Item code goes here
            Warehouse IssuedToWarehouse = new Warehouse(ProductCode);
            switch (ProductCode.Substring(0,1))
            {
                case "A":
                    IssuedToWarehouse.Code = "FM";
                    IssuedToWarehouse.Name = "Fast movers";
                    IssuedToWarehouse.Bin = IssuedToWarehouse.ReturnWarehouseBin();
                    IssuedToWarehouse.BinReorderLevel = 10000;
                    IssuedToWarehouse.LastStockTake = Convert.ToDateTime("2015-09-01");

                    break;
                case "B":
                    IssuedToWarehouse.Code = "FG";
                    IssuedToWarehouse.Name = "Finished Goods";
                    IssuedToWarehouse.Bin = IssuedToWarehouse.ReturnWarehouseBin();
                    IssuedToWarehouse.BinReorderLevel = 500;
                    IssuedToWarehouse.LastStockTake = Convert.ToDateTime("2015-09-04");
                    break;
                case "C":
                    IssuedToWarehouse.Code = "RM";
                    IssuedToWarehouse.Name = "Raw Materials";
                    IssuedToWarehouse.Bin = IssuedToWarehouse.ReturnWarehouseBin();
                    IssuedToWarehouse.BinReorderLevel = 7500;
                    IssuedToWarehouse.LastStockTake = Convert.ToDateTime("2015-09-02");
                    break;
                default:
                    IssuedToWarehouse.Code = "GS";
                    IssuedToWarehouse.Name = "General Stock";
                    IssuedToWarehouse.Bin = IssuedToWarehouse.ReturnWarehouseBin();
                    IssuedToWarehouse.BinReorderLevel = 5000;
                    IssuedToWarehouse.LastStockTake = Convert.ToDateTime("2015-09-09");
                    break;
            }
            return IssuedToWarehouse;
        }


    }


    public class SerialNumberException : Exception
    {
        public SerialNumberException()
        {
        }

        public SerialNumberException(string message)
            : base(message)
        {
        }

        public SerialNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class Warehouse
    {
        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(this.ProductionYear >= 0);        
            Contract.Invariant(this.ProductionMonth >= 0);
            Contract.Invariant(this.ProductionMonth <= 12);
            Contract.Invariant(this.ProductionDay >= 0);
            Contract.Invariant(this.ProductionDay <= 30);
        }

        public Warehouse(string stockCode)
        {
            StockCode = stockCode;
        }

        public string ReturnWarehouseBin()
        {
            Contract.Requires(0 <= (this.StockCode.Length - 1));

            string returnBin = "";
            try
            {
                if (!StockCode.Substring(0, 1).ToLower().Equals("X"))
                {
                    returnBin = ReadWarehouseBin();
                }
                return returnBin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string StockCode { get; private set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Bin { get; set; }
        public int BinReorderLevel { get; set; }
        public DateTime LastStockTake { get; set; }

        public int ProductionDay { get; set; }
        public int ProductionMonth { get; set; }
        public int ProductionYear { get; set; }

        private string ReadWarehouseBin()
        {
            string bin = "GS";

            if (StockCode.Substring(0, 1).ToLower().Equals("a"))
                bin = "A";
            if (StockCode.Substring(0, 1).ToLower().Equals("b"))
                bin = "B";
            if (StockCode.Substring(0, 1).ToLower().Equals("c"))
                bin = "AD";

            return bin;
        }
    }

    */

   
}




