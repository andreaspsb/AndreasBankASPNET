using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AndreasBank.Models;

public class Agencia
{
    // Padronização dos campos privados para camelCase
    private string? numeroAgencia = string.Empty;
    private string? nomeAgencia = string.Empty;
    private string? enderecoAgencia = string.Empty;
    private string? telefoneAgencia = string.Empty;
    private string? emailAgencia = string.Empty;
    private DateTime dataCriacaoAgencia = DateTime.Now;
    private EnumStatusAgencia statusAgenciaEnum = EnumStatusAgencia.Ativo;

    // Construtor público sem parâmetros para o Entity Framework
    public Agencia() { }

    // Construtor simplificado
    public Agencia(string numero, string nome, string endereco, string telefone, string email)
    {
        numeroAgencia = numero;
        nomeAgencia = nome;
        enderecoAgencia = endereco;
        telefoneAgencia = telefone;
        emailAgencia = email;
    }

    [Key]
    [Required]
    [StringLength(4, MinimumLength = 4, ErrorMessage = "O número da agência deve ter exatamente 4 dígitos.")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "O número da agência deve conter apenas dígitos.")]
    public string? Numero
    {
        get => numeroAgencia;
        set => numeroAgencia = value;
    }

    [Required]
    [StringLength(100)]
    public string? Nome
    {
        get => nomeAgencia;
        set => nomeAgencia = value;
    }

    [Required]
    [StringLength(200)]
    public string? Endereco
    {
        get => enderecoAgencia;
        set => enderecoAgencia = value;
    }

    [Required]
    [StringLength(20)]
    public string? Telefone
    {
        get => telefoneAgencia;
        set => telefoneAgencia = value;
    }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string? Email
    {
        get => emailAgencia;
        set => emailAgencia = value;
    }
    public DateTime DataCriacao
    {
        get => dataCriacaoAgencia;
        set => dataCriacaoAgencia = value;
    }
    public EnumStatusAgencia Status
    {
        get => statusAgenciaEnum;
        set => statusAgenciaEnum = value;
    }

    // Propriedade de navegação para contas vinculadas à agência
    public virtual ICollection<Conta> Contas { get; set; } = new List<Conta>();
}
public enum EnumStatusAgencia
{
    Ativo,
    Inativo,
    Suspenso
}