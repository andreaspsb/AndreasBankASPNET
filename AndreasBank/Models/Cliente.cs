using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AndreasBank.Models;

public class Cliente
{
    // Padronização dos campos privados para camelCase
    private string? cpfCliente = string.Empty;
    private string? nomeCliente = string.Empty;
    private string? emailCliente = string.Empty;
    private DateTime dataNascimentoCliente = DateTime.Now;

    [Key]
    [Required]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
    public string? CPF
    {
        get => cpfCliente;
        set => cpfCliente = value;
    }

    [Required]
    [StringLength(100)]
    public string? Nome
    {
        get => nomeCliente;
        set => nomeCliente = value;
    }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string? Email
    {
        get => emailCliente;
        set => emailCliente = value;
    }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataNascimento
    {
        get => dataNascimentoCliente;
        set => dataNascimentoCliente = value;
    }

    // Propriedade de navegação para as contas do cliente
    public virtual ICollection<Conta> Contas { get; set; } = new List<Conta>();

    // Construtor público sem parâmetros para o Entity Framework
    public Cliente() { }    

    public Cliente(string cpf, string nome, string email, DateTime dataNascimento)
    {
        cpfCliente = cpf;
        nomeCliente = nome;
        emailCliente = email;
        dataNascimentoCliente = dataNascimento;
    }
}