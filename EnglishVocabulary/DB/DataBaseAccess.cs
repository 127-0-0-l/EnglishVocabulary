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
    static class DataBaseAccess
    {
        public static void CreateTopic(Topic topic)
        {
            using(IDbConnection db = new SQLiteConnection(ConfigurationManager.ConnectionStrings["VocabularyDBConnectionString"].ConnectionString))
            {
                int count = db.Query<object>(
                    "select Topic from Topics " +
                    "where Topic='@TopicName'",
                    new { TopicName = topic.TopicName }).
                    Count();

                // If there is no such topic in table,
                // then create it.
                if(count == 0)
                {
                    // Insert new topic in Topics table.
                    db.Execute("insert into Topics (Topic) values (@TopicName)",
                        new { TopicName = topic.TopicName });

                    // Create new table for this topic.
                    db.Execute("create table \"(@name)\" (" +
                        "\"ID\" integer not null unique," +
                        "\"Subtopic\" text not null unique," +
                        "primary key(\"ID\" autoincrement))",
                        new { name = topic.TopicName });
                }

                count = db.Query<object>(
                    "select Subtopic from @TopicName " +
                    "where Subtopic='@SubtopicName'",
                    new { TopicName = topic.TopicName,
                        SubtopicName = topic.Subtopic.SubtopicName}).
                    Count();

                // If there is no such Subtopic in current topic,
                // then create it.
                if(count == 0)
                {
                    // Insert subtopic in current topic table.
                    db.Execute("insert into @TopicName (Subtopic) " +
                        "values (@SubtopicName)",
                        new
                        {
                            TopicName = topic.TopicName,
                            SubtopicName = topic.Subtopic.SubtopicName
                        });

                    // Create new table for current subtopic.
                    db.Execute("create table \"(@name)\" (" +
                        "\"ID\" integer not null unique," +
                        "\"EngWord\" text not null unique," +
                        "\"RusWord\" text not null," +
                        "primary key(\"ID\" autoincrement))",
                        new { name = topic.Subtopic.SubtopicName });
                }

                // Insert words in table.
                foreach (var word in topic.Subtopic.Words)
                {
                    count = db.Query<object>(
                        "select EngWord from @SubtopicName " +
                        "where EngWord='@Eng'",
                        new
                        {
                            SubtopicName = topic.Subtopic.SubtopicName,
                            Eng = word.Eng
                        }).
                        Count();

                    // If there no such word in table,
                    // then insert it.
                    if(count == 0)
                    {
                        db.Execute("insert into @SubtopicName (EngWord ,RusWord)" +
                        " values (@Eng ,@Rus)",
                        new { Eng = word.Eng, Rus = word.Rus });
                    }
                }
            }
        }

        public static List<string> GetData()
        {
            using(IDbConnection db = new SQLiteConnection(ConfigurationManager.ConnectionStrings["VocabularyDBConnectionString"].ConnectionString))
            {
                var output = db.Query<string>("select Topic from Topics");
                return output.ToList();
            }
        }
    }
}
