using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using RestAspNetStudio.Model.Base;
using RestAspNetStudio.Model.Context;
using Microsoft.Extensions.Logging; 

namespace RestAspNetStudio.Data.Generic
{
    public class GenericDataImplementation<T> : IGenericData<T> where T : BaseEntity
    {
        private readonly DapperContext _context;
        private readonly ILogger<GenericDataImplementation<T>> _logger;

        public GenericDataImplementation(DapperContext context, ILogger<GenericDataImplementation<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public T Create(T item)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = $"INSERT INTO {GetTableName()} ({string.Join(", ", GetColumns())}) VALUES (@{string.Join(", @", GetColumns())}) RETURNING Id";
                    item.Id = connection.ExecuteScalar<long>(query, item);
                    return item;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating item.");
                throw;
            }
        }

        public void Delete(long id)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = $"DELETE FROM {GetTableName()} WHERE Id = @Id";
                    connection.Execute(query, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting item.");
                throw;
            }
        }

        public List<T> FindAll()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = $"SELECT * FROM {GetTableName()}";
                    return connection.Query<T>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all items.");
                throw;
            }
        }

        public T FindById(long id)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = $"SELECT * FROM {GetTableName()} WHERE Id = @Id";
                    return connection.QuerySingleOrDefault<T>(query, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving item by Id.");
                throw;
            }
        }

        public T Update(T item)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = $"UPDATE {GetTableName()} SET {string.Join(", ", GetColumns().Select(c => $"{c} = @{c}"))} WHERE Id = @Id";
                    connection.Execute(query, item);
                    return item;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating item.");
                throw;
            }
        }

        private bool Exists(long id)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = $"SELECT COUNT(1) FROM {GetTableName()} WHERE Id = @Id";
                    return connection.ExecuteScalar<bool>(query, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking if item exists.");
                throw;
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
