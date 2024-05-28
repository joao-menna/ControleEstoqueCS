namespace Dominio
{
    public class Cliente
    {
        // campos
        private int codigo;
        private string nome;
        private string endereco;
        private string telefone;
        private string cpf;
        private string email;
        private string rg;

        // propriedades
        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Email { get => email; set => email = value; }
        public string Rg { get => rg; set => rg = value; }

        public Cliente(int codigo, string nome, string endereco, string telefone, string cpf, string email, string rg)
        {
            if (codigo < 1) throw new ArgumentException("Código inválido");
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome inválido");
            if (string.IsNullOrEmpty(endereco)) throw new ArgumentException("Endereço inválido");
            if (string.IsNullOrEmpty(telefone)) throw new ArgumentException("Telefone inválido");
            if (string.IsNullOrEmpty(rg)) throw new ArgumentException("Telefone inválido");
            if (string.IsNullOrEmpty(cpf) || !CPFvalido(cpf)) throw new ArgumentException("CPF inválido");
            if (!string.IsNullOrEmpty(email) && !EmailValido(email)) throw new ArgumentException("Email inválido");

            this.codigo = codigo;
            this.nome = nome;
            this.endereco = endereco;
            this.telefone = telefone;
            this.cpf = cpf;
            this.email = email;
            this.rg = rg;
        }



        public bool EmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        public bool CPFvalido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }



    }
}