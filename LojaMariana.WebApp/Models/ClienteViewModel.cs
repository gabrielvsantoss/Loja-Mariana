using LojaMariana.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaMariana.WebApp.Models
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
    }

    public class ClienteIndexViewModel
    {
        public List<ClienteViewModel> Clientes { get; set; } = new List<ClienteViewModel>();
    }

    public class CadastrarClienteViewModel
    {
        [Required] public string Nome { get; set; }
        [Required] public string Telefone { get; set; }
        [Required] public string Endereco { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
    }

    public class EditarClienteViewModel
    {
        public Guid Id { get; set; }
        [Required] public string Nome { get; set; }
        [Required] public string Telefone { get; set; }
        [Required] public string Endereco { get; set; }
        [Required, EmailAddress] public string Email { get; set; }

        public EditarClienteViewModel() { }

        public EditarClienteViewModel(Guid id, string nome, string telefone, string endereco, string email)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Email = email;
        }
    }

    public class ExcluirClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ExcluirClienteViewModel() { }
        public ExcluirClienteViewModel(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
