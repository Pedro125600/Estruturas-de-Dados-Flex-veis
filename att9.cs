using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista();
            ListaDupla listaDupla = new ListaDupla();

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                lista.InserirFim(random.Next(0, 100));
                listaDupla.inserirFim(random.Next(0, 100));
            }
            lista.Ordenar();
            listaDupla.Ordenar();
            Console.WriteLine("Lista:");
            lista.Mostrar();


            Console.Write("Adicionar na lista:");
            int n = int.Parse(Console.ReadLine());
            lista.InserirOrdenar(n);
            Console.WriteLine("Lista nova:");
            lista.Mostrar();

            Console.WriteLine("Lista dupla:");
            listaDupla.Mostrar();


            Console.Write("Adicionar na lista Dupla:");
            n = int.Parse(Console.ReadLine());
            listaDupla.InserirOrdenar(n);
            Console.WriteLine("Lista Dupla nova:");
            listaDupla.Mostrar();

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


    class Lista
    {
        private Celula primeiro, ultimo;
        public Lista()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }

        public void InserirInicio(int x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = primeiro.Prox;
            primeiro.Prox = tmp;
            if (primeiro == ultimo)
            {
                ultimo = tmp;
            }
            tmp = null;
        }

        public int RemoverFim()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");
            Celula i;
            for (i = primeiro; i.Prox != ultimo; i = i.Prox) ;
            int elemento = ultimo.Elemento;
            ultimo = i;
            i = ultimo.Prox = null;
            return elemento;
        }

        public void InserirOrdenar(int x)
        {
            if (primeiro == ultimo)
                InserirFim(x);
            else
            {
                int cont = 0;
                for (Celula i = primeiro.Prox; i != null; i = i.Prox, cont++)
                {
                    if (i.Elemento > x)
                    {
                        Inserir(x, cont);
                        return;
                    }
                }

            }

        }


        public void InserirFim(int x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }



        public void Inserir(int x, int pos)
        {
            int tamanho = Tamanho();
            if (pos < 0 || pos > tamanho)
            {
                throw new Exception("Erro!");
            }
            else if (pos == 0)
            {
                InserirInicio(x);
            }
            else if (pos == tamanho)
            {
                InserirFim(x);
            }
            else
            {
                Celula i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                Celula tmp = new Celula(x);
                tmp.Prox = i.Prox;
                i.Prox = tmp;
                tmp = i = null;
            }
        }

        public int RemoverInicio()
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

        public int Remover(int pos)
        {
            int elemento, tamanho = Tamanho();
            if (primeiro == ultimo || pos < 0 || pos >= tamanho)
            {
                throw new Exception("Erro!");
            }
            else if (pos == 0)
            {
                elemento = RemoverInicio();
            }
            else if (pos == tamanho - 1)
            {
                elemento = RemoverFim();
            }
            else
            {
                Celula i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                Celula tmp = i.Prox;
                elemento = tmp.Elemento; i.Prox = tmp.Prox;
                tmp.Prox = null; i = tmp = null;
            }
            return elemento;
        }

        public void Inverter()
        {
            Lista temp = new Lista();



            while (primeiro.Prox != null)
            {
                temp.InserirFim(RemoverFim());
            }

            while (temp.primeiro.Prox != null)
            {
                InserirFim(temp.RemoverInicio());
            }
        }

        public int Tamanho()
        {

            int cont = 0;

            for (Celula i = primeiro.Prox; i != null; i = i.Prox) { cont++; }
            return cont;

        }

        public bool Buscar(ref int x)
        {

            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == x)
                {
                    x = i.Elemento;
                    return true;

                }

            }

            return false;
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

        public void Ordenar()
        {
            if (primeiro == ultimo || primeiro.Prox == null)
                return;

            bool trocou;
            do
            {
                trocou = false;
                CelulaDupla atual = primeiro.Prox;

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

        public void InserirOrdenar(int x)
        {
            if (primeiro == ultimo)
                inserirFim(x);
            else
            {
                int cont = 0;
                for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox, cont++)
                {
                    if (i.Elemento > x)
                    {
                        inserir(x, cont);
                        return;
                    }
                }

            }

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

        public bool Buscar(ref int x)
        {

            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == x)
                {
                    x = i.Elemento;
                    return true;

                }

            }

            return false;
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
