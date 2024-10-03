using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaDupla listaDupla = new ListaDupla();


            int opcao = 0;

            while (opcao != 5)
            {
                Console.Clear();
                Console.WriteLine("Agenda de Contatos");
                Console.WriteLine("1 - Adicionar um novo contato");
                Console.WriteLine("2 - Atualizar informações de um contato");
                Console.WriteLine("3 - Excluir um contato da agenda");
                Console.WriteLine("4 - Listar todos os contatos");
                Console.WriteLine("5 - Encerrar o programa");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Nome do Contato: ");
                        string nome = Console.ReadLine();
                        Console.Write("Telefone: ");
                        string telefone = Console.ReadLine();
                        Console.Write("E-mail: ");
                        string email = Console.ReadLine();

                        string contato = $"{nome} {telefone} {email}";
                        listaDupla.inserirFim(contato);

                        Console.WriteLine("\nContato adicionado com sucesso!");
                        break;
                    case 2:
                        Console.Write("Digite o número do contato que deseja atualizar: ");
                        int nun = int.Parse(Console.ReadLine()) ;

                        if (nun >= 0 && nun < listaDupla.Tamanho())
                        {
                            Console.WriteLine("Atualize as informações:");
                            Console.Write("Nome do Contato: ");
                            nome = Console.ReadLine();
                            Console.Write("Telefone: ");
                            telefone = Console.ReadLine();
                            Console.Write("E-mail: ");
                            email = Console.ReadLine();
                             contato = $"{nome} {telefone} {email}";
                            listaDupla.Atualizar(nun, contato);

                            Console.WriteLine("Contato atualizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado.");
                        }

                        break;
                    case 3:

                        Console.Write("Digite o número do contato que deseja excluir: ");
                        nun = int.Parse(Console.ReadLine()) - 1;

                        if (nun >= 0 && nun < listaDupla.Tamanho())
                        {
                            listaDupla.remover(nun);
                            Console.WriteLine("\nContato excluído com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Lista de Contatos:");

                        if (listaDupla.Tamanho() == 0)
                        {
                            Console.WriteLine("A agenda está vazia.");
                        }
                        else
                        {
                            listaDupla.Mostrar();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();

            }
        }
        class CelulaDupla
        {
            private string elemento;
            private CelulaDupla prox, ant;

            public CelulaDupla(string elemento)
            {
                this.elemento = elemento;
                this.prox = null;
                this.ant = null;
            }

            public CelulaDupla()
            {
                this.elemento = null;
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

            public string Elemento
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

            public void inserirInicio(string x)
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

            public void inserirFim(string x)
            {
                ultimo.Prox = new CelulaDupla(x);
                ultimo.Prox.Ant = ultimo;
                ultimo = ultimo.Prox;
            }

            public string removerInicio()
            {
                if (primeiro == ultimo)
                    throw new Exception("Erro!");
                CelulaDupla tmp = primeiro;
                primeiro = primeiro.Prox;
                string elemento = primeiro.Elemento;
                tmp.Prox = primeiro.Ant = null;
                tmp = null;
                return elemento;
            }

            public string removerFim()
            {
                if (primeiro == ultimo)
                    throw new Exception("Erro!");
                string elemento = ultimo.Elemento;
                ultimo = ultimo.Ant;
                ultimo.Prox.Ant = null;
                ultimo.Prox = null;
                return elemento;
            }

            public void inserir(string x, int pos)
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

            public string remover(int pos)
            {
                int tamanho = Tamanho();
                string elemento;
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

            public bool Buscar(ref string x)
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

            public void Atualizar(int x, string text)
            {
                remover(x);
                inserir(text, x);

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
}
