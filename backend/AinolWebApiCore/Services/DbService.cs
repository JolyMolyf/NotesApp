using AinolWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AinolWebApiCore.Services
{
    public class DbService : IDbService
    {
        private readonly MyDbContext dbContext;
        public DbService(MyDbContext dbContext)
        {

            this.dbContext = dbContext;

        }

        public Note getNoteById(String id)
        {

            if (id != "undefined")
            {
                Note note = dbContext.Notes.Single<Note>(n => n.IdNote == int.Parse(id));

                Console.WriteLine(note);



                return new Note()
                {
                    IdNote = note.IdNote,
                    Title = note.Title,
                    Text = note.Text

                };
            }
            else {
                return null;
                    
                    }
         

        }

        public IEnumerable<Note> getNotes()
        {
            var notes = dbContext.Notes.ToList();

            return notes;


        }

        public void DeleteNoteById(String id) {
            var noteToDelete = dbContext.Notes.Single<Note>(n => n.IdNote == int.Parse(id));
            dbContext.Notes.Remove(noteToDelete);
            dbContext.SaveChanges(); 


        }

        public void UpdateNote(String  id)
        {
            var note = dbContext.Notes.Single<Note>(n => n.IdNote == int.Parse(id)); 

            var noteToUpdate = dbContext.Notes.Single(n => n.IdNote == note.IdNote);
            if (note.IdNote != null && note.Text != null && note.Title != null)
            {

                noteToUpdate.Text = note.Text;
                noteToUpdate.Title = note.Title;

            }
            else {

                throw new ArgumentException(
             $"not all parametrs we inputed");
            }


        }

        public void AddNote(string id, string Author, string Text)
        {
            var note = new Note()
            {
                IdNote = int.Parse(id), 
                Title = Author, 
                Text = Text
            };

            dbContext.Add(note);
            dbContext.SaveChanges(); 


        }
    }
}
