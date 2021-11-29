using DapperCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCoreMVC.Repository
{
    public interface IHerbRepository
    {
        Herbs Find(int id);
        List<Herbs> GetAll();
        Herbs Add(Herbs herb);
        Herbs Update(Herbs herb);
        void Remove(int id);
    }
}
