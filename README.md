# 🏦 FintechBank

![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![xUnit](https://img.shields.io/badge/Testes-xUnit-5C2D91?style=for-the-badge)
![License](https://img.shields.io/badge/Licença-MIT-green?style=for-the-badge)

Solução .NET que simula as regras de negócio de um banco digital (conta corrente e empréstimos), com testes unitários parametrizados em **xUnit**. 💳

> [!NOTE]
> Projeto desenvolvido como atividade prática da disciplina de **Garantia da Qualidade de Software**.

---

## 📖 Visão geral

O `FintechBank` é composto por dois projetos:

| Projeto | Papel |
|---|---|
| `FintechBank.App` | Código de produção, com as classes de regras de negócio |
| `FintechBank.Tests` | Testes unitários com xUnit |

## ⚙️ Requisitos técnicos

- **.NET 10 SDK** ([download](https://dotnet.microsoft.com/download))
- Terminal (Git Bash, PowerShell, etc.)

Para conferir a versão instalada:

```bash
dotnet --version
```

---

## 💼 Regras de negócio

### `ContaCorrenteService`

| Método | Regra |
|---|---|
| `CalcularTaxaManutencao(saldo, clienteEspecial)` | Saldo ≥ R$ 5.000,00 **ou** cliente especial: isento (`0.00`). Saldo entre R$ 1.000,00 e R$ 4.999,99: `12.50`. Saldo abaixo de R$ 1.000,00: `25.00` |
| `PodeRealizarSaque(saldo, limiteChequeEspecial, valorSaque)` | Retorna `true` apenas se `valorSaque <= saldo + limiteChequeEspecial` |

### `EmprestimoService`

| Método | Regra |
|---|---|
| `CalcularValorParcela(valorTotal, parcelas, scoreCredito)` | Score ≥ 700: juros de 5% (×1.05). Score de 500 a 699: 12% (×1.12). Score < 500: 20% (×1.20). Retorna o valor com juros dividido pelo número de parcelas |
| `AprovarEmprestimo(rendaMensal, valorParcela)` | Aprova (`true`) se a parcela comprometer no máximo 30% da renda mensal |

---

## 🧪 Testes parametrizados (`[Theory]` / `[InlineData]`)

Em vez de escrever um método `[Fact]` para cada cenário, cada regra é testada por **um único método `[Theory]`**, que roda várias vezes, uma para cada `[InlineData]`. Cada linha de `[InlineData]` vira um teste individual no relatório do xUnit.

### `ContaCorrenteServiceTests`

| Teste | Cenários (`[InlineData]`) |
|---|---|
| `CalcularTaxaManutencao_DeveRetornarTaxaCorreta` | Saldo alto (isento), cliente especial (isento), saldo intermediário (12,50), saldo baixo (25,00) |
| `PodeRealizarSaque_DeveValidarLimiteCorretamente` | Saque dentro do limite (`true`), saque acima de saldo + limite (`false`) |

### `EmprestimoServiceTests`

| Teste | Cenários (`[InlineData]`) |
|---|---|
| `CalcularValorParcela_DeveAplicarJurosConformeScore` | Score alto (1.050,00), médio (1.120,00) e baixo (1.200,00) |
| `AprovarEmprestimo_DeveValidarMargemDe30Porcento` | Parcela igual a 30% da renda (`true`), parcela acima de 30% (`false`) |

**Total: 4 métodos `[Theory]`, resultando em 11 execuções de teste.**

---

## 🚀 Como executar

### 1. Clonar o repositório

```bash
git clone https://github.com/JoTaP-MX/fintech-bank-xunit.git
cd fintech-bank-xunit
```

### 2. Compilar a solução

```bash
dotnet build
```

### 3. Executar os testes unitários

```bash
dotnet test
```

Saída esperada:

```
Resumo do teste: total: 11; falhou: 0; bem-sucedido: 11; ignorado: 0
```

---

## 👤 Sobre o Autor

Feito com 💻 por **João Pedro Gonçalves**

## 📄 Licença

Este projeto está sob a licença **MIT**. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
