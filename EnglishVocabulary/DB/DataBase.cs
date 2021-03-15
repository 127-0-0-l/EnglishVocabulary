using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Configuration;
using Dapper;

namespace EnglishVocabulary
{
    static class DataBase
    {
        public static void CreateTopic(Topic topic)
        {
            using (IDbConnection db = new SQLiteConnection(
                ConfigurationManager.
                ConnectionStrings["VocabularyDBConnectionString"].
                ConnectionString))
            {
                string queryString =
                    "select Topic " +
                    "from Topics " +
                    $"where Topic='{topic.TopicName}'";

                int count = db.Query<object>(queryString).Count();

                // If there is no such topic in table,
                // then create it.
                if (count == 0)
                {
                    // Insert new topic in Topics table.
                    db.Execute($"insert into Topics (Topic) " +
                        $"values ('{topic.TopicName}')");

                    queryString =
                        $"create table \"Topic {topic.TopicName}\" (" +
                        "'ID' integer not null unique," +
                        "'Subtopic' text not null unique," +
                        "primary key('ID' autoincrement))";

                    // Create new table for this topic.
                    db.Execute(queryString);
                }

                count = db.Query<object>(
                    $"select Subtopic from \"Topic {topic.TopicName}\" " +
                    $"where Subtopic='{topic.Subtopic.SubtopicName}'").
                    Count();

                // If there is no such Subtopic in current topic,
                // then create it.
                if (count == 0)
                {
                    // Insert subtopic in current topic table.
                    db.Execute($"insert into \"Topic {topic.TopicName}\" (Subtopic) " +
                        $"values ('{topic.Subtopic.SubtopicName}')");

                    queryString = $"create table \"Subtopic {topic.TopicName} {topic.Subtopic.SubtopicName}\" (" +
                        "'ID' integer not null unique," +
                        "'LeftWord' text not null unique," +
                        "'RightWord' text not null," +
                        "primary key('ID' autoincrement))";

                    // Create new table for current subtopic.
                    db.Execute(queryString);
                }

                // Insert words in table.
                foreach (var word in topic.Subtopic.Words)
                {
                    count = db.Query<object>(
                        $"select LeftWord from \"Subtopic {topic.TopicName} {topic.Subtopic.SubtopicName}\" " +
                        $"where LeftWord='{word.Left}'").
                        Count();

                    // If there no such word in table,
                    // then insert it.
                    if (count == 0)
                    {
                        db.Execute(
                            $"insert into \"Subtopic {topic.TopicName} {topic.Subtopic.SubtopicName}\" " +
                            $"(LeftWord ,RightWord)" +
                            $" values ('{word.Left}' ,'{word.Right}')");
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
                var topics = db.
                    Query<string>("select Topic from Topics").
                    ToList();

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
                var subtopics = db.
                    Query<string>($"select Subtopic from \"Topic {topic}\"").
                    ToList();

                return subtopics;
            }
        }

        public static List<(string left, string right)> GetWords(string topic, string subtopic)
        {
            using (IDbConnection db = new SQLiteConnection(
                ConfigurationManager.
                ConnectionStrings["VocabularyDBConnectionString"].
                ConnectionString))
            {
                var words = db.
                    Query<(string, string)>($"select LeftWord, RightWord from \"Subtopic {topic} {subtopic}\"").
                    ToList();
                return words;
            }
        }

        public static void DeleteSubtopic(string topicName, string subtopicName)
        {
            using (IDbConnection db = new SQLiteConnection(
                ConfigurationManager.
                ConnectionStrings["VocabularyDBConnectionString"].
                ConnectionString))
            {
                db.Execute(
                    $"drop table \"Subtopic {topicName} {subtopicName}\"");

                db.Execute(
                    $"delete from \"Topic {topicName}\" where Subtopic=\"{subtopicName}\"");

                if(GetSubtopics(topicName).Count == 0)
                {
                    db.Execute(
                        $"drop table \"Topic {topicName}\"");

                    db.Execute(
                        $"delete from Topics where Topic=\"{topicName}\"");
                }
            }
        }
    }
}
