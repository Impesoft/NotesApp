using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesApp.Repositories
{
    public class ToDoRepository
    {
        public ToDo GetTodo(int id)
        {
            using (var dbContext = new NotesContext())
            {
                var toDo = dbContext.ToDos.Find(id);
                return toDo;
            }
        }

        public void SaveTodo(ToDo toDo)
        {
            using (var dbContext = new NotesContext())
            {
                if (toDo.Id == 0)
                {
                    dbContext.ToDos.Add(toDo);
                }
                else
                {
                    dbContext.ToDos.Update(toDo);
                }

                dbContext.SaveChanges();
            }
        }

        public void DeleteTodo(ToDo toDo)
        {
            using (var dbContext = new NotesContext())
            {
                dbContext.Remove(toDo);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<ToDo> GetAllToDos()
        {
            using (var dbContext = new NotesContext())
            {
                return dbContext.ToDos.ToList();
            }
        }
    }
}