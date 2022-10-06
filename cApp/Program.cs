using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            //int[] A = { 1, 3, 4, 5, 6 };///[1][3][4][5][6]  //inicializar un Vector






            ///Matriz Original
            int[,] A = { { 1, 0, 0, 0, 0, 0 }, 
                         { 3, 2, 0, 0, 3, 0 },
                         { 0, 0, 0, 0, 0, 0 },
                         { 0, 0, 0, 0, 0,-4 },
                         { 1,-2, 0, 0, 0, 1 },
                         { 0, 0, 0, 0, 1, 0 }
                        };


            int[,] B = { { 1, 0, 0, 0, 0, 0 },
                         { 3, 2, 0, 0, 3, 0 },
                         { 0, 0, 0, 0, 0, 0 },
                         { 0, 0, 0, 0, 0,-4 },
                         { 1,-2, 0, 0, 0, 1 },
                         { 0, 0, 0, 0, 1, 0 }
                        };


            int[,] C = { { 0, 0, 0, 0, 0, 0 },
                         { 0, 0, 0, 0, 0, 0 },
                         { 0, 0, 0, 0, 0, 0 },
                         { 0, 0, 0, 0, 0, 0 },
                         { 0, 0, 0, 0, 0, 0 },
                         { 0, 0, 0, 0, 0, 0 }
                        };


            clsSpar m = new clsSpar();
            clsSpar n = new clsSpar();
            clsSpar resultante = new clsSpar();
            Console.WriteLine("--------Matriz Original-----------------");
            System.Console.WriteLine(m.MostrarMatriz(A));
            System.Console.WriteLine(n.MostrarMatriz(B));
            
            Console.WriteLine("-------------------------");
            Console.WriteLine();
           
            m.Cargar(A);
            n.Cargar(B);
            //resultante.Cargar(C);
            Console.WriteLine("-------------------------");
            System.Console.WriteLine(m.MostrarMatrizSparce());
            System.Console.WriteLine(n.MostrarMatrizSparce());
            Console.WriteLine("-------------------------");
            resultante.Transpose(m, n);
            //Console.WriteLine(resultante.SumarMatrices(m,n).MostrarMatrizSparce());
            Console.WriteLine(resultante.MostrarMatrizSparce());
            

            Console.ReadKey();

        }
    }
}
