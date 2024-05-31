# ConvertTStoMp4

ConvertTStoMp4 é uma aplicação de desktop simples desenvolvida em Windows Forms para converter arquivos .ts para .mp4 usando a biblioteca Xabe.FFmpeg em C#. Esta aplicação é útil para converter vídeos gravados em formato .ts (Transport Stream) para o formato .mp4, que é mais comumente suportado em reprodutores de vídeo e plataformas de compartilhamento de vídeo.

## Funcionalidades

- **Seleção de Arquivos**: A aplicação permite ao usuário selecionar uma pasta contendo arquivos .ts para conversão.
  
- **Seleção de Pasta de Saída**: O usuário pode escolher a pasta onde deseja salvar os arquivos convertidos.

- **Velocidade de Conversão Customizável**: A velocidade de conversão pode ser ajustada pelo usuário, com opções que vão desde "Medium" até "UltraFast".

- **Conversão Assíncrona**: A conversão dos arquivos é realizada de forma assíncrona para evitar bloqueios na interface do usuário.

- **Feedback Visual**: Durante o processo de conversão, o usuário recebe feedback visual na forma de uma barra de progresso e mensagens de status.

## Pré-requisitos

- **Plataforma**: Windows
- **.NET Core SDK**: Versão 3.1 ou superior

## Como Usar

1. **Clonar o Repositório**: Clone este repositório em sua máquina local.

2. **Instalar Dependências**: Abra o projeto em sua IDE de preferência e restaure as dependências do NuGet.

3. **Compilar e Executar**: Compile e execute o projeto. A aplicação será aberta e estará pronta para uso.

4. **Selecionar Arquivos**: Clique no botão "Selecionar Arquivos" para abrir uma janela de seleção de pasta. Selecione a pasta que contém os arquivos .ts que deseja converter.

5. **Selecionar Pasta de Saída**: Clique no botão "Selecionar Pasta de Saída" para escolher a pasta onde deseja salvar os arquivos convertidos.

6. **Selecionar Velocidade de Conversão**: Escolha a velocidade de conversão desejada no menu suspenso.

7. **Converter os Arquivos**: Clique no botão "Converter" para iniciar o processo de conversão. O progresso da conversão será exibido na barra de progresso e o status atual será exibido abaixo.

## Nota

- Certifique-se de que os arquivos .ts que você deseja converter estão localizados na pasta selecionada.
- Os arquivos convertidos serão salvos na pasta de saída com a mesma estrutura de nome de arquivo, mas com a extensão .mp4.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
