using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AinolWebApiCore.Models;
using AinolWebApiCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AinolWebApiCore.Controllers
{
    [Route("notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {



        private IDbService dbservice;

        public NotesController(IDbService dbservice)
        {   
            this.dbservice = dbservice;
        }

        [HttpGet]
        public IEnumerable<Note> GetAll()
        {

            Console.WriteLine("Hello  world!");

            List<Note> notes = (List<Note>)dbservice.getNotes();

            return notes;
        }


        [HttpGet("{id}")]
        public Note GetNote(String id)
        {

            Console.WriteLine("Hello  world" + " " + id);

            Note note = dbservice.getNoteById(id);

            return note;
         
        
        }

     


        [HttpDelete("{id}")]
        public void DeleteNote(String id) {

            dbservice.DeleteNoteById(id); 

            Console.WriteLine("Delete");

        }


        [HttpPost]
        public void PostNote(String id, String Author, String Text)
        {
            dbservice.AddNote(id, Author, Text);  


            Console.WriteLine("Posted");

        }

        [HttpPut("{id}")]
        public void UpdateNote(String id)
        {


            dbservice.UpdateNote(id); 
            
            
            Console.WriteLine("Updated" + " " + id);

        }







    }

}
