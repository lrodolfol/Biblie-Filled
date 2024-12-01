using Biblie_Filled.Builders;
using Biblie_Filled.Models;
using Biblie_Filled.Repository;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal.Logging;
using System.Collections.ObjectModel;


var pathDrive = @"chromedriver.exe";
ChromeDriver driver = new ChromeDriver(pathDrive);
Log.SetLevel(LogEventLevel.Error);

BookBuilders bookBuilders = new BookBuilders();
Book? bookCreated;

MongoDAO dao = new();

do
{
    bookCreated = bookBuilders.CreateNew();
    if (bookCreated is null)
        return;   

    for (int number = 1; number <= bookCreated.Chapters.Capacity; number++)
    {
        driver.Navigate().GoToUrl($"https://www.bibliaon.com/{bookCreated.Name.ToLower()}_{number}");
        ReadOnlyCollection<IWebElement> versesScrap = driver.FindElements(By.ClassName("vers-wrap"));
        short cont = 1;

        Chapter chapter = new();
        chapter.Number = number;

        foreach (var itemVerseScrap in versesScrap)
        {
            var paragraph = itemVerseScrap.FindElement(By.TagName("p"));
            var span = paragraph.FindElements(By.TagName("span"));
            var text = span[1].Text;

            Verse verse = new() { Number = cont, Text = text };
            chapter.Verses.AddLast(verse);

            cont++;
        }

        bookCreated.Chapters.Add(chapter);
    }

    dao.Insert(bookCreated).Wait();

} while(bookCreated is not null);