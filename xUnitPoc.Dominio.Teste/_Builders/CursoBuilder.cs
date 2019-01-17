using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using xUnitPoc.Dominio.Enums;

namespace xUnitPoc.Dominio.Teste._Builders
{
    public class CursoBuilder
    {
        private static Faker faker = new Faker();
        private string _nome = faker.Random.Word();
        private string _descricao = faker.Lorem.Paragraph();
        private double _cargaHoraria = faker.Random.Double(50, 1000);
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valor = faker.Random.Double(100, 1000);


        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComCargaHorario(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }
    }
}
