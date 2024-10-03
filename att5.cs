using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila();
            Random random = new Random();

            for (int i = 0; i < 10; i++) 
            {
                fila.Inserir(random.Next(0, 100));
            }

            Console.WriteLine("Fila:");
            fila.Mostrar();

            fila.inverter();
            Console.WriteLine("Fila Invertida:");
            fila.Mostrar();

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

        public void inverter()
        {
            Pilha pilha = new Pilha();

            while(primeiro.Prox != null)
            {
                pilha.Inserir(Remover());
            }  


            while(pilha.Topo != null)
            {
                Inserir(pilha.Remover());
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

    class Pilha
    {
        private Celula topo;

        public Pilha()
        {
            topo = null;
        }

        public Celula Topo { get { return topo; } set { this.topo = value; } }

        public void Inserir(int x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = topo;
            topo = tmp;
        }

        public int Remover()
        {
            if (topo == null)
                throw new Exception("Erro: Pilha vazia");
            int elemento = topo.Elemento;
            Celula tmp = topo;
            topo = tmp.Prox;
            return elemento;
        }

        public void Inverter()
        {
            Pilha temp = new Pilha();
            while (topo != null)
            {
                temp.Inserir(Remover());
            }
            topo = temp.topo;
        }

        public void Mostrar()
        {
            Console.Write("[ ");
            for (Celula i = topo; i != null; i = i.Prox)
            {
                Console.Write(i.Elemento + " ");
            }
            Console.WriteLine("]");
        }

        public bool VerificarPalindromo()
        {
            Pilha copiaPilha = new Pilha();
            Pilha inversaPilha = new Pilha();
            Celula atual = topo;


            while (atual != null)
            {

                inversaPilha.Inserir(atual.Elemento);
                atual = atual.Prox;
            }

            atual = inversaPilha.topo;

            while (atual != null)
            {
                copiaPilha.Inserir(atual.Elemento);
                atual = atual.Prox;
            }


            while (copiaPilha.topo != null)
            {
                if (copiaPilha.Remover() != inversaPilha.Remover())
                {
                    return false;
                }
            }

            return true;
        }

    }
}



