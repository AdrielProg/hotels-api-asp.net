// Data/Generic/GenericDataImplementation.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Dapper;
using RestAspNetStudio.Model.Base;
using RestAspNetStudio.Model.Context;

namespace RestAspNetStudio.Data.Generic
{
    public class GenericDataImplementation<T> : IGenericData<T> where T : BaseEntity
    {
        private readonly DapperContext _context;

        public GenericDataImplementation(DapperContext context)
        {
            _context = context;
        }

        public T Create(T item)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = $"INSERT INTO {GetTableName()} ({string.Join(", ", GetColumns())}) VALUES (@{string
                            .Join(", @", GetColumns())}) RETURNING Id";
                item.Id = connection.ExecuteScalar<long>(query, item);
                return item;
            }
        }

        public void Delete(long id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = $"DELETE FROM {GetTableName()} WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }

        public List<T> FindAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = $"SELECT * FROM {GetTableName()}";
                return connection.Query<T>(query).ToList();
            }
        }

        public T FindById(long id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = $"SELECT * FROM {GetTableName()} WHERE Id = @Id";
                return connection.QuerySingleOrDefault<T>(query, new { Id = id });
            }
        }

        public T Update(T item)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = $"UPDATE {GetTableName()} SET {string.Join(", ",GetColumns()
                            .Select(c => $"{c} = @{c}"))} WHERE Id = @Id";
                connection.Execute(query, item);
                return item;
            }
        }

        private bool Exists(long id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = $"SELECT COUNT(1) FROM {GetTableName()} WHERE Id = @Id";
                return connection.ExecuteScalar<bool>(query, new { Id = id });
            }
        }

        private string GetTableName()
        {
            var tableAttr = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
            return tableAttr != null ? tableAttr.Name : typeof(T).Name + "s";
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(T).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(ColumnAttribute), true).Any())
                .Select(p => ((ColumnAttribute)p.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault()).Name);
        }
    }
}
