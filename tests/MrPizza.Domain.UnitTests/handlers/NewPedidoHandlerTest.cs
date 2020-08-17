using MrPizza.Domain.Commands.Pedido;
using MrPizza.Domain.Entities;
using MrPizza.Domain.Handlers.NewPedidoHandler;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MrPizza.Domain.UnitTests.handlers
{
    public class NewPedidoHandlerTest
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ISaborRepository _saborRepository;

        public NewPedidoHandlerTest()
        {
            _pedidoRepository = Substitute.For<IPedidoRepository>();
            _enderecoRepository = Substitute.For<IEnderecoRepository>();
            _saborRepository = Substitute.For<ISaborRepository>();
        }

        private async Task<GenericCommandResult> CreateRequest(EnderecoModel endereco)
        {
            var sabores = new List<Sabor>
            {
                new Sabor("Mussarela", 10),
                new Sabor("Frango", 15)
            };

            var pizzas = new List<PizzaSaborModel>
            {
                new PizzaSaborModel{ Ordem = 0, Sabores = sabores.Select(x => x.Id).ToList()}
            };

           


            var handler = new NewPedidoHandler(_pedidoRepository, _enderecoRepository, _saborRepository);
            await _enderecoRepository.Create(Arg.Any<Endereco>());
            await _pedidoRepository.Create(Arg.Any<Pedido>());
            _saborRepository.Get().ReturnsForAnyArgs(sabores);
            var request = new NewPedidoCommand(pizzas, null, endereco);
            var result = await handler.Handle(request, CancellationToken.None);
            return result;
        }

        [Fact(DisplayName = "Handler without login - OK")]
        public async Task Handler_ok()
        {
            var endereco = new EnderecoModel
            {
                Rua = "Rua teste",
                Numero = "160",
                Complemento = "2101A",
                Bairro = "Centro",
                Cep = "03040010",
                Cidade = "São Paulo",
                Estado = "SP"
            };

            var result = await CreateRequest(endereco);
            Assert.True(result.Ok);
        }

        [Fact(DisplayName = "Handler without login - rua null NOK")]
        public async Task Handler_ruanull_nok()
        {
            var endereco = new EnderecoModel
            {
                Numero = "160",
                Complemento = "2101A",
                Bairro = "Centro",
                Cep = "03040010",
                Cidade = "São Paulo",
                Estado = "SP"
            };

            var result = await CreateRequest(endereco);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}","Rua"), result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "Handler without login - numero null NOK")]
        public async Task Handler_numeronull_nok()
        {
            var endereco = new EnderecoModel
            {
                Rua = "Rua teste",
                Complemento = "2101A",
                Bairro = "Centro",
                Cep = "03040010",
                Cidade = "São Paulo",
                Estado = "SP"
            };

            var result = await CreateRequest(endereco);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "Numero"), result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "Handler without login - bairro null NOK")]
        public async Task Handler_bairronull_nok()
        {
            var endereco = new EnderecoModel
            {
                Rua = "Rua teste",
                Numero = "160",
                Complemento = "2101A",
                Cep = "03040010",
                Cidade = "São Paulo",
                Estado = "SP"
            };

            var result = await CreateRequest(endereco);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "Bairro"), result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "Handler without login - cidade null NOK")]
        public async Task Handler_cidadenull_nok()
        {
            var endereco = new EnderecoModel
            {
                Rua = "Rua teste",
                Numero = "160",
                Complemento = "2101A",
                Cep = "03040010",
                Bairro = "Centro",
                Estado = "SP"
            };

            var result = await CreateRequest(endereco);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "Cidade"), result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "Handler without login - estado null NOK")]
        public async Task Handler_estadonull_nok()
        {
            var endereco = new EnderecoModel
            {
                Rua = "Rua teste",
                Numero = "160",
                Complemento = "2101A",
                Cep = "03040010",
                Bairro = "Centro",
                Cidade = "São Paulo"
            };

            var result = await CreateRequest(endereco);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "Estado"), result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "Handler without login - cep null NOK")]
        public async Task Handler_cepnull_nok()
        {
            var endereco = new EnderecoModel
            {
                Rua = "Rua teste",
                Numero = "160",
                Complemento = "2101A",
                Bairro = "Centro",
                Cidade = "São Paulo",
                Estado = "SP"
            };

            var result = await CreateRequest(endereco);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "Cep"), result.Errors.FirstOrDefault());
        }


        [Fact(DisplayName = "Handler without login - cep maxlen NOK")]
        public async Task Handler_cepmaxlen_nok()
        {
            var endereco = new EnderecoModel
            {
                Rua = "Rua teste",
                Numero = "160",
                Complemento = "2101A",
                Bairro = "Centro",
                Cep = "0400101213",
                Cidade = "São Paulo",
                Estado = "SP"
            };

            var result = await CreateRequest(endereco);
            Assert.Equal(ErrorMessages.MaxLen.Replace("{PropertyName}", "Cep").Replace("{MaxLength}", "8"), result.Errors.FirstOrDefault());
        }

    }
}
