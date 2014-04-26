using System;

namespace MobilePhoneDevice
{
    class GSMCallHistoryTest
    {
        public static void CallHistoryTest()
        {
            GSM testGSM = GSM.IPhone4s;
            testGSM.AddCall("0999-999-999", 2.3);
            testGSM.AddCall("0888-999-999", 12.4);
            testGSM.AddCall("0777-999-999", 4.34);
            testGSM.AddCall("0666-999-999", 8.2);
            testGSM.AddCall("0555-999-999", 11.2);
            Console.WriteLine("-------Showing added calls--------");
            testGSM.ShowCallHistory();

            Console.WriteLine("------Calculating total price for calls------");
            double totalCallPrice = testGSM.CalculateCallsTotalPrice();
            Console.WriteLine("{0:C}", totalCallPrice);

            Console.WriteLine("----Removing longest call and recalculating-----");
            testGSM.RemoveLongestCallEntry();
            testGSM.ShowCallHistory();
            totalCallPrice = testGSM.CalculateCallsTotalPrice();
            Console.WriteLine("{0:C}", totalCallPrice);

            Console.WriteLine("----Clearing call history-----");
            testGSM.ClearCallHistory();
            testGSM.ShowCallHistory();
        }
    }
}
