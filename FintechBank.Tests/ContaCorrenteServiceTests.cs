using FintechBank.App;
using Xunit;

namespace FintechBank.Tests;

public class ContaCorrenteServiceTests
{
    private readonly ContaCorrenteService _service = new();

    [Theory]
    [InlineData(6000.00, false, 0.00)]
    [InlineData(500.00, true, 0.00)]
    [InlineData(2500.00, false, 12.50)]
    [InlineData(300.00, false, 25.00)]
    public void CalcularTaxaManutencao_DeveRetornarTaxaCorreta(decimal saldo, bool clienteEspecial, decimal taxaEsperada)
    {
        var resultado = _service.CalcularTaxaManutencao(saldo, clienteEspecial);
        Assert.Equal(taxaEsperada, resultado);
    }

    [Theory]
    [InlineData(1000.00, 500.00, 1200.00, true)]
    [InlineData(1000.00, 500.00, 1600.00, false)]
    public void PodeRealizarSaque_DeveValidarLimiteCorretamente(decimal saldo, decimal limiteChequeEspecial, decimal valorSaque, bool resultadoEsperado)
    {
        var resultado = _service.PodeRealizarSaque(saldo, limiteChequeEspecial, valorSaque);
        Assert.Equal(resultadoEsperado, resultado);
    }
}
