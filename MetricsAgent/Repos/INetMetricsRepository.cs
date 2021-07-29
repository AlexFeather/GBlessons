using Dapper;
using MetricsAgent.Metrics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Repos
{
    public interface INetMetricsRepository : IRepository<NetMetric>
    {

    }

    public class NetMetricsRepository : INetMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public NetMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public void Create(NetMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO netmetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time.TotalSeconds
                });

            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM netmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            };
        }

        public IList<NetMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<NetMetric>("SELECT Id, Time, Value FROM netmetrics").ToList();
            };

        }


        public NetMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<NetMetric>("SELECT Id, Time, Value FROM netmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }

        }

        public void Update(NetMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE netmetrics SET value = @value, time = @time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
            }

        }
    }
}
