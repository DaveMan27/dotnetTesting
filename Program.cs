using System;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
// using System.string;


namespace ConsoleApp1;

public class returnedOutput
{
    public string? portraitImage { get; set; }
    public int statusCode { get; set; }
    public string? errorMessage { get; set; }
    public Dictionary<string, object>? fields { get; set; }
    public string? regulaResponse { get; set; }

}

public class AvailableSourceList
{
    public string? source { get; set; }
    public int validityStatus { get; set; }
    public int containerType { get; set; }
}

public class ContainerList
{
    public List<List>? List { get; set; }
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
    public string? ICAOCode { get; set; }
    public List<int>? List { get; set; }
    public int dType { get; set; }
    public string? dDescription { get; set; }
    public string? dYear { get; set; }
    public string? dCountryName { get; set; }
}

public class FieldList
{
    public int fieldType { get; set; }
    public string? fieldName { get; set; }
    public int status { get; set; }
    public int validityStatus { get; set; }
    public int comparisonStatus { get; set; }
    public string? value { get; set; }
    public List<ValueList>? valueList { get; set; }
    public List<ValidityList>? validityList { get; set; }
    public List<object>? comparisonList { get; set; }



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
    public List<AvailableSourceList>? availableSourceList { get; set; }
    public List<FieldList>? fieldList { get; set; }
}

public class List
{
    public OneCandidate? OneCandidate { get; set; }
    public int buf_length { get; set; }
    public int result_type { get; set; }
    public Text? Text { get; set; }
    public Images? Images { get; set; }
    public Status? Status { get; set; }
}

public class OneCandidate
{
    public string? DocumentName { get; set; }
    public int ID { get; set; }
    public double P { get; set; }
    public FDSIDList? FDSIDList { get; set; }
    public int NecessaryLights { get; set; }
    public int CheckAuthenticity { get; set; }
    public int UVExp { get; set; }
    public int AuthenticityNecessaryLights { get; set; }
}

public class OriginalSymbol
{
    public int code { get; set; }
    public int probability { get; set; }
    public Rect? rect { get; set; }
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
    public ContainerList? ContainerList { get; set; }
    public TransactionInfo? TransactionInfo { get; set; }
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
    public DetailsRFID? detailsRFID { get; set; }
    public DetailsOptical? detailsOptical { get; set; }
}

public class Text
{
    public int status { get; set; }
    public int validityStatus { get; set; }
    public int comparisonStatus { get; set; }
    public List<FieldList>? fieldList { get; set; }
    public List<AvailableSourceList>? availableSourceList { get; set; }
}

public class TransactionInfo
{
    public string? ComputerName { get; set; }
    public DateTime DateTime { get; set; }
    public string? TransactionID { get; set; }
    public string? UserName { get; set; }
}

public class ValidityList
{
    public string? source { get; set; }
    public int status { get; set; }
}

public class ValueList
{
    public string? source { get; set; }
    public string? value { get; set; }
    public List<OriginalSymbol>? originalSymbols { get; set; }
    public int pageIndex { get; set; }
    public string? originalValue { get; set; }
    public int? probability { get; set; }
    public FieldRect? fieldRect { get; set; }
    public int lightIndex { get; set; }
    public int containerType { get; set; }
}


public static class Program
{

    private static readonly string textFile = @"C:\Users\davidl\Downloads\document_reader_2024-10-01_12-55-06_response.json";
    //private static readonly string textFile = @"C:\Users\davidl\Downloads\data.txt";
    //private static readonly string textFile = @"C:\Users\davidl\Downloads\olwyn_visa.json";
    //private static readonly string textFile = @"C:\Users\davidl\Downloads\viviane_json.json";





    static void Main(string[] args)
    {

        try
        {
            string text = File.ReadAllText(textFile);
            Console.WriteLine("Hello, World!");
            if (!String.IsNullOrEmpty(text))
            {
                //RegulaResponse? regulaResponse = JsonConvert.DeserializeObject<RegulaResponse>(textFile);
                RegulaResponse? myResponse = JsonSerializer.Deserialize<RegulaResponse>(text);
                Console.WriteLine(myResponse);

                List<FieldList> retrievedFieldList = new List<FieldList>();
                if (myResponse != null &&
                        myResponse.ContainerList != null &&
                        myResponse.ContainerList.List != null &&
                        myResponse.ContainerList.List.Count > 0)
                {
                    foreach (var listItem in myResponse.ContainerList.List)
                    {
                        if (listItem.Text != null &&
                            listItem.Text.fieldList != null &&
                            listItem.Text.fieldList.Count > 0)
                        {
                            retrievedFieldList = listItem.Text.fieldList;
                        }

                        if (listItem.Images != null &&
                            listItem.Images.fieldList != null &&
                            listItem.Images.fieldList.Count > 0
                        )
                        {
                            foreach (FieldList fl in listItem.Images.fieldList)
                            {
                                if (fl.fieldName == "Portrait")
                                {
                                    if (fl.valueList != null &&
                                        fl.valueList.Count > 0)
                                    {
                                        foreach (var vlProp in fl.valueList)
                                        {
                                            if (vlProp.source == "VISUAL" &&
                                                vlProp.value != null)
                                            {
                                                Console.WriteLine("" + vlProp.value);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    HashSet<string> fieldHashSet = new HashSet<string>();
                    List<string> duplicateFieldsList = new List<string>();

                    //List<Dictionary<string, object>> objectList = new List<Dictionary<string, object>>();
                    foreach (var item in retrievedFieldList)
                    {
                        if (fieldHashSet.Add(item.fieldName))
                        {
                            fieldHashSet.Add(item.fieldName);
                        }
                        else
                        {
                            duplicateFieldsList.Add(item.fieldName.ToString());
                            Console.WriteLine("Duplicate Fields: " + item.fieldName.ToString());
                        }
                    }
                    Console.WriteLine("Finished building duplicateFieldList");
                    Dictionary<string, object> newObject = new Dictionary<string, object>();

                    List<FieldList> duplicateRecords = new List<FieldList>();

                    foreach (FieldList item in retrievedFieldList)
                    {
                        if (duplicateFieldsList.Contains(item.fieldName.ToString()))
                        {
                            duplicateRecords.Add(item);
                        }
                        else
                        {
                            newObject.Add(String.Concat(item.fieldName.ToString().Where(c => !Char.IsWhiteSpace(c))), item.value);
                        }
                    }

                    foreach (FieldList item in duplicateRecords)
                    {
                        Console.WriteLine(item.fieldName.ToString() + ": " + item.value.ToString() + "---" + ContainsNonEnglishCharacters(item.value.ToString()));

                        var mrzVl = item.valueList.Where(vl => vl.source == "MRZ").ToList();
                        var visualVl = item.valueList.Where(vl => vl.source == "VISUAL").ToList();


                        if (mrzVl.Any())
                        {
                            if (!ContainsNonEnglishCharacters(mrzVl[0].value.ToString()))
                            {
                                newObject.Add(String.Concat(item.fieldName.ToString().Where(c => !Char.IsWhiteSpace(c))), mrzVl[0].value);
                            }

                            if (ContainsNonEnglishCharacters(item.value.ToString()) || ContainsNonEnglishCharacters(visualVl[0].value.ToString()))
                            {
                                //if (!newObject.ContainsKey(String.Concat(item.fieldName.ToString().Where(c => !Char.IsWhiteSpace(c)))))
                                //{
                                newObject.Add(String.Concat(item.fieldName.ToString().Where(c => !Char.IsWhiteSpace(c))) + "_SecondaryLanguage", visualVl[0].value);
                                //}
                            }

                        }


                        /*
                        
                        if (ContainsNonEnglishCharacters(item.value.ToString()))
                        {
                            Console.WriteLine("---------------");
                            Console.WriteLine(item.value.ToString() + "");

                                               
                            


                            if (ContainsNonEnglishCharacters(visualVl[0].value.ToString()))
                            {
                                Console.WriteLine(visualVl[0].value.ToString() + "");
                                newObject.Add(String.Concat(item.fieldName.ToString().Where(c => !Char.IsWhiteSpace(c))) + "_SecondaryLanguage", visualVl[0].value);
                            }
                            else
                            {
                                newObject.Add(String.Concat(item.fieldName.ToString().Where(c => !Char.IsWhiteSpace(c))), mrzVl[0].value);
                            }
                        }
                        else
                        {
                            newObject.Add(String.Concat(item.fieldName.ToString().Where(c => !Char.IsWhiteSpace(c))), item.value.ToString());
                        }
                    }*/
                    }

                    foreach (var objItem in newObject)
                    {
                        Console.WriteLine(objItem);
                    }

                }
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private static bool ContainsNonEnglishCharacters(string input)
    {
        // Regular expression to match any character outside the ASCII range
        Regex regex = new Regex(@"[^\x00-\x7F]|[\?]");

        return regex.IsMatch(input);
    }
}
