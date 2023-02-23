
using HealthCare.Data.Configurations;
using HealthCare.Data.IRepositories;
using HealthCare.Domain.Commons;
using HealthCare.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;


namespace HealthCare.Data.Repositories
{
    public class Repository<TResult>:IRepository<TResult> where TResult : Auditable
    {
        private string path;
        private long lastId;

        public Repository()
        {
            if (typeof(TResult) == typeof(User))
            {
                path = Constants.USER_PATH;
            }
           
        }

        public async Task<TResult> CreateAsync(TResult value)
        {

            var entities = await GetAllAsync();
            if (entities.Count == 0)
            {
                value.Id = 1;
            }
            else
            {
                value.Id = entities[entities.Count - 1].Id + 1;
            }

            
            value.CreatedAt = DateTime.UtcNow;

            var values = await GetAllAsync();
            values.Add(value);

            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);
            return value;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var values = await GetAllAsync();
            var value = values.FirstOrDefault(x => x.Id == id);

            if (value is null)
                return false;

            values.Remove(value);
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);

            return true;
        }

        public async Task<List<TResult>> GetAllAsync()
        {
            string text = File.ReadAllText(path);
            if (string.IsNullOrEmpty(text))
            {
                text = "[]";
            }

            var result = JsonConvert.DeserializeObject<List<TResult>>(text);
            return result;
        }

        public async Task<TResult> GetByIdAsync(long id)
        {
            var values = await GetAllAsync();
            var result = values.FirstOrDefault(x => x.Id == id);
            if(result is null)
            {
                return null;
            }
            return result;
        }

        public async Task<TResult> UpdateAsync(long id, TResult value)
        {
            var values = await GetAllAsync();
            var model = values.FirstOrDefault(x => x.Id == id);
            if (model is not null)
            {
                var index = values.IndexOf(model);
                values.Remove(model);

                value.CreatedAt = model.CreatedAt;
                value.UpdatedAt = DateTime.UtcNow;

                values.Insert(index, value);
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                await File.WriteAllTextAsync(path, json);
                return model;
            }

            return model;
        }
    }
}
