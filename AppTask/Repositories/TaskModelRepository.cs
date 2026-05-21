using System;
using System.Collections.Generic;
using System.Text;
using AppTask.Database;
using AppTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTask.Repositories;

public class TaskModelRepository : ITaskModelRepository
{
    private AppTaskContext _db;

    public TaskModelRepository()
    {
        _db = new AppTaskContext();
    }

    public IList<TaskModel> GetAll()
    {
        return _db.Tasks.OrderByDescending(t => t.PrevisionDate).ToList();
    }

    public TaskModel GetById(int id)
    {
        return _db.Tasks.Include(a => a.SubTasks).First(t => t.Id == id);
    }

    public void Add(TaskModel task)
    {
        _db.Tasks.Add(task);
        _db.SaveChanges();
    }

    public void Update(TaskModel task)
    {
        _db.Tasks.Update(task);
        _db.SaveChanges();
    }

    public void Delete(TaskModel task)
    {
        task = GetById(task.Id);
        foreach (var subtask in task.SubTasks)
        {
            _db.SubTasks.Remove(subtask);
        }

        _db.Tasks.Remove(task);
        _db.SaveChanges();
    }
}
