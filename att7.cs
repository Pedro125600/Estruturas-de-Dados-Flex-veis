using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace att7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaDupla lista = new ListaDupla();
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                lista.inserirFim(random.Next(0, 100));
            }

            Console.WriteLine("Lista:");
            lista.Mostrar();

            lista.Inverter();
            Console.WriteLine("Lista Invertida:");
            lista.Mostrar();

            Console.ReadLine();


        }
    }

    class CelulaDupla
    {
        private int elemento;
        private CelulaDupla prox, ant;
        public CelulaDupla(int elemento)
        {
            this.elemento = elemento;
            this.prox = null;
            this.ant = null;
        }
        public CelulaDupla()
        {
            this.elemento = 0;
            this.prox = null;
            this.ant = null;
        }
        public CelulaDupla Prox
        {
            get { return prox; }
            set { prox = value; }
        }
        public CelulaDupla Ant
        {
            get { return ant; }
            set { ant = value; }
        }
        public int Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }

    class ListaDupla
    {
        private CelulaDupla primeiro, ultimo;
        public ListaDupla()
        {
            primeiro = new CelulaDupla();
            ultimo = primeiro;
        }


        public int Tamanho()
        {

            int cont = 0;

            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox) { cont++; };
            return cont;

        }

        public void inserirInicio(int x)
        {
            CelulaDupla tmp = new CelulaDupla(x);
            tmp.Ant = primeiro;
            tmp.Prox = primeiro.Prox;
            primeiro.Prox = tmp;
            if (primeiro == ultimo)
            {
                ultimo = tmp;
            }
            else
            {
                tmp.Prox.Ant = tmp;
            }
            tmp = null;
        }

        public void inserirFim(int x)
        {
            ultimo.Prox = new CelulaDupla(x);
            ultimo.Prox.Ant = ultimo;
            ultimo = ultimo.Prox;
        }

        public int removerInicio()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");
            CelulaDupla tmp = primeiro;
            primeiro = primeiro.Prox;
            int elemento = primeiro.Elemento;
            tmp.Prox = primeiro.Ant = null;
            tmp = null;
            return elemento;
        }

        public int removerFim()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");
            int elemento = ultimo.Elemento;
            ultimo = ultimo.Ant;
            ultimo.Prox.Ant = null;
            ultimo.Prox = null;
            return elemento;
        }

        public void inserir(int x, int pos)
        {
            int tamanho = Tamanho();
            if (pos < 0 || pos > tamanho)
            {
                throw new Exception("Erro!");
            }
            else if (pos == 0)
            {
                inserirInicio(x);
            }
            else if (pos == tamanho)
            {
                inserirFim(x);
            }
            else
            {
                CelulaDupla i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                CelulaDupla tmp = new CelulaDupla(x);
                tmp.Ant = i;
                tmp.Prox = i.Prox;
                tmp.Ant.Prox = tmp.Prox.Ant = tmp;
                tmp = i = null;

            }
        }

        public int remover(int pos)
        {
            int elemento, tamanho = Tamanho();
            if (primeiro == ultimo)
            {
                throw new Exception("Erro!");
            }
            else if (pos < 0 || pos >= tamanho)
            {
                throw new Exception("Erro!");
            }
            else if (pos == 0)
            {
                elemento = removerInicio();
            }
            else if (pos == tamanho - 1)
            {
                elemento = removerFim();
            }
            else
            {
                CelulaDupla i = primeiro.Prox;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                i.Ant.Prox = i.Prox;
                i.Prox.Ant = i.Ant;
                elemento = i.Elemento;
                i.Prox = i.Ant = null;
                i = null;
            }
            return elemento;
        }

        public void Inverter()
        {

            ListaDupla temp = new ListaDupla();


            while (primeiro.Prox != null)
            {
                temp.inserirFim(removerFim());
            }

            while (temp.primeiro.Prox != null)
            {
                inserirFim(temp.removerInicio());
            }

        }

        public void Mostrar()
        {
            Console.Write("[");
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.Write(i.Elemento + " ");
            }
            Console.WriteLine("]");
        }
    }
}