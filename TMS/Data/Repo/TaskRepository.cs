using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext dbContext;

        public TaskRepository(TaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Model.Task> AddTask(Model.Task task)
        {

            try
            {
                dbContext.Tasks.Add(task);
                await dbContext.SaveChangesAsync();
                return task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Model.Task> UpdateTask(Model.Task task)
        {
            try
            {
                dbContext.Tasks.Update(task);
                await dbContext.SaveChangesAsync();
                return task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            try
            {
                var task = await dbContext.Tasks.FindAsync(taskId);
                if (task == null)
                    return false;

                dbContext.Tasks.Remove(task);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Model.Task> GetTask(int taskId)
        {
            try
            {
                return await dbContext.Tasks.FindAsync(taskId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<List<Model.Task>> GetAllTasks()
        {
            try
            {
                return await dbContext.Tasks.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
