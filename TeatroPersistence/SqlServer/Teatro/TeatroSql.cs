using InfrastructureTeatro.Interface.TeatroInfra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace TeatroPersistence.SqlServer.Teatro
{
    public class TeatroSql : ITeatroRepository
    {
        private string connectionString;
        public TeatroSql(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<List<Domain.Entities.Teatro>> GetAllTeatro()
        {
            var teatroList = new List<Domain.Entities.Teatro>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                await sqlConnection.OpenAsync();
                SqlCommand command = new SqlCommand("SelectAllTeatro", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                var reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    var teatroModel = new TeatroModel()
                    {
                        IdTeatro = Convert.ToInt16(reader["IdTeatro"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        Capacidad = Convert.ToInt16(reader["Cantidad"])
                    };

                    var teatro = new Domain.Entities.Teatro(teatroModel.Nombre) 
                    {
                        IdTeatro = teatroModel.IdTeatro,
                        Capacidad = teatroModel.Capacidad
                    };
                    teatroList.Add(teatro);

                }
                await command.Connection.CloseAsync();

            }
            catch (Exception ex)
            {

                Console.Write("Exception Message: " + ex.Message);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
            return teatroList;
        }
    }
}
