using Domain.Entities;
using InfrastructureTeatro.Interface.ObraInfra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace TeatroPersistence.SqlServer.Obra
{
    public class ObraSql : IObraRepository
    {
        private string connectionString;

        public ObraSql(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task<List<Domain.Entities.Obra>> GetObrasByIdTeatro(int idTeatro)
        {
            var obraList = new List<Domain.Entities.Obra>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                await sqlConnection.OpenAsync();
                SqlCommand command = new SqlCommand("[dbo].[SelectAllOBraBYIdTeatro]", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdTeatro", idTeatro);
                //command.Parameters.Add(new SqlParameter("@IdTeatro", idTeatro));
                var reader = await command.ExecuteReaderAsync();                
                while (reader.Read())
                {
                    var obraModel = new ObraModel()
                    {
                        IdObra = Convert.ToInt16(reader["IdObra"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        Hora = Convert.ToInt16(reader["Hora"]),
                        IdTeatro = Convert.ToInt16(reader["IdTeatro"])
                    };
                    var obra = new Domain.Entities.Obra(obraModel.Nombre, obraModel.Hora)
                    {
                        IdObra = obraModel.IdObra,
                        IdTeatro = obraModel.IdTeatro
                    };

                    obraList.Add(obra);
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
            return obraList;
        }
    }
}
