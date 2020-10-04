﻿using System;
using System.Globalization;
using ExercicioInterface.Entities;
using ExercicioInterface.Services;

namespace ExercicioInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data:");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime Date = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(number, Date, contractValue);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(myContract, months);

            Console.WriteLine();
            Console.WriteLine("INSTALLMENTS:");
            foreach (Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }
        }
    }
}
/*
 Uma empresa deseja automatizar o processamento de seus contratos. O processamento de
um contrato consiste em gerar as parcelas a serem pagas para aquele contrato, com base no
número de meses desejado.
A empresa utiliza um serviço de pagamento online para realizar o pagamento das parcelas.
Os serviços de pagamento online tipicamente cobram um juro mensal, bem como uma taxa
por pagamento. Por enquanto, o serviço contratado pela empresa é o do Paypal, que aplica
juros simples de 1% a cada parcela, mais uma taxa de pagamento de 2%.
Fazer um programa para ler os dados de um contrato (número do contrato, data do contrato,
e valor total do contrato). Em seguida, o programa deve ler o número de meses para
parcelamento do contrato, e daí gerar os registros de parcelas a serem pagas (data e valor),
sendo a primeira parcela a ser paga um mês após a data do contrato, a segunda parcela dois
meses após o contrato e assim por diante. Mostrar os dados das parcelas na tela.

Calculations (1% monthly simple interest + 2% payment fee):
Quota #1:
200 + 1% * 1 = 202
202 + 2% = 206.04

Quota #2:
200 + 1% * 2 = 204
204 + 2% = 208.08

Quota #3:
200 + 1% * 3 = 206
206 + 2% = 210.12

EXEMPLO:

Enter contract data
Number: 8028
Date (dd/MM/yyyy): 25/06/2018
Contract value: 600.00
Enter number of installments: 3
Installments:
25/07/2018 - 206.04
25/08/2018 - 208.08
25/09/2018 - 210.12

 */