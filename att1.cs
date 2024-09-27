using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Pilha pilha1 = new Pilha();
         

            Console.Write("Digite os numeros que irão ser inserios na pilha(Digite -1 para parar)");
            int cont = 1;
            Console.Write($"\nNumero {cont}:");
            int inserir = int.Parse(Console.ReadLine());
            pilha1.Inserir(inserir);
            while(inserir != -1)
            {
                cont++;
                Console.Write($"Numero {cont}:");
                inserir = int.Parse(Console.ReadLine());
                if (inserir == -1)
                    break;
                else
                    pilha1.Inserir(inserir);
               
            }

            Console.WriteLine();
            Console.WriteLine("Pilha:");
            pilha1.Mostrar();

            pilha1.Inverter();

            Console.WriteLine("Pilha invertida:");
            pilha1.Mostrar();

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

    class Pilha
    {

        public Celula Topo { get { return this.topo; } set { this.topo = value; } }

        private Celula topo;
        public Pilha()
        {
            topo = null;
        }

        public void Inserir(int x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = topo;
            topo = tmp;
            tmp = null;
        }

        public int Remover()
        {
            if (topo == null)
                throw new Exception("Erro");
            int elemento = topo.Elemento;
            Celula tmp = topo;
            topo = tmp.Prox;
            tmp.Prox = null;
            tmp = null;
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

    }
}
