using Entity;
namespace ipsweb.Models
{
    public class CopagoInputModel
    {
        public string IdentificacionPaciente { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal SalarioTrabajador { get; set; }
    }
    public class CopagoViewModel : CopagoInputModel
    {
        public decimal ValorCopago { get; set; }
        public CopagoViewModel() { }
        public CopagoViewModel(Copago copago)
        {
            IdentificacionPaciente = copago.IdentificacionPaciente;
            ValorServicio = copago.ValorServicio;
            SalarioTrabajador = copago.SalarioTrabajador;
            ValorCopago = copago.ValorCopago;
        }
    }
}