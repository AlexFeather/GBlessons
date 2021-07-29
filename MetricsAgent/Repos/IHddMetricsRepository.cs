using Dapper;
using MetricsAgent.Metrics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Repos
{
    public interface IHddMetricsRepository : IRepository<HddMetric>
    {

    }

    public class HddMetricsRepository : IHddMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public void Create(HddMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO hddmetrics(value) VALUES(@value)",
                new
                {
                    value = item.Value
                });

            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM cpumetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            };
        }

        public IList<HddMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<HddMetric>("SELECT Id, Value FROM hddmetrics").ToList();
            };

        }


        public HddMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<HddMetric>("SELECT Id, Value FROM hddmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }

        }

        public void Update(HddMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE hddmetrics SET value = @value WHERE id=@id");
            };

        }

        public HddMetric GetLast()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<HddMetric>("SELECT Id, Value FROM Hddmetrics LIMIT 1");
            };
        }
    }
}
