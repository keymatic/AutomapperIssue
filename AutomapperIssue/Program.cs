using System;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace AutoMapperIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            // init AutoMapper
            AutomapperInit();
            // to test ASP.NET HTTP PATCH controller method let's create
            // a JsonPatchDocument for UserNoteDto 
            var jsonPatchDoc = new JsonPatchDocument<UserNoteDto>();
            jsonPatchDoc.Replace(t => t.Text, "updated value");

            // convert incoming Dto to model
            // !!! exception raised here but it works with Automapper 8.1.0
            var notePatchDoc = Mapper.Map<JsonPatchDocument<UserNote>>(jsonPatchDoc);

            // get existing note from DB
            var noteDb = new UserNote
            {
                Text = "original value"
            };

            // apply patch to model
            notePatchDoc.ApplyTo(noteDb);
            
            // noteDb.Text should be "updated value"
            Console.WriteLine(noteDb.Text);
            Console.ReadKey();
        }

        private static void AutomapperInit()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperAPIProfile>();
            });
        }
    }
}
