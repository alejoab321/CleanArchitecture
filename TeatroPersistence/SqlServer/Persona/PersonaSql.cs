using Domain.Entities.Person;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace TeatroPersistence.SqlServer.Persona
{
    public class PersonaSql : IPersonaRepository
    {
        private string connectionString;

        public PersonaSql(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<List<Espectador>> GetEspectadors()
        {
            List<Espectador> espectadors = new List<Espectador>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                await sqlConnection.OpenAsync();
                string query = "SELET * FROM Persona";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    var personaModel = new PersonaModel
                    {
                        IdPersona = Convert.ToInt16(reader["IdPersona"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        IdClasificado = Convert.ToInt16(reader["IdClasificado"])
                    };
                    if (personaModel.IdClasificado == 2)
                    {
                        var abonado = new Abonado(personaModel.Nombre)
                        {
                            IdPersona = personaModel.IdPersona
                        };
                        espectadors.Add(abonado);
                    }                    
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

            return espectadors;
        }
    }
}
