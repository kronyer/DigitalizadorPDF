# Digitalizador

<strong>Atualmente não está funcionando, o commit working funciona. Preciso fazer debug no computador do meu avô pois o meu nao tem scanner</strong>


Esse é um projeto feito para facilitar a vida do meu avô, que possui uma HP Photosmart da série 4600 que perdeu seu hub de digitalização com o fim do Flash Player.

A imagem é adquirida utilizando o WIA, armazenada temporariamente em .jpg e logo após convertida em .pdf e salva no local escolhido pelo usuário.

![image](https://github.com/kronyer/DigitalizadorPDF/assets/152650887/91cc8364-7426-4169-8688-2731c728c358)


## Sobre o funcionamento do projeto
- É verificado a existencia de scanners no inicio da aplicação e as opções disponíveis são adicionadas ao dropdown de escolha
- Há uma ImageBox em formato a4 para o preview do que foi digitalizado
- Ao clicar em digitalizar é feita novamente uma verificação dos scanners e é selecionado aquele que bate com o nom escolhido no dropdown e cria-se a conexão
- É criado uma ImageFile temporária no formato Jpeg e essa imagem é mostrada no PictureBox mencionado anteriormente
- É aberto um Dialog para escolher o caminho onde será salvado o arquivo
- Por fim o arquivo a ser salvo é convertido em PDF usando o PdfSharp
- Para melhor usabilidade existe um botão para abrir a pasta onde foi salvo o arquivo

## Sobre o funcionamento do WIA

## Sobre o funcionamento do Pdf Sharp

## Sobre o instalador
- Para facilitar as coisas, ao testar no computador do meu avô fui obrigado a baixar a pasta toda bagunçada do drive e ainda instalar o .Net SDK, por isso procurei sobre um instalador
- Com as configurações basicas feitas no instalador, basta fazer um Build no "DigitalizadorSetup"
- O instalador vai suprir as necessidades do .Net SDK, instalar no disco local e criar um atalho na Área de Trabalho

## Sobre a interface
- Botão para digitalizar
- Dropdown para selecionar o scanner
- ImageBox para preview do arquivo digitalizado
- Label que mostra o caminho do arquivo que foi salvo
- Botão para abrir a pasta onde o arquivo foi salvo

## Coisas para acrescentar
- Uma loading bar

