using DapperCoreMVC.Data;
using DapperCoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCoreMVC.Repository
{
    public class HerbsRepositoryEF : IHerbRepository
    {
        private readonly ApplicationDbContext _db;
        public HerbsRepositoryEF (ApplicationDbContext db)
        {
            _db = db;
        }      

        public Herbs Add(Herbs herb)
        {
            _db.Add(herb);
            _db.SaveChanges();
            return herb;
        }

        public Herbs Find(int id)
        {
            return _db.Herbs.FirstOrDefault(u => u.HerbId == id);
        }

        public List<Herbs> GetAll()
        {
            return _db.Herbs.ToList();
        }

        public void Remove(int id)
        {
            Herbs Herb = _db.Herbs.FirstOrDefault(u => u.HerbId == id);
            _db.Herbs.Remove(Herb);
            _db.SaveChanges();
            return;
        }

        public Herbs Update(Herbs herb)
        {
            _db.Herbs.Update(herb);
            _db.SaveChanges();
            return herb;
        }
    }
}
