using STLSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSites.Data
{
    public class BaseRepository : IRepository
    {
        protected List<IModel> models = new List<IModel>();
        protected int nextId = 1;

        public IModel GetById(int id)
        {
            return (Location)models.SingleOrDefault(d => d.Id == id);
        }

        public List<IModel> GetModels()
        {
            return models;
        }

        public int Save(IModel model)
        {
            model.Id = nextId++;
            models.Add(model);
            return model.Id;
        }
    }
}
