using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace labBanco
{
    public class Cuenta
    {
        #region  ATRIBUTOS
        //Atributos de la clase
        float saldo;
        int consignaciones;
        int retiros;
        float tasaAnual;
        float comisionMensual;
        #endregion

        #region GETTERS & SETTERS
        ///Getters & Setters
        public float Saldo { get => saldo; set => saldo = value; }
        public int Consignaciones { get => consignaciones; set => consignaciones = value; }
        public float TasaAnual { get => tasaAnual; set => tasaAnual = value; }
        public float Comision_Mensual { get => comisionMensual; set => comisionMensual = value; }
        public int Retiros { get => retiros; set => retiros = value; }

        #endregion

        #region CONSTRUCTOR
        //Constructor 
        public Cuenta (float Saldo, float TasaAnual)
        {
            this.saldo = Saldo;
            this.tasaAnual = TasaAnual;
            this.consignaciones = 0;
            this.retiros = 0;
            this.comisionMensual = 0; /* CREAR UNA COMISION MENSUAL FIJA */
        }

        #endregion

        #region METODOS
        //Metodo para consignar dinero (depositar)
        public virtual void consignarDinero(float saldoPorConsignar)
        {
            this.saldo += saldoPorConsignar;
            Write($"Se han depositado ${saldoPorConsignar} a su cuenta. \n");
            this.consignaciones++;
            
        }

        //Metodo para retirar dinero de una cuenta. 
        public virtual void retirarDinero(float saldoPorRetirar)
        {
            if(this.saldo - saldoPorRetirar > 0)
            {
                this.saldo -= saldoPorRetirar;
                Write($"Se han retirado ${saldoPorRetirar} exitosamente. \n");
                this.retiros++;
            } else {
                Write("El monto a retirar excede el saldo. Porfavor ingresar un monto menor. ");
            }
        }

        //Metodo para calcular interes mensual y actualizar el saldo correspondiente.
        public void interesMensual()
        {
            //VERIFICAR SI USAR 'saldo (clase)' o 'Saldo (getter)' 
            float intereses = this.saldo * ((this.tasaAnual/100)/12);
            saldo += intereses;
            Write($"Su interes mensual de ${intereses} se han añadido exitosamente a su cuenta, con un saldo total de ${saldo}. \n");
        }

        //Metodo para realizar el extracto mensual de la comision, y calcular los intereses y sumarlos al saldo.
        public virtual void extractoMensual()
        {
            if(this.saldo < 30)
            {
                this.comisionMensual = 6;
            } else if(this.saldo < 100)
            {
                this.comisionMensual = 1;
            } else
            {
                this.comisionMensual = 0;
            }

            this.saldo -= this.saldo * (this.comisionMensual / 100);
            Write($"Se ha cobrado una comision por valor minimo de un {comisionMensual}%, con un saldo restante de ${saldo}. \n");

            this.interesMensual();
        }

        //Metodo para imprimir valores de los atributos en pantalla
        public virtual void imprimir()
        {
            Write($"Saldo total: ${saldo} \n");
            Write($"Consignaciones realizadas: {consignaciones} \n");
            Write($"Retiros realizados: {retiros} \n");
            Write($"Tasa anual: {tasaAnual}% \n");
            Write($"Tasa de comision mensual actual: {comisionMensual}% \n");


        }
        #endregion
    }
}
