using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;

namespace EnglishVocabulary
{
    static class DataBase
    {
        public static void CreateTopic(Topic topic)
        {
            using(IDbConnection db = new SQLiteConnection(
                ConfigurationManager.
                ConnectionStrings["VocabularyDBConnectionString"].
                ConnectionString))
            {
                int count = db.Query<object>(
                    "select Topic from Topics " +
                    $"where Topic='{topic.TopicName}'").
                    Count();

                // If there is no such topic in table,
                // then create it.
                if(count == 0)
                {
                    // Insert new topic in Topics table.
                    db.Execute($"insert into Topics (Topic) " +
                        $"values ('{topic.TopicName}')");

                    // Create new table for this topic.
                    db.Execute($"create table '{topic.TopicName}' (" +
                        "'ID' integer not null unique," +
                        "'Subtopic' text not null unique," +
                        "primary key('ID' autoincrement))");
                }

                count = db.Query<object>(
                    $"select Subtopic from {topic.TopicName} " +
                    $"where Subtopic='{topic.Subtopic.SubtopicName}'").
                    Count();

                // If there is no such Subtopic in current topic,
                // then create it.
                if(count == 0)
                {
                    // Insert subtopic in current topic table.
                    db.Execute($"insert into {topic.TopicName} (Subtopic) " +
                        $"values ('{topic.Subtopic.SubtopicName}')");

                    // Create new table for current subtopic.
                    db.Execute($"create table '{topic.Subtopic.SubtopicName}' (" +
                        "'ID' integer not null unique," +
                        "'EngWord' text not null unique," +
                        "'RusWord' text not null," +
                        "primary key('ID' autoincrement))");
                }

                // Insert words in table.
                foreach (var word in topic.Subtopic.Words)
                {
                    count = db.Query<object>(
                        $"select EngWord from {topic.Subtopic.SubtopicName} " +
                        $"where EngWord='{word.Eng}'").
                        Count();

                    // If there no such word in table,
                    // then insert it.
                    if(count == 0)
                    {
                        db.Execute($"insert into {topic.Subtopic.SubtopicName} (EngWord ,RusWord)" +
                        $" values ('{word.Eng}' ,'{word.Rus}')");
                    }
                }
            }
        }

        public static List<string> GetTopics()
        {
            using(IDbConnection db = new SQLiteConnection(
                ConfigurationManager.
                ConnectionStrings["VocabularyDBConnectionString"].
                ConnectionString))
            {
                var topics = db.Query<string>("select Topic from Topics").ToList();
                return topics;
            }
        }

        public static List<string> GetSubtopics(string topic)
        {
            using (IDbConnection db = new SQLiteConnection(
                ConfigurationManager.
                ConnectionStrings["VocabularyDBConnectionString"].
                ConnectionString))
            {
                var subtopics = db.Query<string>($"select Subtopic from {topic}").ToList();
                return subtopics;
            }
        }

        public static List<(string eng, string rus)> GetWords(string subtopic)
        {
            using (IDbConnection db = new SQLiteConnection(
                ConfigurationManager.
                ConnectionStrings["VocabularyDBConnectionString"].
                ConnectionString))
            {
                var words = db.Query<(string, string)>($"select EngWord, RusWord from {subtopic}").ToList();
                return words;
            }
        }
    }
}
