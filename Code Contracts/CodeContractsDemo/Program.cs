using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CodeContractsDemoProject;

//Warehouse IssueWarehouse = ERPIntegration.AddSerializedItem("AC32WL", 1000000, 2500);
//Console.WriteLine("The following product...");
//Console.WriteLine("Product code: BC32WL");
//Console.WriteLine("Serial: 100000005");
//Console.WriteLine("Quantity: 1251");
//Console.WriteLine("...has been issued to...");
//Console.WriteLine("Warehouse: " + IssueWarehouse.Name);
//Console.WriteLine("Warehouse code: " + IssueWarehouse.Code);
//Console.WriteLine("Issued to bin: " + IssueWarehouse.Bin);
//Console.WriteLine("Reorder level: " + IssueWarehouse.BinReorderLevel);
//Console.WriteLine("Last stock take: " + IssueWarehouse.LastStockTake);
//Console.ReadLine();

namespace CodeContractsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //int iFactor = 7;
                //int steelVolume = 10;
                //int binVolume = 2;
                //int binWastedSpace = 0; // This must always equal zero
                //ERPWarehouseIntegration oWhi = new ERPWarehouseIntegration();
                //oWhi.BinQtyAvailable();
                //oWhi.ProductionVolumePerBin(binVolume, iFactor);
                //oWhi.EnsureAllBinsFilled(out binWastedSpace, binVolume, steelVolume);

                //Console.Write("All bins filled");
                //Console.ReadLine();


                //Male oMan = new Male();
                //oMan.Sleep(9);

                #region old code
                //int volumeSteel = 100;
                //int cutFactor = 2;
                //int factorModifier = 10;
                //DemoPurity oDemo = new DemoPurity(cutFactor);
                //volumeSteel = oDemo.VolumeCut(volumeSteel, factorModifier);

                //Console.Write("Steel volume cut = " + volumeSteel + " sheets.");
                //Console.ReadLine(); 
                #endregion

                //int a = int.MinValue;
                //int result = int.MinValue % -1;
                int binVol = 20;
                int factor = 3;
                CodeContractsDemoProject.ERPWarehouseIntegration oWhi = 
                    new CodeContractsDemoProject.ERPWarehouseIntegration();



                int result = oWhi.ProductionVolumePerBin(binVol, factor);



                //string input = "Hello World";
                //input.Substring()

                                

                if (oWhi.CalculatedCuttingFactor != factor && oWhi.CalculatedCuttingFactor != 0)
                {
                    Console.Write($"The supplied cutting factor of {factor} resulted in " 
                        + "an imperfect cut. The system suggests using the following " 
                        + $"cutting factor: {oWhi.CalculatedCuttingFactor}");
                }
                else
                    Console.Write($"The cutting factor of {factor} resulted in 0 scrap");
                
                Console.ReadLine();


            }
            catch (Exception ex)  
            {
                Console.Write(ex.Message);
                Console.ReadLine();
            }
        }

        static string Substring(string input, int start, int end)
        {
            return input.Substring(0, end - start);
        }

        






    }
}
