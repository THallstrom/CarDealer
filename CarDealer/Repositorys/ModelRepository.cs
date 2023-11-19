using CarDealer.Contexts;
using CarDealer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Repositorys
{
    public class ModelRepository : Repo<ModelEntity>
    {
        public ModelRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
