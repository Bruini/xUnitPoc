using Bogus;
using ExpectedObjects;
using System;
using Xunit;
using xUnitPoc.Dominio.Enums;
using xUnitPoc.Dominio.Teste._Builders;
using xUnitPoc.Dominio.Teste._Util;

namespace xUnitPoc.Dominio.Teste.Cursos
{
    //"Eu, enquanto administrador, quero criar e editar cursos para que sejam abertas matriculas para o mesmo."

    //Critério de aceite

    //- Criar um curso com o nome, carga horária, público alvo e valor do curso.
    //- As opções para público alvo são: Estudante, Universitário, Empregado e Empreendedor.
    //- Todos os campos do curso são obrigatórios.
    //- Curso deve ter uma descrição.


    public class CursoTest
    {

        private readonly string _nome;
        private readonly string _descricao;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;


        public CursoTest()
        {
            var faker = new Faker();

            _nome = faker.Random.Word();
            _descricao = faker.Lorem.Paragraph();
            _cargaHoraria = faker.Random.Double(50, 1000);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Double(100, 1000);

        }


        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                Descricao = _descricao,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComCargaHorario(cargaHorariaInvalida).Build())
                .ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCursoTerUmValorMenorQue1(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComValor(valorInvalido).Build())
                .ComMensagem("Valor inválida");
        }
    }
}
