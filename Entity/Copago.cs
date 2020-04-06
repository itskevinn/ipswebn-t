using System;

namespace Entity {
    public class Copago {
        public string IdentificacionPaciente { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal SalarioTrabajador { get; set; }
        public decimal Tarifa { get; set; }
        public decimal ValorCopago {
            get {
                if (this.SalarioTrabajador > 2500000) {
                    this.Tarifa = 0.2M;                    
                }
                else {
                    this.Tarifa = 0.1M;                    
                }
                return (this.Tarifa * this.ValorServicio) + this.ValorServicio;
            }
        }
    }
}