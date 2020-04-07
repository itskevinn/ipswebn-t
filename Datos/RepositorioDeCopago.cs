using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos {
    public class RepositorioDeCopago {
        private readonly SqlConnection _conexión;
        private readonly List<Copago> _copagos = new List<Copago> ( );
        public RepositorioDeCopago (GestionadorDeConexión conexión) {
            _conexión = conexión._conexion;
        }

        public void Guardar (Copago copago) {
            using (var comando = _conexión.CreateCommand ( )) {
                comando.CommandText = @"Insert Into Copago (Id,ValServ,SalTrab,ValCop)
values (@Id, @ValorServicio, @SalarioTrabajador, @ValorCopago)";
                comando.Parameters.AddWithValue ("@Id", copago.IdentificacionPaciente);
                comando.Parameters.AddWithValue ("@ValorServicio", copago.ValorServicio);
                comando.Parameters.AddWithValue ("@SalarioTrabajador", copago.SalarioTrabajador);
                comando.Parameters.AddWithValue ("@ValorCopago", copago.ValorCopago);
                var filas = comando.ExecuteNonQuery ( );
            }
        }
        public Copago BuscarxId(string idABuscar){
List<Copago> copagos = ConsultarTodos();
Copago copago = new Copago();
copago = copagos.Find(c => c.IdentificacionPaciente == idABuscar);
return copago;

        }

        public List<Copago> ConsultarTodos ( ) {
            SqlDataReader lectorDeDatos;
            List<Copago> copagos = new List<Copago> ( );
            using (var comando = _conexión.CreateCommand ( )) {
                comando.CommandText = "Select * from Copago ";
                lectorDeDatos = comando.ExecuteReader ( );
                if (lectorDeDatos.HasRows) {
                    while (lectorDeDatos.Read ( )) {
                        Copago copago = MapearDatosEnLector (lectorDeDatos);
                        copagos.Add (copago);
                    }
                }
            }
            return copagos;
        }

        private Copago MapearDatosEnLector (SqlDataReader lectorDeDatos) {
            if (!lectorDeDatos.HasRows) return null;
            Copago copago = new Copago ( );
            copago.IdentificacionPaciente = (string) lectorDeDatos["Id"];
            copago.ValorServicio = (decimal) lectorDeDatos["ValServ"];
            copago.SalarioTrabajador = (decimal) lectorDeDatos["SalTrab"];                     
            return copago;
        }
    }
}