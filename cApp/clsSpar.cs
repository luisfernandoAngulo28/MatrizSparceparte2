using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cApp
{
    public class clsSpar
    {
        //Atributos
        const int Max = 100;  //Maximo de filas 
        public int F; //filas de la matriz
        public int C; //columnas de la matriz
        public int cant; //cantidad de elementos de la matriz espacida

        public int[,] Sparce = new int[Max, 3]; //  [filas,columnas]

        //Constructor
        public clsSpar()
        {
            this.F = 0;
            this.C = 0;
            this.cant = 0;
            int i = 0;
            while (i < Max)
            {
                this.Sparce[i, 0] = 0;
                this.Sparce[i, 1] = 0;
                this.Sparce[i, 2] = 0;
                i++;
            }

        }

        //Constructor de copia
        public clsSpar(clsSpar m)
        {
            this.F = m.F;
            this.C = m.C;
            this.cant = m.cant;
            int i = 0;
            while (i < Max)
            {
                this.Sparce[i, 0] = m.Sparce[i,0];
                this.Sparce[i, 1] = m.Sparce[i, 1];
                this.Sparce[i, 2] = m.Sparce[i, 2];
                i++;
            }

        }

        public void clearMatrizSparce()
        {
            cant = 0;
            int i = 0;
            while (i < Max)
            {
                this.Sparce[i, 0] = 0;
                this.Sparce[i, 1] = 0;
                this.Sparce[i, 2] = 0;
                i++;
            }
        }


       
        ///--Mostrar la Matriz Original 
        public String MostrarMatriz(int[,] A)
        {
            String S = "";
            F = A.GetLength(0);//obtiene el numero de filas
            C = A.GetLength(1);//obtiene el numero de columnas
            
            for(int i = 0; i < F; i++)//recorrido de las Filas
            {
                S = S + "\n";//  "\n"->Salto de Linea
                for (int j = 0; j < C; j++) //recorrido de las Columnas
                {
                    S = S + "[" + A[i, j] + "]";
                }

            }

            return S;
        }
        /*              { 1, 0, 0, 0, 0, 0 }, 
                        { 3, 2, 0, 0, 3, 0 },
                        { 0, 0, 0, 0, 0, 0 },
          A=            { 0, 0, 0, 0, 0,-4 },
                        { 1,-2, 0, 0, 0, 1 },
                        { 0, 0, 0, 0, 1, 0 }
        */

        public void Cargar(int[,] A)
        {
            this.F = A.GetLength(0);//numero de filas de la M.O.
            this.C = A.GetLength(1);//numero de columas de la M.O.
            this.cant = 1;//1 porque cuenta la primer fila
            Sparce[0, 0] = F;//Filas de la Matriz Original
            Sparce[0, 1] = C;//Columnas de la Matriz Original
            int i = 0;
            while (i < F)
            {
                int j = 0;
                while (j < C)
                {
                    if (A[i, j] != 0)
                    {
                        Sparce[cant, 0] = i;
                        Sparce[cant, 1] = j;
                        Sparce[cant, 2] = A[i,j];
                        cant++;
                    }
                    j++;
                }
                i++;


            }

            cant--;
            Sparce[0, 2] = cant;
        }



        public String MostrarMatrizSparce()
        {
            String S = "";
            for(int i = 0; i <= cant; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    S = S + "[" + Sparce[i, j] + "]";
                }
                S=S+"\n";//Salto de Linea
            }
            return S;
        }


        ///C = A + B usando matrices normales
        /*              { 1, 0, 0, 0, 0, 0 }, 
                       { 3, 2, 0, 0, 3, 0 },
                       { 0, 0, 0, 0, 0, 0 },
         A=            { 0, 0, 0, 0, 0,-4 },
                       { 1,-2, 0, 0, 0, 1 },
                       { 0, 0, 0, 0, 1, 0 }
       */

        /*              { 1, 0, 0, 0, 0, 0 }, 
                       { 3, 2, 0, 0, 3, 0 },
                       { 0, 0, 0, 0, 0, 0 },
         B=            { 0, 0, 0, 0, 0,-4 },
                       { 1,-2, 0, 0, 0, 1 },
                       { 0, 0, 0, 0, 1, 0 }
       */

        public String SumaAB(int [,]A,int[,] B)
        {
            
            int cont = 0;
            String sum = "";
            for(int i = 0; i < F; i++)
            {

                sum = sum + "\n";
                for (int j = 0; j < C; j++)
                {
                    cont = A[i, j] + B[i, j];
                    sum = sum + "[" + cont + "]";
                }

            }

            return sum;
        }

        public int[,] SumaAB2(int[,] A, int[,] B, int[,] resultante)
        {
            
            
            
            for (int i = 0; i < F; i++)
            {

             //   sum = sum + "\n";
                for (int j = 0; j < C; j++)
                {
                    resultante[i,j] = A[i, j] + B[i, j];
                    //sum = sum + "[" + cont + "]";
                }

            }

            return resultante;
        }





        public clsSpar SumarMatrices(clsSpar A,clsSpar B) 
        {
            int i = 1;/// contador de elementos
            clsSpar R = new clsSpar();//  matriz de salida 
            if ((A.Sparce[0, 0] == B.Sparce[0, 0]) && (A.Sparce[0, 1]== B.Sparce[0, 1]))
            {

                R.Sparce[0, 0] = A.Sparce[0, 0];
                R.Sparce[0, 1] = A.Sparce[0, 1];
                R.F=A.F;
                R.C=A.C;
                R.cant = 0;
                while ((i <=A.cant) && (i <= B.cant ))
                {
                    if ((A.Sparce[i, 0] == B.Sparce[i, 0]) && (A.Sparce[i, 1] == B.Sparce[i, 1]))
                    {
                        if(A.Sparce[i, 2] + B.Sparce[i, 2] != 0)
                        {
                            R.Sparce[i, 0] = A.Sparce[i, 0];
                            R.Sparce[i, 1] = A.Sparce[i, 1];
                            R.Sparce[i, 2] = A.Sparce[i, 2] + B.Sparce[i, 2];
                            
                            R.cant++;
                        }
                       // if (A.Sparce[i,2]==0)
                        //{

                        //}
                       
                        i = i + 1;

                    }
                    else
                    {
                        R.Sparce[i, 0] = A.Sparce[i, 0] ;
                        R.Sparce[i, 1] = A.Sparce[i, 1] ;
                        R.Sparce[i, 2] = A.Sparce[i, 2] ;
                      
                        i = i + 1;
                    }
                }
            }
            R.Sparce[0, 2] = R.cant ;
            
            return R;
            
        }

        public void Transpose( clsSpar A,clsSpar B)
        {
            //m=F ,n=C,t,
            int m = A.Sparce[0, 0];
            int n = A.Sparce[0, 1];
            int t = A.Sparce[0, 2];
            B.Sparce[0, 0] = m;
            B.Sparce[0, 1] = n;
            B.Sparce[0, 2] = t;
            if (t <= 0){
                return; ///Salir de metodo
            }
            int q = 1;
            for (int col = 1; col < n; col++)
            {
                for (int p = 1; p < t; p++)
                {
                    if (A.Sparce[p, 1] == col)
                    {
                        B.Sparce[q, 0] = A.Sparce[p, 1];
                        B.Sparce[q, 1] = A.Sparce[p, 0];
                        B.Sparce[q, 2] = A.Sparce[p, 2];
                        q = q + 1;
                    }
                }
            }
           
        }


        public void Fast_Transpose(clsSpar A, clsSpar B)
        {
            int m = A.Sparce[0, 0];//f
            int n = A.Sparce[0, 1];//C
            int t = A.Sparce[0, 2];//t numero de terminos
            B.Sparce[0, 0] = n;//
            B.Sparce[0, 1] = m;//
            B.Sparce[0, 2] = t;//
           
            int[] S = new int[n];
            int[] T = new int[n];
            if (t <= 0)
            {

                return;
            }
            for (int i = 0; i < n; i++)
            {
                S[i] = 0;
            }
            for (int i = 1; i <= t; i++)
            {
                S[A.Sparce[i, 1]] = S[A.Sparce[i, 1]] + 1;
            }
            T[0] = 1;
            for (int i = 1; i < n; i++)
            {
                T[i] = T[i - 1] + S[i - 1];
            }
            for (int i = 1; i <= t; i++)
            {
                int j = A.Sparce[i, 1];
                B.Sparce[T[j], 0] = A.Sparce[i, 1];
                B.Sparce[T[j], 1] = A.Sparce[i, 0];
                B.Sparce[T[j], 2] = A.Sparce[i, 2];
                T[j] = T[j] + 1;
            }

        }


















    }
}
