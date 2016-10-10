using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Sat.Extrato.FastReport
{
	public static class Extensions
	{
		public static string Descricao(this CodigoMP codigo)
		{
			return codigo.GetStr(
				new[] {
					CodigoMP.Dinheiro, CodigoMP.Cheque, CodigoMP.CartaodeCredito,
					CodigoMP.CartaodeDebito, CodigoMP.CreditoLoja, CodigoMP.ValeAlimentacao,
					CodigoMP.ValeRefeicao, CodigoMP.ValePresente, CodigoMP.ValeCombustivel,
					CodigoMP.Outros
				},
				new[]
				{
					"Dinheiro", "Cheque", "Cartão de Crédito",
					"Cartão de Débito", "Crédito Loja", "Vale Alimentação",
					"Vale Refeição", "Vale Presente", "Vale Combustível",
					"Outros"
				});
		}
	}
}