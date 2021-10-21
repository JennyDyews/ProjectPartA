using System;

namespace ProjectPartA_A1
{
    class Program
    {
        struct Article
        {
            public string Name;
            public decimal Price;
            static public decimal total;
        }

        const int _maxNrArticles = 10;
        const int _maxArticleNameLength = 20;
        const decimal _vat = 0.25M;

        static Article[] articles = new Article[_maxNrArticles];
        static int nrArticles;
        static void Main(string[] args)
        {
            ReadArticles();
            PrintReciept();
        }

        private static void ReadArticles()
        {

            nrArticles = 0;
            bool nrOfArticlesValid = true;
            Console.WriteLine("Welcome to project part A!");
            Console.WriteLine("Let´s print a recipt!");
            Console.WriteLine();

            while (nrOfArticlesValid)
            {
                Console.WriteLine("How many articles do you want (Between 1-10)?");
                try
                {
                    nrArticles = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    if (nrArticles > _maxNrArticles || nrArticles < 1)
                    {
                        Console.WriteLine("Wrong input! Number of articles must be between 1 and 10");
                        continue;
                    }
                }
                catch (OverflowException) //if the number are too large
                {
                    Console.WriteLine("Value too large, number of articles must be between 1 and 10");
                    continue;
                }
                catch (FormatException) //letters instead of numbers
                {
                    Console.WriteLine("Your value is not a number, number of articles must be between 1 and 10");
                    continue;
                }

                nrOfArticlesValid = false;
            }

            for (int i = 0; i < nrArticles; i++)
            {
                Console.WriteLine($"Please enter name and price of the article #{i} in the format name;price");
                String articleInfo = Console.ReadLine();
                Console.WriteLine();
                if (!articleInfo.Contains(';'))
                {
                    Console.WriteLine("Use semicolon as seperator");
                    i--;
                    continue;
                }
                string[] article = articleInfo.Split(";");

                if (string.IsNullOrEmpty(article[0]) || string.IsNullOrWhiteSpace(article[0]))
                {
                    Console.WriteLine("Name error");
                    i--;
                    continue;
                }
                bool checkValue = decimal.TryParse(article[1], out decimal f);
                if (!checkValue)
                { 
                    Console.WriteLine("Price error");
                    i--;
                    continue;
                }
                Article.total = Article.total + Convert.ToDecimal(article[1]);
                Article article1 = new Article { Name = article[0], Price = Convert.ToDecimal(article[1]) };  
                articles[i] = article1; //Skapat en instans av en artikel
            }

        }
        private static void PrintReciept()
        {
            Console.WriteLine();
            Console.WriteLine("\nReceipt pursched articles");
            DateTime ReceiptdateTime = DateTime.Now;
            Console.Write("Purchase date:");
            Console.WriteLine(ReceiptdateTime.ToString("MM/dd/yyy HH:mm:ss"));
            Console.WriteLine();
            Console.Write($"\nNumber of items purchased:");
            Console.WriteLine(nrArticles);
            Console.WriteLine();
            Console.WriteLine("\n{0,-50} {1,5}", "# Name", "  Price");

            for (int i = 0; i < nrArticles; i++)
            {      

                Console.WriteLine($"{i + 1} {articles[i].Name,-50} {articles[i].Price,-50:C2}");
                //Your code to print out a reciept 
            }

            Console.WriteLine($"\n{"Total purchased",-52} {Article.total,-70:C2}");
            Console.WriteLine($"{"Includes VAT 25%",-51}  {Article.total * _vat,-70:C2}");
           
        }
}   } 
        

  
    
