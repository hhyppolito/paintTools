# paintTools

Ferramenta Revit para aplicar um material de pintura a faces selecionadas pela lógica de cofragem, permitindo apoiar a identificação e medição dessas superfícies.

## Estado do projeto

Implementação com formulário e projeto de instalador; execução não validada nesta revisão.

O nome do material tem de corresponder ao do documento. O projeto usa internamente o nome `Cofragem`, incluindo a DLL; não instalar por cima de outra ferramenta com esse mesmo nome. A depuração aponta para 2022 e as referências para 2023. A seleção automática de faces não equivale a uma medição de cofragem validada.

## Requisitos e preparação

- Windows, Autodesk Revit e as bibliotecas da API correspondentes à versão de compilação.
- Visual Studio com ferramentas de desenvolvimento .NET e targeting pack do **.NET Framework 4.8**.
- As referências atuais de [Cofragem/Cofragem.csproj](Cofragem/Cofragem.csproj) apontam para **Revit 2023**. Isto descreve a configuração existente, não uma certificação de compatibilidade com esta ou outras versões.

1. Clonar o repositório e abrir [Cofragem.sln](Cofragem.sln).
2. Conferir os caminhos de `RevitAPI.dll` e `RevitAPIUI.dll`, a versão de depuração e os eventos de compilação/limpeza. Alguns eventos copiam ou removem ficheiros na pasta de add-ins do utilizador.
3. Resolver as limitações de compilação/manifesto indicadas acima antes de tentar instalar. Compilar numa configuração de teste.
4. Conferir [Cofragem/Cofragem.addin](Cofragem/Cofragem.addin): a assembly e as classes devem coincidir com o projeto. Para um ensaio manual, colocar o manifesto em `%AppData%\\Autodesk\\Revit\\Addins\\2023` e apontar a assembly para a DLL compilada; incluir os recursos usados por `App.cs`.
5. Reiniciar o Revit e utilizar uma cópia de modelo descartável para a primeira execução.

## Funcionamento

Selecionar paredes, lajes, vigas, pilares ou fundações; executar o comando; indicar no formulário o nome do material existente no modelo. `PaintFace` procura esse nome exato e aplica-o às faces escolhidas pela lógica de cada categoria.

## Organização do código

- [Cofragem/Command.cs](Cofragem/Command.cs): ponto de entrada e fluxo do comando.
- [Cofragem/Cofragem.csproj](Cofragem/Cofragem.csproj): referências, assembly e configuração de compilação.
- [Cofragem/Cofragem.addin](Cofragem/Cofragem.addin): registo do complemento no Revit.

Ficheiros de apoio: [Cof_Paint/Cof_Paint.vdproj](Cof_Paint/Cof_Paint.vdproj), [Cofragem/Cofragem.cs](Cofragem/Cofragem.cs), [Cofragem/Form1.cs](Cofragem/Form1.cs), [Cofragem/PaintFace.cs](Cofragem/PaintFace.cs).

## Verificação

Comparar as faces pintadas com uma seleção manual para cada categoria, incluindo superfícies inclinadas e encontros entre elementos. Confirmar o tratamento de material inexistente e cancelamento.

Este README resulta da leitura do código em 11/11/2026; não foram executados build nem ensaios dentro do Revit. Não foi identificada uma suite de testes automatizados na árvore inspecionada. Quando há quantidades ou geometria de engenharia, verificar o funcionamento do software é distinto de validar as hipóteses e os resultados técnicos.
