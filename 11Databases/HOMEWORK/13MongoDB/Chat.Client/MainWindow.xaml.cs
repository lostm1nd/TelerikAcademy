namespace Chat.Client
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Threading;

    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "mongodb://tester:tester@ds063769.mongolab.com:63769/chat";

        private DateTime signedInTimeUTC;
        private User user;
        private MongoDatabase chatDb;

        public MainWindow(string username)
        {
            InitializeComponent();

            this.signedInTimeUTC = DateTime.Now.ToUniversalTime();
            this.user = new User { Name = username };
            this.chatDb = GetChatDatabase(ConnectionString);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += ShowMessages;
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        void ShowMessages(object sender, EventArgs e)
        {
            var lastMessagesQuery = Query<Message>.Where(msg => msg.PostDate > this.signedInTimeUTC);
            var messages = chatDb.GetCollection<Message>("messages").Find(lastMessagesQuery);

            foreach (var msg in messages)
            {
                string text = string.Format("[{0} {1}] {2}", msg.PostDate.ToLocalTime(), msg.User.Name, msg.Text);

                if (!this.messageContainer.Items.Contains(text))
                {
                    this.messageContainer.Items.Add(text);
                }
            }
        }

        private MongoDatabase GetChatDatabase(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            return server.GetDatabase("chat");
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            Message newMessage = new Message
            {
                Text = this.message.Text,
                PostDate = DateTime.Now,
                User = this.user
            };

            var messages = this.chatDb.GetCollection<Message>("messages");
            messages.Insert(newMessage);

            this.message.Clear();
        }
    }
}