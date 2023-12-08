namespace DesafioFundamentos.Models
	{
	public class Estacionamento
		{
		private decimal precoInicial = 0;
		private decimal precoPorHora = 0;
		private List<string> veiculos = new List<string>();


		public Estacionamento(decimal precoInicial, decimal precoPorHora)
			{
			this.precoInicial = precoInicial;
			this.precoPorHora = precoPorHora;
			}

		public void AdicionarVeiculo()
			{
			string inputVeiculo;
			bool verificaPlaca = false;

			while (verificaPlaca == false)
				{
				Console.WriteLine("Digite a placa do veículo para estacionar:");
				inputVeiculo = Console.ReadLine().ToUpper();

				if (!veiculos.Contains(inputVeiculo))
					{
					veiculos.Add(inputVeiculo);
					verificaPlaca = true;
					}
				else Console.WriteLine($"Placa '{inputVeiculo}' já cadastrada, por favor, digite uma placa diferente.");
				}

			verificaPlaca = false;
			}

		public void RemoverVeiculo()
			{
			Console.WriteLine("Digite a placa do veículo para remover:");
			string placa = Console.ReadLine();

			// Verifica se o veículo existe
			if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
				{
				bool validaHora = false;
				int horas = ObterHorasEstacionado();
				decimal valorTotal = 0;

				if (horas > 1)
					{
					valorTotal = precoInicial + (horas - 1) * precoPorHora;
					}
				else valorTotal = precoInicial;

				Console.WriteLine($"O veículo '{placa}' foi removido e o preço total foi de: R$ {valorTotal}");
				veiculos.Remove(placa);
				}
			else Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
			}

		public void ListarVeiculos()
			{
			// Verifica se há veículos no estacionamento
			if (veiculos.Any())
				{
				Console.WriteLine("Os veículos estacionados são:");
				foreach (string item in veiculos)
					{
					Console.Write($"{item}\n");
					}
				}
			else Console.WriteLine("Não há veículos estacionados.");
			}

		public int ObterHorasEstacionado()
			{
			while (true)
				{
				Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
				if (int.TryParse(Console.ReadLine(), out int entradaHoras))
					{
					return entradaHoras;
					}
				else Console.WriteLine("Hora inválida, digite apenas números inteiros.");
				}
			}
		}
	}
