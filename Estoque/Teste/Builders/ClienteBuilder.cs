using Bogus;
using Bogus.Extensions.Brazil;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Builders
{
    public class ClienteBuilder
    {
        // campos
        private int codigo;
        private string nome;
        private string endereco;
        private string telefone;
        private string cpf;
        private string email;
        private string rg;

        private ClienteBuilder()
        {
            Faker faker = new();
            codigo = faker.Random.Int(1, 10000);
            nome = faker.Person.FullName;
            endereco = faker.Address.StreetName();
            telefone = faker.Person.Phone;
            cpf = faker.Person.Cpf();
            email = faker.Person.Email;
            rg = faker.Random.Int(100_000, 999_999).ToString();
        }

        public static ClienteBuilder Novo()
        {
            return new ClienteBuilder();
        }


        public Cliente Criar()
        {
            return new Cliente(
                codigo,
                nome,
                endereco,
                telefone,
                cpf,
                email,
                rg);
        }


        public ClienteBuilder ComCodigo(int cod)
        {
            codigo = cod;
            return this;
        }


        public ClienteBuilder ComNome(string nom)
        {
            nome = nom;
            return this;
        }


        public ClienteBuilder ComEndereco(string end)
        {
            endereco = end;
            return this;
        }

        public ClienteBuilder ComTelefone(string fon)
        {
            telefone = fon;
            return this;
        }

        public ClienteBuilder ComCPF(string cpf)
        {
            this.cpf = cpf;
            return this;
        }

        public ClienteBuilder ComEmail(string eml)
        {
            email = eml;
            return this;
        }

        public ClienteBuilder ComRg(string rg)
        {
            this.rg = rg;
            return this;
        }

    }
}
