using Biblie_Filled.Builders;
using Biblie_Filled.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal.Logging;

var pathDrive = @"chromedriver.exe";
ChromeDriver driver = new ChromeDriver(pathDrive);
Log.SetLevel(LogEventLevel.None);

BookBuilders bookBuilders = new BookBuilders();
Book? bookCreated;

do
{
    bookCreated = bookBuilders.CreateNew();
    if (bookCreated is null)
        return;

    for (int chapter = 1; chapter <= bookCreated.Chapters.Capacity; chapter++)
    {
        driver.Navigate().GoToUrl($"https://www.bibliaon.com/{bookCreated.Name.ToLower()}_{chapter}");
        var verses = driver.FindElements(By.ClassName("vers-wrap"));
        short cont = 1;

        foreach (var verse in verses)
        {
            var paragraph = verse.FindElement(By.TagName("p"));
            var span = paragraph.FindElements(By.TagName("span"));
            var text = span[1].Text;

            Console.WriteLine($"{bookCreated.Name} {chapter}-{cont}:  ");
            Console.WriteLine(text);

            cont++;
        }
    }

} while(bookCreated is not null);