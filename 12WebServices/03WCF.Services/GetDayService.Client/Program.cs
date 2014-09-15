namespace GetDayService.Client
{
    using GetDayService.Client.DayTellerService;
    using System;

    class Program
    {
        static void Main()
        {
            using (DayTellerClient client = new DayTellerClient())
            {
                for (int i = 0; i <= 7; i++)
                {
                    Console.WriteLine(client.GetDayFromDate(DateTime.Now.AddDays(-i)));
                }
            }
        }
    }
}