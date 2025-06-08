
using System;
using System.ComponentModel.DataAnnotations;

namespace AndreasBank.Models;

public class Cliente
{
    private string _nome;
    private string _cpf;
    private string _email;
    private string _telefone;
    private string _endereco;
    private DateTime _dataNascimento;
    private DateTime _dataCadastro;
    private EnumStatusCliente _status;

    public enum EnumStatusCliente
    {
        Ativo,
        Inativo,
        Bloqueado
    }

    // Construtor público sem parâmetros para o Entity Framework
    public Cliente() { }

    public Cliente(string nome, string cpf, string email, string telefone, string endereco, DateTime dataNascimento)
    {
        _nome = nome;
        _cpf = cpf;
        _email = email;
        _telefone = telefone;
        _endereco = endereco;
        _dataNascimento = dataNascimento;
        _dataCadastro = DateTime.Now;
        _status = EnumStatusCliente.Ativo; // Default status
    }

    public string Nome
    {
        get => _nome;
        set => _nome = value;
    }

    [Key]
    public string Cpf
    {
        get => _cpf;
        set => _cpf = value;
    }
    public string Email
    {
        get => _email;
        set => _email = value;
    }
    public string Telefone
    {
        get => _telefone;
        set => _telefone = value;
    }
    public string Endereco
    {
        get => _endereco;
        set => _endereco = value;
    }
    public DateTime DataNascimento
    {
        get => _dataNascimento;
        set => _dataNascimento = value;
    }
    public DateTime DataCadastro
    {
        get => _dataCadastro;
        set => _dataCadastro = value;
    }
    public EnumStatusCliente Status
    {
        get => _status;
        set => _status = value;
    }
}