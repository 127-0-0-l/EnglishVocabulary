using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishVocabulary
{
    class VocabularyDBContext : DbContext
    {
        public VocabularyDBContext() : base()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<VocabularyDBContext>());
        }

        public DbSet<Vocabulary> Topics { get; set; }
    }
}
