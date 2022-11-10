using DataAccess.Models.Interface;
using Domain.Models;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CohabitationRepository : ICohabitationRepository
    {
        // private readonly ApplicationContext _db;
        private readonly ApplicationContextSQL _db;

        // public CohabitationRepository(ApplicationContext db) => _db = db;
        public CohabitationRepository(ApplicationContextSQL db) => _db = db;

        public async Task<Cohabitation[]> AddCohabitation(Cohabitation cohabitation)
        {
            // как хранить ФИО
            string commandText = $"INSERT INTO Users Values (Name, FirstName, Age, )('{cohabitation.FIO}')";
            //await using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection))
            //{
            //    cmd.Parameters.AddWithValue("id", id);

            //    await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
            //        while (await reader.ReadAsync())
            //        {
            //            BoardGame game = ReadBoardGame(reader);
            //            return game;
            //        }
            //}
            //return null;

            throw new NotImplementedException();
        }

        public async Task<Cohabitation[]> Delete(string FIO)
        {
            throw new NotImplementedException();
        }

        public async Task<Cohabitation[]> GetCohabitations(Filter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Cohabitation[]> Insert(Cohabitation cohabitation)
        {
            throw new NotImplementedException();
        }
    }
}
