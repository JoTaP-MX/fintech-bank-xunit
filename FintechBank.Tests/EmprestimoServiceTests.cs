using FintechBank.App;
using Xunit;

namespace FintechBank.Tests;

public class EmprestimoServiceTests
{
    private readonly EmprestimoService _service = new();

    [Theory]
    [InlineData(10000.00, 10, 800, 1050.00)]
    [InlineData(10000.00, 10, 600, 1120.00)]
    [InlineData(10000.00, 10, 400, 1200.00)]
    public void CalcularValorParcela_DeveAplicarJurosConformeScore(decimal valorTotal, int parcelas, int scoreCredito, decimal valorEsperado)
    {
        var resultado = _service.CalcularValorParcela(valorTotal, parcelas, scoreCredito);
        Assert.Equal(valorEsperado, resultado);
    }

    [Theory]
    [InlineData(5000.00, 1500.00, true)]
    [InlineData(5000.00, 1600.00, false)]
    public void AprovarEmprestimo_DeveValidarMargemDe30Porcento(decimal rendaMensal, decimal valorParcela, bool resultadoEsperado)
    {
        var resultado = _service.AprovarEmprestimo(rendaMensal, valorParcela);
        Assert.Equal(resultadoEsperado, resultado);
    }
}
