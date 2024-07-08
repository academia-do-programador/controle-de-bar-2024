﻿using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloConta;
namespace ControleDeBar.Dominio.ModuloMesa
{
    public class Mesa() : EntidadeBase
    {
        public decimal Numero { get; set; }
        public Conta Conta { get; set; }

        public Mesa(decimal numero, Conta conta) : this()
        {
            Numero = numero;
            Conta = conta;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Mesa atualizado = (Mesa)novoRegistro;

            Numero = atualizado.Numero;
            Conta = atualizado.Conta;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];

            VerificaNulo(ref erros, Numero, "Número da mesa");
            //VerificaNulo(ref erros, Conta, "Conta");

            return erros;
        }
        public override string ToString() => $"Mesa nº {Numero}";
    }
}

