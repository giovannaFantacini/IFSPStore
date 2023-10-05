using IFStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace IFStroreTeste
{
    [TestClass]
    public class UnitTestRepository
    {

        public class MyDbContext : DbContext
        {
            public DbSet<Usuario> Usuario { get; set; }
            public DbSet<Cidade> Cidade { get; set; }

            public DbSet<Cliente> Cliente { get; set; }

            public DbSet<Grupo> Grupo { get; set; }
            public DbSet<Produto> Produto { get; set; }

            public DbSet<Venda> Venda { get; set; }

            public DbSet<VendaItem> VendaItem { get; set; }
            public MyDbContext() { 
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var server = "localhost";
                var port = "3306";
                var database = "IFSPStore";
                var username = "root";
                var password = "";
                var strCon = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password}";
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseMySql(strCon, ServerVersion.AutoDetect(strCon));
                }
            }

        }

        [TestMethod]
        public void TestUsuario()
        {
            using (var context = new MyDbContext())
            {
                var usuario = new Usuario();
                usuario.Email = "teste@gmail.com";
                usuario.Senha = "teste";
                usuario.Login = "teste";
                usuario.DataCadastro = DateTime.Now;
                usuario.DataLogin = DateTime.Now;
                usuario.Ativo = true;
                usuario.Nome = "Giovanna";

                context.Usuario.Add(usuario);
                context.SaveChanges();
            }

        }

        [TestMethod]
        public void TestSelectUsuario()
        {
            using (var context = new MyDbContext())
            {
                foreach (var usuario in context.Usuario)
                {
                    Console.WriteLine(JsonSerializer.Serialize(usuario));
                }
            }

        }

        [TestMethod]
        public void TestCidade()
        {
            using (var context = new MyDbContext())
            {
                var cidade = new Cidade();

                cidade.Nome = "Batatais";
                cidade.Estado = "SP";


                context.Cidade.Add(cidade);
                context.SaveChanges();
            }

        }

        [TestMethod]
        public void TestSelectCidade()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cidade in context.Cidade)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cidade));
                }
            }

        }

        [TestMethod]
        public void TestCliente()
        {
            using (var context = new MyDbContext())
            {
                var cidade = context.Cidade.First(u => u.Id == 1);
                var cliente = new Cliente();

                cliente.Nome = "Giovanna";
                cliente.Cidade = cidade;
                cliente.Bairro = "Centro";
                cliente.Endereco = "Rua Teste";


                context.Cliente.Add(cliente);
                context.SaveChanges();
            }

        }

        [TestMethod]
        public void TestSelectCliente()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cliente in context.Cliente)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cliente));
                }
            }

        }

        [TestMethod]
        public void TesteGrupo()
        {
            using (var context = new MyDbContext())
            {
                var grupo = new Grupo();
                grupo.Nome = "Alimentos";

                context.Grupo.Add(grupo);
                context.SaveChanges();

            }


        }

        [TestMethod]
        public void TestSelectGrupo()
        {
            using (var context = new MyDbContext())
            {
                foreach (var grupo in context.Grupo)
                {
                    Console.WriteLine(JsonSerializer.Serialize(grupo));
                }
            }

        }

        [TestMethod]
        public void TesteProduto()
        {
            using (var context = new MyDbContext())
            {
                var produto = new Produto();
                var grupo = context.Grupo.First(u => u.Id == 1);

                produto.Nome = "Arroz";
                produto.UnidadeVenda = "BRI";
                produto.Quantidade = 2;
                produto.Grupo = grupo;

                context.Produto.Add(produto);
                context.SaveChanges();

            }


        }

        [TestMethod]
        public void TestSelectProduto()
        {
            using (var context = new MyDbContext())
            {
                foreach (var produto in context.Produto)
                {
                    Console.WriteLine(JsonSerializer.Serialize(produto));
                }
            }

        }

        [TestMethod]
        public void TesteVendas()
        {
            using (var context = new MyDbContext())
            {
                var venda = new Venda();
                var vendaItem = new VendaItem();

                var produto = context.Produto.First(u => u.Id == 1);

                var grupo = context.Grupo.First(u => u.Id == 1);

                var cidade = context.Cidade.First(u => u.Id == 1);

                var cliente = context.Cliente.First(u => u.Id == 1);

                var usuario = context.Usuario.First(u => u.Id == 1);


                venda.Usuario = usuario;
                venda.Cliente = cliente;
                venda.Data = DateTime.Today;

                context.Venda.Add(venda);
                context.SaveChanges();

                venda = context.Venda.First(u => u.Id == 1);

                vendaItem.Quantidade = 2;
                vendaItem.Produto = produto;
                vendaItem.ValorUnitario = 5;
                vendaItem.Venda = venda;

                context.VendaItem.Add(vendaItem);
                context.SaveChanges();

            }


        }

        [TestMethod]
        public void TestSelectVendas()
        {
            using (var context = new MyDbContext())
            {
                foreach (var venda in context.Venda)
                {
                    Console.WriteLine(JsonSerializer.Serialize(venda));
                }
            }

        }

        [TestMethod]
        public void TestSelectVendasItems()
        {
            using (var context = new MyDbContext())
            {
                foreach (var venda in context.VendaItem)
                {
                    Console.WriteLine(JsonSerializer.Serialize(venda));
                }
            }

        }


    }
}