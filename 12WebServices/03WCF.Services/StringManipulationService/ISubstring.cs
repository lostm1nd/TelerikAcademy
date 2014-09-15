namespace StringManipulationService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface ISubstring
    {
        [OperationContract]
        int CountOccurrence(string source, string target);
    }
}