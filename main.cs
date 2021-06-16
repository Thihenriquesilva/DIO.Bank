using System;
using System.Collections.Generic;

class MainClass {
  //coleção que possui as contas cadastradas
  static List<Conta>listContas = new List<Contas>();

  public static void Main (string[] args) {
    string opcaoUsuario = ObterOpcaoUsuario();

    while(opcaoUsuario.ToUpper() != "X"){
      switch(opcaoUsuario){
        case "1":
          ListarContas();
          break;
        case "2":
          InserirConta();
          break;
        case "3":
          Transferir();
          break;  
        case "4":
          Sacar();
          break;
        case "5":
          Depositar();
          break;
        case "C":
          Console.Clear();
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
      opcaoUsuario = ObterOpcaoUsuario();
    }
    Console.WriteLine("Obrigado por utilizar nossos serviços.");
    Console.ReadLine();
  }

  //Cadastrar nova conta bancária
  private static void InserirConta(){
    Console.WriteLine("Inserir nova conta");

    Console.WriteLine("Digite 1 para Conta Física ou 2 para Juridica: ");
    int entradaTipoConta = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o nome do Cliente:");
    string entradaNome = Console.ReadLine();

    Console.WriteLine("Digite o saldo inicial:");
    double entradaSaldo = double.Parse(Console.ReadLine());

    Console.WriteLine("Digite o crédito:");
    double entradaCredito = double.Parse(Console.ReadLine());

    Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                saldo: entradaSaldo,
                                credito: entradaCredito,
                                nome: entradaNome);

    listContas.Add(novaConta);

  }

  //Lista as contas existentes cadastradas
  private static void ListarContas(){
    Console.WriteLine("Listar contas");

    if(listContas.Count == 0){
      Console.WriteLine("Nenhuma conta cadastrada.");
      return;
    }

    for(int i = 0; i < listContas.Count;i++){
      Conta conta = listContas(i);
      Console.WriteLine("#{0} - ", i);

      //Mostra os dados conforme foi alterado no método ToString da classe conta
      Console.WriteLine(conta);
    } 
  }

//Transferir 
  private static void Transferir(){
    Console.WriteLine("Digite o número da conta de origem: ");
    int indiceContaOrigem = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o número da conta de destino: ");
    int indiceContaDestino = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor a ser transferido: ");
    double valorTransferencia = double.Parse(Console.ReadLine());

    listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
  }







  //Sacar
  private static void Sacar(){

    Console.WriteLine("Digite o número da conta: ");
    int indiceConta = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor a ser sacado: ");
    double valorDeposito = double.Parse(Console.ReadLine());

    
    listContas[indiceConta].Sacar(valorDeposito);
  }

  //Depositar
  private static void Depositar(){
    Console.WriteLine("Digite o número da conta: ");
    int indiceConta = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor a ser depositado: ");
    double valorDeposito = double.Parse(Console.ReadLine());

    listContas[indiceConta].Depositar(valorDeposito);
  }

  //Menu inicial
  private static string ObterOpcaoUsuario(){
    Console.WriteLine();
    Console.WriteLine("Bem vindo ao DIO Bank!!");
    Console.WriteLine("Informe a opção desejada:");

    Console.WriteLine("1- Listar contas");
    Console.WriteLine("2- Inserir nova conta");
    Console.WriteLine("3- Transferir");
    Console.WriteLine("4- Sacar");
    Console.WriteLine("5- Depositar");
    Console.WriteLine("C- Limpar Tela");
    Console.WriteLine("X- Sair");
    Console.WriteLine();
    
    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
  }
}



