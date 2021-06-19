using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public class SeedData
    {
        public SeedData() {}

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any scriptures.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Moses",
                        Chapter = 1,
                        Verse = 39,
                        Note = "I want to shoulder the work!",
                        EntryDate = DateTime.Parse("2021-3-22")
                    },

                    new Scripture
                    {
                        Book = "John",
                        Chapter = 3,
                        Verse = 5,
                        Note = "Being born again is an everyday effort.",
                        EntryDate = DateTime.Parse("2021-4-10")
                    },

                    new Scripture
                    {
                        Book = "D&C",
                        Chapter = 19,
                        Verse = 23,
                        Note = "Learn from the greatest source of knowledge: the Lord.",
                        EntryDate = DateTime.Parse("2021-4-17")
                    },

                    new Scripture
                    {
                        Book = "Alma",
                        Chapter = 39,
                        Verse = 9,
                        Note = "Go and sin no more.",
                        EntryDate = DateTime.Parse("2021-5-12")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
