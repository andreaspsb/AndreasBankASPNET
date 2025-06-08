
using System;
using System.ComponentModel.DataAnnotations;

namespace AndreasBank.Models;
public class Conta
{
    private string _numero;
    private Agencia _agencia;
    private decimal _saldo;
    private Cliente _titular;
    private string _senha;
    private EnumStatusConta _statusConta;
    private DateTime _dataCriacao;
    private DateTime _dataUltimoAcesso;
    private EnumTipoConta _tipoConta;

    // Construtor público sem parâmetros para o Entity Framework
    public Conta() { }

    public Conta(string numero, Agencia agencia, Cliente titular, string senha, EnumTipoConta tipoConta)
    {
        _numero = numero;
        _agencia = agencia;
        _saldo = 0;
        _titular = titular;
        _senha = senha;
        _statusConta = EnumStatusConta.Ativo; // Default status
        _dataCriacao = DateTime.Now;
        _dataUltimoAcesso = DateTime.Now;
        _tipoConta = tipoConta;
    }

    [Key]
    public string Numero
    {
        get => _numero;
        set => _numero = value;
    }
    public Agencia Agencia
    {
        get => _agencia;
        set => _agencia = value;
    }
    public decimal Saldo
    {
        get => _saldo;
        set => _saldo = value;
    }
    public Cliente Titular
    {
        get => _titular;
        set => _titular = value;
    }
    public string Senha
    {
        get => _senha;
        set => _senha = value;
    }
    public EnumStatusConta StatusConta
    {
        get => _statusConta;
        set => _statusConta = value;
    }
    public DateTime DataCriacao
    {
        get => _dataCriacao;
        set => _dataCriacao = value;
    }
    public DateTime DataUltimoAcesso
    {
        get => _dataUltimoAcesso;
        set => _dataUltimoAcesso = value;
    }
    public EnumTipoConta TipoConta
    {
        get => _tipoConta;
        set => _tipoConta = value;
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