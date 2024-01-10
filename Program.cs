using System;
using System.IO;

namespace ConsoleApp1;

public class returnedOutput
{
    public string portraitImage { get; set; }
    public int statusCode { get; set; }
    public string errorMessage { get; set; }
    public Dictionary<string, object> fields { get; set; }
    public string regulaResponse { get; set; }

}

public class AvailableSourceList
{
    public string source { get; set; }
    public int validityStatus { get; set; }
    public int containerType { get; set; }
}

public class ContainerList
{
    public List<List> List { get; set; }
}

public class DetailsOptical
{
    public int overallStatus { get; set; }
    public int docType { get; set; }
    public int expiry { get; set; }
    public int imageQA { get; set; }
    public int mrz { get; set; }
    public int pagesCount { get; set; }
    public int security { get; set; }
    public int text { get; set; }
}

public class DetailsRFID
{
    public int overallStatus { get; set; }
    public int AA { get; set; }
    public int BAC { get; set; }
    public int CA { get; set; }
    public int PA { get; set; }
    public int PACE { get; set; }
    public int TA { get; set; }
}

public class FDSIDList
{
    public string ICAOCode { get; set; }
    public List<int> List { get; set; }
    public int dType { get; set; }
    public string dDescription { get; set; }
    public string dYear { get; set; }
    public string dCountryName { get; set; }
}

public class FieldList
{
    public int fieldType { get; set; }
    public string fieldName { get; set; }
    public int status { get; set; }
    public int validityStatus { get; set; }
    public int comparisonStatus { get; set; }
    public string value { get; set; }
    public List<ValueList> valueList { get; set; }
    public List<ValidityList> validityList { get; set; }
    public List<object> comparisonList { get; set; }

    internal FieldList Where(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }

    /*public static explicit operator FieldList(List<FieldList> v)
    {
        throw new NotImplementedException();
    }

    internal void Where(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }*/
}

public class FieldRect
{
    public int left { get; set; }
    public int top { get; set; }
    public int right { get; set; }
    public int bottom { get; set; }
}

public class Images
{
    public List<AvailableSourceList> availableSourceList { get; set; }
    public List<FieldList> fieldList { get; set; }
}

public class List
{
    public OneCandidate OneCandidate { get; set; }
    public int buf_length { get; set; }
    public int result_type { get; set; }
    public Text Text { get; set; }
    public Images Images { get; set; }
    public Status Status { get; set; }
}

public class OneCandidate
{
    public string DocumentName { get; set; }
    public int ID { get; set; }
    public double P { get; set; }
    public FDSIDList FDSIDList { get; set; }
    public int NecessaryLights { get; set; }
    public int CheckAuthenticity { get; set; }
    public int UVExp { get; set; }
    public int AuthenticityNecessaryLights { get; set; }
}

public class OriginalSymbol
{
    public int code { get; set; }
    public int probability { get; set; }
    public Rect rect { get; set; }
}

public class Rect
{
    public int left { get; set; }
    public int top { get; set; }
    public int right { get; set; }
    public int bottom { get; set; }
}

public class RegulaResponse
{
    public int ProcessingFinished { get; set; }
    public ContainerList ContainerList { get; set; }
    public TransactionInfo TransactionInfo { get; set; }
    public int morePagesAvailable { get; set; }
    public int elapsedTime { get; set; }
}

public class Status
{
    public int overallStatus { get; set; }
    public int optical { get; set; }
    public int portrait { get; set; }
    public int rfid { get; set; }
    public int stopList { get; set; }
    public DetailsRFID detailsRFID { get; set; }
    public DetailsOptical detailsOptical { get; set; }
}

public class Text
{
    public int status { get; set; }
    public int validityStatus { get; set; }
    public int comparisonStatus { get; set; }
    public List<FieldList> fieldList { get; set; }
    public List<AvailableSourceList> availableSourceList { get; set; }
}

public class TransactionInfo
{
    public string ComputerName { get; set; }
    public DateTime DateTime { get; set; }
    public string TransactionID { get; set; }
    public string UserName { get; set; }
}

public class ValidityList
{
    public string source { get; set; }
    public int status { get; set; }
}

public class ValueList
{
    public string source { get; set; }
    public string value { get; set; }
    public List<OriginalSymbol> originalSymbols { get; set; }
    public int pageIndex { get; set; }
    public string originalValue { get; set; }
    public int? probability { get; set; }
    public FieldRect fieldRect { get; set; }
    public int lightIndex { get; set; }
    public int containerType { get; set; }
}


public static class Program
{

    private static readonly string textFile = @"C:\Users\davidl\Downloads";

    static void Main(string[] args)
    {
        string text = File.ReadAllText(textFile);
        Console.WriteLine(text);
        Console.WriteLine("Hello, World!");
    }
}
