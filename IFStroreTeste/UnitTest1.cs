using IFStore.Domain.Entities;
using System.Text.Json;

namespace IFStroreTeste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCidade()
        {
            var cidade = new Cidade();
            var cliente = new Cliente();

            cidade.nome = "Batatais";
            cidade.estado = "SP";

            Console.WriteLine(JsonSerializer.Serialize(cidade));
            Assert.AreEqual(cidade.nome, "Batatais");
            Assert.AreEqual(cidade.estado, "SP");

        }
        [TestMethod]
        public void TestCliente() 
        {
            var cidade = new Cidade();
            var cliente = new Cliente();

            cidade.nome = "Batatais";
            cidade.estado = "SP";

            cliente.nome = "Giovanna";
            cliente.cidade = cidade;
            cliente.bairro = "Centro";
            cliente.endereco = "Rua Teste";

            Console.WriteLine(JsonSerializer.Serialize(cliente));
            Assert.AreEqual(cliente.nome, "Giovanna");
            Assert.AreEqual(cliente.cidade.nome, cidade.nome);
            Assert.AreEqual(cliente.bairro, "Centro");
            Assert.AreEqual(cliente.endereco, "Rua Teste");

        }
        [TestMethod]
        public void TesteGrupo ()
        {
            var grupo = new Grupo();
            grupo.nome = "Alimentos";

            Console.WriteLine(JsonSerializer.Serialize(grupo));
            Assert.AreEqual(grupo.nome, "Alimentos");

        }
        [TestMethod]
        public void TesteProduto ()
        {
            var produto = new Produto();
            var grupo = new Grupo();

            grupo.nome = "Alimentos";

            produto.nome = "Arroz";
            produto.unidadeVenda = "BRI";
            produto.quantidade = 2;
            produto.Grupo = grupo;

            Console.WriteLine(JsonSerializer.Serialize(produto));
            Assert.AreEqual(produto.nome, "Arroz");
            Assert.AreEqual(produto.unidadeVenda, "BRI");
            Assert.AreEqual(produto.quantidade, 2);
            Assert.AreEqual(produto.Grupo, grupo);

        }
        [TestMethod]
        public void TesteUsuario()
        {
            var usuario = new Usuario();
            usuario.email = "teste@gmail.com";
            usuario.senha = "teste";
            usuario.login = "teste";
            usuario.dataCadastro = DateTime.Today;
            usuario.ativo = true;

            Assert.AreEqual(usuario.email, "teste@gmail.com");
            Assert.AreEqual(usuario.senha, "teste");
            Assert.AreEqual(usuario.login, "teste");
            Assert.AreEqual(usuario.dataCadastro, DateTime.Today);
            Assert.AreEqual(usuario.ativo, true);


        }

        [TestMethod]
        public void TesteVendas ()
        {
            var venda = new Venda();
            var vendaItem = new VendaItem();

            var produto = new Produto();
            var grupo = new Grupo();

            var cidade = new Cidade();
            var cliente = new Cliente();

            cidade.nome = "Batatais";
            cidade.estado = "SP";

            cliente.nome = "Giovanna";
            cliente.cidade = cidade;
            cliente.bairro = "Centro";
            cliente.endereco = "Rua Teste";

            grupo.nome = "Alimentos";

            produto.nome = "Arroz";
            produto.unidadeVenda = "BRI";
            produto.quantidade = 2;
            produto.Grupo = grupo;

            venda.cliente = cliente;
            venda.data = DateTime.Today;

            Console.WriteLine(JsonSerializer.Serialize(venda));
            Assert.AreEqual(venda.cliente, cliente);
            Assert.AreEqual(venda.data, DateTime.Today);


            vendaItem.quantidade = 2;
            vendaItem.produto = produto;
            vendaItem.valorUnitario = 5;
            vendaItem.venda = venda;

            Console.WriteLine(JsonSerializer.Serialize(vendaItem));
            Assert.AreEqual(vendaItem.quantidade, 2);
            Assert.AreEqual(vendaItem.produto, produto);
            Assert.AreEqual(vendaItem.valorUnitario, 5);
            Assert.AreEqual(vendaItem.venda, venda);

            venda.items.Add(vendaItem);


            Console.WriteLine(JsonSerializer.Serialize(venda));
            Assert.AreEqual(venda.items[0].valorUnitario, vendaItem.valorUnitario);

        }

    }
}