using Dapper;
using DapperCoreMVC.Data;
using DapperCoreMVC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCoreMVC.Repository
{
    public class HerbsRepository : IHerbRepository
    {
        private IDbConnection db;
        public HerbsRepository (IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }      

        public Herbs Add(Herbs herb)
        {
            var sql = "INSERT INTO Herbs (Name, Info, Healing) VALUES(@Name, @Info, @Healing);"
                      + "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(sql, new
            {
                herb.Name,
                herb.Info,
                herb.Healing
            }).Single();
            herb.HerbId = id;
            return herb;
        }

        public Herbs Find(int id)
        {
            var sql = "SELECT * FROM Herbs WHERE HerbId = @HerbId";
            //!nikdy! ...WHERE HerbId = } + id; všechno dávat do parametrů; plus umožní dependency-injection atak!
            return db.Query<Herbs>(sql, new { @HerbId = id }).Single();
        }

        public List<Herbs> GetAll()
        {
            var sql = "SELECT * FROM Herbs";
            return db.Query<Herbs>(sql).ToList();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM Herbs WHERE HerbId = @Id";
            db.Execute(sql, new {id});
        }

        public Herbs Update(Herbs herb)
        {
            var sql = "UPDATE Herbs SET Name = @Name, Info = @Info, Healing = @Healing WHERE " +
                "HerbId = @HerbId";
            db.Execute(sql, herb);
            return herb;
        }
    }
}
