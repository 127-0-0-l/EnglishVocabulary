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
                db.Execute("insert into Vocabulary (Topic) values (@t)", new { t = "hello"});
            }
        }

        public static List<string> GetData()
        {
            using(IDbConnection db = new SQLiteConnection(ConfigurationManager.ConnectionStrings["VocabularyDBConnectionString"].ConnectionString))
            {
                var output = db.Query<string>("select Topic from Vocabulary");
                return output.ToList();
            }
        }
    }
}
