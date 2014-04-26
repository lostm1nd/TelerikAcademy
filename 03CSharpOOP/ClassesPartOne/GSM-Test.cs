namespace MobilePhoneDevice
{
    using System;

    class GSM_Test
    {
        static void Main()
        {
            //create array of gsm object and display info + info iphone4s
            GSM[] gsmArray = new GSM[3]
            {
                new GSM("Asha 1", "Nokia",owner: "Peter"),
                new GSM("One", "HTC", new Battery(Battery.BatteryType.LiPoly, "superBat"), new Display(6, 2640000), price: 999.90),
                new GSM("Xperia", "Sony")
            };

            foreach (var gsm in gsmArray)
            {
                Console.WriteLine(gsm);
                Console.WriteLine();
            }
            Console.WriteLine(GSM.IPhone4s);

            //test the call methods and history
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("---------STARTING CALL TEST-------");
            Console.ResetColor();
            GSMCallHistoryTest.CallHistoryTest();
        }        
    }
}
