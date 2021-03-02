using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows;

namespace EnglishVocabulary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //using (IDbConnection db = new SQLiteConnection(
            //ConfigurationManager.
            //ConnectionStrings["VocabularyDBConnectionString"].
            //ConnectionString))
            //{
            //    int count = db.Query<object>(
            //        "select Topic from Topics " +
            //        $"where Topic='TopicName'").
            //        Count();

            //    // If there is no such topic in table,
            //    // then create it.
            //    if (count == 0)
            //    {
            //        // Insert new topic in Topics table.
            //        db.Execute($"insert into Topics (Topic) " +
            //            $"values ('TopicName')");

            //        // Create new table for this topic.
            //        db.Execute($"create table 'TopicName' (" +
            //            "'ID' integer not null unique," +
            //            "'Subtopic' text not null unique," +
            //            "primary key('ID' autoincrement))");
            //    }

            //    count = db.Query<object>(
            //        $"select Subtopic from TopicName " +
            //        $"where Subtopic='SubtopicName'").
            //        Count();

            //    // If there is no such Subtopic in current topic,
            //    // then create it.
            //    if (count == 0)
            //    {
            //        // Insert subtopic in current topic table.
            //        db.Execute($"insert into TopicName (Subtopic) " +
            //            $"values ('SubtopicName')");

            //        // Create new table for current subtopic.
            //        db.Execute($"create table 'SubtopicName' (" +
            //            "'ID' integer not null unique," +
            //            "'EngWord' text not null unique," +
            //            "'RusWord' text not null," +
            //            "primary key('ID' autoincrement))");
            //    }

            //    // Insert words in table.
            //    //foreach (var word in topic.Subtopic.Words)
            //    //{
            //        count = db.Query<object>(
            //            $"select EngWord from SubtopicName " +
            //            $"where EngWord='Eng'").
            //            Count();

            //        // If there no such word in table,
            //        // then insert it.
            //        if (count == 0)
            //        {
            //            db.Execute($"insert into SubtopicName (EngWord ,RusWord)" +
            //            $" values ('Eng' ,'Rus')");
            //        }
            //    //}
            //}

            //using (IDbConnection db = new SQLiteConnection(
            //ConfigurationManager.
            //ConnectionStrings["VocabularyDBConnectionString"].
            //ConnectionString))
            //{
            //    string name = "newTable";

            //    db.Execute($"create table '{name}' (" +
            //            "'ID' integer not null unique," +
            //            "'EngWord' text not null unique," +
            //            "'RusWord' text not null," +
            //            "primary key('ID' autoincrement))");

            //    db.Query<object>(
            //            $"select EngWord from {name} " +
            //            $"where EngWord='{name}'").
            //            Count();

            //    db.Execute($"insert into {name} (EngWord ,RusWord)" +
            //            $" values ('{name}' ,'{name}')");

            //    name = "newTable2";

            //    db.Execute($"create table '{name}' (" +
            //            "'ID' integer not null unique," +
            //            "'EngWord' text not null unique," +
            //            "'RusWord' text not null," +
            //            "primary key('ID' autoincrement))");

            //    db.Query<object>(
            //            $"select EngWord from {name} " +
            //            $"where EngWord='Eng'").
            //            Count();

            //    db.Execute($"insert into {name} (EngWord ,RusWord)" +
            //            $" values ('123' ,'321')");
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActivateCompanyLogo();
            LoadHelp();
            LoadAbout();
        }
    }
}