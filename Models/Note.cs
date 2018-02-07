using System.Collections.Generic;

namespace CarDealership.Models
{
    public class Note
    {
        private string _note;
        private List<Note> _metaNotes = new List<Note>();
        private int _id;

        private static int ID = 0;

        public Note(string text)
        {
            _note = text;
            _id = ID++;
        }

        public string GetText()
        {
            return _note;
        }

        public void AddNote(Note note)
        {
            _metaNotes.Add(note);
        }

        public List<Note> GetNotes()
        {
            return _metaNotes;
        }

        public int GetID()
        {
            return _id;
        }
    }
}
