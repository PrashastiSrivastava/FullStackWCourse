// IN a publisher subcriber model, the publisher is responsible for sending messages or
// events to subscribers.
// The publisher does not need to know who the subscribers are or how they will handle
// the messages.
// The subscribers can choose to subscribe to specific types of messages or events that
// they are interested in.

// Problemstatement based on real world use case :
// Consider a news agency that publishes news articles on various topics such as sports,
// politics, and entertainment.
// The news agency acts as the publisher, while the readers who subscribe to the news
// articles are the subscribers.
// The news agency can publish articles on different topics, and the readers can choose
// to subscribe to the topics they are interested in.

// Step by step implementation of publisher subscriber model:
//Step bystep implementation of publisher subscriber model in C#:
//Step 1: Define the Publisher class ex : NewsAgency
//Step 2: Define the Subscriber class ex : Reader
//Step 3: Implement the subscription mechanism in the Publisher class ex: Subscribe method
//Step 4: Implement the notification mechanism in the Publisher class ex: Publish method
//Step 5: Create instances of the Publisher and Subscriber classes and
//demonstrate the functionality.

using _3_News_Agency_Publisher_Subscriber_Model;
using System.Reflection.Metadata;

Console.WriteLine("=== News Agency Publisher-Subscriber Demo ===");

// Step 7:- Create Publisher (News Agency)
NewsAgency NDTV = new NewsAgency("NDTV News Agency");
NewsAgency BBC = new NewsAgency("BBC News Agency");

// Step 8:- Create Subscribers (Readers) - Maximum 4 subscribers
Reader rajesh = new Reader("Rajesh Kumar");
Reader priya = new Reader("Priya Sharma");
Reader amit = new Reader("Amit Patel");
Reader neha = new Reader("Neha Singh");

// Step 9:- Readers subscribe to specific topics (each subscribes to 2-3 topics)

// Rajesh is interested in Sports and Politics
rajesh.SubscribeToTopic("Sports");
rajesh.SubscribeToTopic("Politics");

// Priya is interested in Entertainment and Technology
priya.SubscribeToTopic("Entertainment");
priya.SubscribeToTopic("Technology");

// Amit is interested in Sports and Entertainment
amit.SubscribeToTopic("Sports");
amit.SubscribeToTopic("Entertainment");

// Neha is interested in Politics and Technology
neha.SubscribeToTopic("Politics");
neha.SubscribeToTopic("Technology");

// Step 10:- News Agency adds Readers (Subscribers)
NDTV.Subscribe(rajesh);
NDTV.Subscribe(amit);

BBC.Subscribe(priya);
BBC.Subscribe(neha);
BBC.Subscribe(amit);  // Amit subscribes to both news agencies

Console.WriteLine($"\n📊 Subscriber Statistics:");
Console.WriteLine($"BBC News has {BBC.GetSubscriberCount()} active listeners");
Console.WriteLine($"NDTV has {NDTV.GetSubscriberCount()} active listeners\n");

// Step 11: Publish different types of news
Console.WriteLine("=== PUBLISHING NEWS ARTICLES ===\n");

// Publish Sports news
BBC.PublishNews("Sports", "World Cup Final",
    "Exciting match ends with a stunning victory in overtime!");
Thread.Sleep(1000); // Small delay for readability

// Publish Politics news
BBC.PublishNews("Politics", "Election Results",
    "New government announces major policy changes.");
Thread.Sleep(1000);

// Publish Technology news
BBC.PublishNews("Technology", "AI Breakthrough",
    "New AI model achieves human-level performance in complex tasks.");
Thread.Sleep(1000);

// Publish Entertainment news
BBC.PublishNews("Entertainment", "Film Awards",
    "Surprise winner takes home best picture at annual awards.");
Thread.Sleep(1000);

// Publish Sports news from NDTV
NDTV.PublishNews("Sports", "Olympic Updates",
    "New world record set in swimming competition.");

// Publish Technology news from NDTV
NDTV.PublishNews("Technology", "Smartphone Launch",
    "Revolutionary new smartphone with advanced features released.");

// Step 12: Demonstrate unsubscribe functionality
Console.WriteLine("\n=== DEMONSTRATING UNSUBSCRIBE ===\n");
Console.WriteLine("Amit Patel decides to unsubscribe from Sports news");
amit.UnsubscribeFromTopic("Sports");

Console.WriteLine("\nPublishing Sports news after Amit unsubscribed:");
BBC.PublishNews("Sports", "Cricket Tournament",
    "India wins the series in a thrilling finish!");

Console.WriteLine("\n=== DEMO COMPLETE ===");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();