using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entity;

using Logica;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using ipsweb.Models;
namespace ipsweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopagoController : ControllerBase
    {
        private readonly ServicioDeCopago _servicioDeCopago;
        public IConfiguration Configuration { get; }
        public CopagoController(IConfiguration configuration)
        {
            Configuration = configuration;
            string cadenaDeConexión = Configuration["ConnectionStrings:DefaultConnection"];
            _servicioDeCopago = new ServicioDeCopago(cadenaDeConexión);
        }

        // GET: api/Copago
        [HttpGet]
        public IEnumerable<CopagoViewModel> Get()
        {
            var respuesta = _servicioDeCopago.ConsultarCopagos().Copagos.Select(p => new CopagoViewModel(p));
            return respuesta;
        }

        // POST: api/Copago
        [HttpPost]
        public ActionResult<CopagoViewModel> Post(CopagoInputModel copagoInput)
        {
            Copago copago = MapearCopago(copagoInput);
            var respuesta = _servicioDeCopago.Guardar(copago);
            if (respuesta.Error)
            {
                return BadRequest(respuesta.Mensaje);
            }
            return Ok(respuesta.Copago);
        }
        private Copago MapearCopago(CopagoInputModel copagoInput)
        {
            var copago = new Copago
            {
                IdentificacionPaciente = copagoInput.IdentificacionPaciente,
                ValorServicio = copagoInput.ValorServicio,
                SalarioTrabajador = copagoInput.SalarioTrabajador,
            };
            return copago;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<CopagoViewModel> Get(string identificacion)
        {            
            var respuesta = _servicioDeCopago.BuscarxId(identificacion);            
            if (respuesta.Error)
            {
                return Ok(respuesta.Copago);
            }
            return BadRequest(respuesta.Mensaje);                     
        }
    }
}

