using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pilha pilha1 = new Pilha();

            Console.Write("Digite um texto: ");
            string texto = Console.ReadLine();

            foreach (char c in texto)
            {
                pilha1.Inserir(c);
              
            }
            pilha1.Inverter();

            Console.WriteLine();
            Console.WriteLine("Pilha:");
            pilha1.Mostrar();

            if (pilha1.VerificarPalindromo())
            {
                Console.WriteLine("A palavra é um palíndromo.");
            }
            else
            {
                Console.WriteLine("A palavra não é um palíndromo.");
            }

            Console.WriteLine("Pilha após verificação:");
            pilha1.Mostrar();

            Console.ReadLine();
        }
    }

    class Celula
    {
        private char elemento; 
        private Celula prox;

        public Celula(char elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }

        public Celula()
        {
            this.elemento = 'a'; 
            this.prox = null;
        }

        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }

        public char Elemento 
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }

    class Pilha
    {
        private Celula topo;

        public Pilha()
        {
            topo = null;
        }

        public void Inserir(char x) 
        {
            Celula tmp = new Celula(x);
            tmp.Prox = topo;
            topo = tmp;
        }

        public char Remover()
        {
            if (topo == null)
                throw new Exception("Erro: Pilha vazia");
            char elemento = topo.Elemento;
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

            atual =  inversaPilha.topo;

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
