using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att4
{
    internal class Program
    {
        static void Main(string[] args)
            {
                Fila fila1 = new Fila();
                Fila fila2 = new Fila();
              

                Random rnd = new Random();

                int cont = 0;

                while (cont != 10)
                {
                    fila2.Inserir(rnd.Next(0, 100));
                    fila1.Inserir(rnd.Next(0, 100));
                    cont++;
                }


                Console.WriteLine("Fila 1");
                fila1.Mostrar();
                Console.WriteLine("Fila 2");
                fila2.Mostrar();


            fila1.Concatenar(fila2);

                Console.WriteLine("Fila concatenada");
                fila1.Mostrar();

                Console.ReadLine();
            }
        }

        class Celula
        {
            private int elemento;
            private Celula prox;
            public Celula(int elemento)
            {
                this.elemento = elemento;
                this.prox = null;
            }
            public Celula()
            {
                this.elemento = 0;
                this.prox = null;
            }
            public Celula Prox
            {
                get { return prox; }
                set { prox = value; }
            }
            public int Elemento
            {
                get { return elemento; }
                set { elemento = value; }
            }
        }
        class Fila
        {
            private Celula primeiro, ultimo;
            public Fila()
            {
                primeiro = new Celula();
                ultimo = primeiro;
            }

            public void Inserir(int x)
            {
                ultimo.Prox = new Celula(x);
                ultimo = ultimo.Prox;
            }

            public int Remover()
            {
                if (primeiro == ultimo)
                    throw new Exception("Erro!");
                Celula tmp = primeiro;
                primeiro = primeiro.Prox;
                int elemento = primeiro.Elemento;
                tmp.Prox = null;
                tmp = null;
                return elemento;
            }

            public void Mostrar()
            {
                Console.Write("[");
                for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                {
                    Console.Write(i.Elemento + " ");
                }
                Console.WriteLine("]");
            }


        public void Concatenar(Fila f1)
        {
            while (f1.primeiro.Prox != null)
            {

                Inserir(f1.Remover());
                   
     
            }


        }

        public void PreencherFila(Fila f1, Fila f2)
            {
                while (f1.primeiro.Prox != null && f2.primeiro.Prox != null)
                {
                    if (f1.primeiro.Prox.Elemento < f2.primeiro.Prox.Elemento)
                    {
                        Inserir(f1.Remover());
                    }
                    else if (f2.primeiro.Prox.Elemento < f1.primeiro.Prox.Elemento)
                    {
                        Inserir(f2.Remover());
                    }
                    else
                    {
                        Inserir(f1.Remover());
                        f2.Remover();
                    }
                }

                while (f1.primeiro.Prox != null)
                {
                    Inserir(f1.Remover());
                }
                while (f2.primeiro.Prox != null)
                {
                    Inserir(f2.Remover());
                }

            }

            public void Ordenar()
            {
                if (primeiro == ultimo || primeiro.Prox == null)
                    return;

                bool trocou;
                do
                {
                    trocou = false;
                    Celula atual = primeiro.Prox;

                    while (atual != null && atual.Prox != null)
                    {
                        if (atual.Elemento > atual.Prox.Elemento)
                        {
                            int temp = atual.Elemento;
                            atual.Elemento = atual.Prox.Elemento;
                            atual.Prox.Elemento = temp;

                            trocou = true;
                        }
                        atual = atual.Prox;
                    }
                } while (trocou);
            }
        }

    }


