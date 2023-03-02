using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace labBanco
{
    public class cuentaCorriente : Cuenta
    {
        //Atributos adicionales
        float sobregiro;

        #region CONSTRUCTORES
        //Constructor
        public cuentaCorriente(float Saldo, float TasaAnual) : base(Saldo, TasaAnual)
        {
            this.TasaAnual = 0;
        }

        #endregion

        #region METODOS

        //Se retira dinero actualizado, puede ser superior al saldo.
        public override void retirarDinero(float saldoPorRetirar)
        {
            if((this.Saldo - saldoPorRetirar) < 0)
            {
                this.sobregiro = saldoPorRetirar - this.Saldo;
                this.Saldo = 0;
                Write($"Se han retirado ${saldoPorRetirar} exitosamente, dejando un saldo restante de ${Saldo} con un sobregiro de ${sobregiro}. \n");

            }
            else {
                Saldo -= saldoPorRetirar;
                Write($"Se han retirado ${saldoPorRetirar} exitosamente, dejando un saldo restante de ${Saldo} \n");
            }
            Retiros++;
        }

        //Consignar dinero dependiendo del estado del sobregiro.
        public override void consignarDinero(float saldoPorConsignar)
        {
            if(this.sobregiro > 0)
            {
                if((this.sobregiro - saldoPorConsignar) < 0)
                {
                    this.Saldo = saldoPorConsignar - this.sobregiro;
                    this.sobregiro = 0;
                    Write($"Se han depositado ${saldoPorConsignar} a su cuenta, cumpliendo con el monto del sobregiro, con un saldo resante de ${Saldo}. \n");

                }
                else {
                    this.sobregiro -= saldoPorConsignar;
                    Write($"Se han depositado ${saldoPorConsignar} a su cuenta, dejando un sobregiro de ${sobregiro}. \n");

                }
            } else {
                this.Saldo += saldoPorConsignar;
                Write($"Se han depositado ${saldoPorConsignar} a su cuenta. \n");
            }
            Consignaciones++;
        }

        //Imprimir todos los atributos.
        public override void imprimir()
        {
            base.imprimir();
            Write($"Monto de sobregiro: ${sobregiro} \n");
        }

        #endregion

    }
}
