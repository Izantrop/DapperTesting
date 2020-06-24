﻿using Dapper;
using TestingProject.DTOs;
using TestingProject.IServices;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TestingProject.DbServices
{
    public class DbCarServices : DbBaseService, ICarService
    {
        public DbCarServices(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> Create(CarDTO DTO)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            return await conn.ExecuteScalarAsync<int>(@"INSERT INTO [testing].[Cars]([Name], [Price], [DateId])
                                                        VALUES(@Name, @Price, @DateId)",
                                                        new { DTO.Name, DTO.Price, DTO.DateId });
        }

        public async Task<int> Update(CarDTO DTO)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            return await conn.ExecuteScalarAsync<int>(@"UPDATE [testing].[Cars]
                                                        SET [Name] = @Name,
                                                            [Price] = @Price,
                                                            [DateId] = @DateId
                                                        WHERE [Id] = @Id",
                                                        new { DTO.Id, DTO.Name, DTO.Price, DTO.DateId });
        }

        public async Task Delete(int Id)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            await conn.ExecuteScalarAsync(@"DELETE FROM [testing].[Cars]
                                            WHERE [Id] = @Id", new { Id });
        }

        public async Task<CarDTO> Get(int Id)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<CarDTO>(@"SELECT [Id], [Name], [Price], [DateId]
                                                                 FROM [testing].[Cars]
                                                                 WHERE [Id] = @Id",
                                                                 new { Id });
        }

        public async Task<IEnumerable<CarDTO>> Get()
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<CarDTO>(@"SELECT [Id], [Name], [Price], [DateId]
                                                   FROM [testing].[Cars]");
        }
    }
}