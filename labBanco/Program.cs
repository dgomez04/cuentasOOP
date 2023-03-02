using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace labBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///Atributos de control
            float monto;
            int opc = 0;
            
            //Inicializar objeto
            cuentaAhorro cuenta = new cuentaAhorro(10000, 7);
            Write("Bienvenido al Banco Patitos Fronterizo. \n");

            #region MENU
            while (opc != 5)
            {
                WriteLine(" \n \t Su Cuenta de Ahorros: " +
                                      " \n \t \t 1. Consignar Dinero " +
                                      " \n \t \t 2. Retirar Dinero   " +
                                      " \n \t \t 3. Calcular extratuo mensual " +
                                      " \n \t \t 4. Estado de cuenta " +
                                      " \n \t \t 5. Salir ");

                Write(" \n \t Ingrese una opcion: ");
                opc = int.Parse(ReadLine());

                switch (opc)
                {
                    case 1:
                        Clear();
                        Write("Ingrese la cantidad que desea consignar: ");
                        monto = float.Parse(ReadLine());
                        cuenta.consignarDinero(monto);
                        break;

                    case 2:
                        Clear();
                        Write("Ingrese la cantidad que desea retirar: ");
                        monto = float.Parse(ReadLine());
                        cuenta.retirarDinero(monto);
                        break;

                    case 3: 
                        Clear();
                        cuenta.extractoMensual();
                        break;

                    case 4:
                        Clear();
                        cuenta.imprimir();
                        break;

                    case 5:
                        opc = 5;
                        Write("Gracias por utilizar al Banco Patito Fronterizo. ");
                        break;

                    default:
                        Console.Clear();
                        Write("\n Recuerde escoger una opcion entre el 1 y el 5. ");
                        break;


                }

                #endregion
            }


        }
    }
}
