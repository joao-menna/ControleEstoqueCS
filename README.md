# ControleEstoqueCS
Aluno: João Miguel de Castro Menna

Professor: Paulo Rogério Pires Manseira

Controle de estoque, fase 3, n2 de testes de software

## Introdução

Esse sistema de controle de estoque básico possui 66 testes.

Foram usados alguns conceitos não ensinados na aula, então desculpa se
algo não condiz. Pode estar implementado diferentemente, mas tudo funciona.

## Conceitos utilizados não ensinados em aula

- Sufixos de número para forçar tipo: existem sufixos para forçar o tipo
de um número, como "f" para float, "d" para double e "l" para long, é estranho
de primeira vista, mas funciona. Isso é bem usado no mundo do Unity, visto que
ele trabalha apenas com floats.

```c#
var meuInt = 1;
var meuFloat = 1.0f;
var meuDouble = 1.0d;
var meuLong = 1.0l;
```

- Short-hand syntax para criar objetos anonimos: quando a propriedade possui
o mesmo nome da propriedade que está recebendo, ela pode ser encurtada, por exemplo:

```c#
var movimentoEsperado = new
{
	Codigo = movimento.Codigo,
	// vira
	movimento.Codigo
}.ToExpectedObject();
```

- Classe Random para randomizar booleans e enums: foi usado a classe Random,
para randomizar booleans e enums.

```c#
// Gerar cliente ou fornecedor aleatorio
var hasFornecedor = random.NextDouble() >= 0.5d;
_fornecedor = hasFornecedor ? faker.Person.FullName : null;
_cliente = !hasFornecedor ? faker.Person.FullName : null;

// Selecionar FornecedorTransacaoType aleatorio
Array values = Enum.GetValues(typeof(FornecedorTransacaoType));
FornecedorTransacaoType randomTransacaoType =
    (FornecedorTransacaoType)values.GetValue(random.Next(values.Length))!;
```

- Namespaces: Usei namespaces diferentes para referenciar a coisas diferentes
