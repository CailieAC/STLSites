using STLSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSites.Data
{
    public interface IRepository
    {
        IModel GetById(int id);
        List<IModel> GetModels();
        int Save(IModel model);
    }
}
