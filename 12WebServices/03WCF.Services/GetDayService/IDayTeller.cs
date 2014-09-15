namespace GetDayService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayTeller
    {
        [OperationContract]
        string GetDayFromDate(DateTime date);
    }
}