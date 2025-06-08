using System;
using System.ComponentModel.DataAnnotations;

namespace AndreasBank.Models;

public class Agencia
{
    private string _numero;
    private string _nome;
    private string _endereco;
    private string _telefone;
    private string _email;
    private DateTime _dataCriacao;
    private EnumStatusAgencia _status;

    // Construtor público sem parâmetros para o Entity Framework
    public Agencia() { }

    public Agencia(string numero, string nome, string endereco, string telefone, string email)
    {
        _numero = numero;
        _nome = nome;
        _endereco = endereco;
        _telefone = telefone;
        _email = email;
        _dataCriacao = DateTime.Now;
        _status = EnumStatusAgencia.Ativo; // Default status
    }

    [Key]
    public string Numero
    {
        get => _numero;
        set => _numero = value;
    }
    public string Nome
    {
        get => _nome;
        set => _nome = value;
    }
    public string Endereco
    {
        get => _endereco;
        set => _endereco = value;
    }
    public string Telefone
    {
        get => _telefone;
        set => _telefone = value;
    }
    public string Email
    {
        get => _email;
        set => _email = value;
    }
    public DateTime DataCriacao
    {
        get => _dataCriacao;
        set => _dataCriacao = value;
    }
    public EnumStatusAgencia Status
    {
        get => _status;
        set => _status = value;
    }
}
public enum EnumStatusAgencia
{
    Ativo,
    Inativo,
    Suspenso
}