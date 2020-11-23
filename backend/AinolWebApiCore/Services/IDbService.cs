using AinolWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AinolWebApiCore.Services
{
   public interface IDbService
    {

        public IEnumerable<Note> getNotes();

        public Note getNoteById(String id);

        public void DeleteNoteById(String id);

        public void UpdateNote(String id);

        public void AddNote(String id, String Title,  String Text); 




    }
}
