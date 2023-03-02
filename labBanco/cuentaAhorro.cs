using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace labBanco
{
    public class cuentaAhorro : Cuenta 
    {
        //Atributos adicionales
        String estado = "inactiva";

        #region CONSTRUCTOR
        //Constructor
        public cuentaAhorro(float Saldo, float TasaAnual) : base(Saldo, TasaAnual)
        {
            this.Saldo = Saldo;
            this.TasaAnual= TasaAnual;
        }
        #endregion

        #region METODOS
        //Metodo para ingresar dinero, si la cuenta se encuentra activa (> $10000)
        public override void consignarDinero(float saldoPorConsignar)
        {
            //Si el saldo es mayor a $10000, la cuenta se encuentra activa y se puede depositar.
            if(this.Saldo + saldoPorConsignar >= 10000)
            {
                this.Saldo += saldoPorConsignar;
                Write($"Se han depositado ${saldoPorConsignar} a su cuenta. \n");
                this.Consignaciones++;
                //base.consignarDinero(saldoPorConsignar);
                estado = "activa";
            } else {
                Write("La cuenta se encuentra inactiva debido a que su saldo es menor a $10000, favor ingresar un valor que la lleve a ese monto o superior. \n");
            }
        }

        //Metodo para retirar dinero, si la cuenta se encuentra activa.
        public override void retirarDinero(float saldoPorRetirar)
        {
            if (estado == "activa")
            {
                base.retirarDinero(saldoPorRetirar);
            } else {
                Write("La cuenta se encuentra inactiva, porfavor incrementar saldo a un monto superior a $10000 para activar la cuenta. \n");
            }
        }

        //Metodo para realizar comisiones y pago de intereses.
        public override void extractoMensual()
        {
            if(Retiros < 4)
            {
                this.Comision_Mensual = 0;
                Write("No se cobrara comision mensual debido a que se mantuvo dentro del limite de retiros. \n");
            } else {
                this.Comision_Mensual = 1000;
                Write($"Se cobrara una comision de ${Comision_Mensual} por retiro, ya que excedio el limite de cuatro retiros. \n");

            }

            this.Saldo -= ((Retiros - 4) * this.Comision_Mensual);
            this.interesMensual();

            if (this.Saldo > 10000) estado = "activa";
            else estado = "inactiva";

            Write($"Estado de cuenta: {estado} \n");


        }

        //Metodo para imprimir valor de atributos.
        public override void imprimir()
        {
            Write($"Saldo total: ${Saldo} \n");
            Write($"Transacciones realizadas: {Consignaciones + Retiros} \n");
            Write($"Tasa anual: {TasaAnual}% \n");
            Write($"Tasa de comision mensual actual: ${(Retiros - 4) * Comision_Mensual} \n");

        }
        #endregion 
    }
}
