using System;
using System.Collections.Generic;
using Datos;

using Entity;

namespace Logica
{
    public class ServicioDeCopago
    {
        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioDeCopago _repositorio;
        public ServicioDeCopago(string cadenaDeConexión)
        {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            _repositorio = new RepositorioDeCopago(_conexión);
        }

        public GuardarCopagoResponse Guardar(Copago copago)
        {
            try
            {
                _conexión.Abrir();
                _repositorio.Guardar(copago);
                _conexión.Cerrar();
                return new GuardarCopagoResponse(copago);
            }
            catch (Exception e)
            {
                return new GuardarCopagoResponse(e.Message);
            }
        }
        public ConsultarCopagosResponse ConsultarCopagos()
        {            
            try
            {
                _conexión.Abrir();
                List<Copago> copagos = _repositorio.ConsultarTodos();
                _conexión.Cerrar();
                return new ConsultarCopagosResponse(copagos);
            }
            catch (Exception e)
            {
                return new ConsultarCopagosResponse(e.Message);
            }
        }
        public class GuardarCopagoResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Copago Copago { get; set; }
            public GuardarCopagoResponse(Copago copago)
            {
                Error = false;
                Copago = copago;
            }
            public GuardarCopagoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }
        public class ConsultarCopagosResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Copago> Copagos = new List<Copago>();
            public ConsultarCopagosResponse(List<Copago> copagos)
            {
                Error = false;
                Copagos = copagos;
            }
            public ConsultarCopagosResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }
    }
}