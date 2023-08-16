using System;

namespace CSVHelperImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVHandlerImplement cSVHandlerImplement = new CSVHandlerImplement();
            cSVHandlerImplement.ImplementCSVHandler();
            cSVHandlerImplement.ImplementCSVHandlerToJson();
            cSVHandlerImplement.ImplementJsonToCsv();
        }
    }
}