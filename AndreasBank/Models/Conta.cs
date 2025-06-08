using System;
using System.ComponentModel.DataAnnotations;

namespace AndreasBank.Models;
public abstract class Conta
{
    // Padronização dos campos privados para camelCase
    private string? numeroConta = string.Empty;
    private Agencia? agenciaConta;
    private decimal saldoConta = 0;
    private Cliente? titularConta;
    private string? senhaHash = string.Empty;
    private EnumStatusConta statusContaEnum = EnumStatusConta.Ativo;
    private DateTime dataCriacaoConta = DateTime.Now;
    private DateTime dataUltimoAcessoConta = DateTime.Now;
    private EnumTipoConta tipoContaEnum = EnumTipoConta.Corrente;

    // Construtor público sem parâmetros para o Entity Framework
    public Conta() { }

    public Conta(string numero, Agencia agencia, Cliente titular, string senha, EnumTipoConta tipoConta)
    {
        numeroConta = numero;
        agenciaConta = agencia;
        saldoConta = 0;
        titularConta = titular;
        DefinirSenha(senha);
        statusContaEnum = EnumStatusConta.Ativo; // Default status
        dataCriacaoConta = DateTime.Now;
        dataUltimoAcessoConta = DateTime.Now;
        tipoContaEnum = tipoConta;
    }

    [Key]
    [Required]
    [StringLength(6, MinimumLength = 6, ErrorMessage = "O número da conta deve ter exatamente 6 dígitos.")]
    [RegularExpression(@"^\d{6}$", ErrorMessage = "O número da conta deve conter apenas dígitos.")]
    public string? Numero
    {
        get => numeroConta;
        set => numeroConta = value;
    }
    // Propriedade de navegação para agência
    [Required]
    public virtual Agencia? Agencia
    {
        get => agenciaConta;
        set => agenciaConta = value;
    }

    // Chave estrangeira explícita
    [Required]
    [StringLength(4, MinimumLength = 4)]
    public string? AgenciaNumero { get; set; }
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "O saldo não pode ser negativo.")]
    public decimal Saldo
    {
        get => saldoConta;
        set => saldoConta = value;
    }
    // Propriedade de navegação para titular
    [Required]
    public virtual Cliente? Titular
    {
        get => titularConta;
        set => titularConta = value;
    }

    // Chave estrangeira explícita
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string? TitularCPF { get; set; }
    [Required]
    public EnumStatusConta StatusConta
    {
        get => statusContaEnum;
        set => statusContaEnum = value;
    }
    [Required]
    public DateTime DataCriacao
    {
        get => dataCriacaoConta;
        private set => dataCriacaoConta = value;
    }
    [Required]
    public DateTime DataUltimoAcesso
    {
        get => dataUltimoAcessoConta;
        private set => dataUltimoAcessoConta = value;
    }
    [Required]
    public EnumTipoConta TipoConta
    {
        get => tipoContaEnum;
        set => tipoContaEnum = value;
    }

    // Propriedade calculada: indica se a conta está ativa
    public bool EstaAtiva => StatusConta == EnumStatusConta.Ativo;

    // Novo método para definir a senha (armazenando o hash)
    public void DefinirSenha(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6)
            throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");
        senhaHash = GerarHash(senha);
    }

    // Novo método para validar a senha
    public bool ValidarSenha(string senha)
    {
        return senhaHash == GerarHash(senha);
    }

    // Método privado para gerar hash (exemplo simples, use um algoritmo seguro em produção)
    private string GerarHash(string senha)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(senha);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}

public class ContaCorrente : Conta
{
    [Range(0, 1000, ErrorMessage = "O limite de cheque especial deve ser entre 0 e 1000.")]
    public decimal LimiteChequeEspecial { get; set; } = 0;

    public ContaCorrente(string numero, Agencia agencia, Cliente titular, string senha)
        : base(numero, agencia, titular, senha, EnumTipoConta.Corrente) { }
    public ContaCorrente() : base() { }

    // Exemplo: cobrança de tarifa de manutenção
    public void CobrarTarifaMensal(decimal valor)
    {
        if (Saldo >= valor)
            Saldo -= valor;
        else
            throw new InvalidOperationException("Saldo insuficiente para tarifa mensal.");
    }
}

public class ContaPoupanca : Conta
{
    [Range(0, 1, ErrorMessage = "A taxa de rendimento deve ser entre 0 e 1 (0% a 100%).")]
    public decimal TaxaRendimento { get; set; } = 0.005m; // 0,5% padrão

    public ContaPoupanca(string numero, Agencia agencia, Cliente titular, string senha)
        : base(numero, agencia, titular, senha, EnumTipoConta.Poupanca) { }
    public ContaPoupanca() : base() { }

    // Exemplo: rendimento mensal
    public void AplicarRendimento(decimal taxa)
    {
        if (taxa < 0) throw new ArgumentException("Taxa não pode ser negativa.");
        Saldo += Saldo * taxa;
    }
}

public class ContaSalario : Conta
{
    [Required]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ do empregador deve ter 14 dígitos.")]
    public string? CnpjEmpregador { get; set; }

    public ContaSalario(string numero, Agencia agencia, Cliente titular, string senha)
        : base(numero, agencia, titular, senha, EnumTipoConta.Salario) { }
    public ContaSalario() : base() { }

    // Exemplo: só permite depósito do empregador
    public void DepositarSalario(decimal valor, string cnpjEmpregador, string cnpjPermitido)
    {
        if (cnpjEmpregador != cnpjPermitido)
            throw new InvalidOperationException("Depósito permitido apenas pelo empregador cadastrado.");
        Saldo += valor;
    }
}

public enum EnumStatusConta
{
    Ativo,
    Inativo,
    Bloqueado,
    Encerrado
}
public enum EnumTipoConta
{
    Corrente,
    Poupanca,
    Salario,
    Investimento
}