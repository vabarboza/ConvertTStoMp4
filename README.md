# ConvertTStoMp4

ConvertTStoMp4 � uma aplica��o de desktop simples desenvolvida em Windows Forms para converter arquivos .ts para .mp4 usando a biblioteca Xabe.FFmpeg em C#. Esta aplica��o � �til para converter v�deos gravados em formato .ts (Transport Stream) para o formato .mp4, que � mais comumente suportado em reprodutores de v�deo e plataformas de compartilhamento de v�deo.

## Funcionalidades

- **Sele��o de Arquivos**: A aplica��o permite ao usu�rio selecionar uma pasta contendo arquivos .ts para convers�o.
  
- **Sele��o de Pasta de Sa�da**: O usu�rio pode escolher a pasta onde deseja salvar os arquivos convertidos.

- **Velocidade de Convers�o Customiz�vel**: A velocidade de convers�o pode ser ajustada pelo usu�rio, com op��es que v�o desde "Medium" at� "UltraFast".

- **Convers�o Ass�ncrona**: A convers�o dos arquivos � realizada de forma ass�ncrona para evitar bloqueios na interface do usu�rio.

- **Feedback Visual**: Durante o processo de convers�o, o usu�rio recebe feedback visual na forma de uma barra de progresso e mensagens de status.

## Pr�-requisitos

- **Plataforma**: Windows
- **.NET Core SDK**: Vers�o 3.1 ou superior

## Como Usar

1. **Clonar o Reposit�rio**: Clone este reposit�rio em sua m�quina local.

2. **Instalar Depend�ncias**: Abra o projeto em sua IDE de prefer�ncia e restaure as depend�ncias do NuGet.

3. **Compilar e Executar**: Compile e execute o projeto. A aplica��o ser� aberta e estar� pronta para uso.

4. **Selecionar Arquivos**: Clique no bot�o "Selecionar Arquivos" para abrir uma janela de sele��o de pasta. Selecione a pasta que cont�m os arquivos .ts que deseja converter.

5. **Selecionar Pasta de Sa�da**: Clique no bot�o "Selecionar Pasta de Sa�da" para escolher a pasta onde deseja salvar os arquivos convertidos.

6. **Selecionar Velocidade de Convers�o**: Escolha a velocidade de convers�o desejada no menu suspenso.

7. **Converter os Arquivos**: Clique no bot�o "Converter" para iniciar o processo de convers�o. O progresso da convers�o ser� exibido na barra de progresso e o status atual ser� exibido abaixo.

## Nota

- Certifique-se de que os arquivos .ts que voc� deseja converter est�o localizados na pasta selecionada.
- Os arquivos convertidos ser�o salvos na pasta de sa�da com a mesma estrutura de nome de arquivo, mas com a extens�o .mp4.

## Licen�a

Este projeto est� licenciado sob a [MIT License](LICENSE).
