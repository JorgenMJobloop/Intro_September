namespace Collections;

class Program
{
    static void Main(string[] args)
    {
        TaskThree three = new TaskThree();

        three.Password = "passord123";

        Console.WriteLine(three.GetStringLength(three.Password));
        Console.WriteLine(three.IsPasswordStrong());


        string number = "2";
        int.TryParse(number, out int _number);
        Console.WriteLine(_number + 2);

        CollectionExamples collectionExamples = new CollectionExamples();
        WebpageInfo webPageInfo = new WebpageInfo();
        FileReader reader = new FileReader();

        collectionExamples.betterShoppingList!.Add("Juice");
        collectionExamples.betterShoppingList!.Add("Waffles");


        foreach (string content in collectionExamples.betterShoppingList)
        {
            Console.WriteLine(content);
        }

        webPageInfo.URLS = ["https://google.com", "https://youtube.com", "https://vg.no"];
        webPageInfo.NumberOfVisitorsDaily = [1050003, 110100250, 1500200];
        webPageInfo.AllTimeVisitors = new Dictionary<string, string>()
        {
            ["22.05.2003"] = "150.000",
            ["23.08.2012"] = "120.000.000"
        };

        foreach (string urls in webPageInfo.URLS)
        {
            Console.WriteLine(urls);
        }

        foreach (double visitors in webPageInfo.NumberOfVisitorsDaily)
        {
            Console.WriteLine("Daily visitors: " + visitors);
        }

        foreach (var alltimeVisits in webPageInfo.AllTimeVisitors)
        {
            Console.WriteLine("All time visits: " + alltimeVisits);
        }

        reader.ReadAllContent("my_document.txt");
        
    }
}
