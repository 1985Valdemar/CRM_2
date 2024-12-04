<h1 align="center"> 🚀 TURMA 1 - Treinamento K&L 💻 🛠️ </h1>

<p align="center">
  <img src="https://img.shields.io/badge/Status-Em%20Desenvolvimento-orange" alt="Status" />
  
  <img src="https://img.shields.io/badge/Versão-1.0.0-blue" alt="Versão" />
</p>

# 🛠️ Bora Juntar Ferramentas Para Desenvolvimento

## 🚀🕹️🎮 Bora Decolar No Conhecimento em C# Com Visual Studio!

## 🚀🚀 CRM -> Gestão Relacionamento com Cliente 🚀🚀


<p align="center"> <a href="https://kellab.com.br/" target="_blank">K&L</a> </p>

<p align="center">
<a href="#sobre">Sobre</a>&nbsp;&nbsp;&nbsp|&nbsp;&nbsp;&nbsp;
<a href="#tecnologia">Tecnologia</a>&nbsp;&nbsp;&nbsp|&nbsp;&nbsp;&nbsp;
<a href="#autores">Autores</a>.
</p>

---

# 📖 Sobre

## Treinamento Para Aprimorar Conhecimento
Este treinamento tem como base aprender e aprimorar conhecimento em C#.

![Captura de tela 2024-12-04 163815](https://github.com/user-attachments/assets/1050786b-8628-47b3-a976-4ec489664e6c)


![Captura de tela 2024-12-04 163719](https://github.com/user-attachments/assets/c3e7c093-ecb1-40ba-8d34-116f9359cac3)

![Captura de tela 2024-12-04 163703](https://github.com/user-attachments/assets/a5134f72-868d-45f3-a9c8-cbd1b0bb9ffc)



<p align="center">Figura-07: Imagem Testando Código.</p>

---

# 💻 Exemplo de Código

### C# Utilizando Forms, e Path para Guardar Informação

```C#

using KEL.CRM.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEL.CRM.ConsoleApp.Repositories
{
    public class PaisRepository
    {

        //INICIAR ID EM ZERO
        //_id para indicar que ficar nesta classe somente
        private static int _id = 0;

        //CRIAR VARIAVEL PARA ARMAZENAR NOME TXT
        private string _nomeArquivo = "listaPaises.txt";


        // Construtor para carregar dados do arquivo e inicializar o ID
        public PaisRepository()
        {
            if (File.Exists(_nomeArquivo))
            {
                InicializarId();
            }
        }

        // Inicializa o ID baseado no maior ID presente no arquivo
        // Método para inicializar o ID baseado no maior ID presente no arquivo
        private void InicializarId()
        {
            using (StreamReader streamReader = new StreamReader(_nomeArquivo))
            {
                string linha;
                while ((linha = streamReader.ReadLine()) != null)
                {
                    // Dividir a linha em campos
                    string[] dados = linha.Split(";");
                    int id = Convert.ToInt32(dados[0]);
                    // Atualizar o ID para garantir que seja único
                    _id = Math.Max(_id, id);
                }
            }
        }

        // Método para criar um novo cliente e salvar no arquivo
        public string Create(Pais model)
        {
            // Incrementa o ID e adiciona ao modelo
            _id++;
            model.Id = _id;

            // Salvar o cliente no arquivo de texto
            using (StreamWriter sw = new StreamWriter(_nomeArquivo, append: true))
            {
                sw.WriteLine($"{model.Id};{model.Nome};{model.Populacao};{model.Idioma}");
            }

            return $"Pais: {model.Nome} cadastrado com sucesso!";
        }

        // Método para obter todos os clientes do arquivo
        public List<Pais> GetAll()
        {
            List<Pais> listaPaises = new List<Pais>();

            // Carrega os dados do arquivo de texto
            if (File.Exists(_nomeArquivo))
            {
                using (StreamReader streamReader = new StreamReader(_nomeArquivo))
                {
                    string linha;
                    while ((linha = streamReader.ReadLine()) != null)
                    {
                        // Dividir a linha em campos
                        string[] dados = linha.Split(";");
                        Pais pais = new Pais
                        {
                            Id = Convert.ToInt32(dados[0]),
                            Nome = dados[1],
                            Populacao = Convert.ToInt32( dados[2]),
                            Idioma = dados[3]
                        };
                        listaPaises.Add(pais);
                    }
                }
            }

            return listaPaises;
        }

        // Método para obter um cliente pelo ID
        public Pais GetById(int id)
        {
            // Busca o cliente pelo ID no arquivo de texto
            if (File.Exists(_nomeArquivo))
            {
                using (StreamReader streamReader = new StreamReader(_nomeArquivo))
                {
                    string linha;
                    while ((linha = streamReader.ReadLine()) != null)
                    {
                        // Dividir a linha em campos
                        string[] dados = linha.Split(";");
                        if (Convert.ToInt32(dados[0]) == id)
                        {
                            return new Pais
                            {
                                Id = id,
                                Nome = dados[1],
                                Populacao = Convert.ToInt32(dados[2]), 
                                Idioma = dados[3]
                            };
                        }
                    }
                }
            }

            return null;
        }


    }
}


```
---

## 🛠️ Tecnologias Utilizadas

Este projeto foi desenvolvido com as seguintes tecnologias:

- **IDE**: [Visual Studio](https://visualstudio.microsoft.com/)
- **Controle de Versão**: [Git](https://git-scm.com/) e [GitHub](https://github.com/)
- **Linguagem**: [C#](https://learn.microsoft.com/dotnet/csharp/)
- **Arquitetura Base**: Models, Views, Repositories.
- **Manipulação de Arquivos**: Salvando e Recuperando TXT.
- **Gerenciamento de Projetos**: Kanban para gerenciamento do fluxo de trabalho e organização de tarefas
  
---
✍️ Autores
- Valdemar

---

Agradecemos por visitar nosso site e esperamos que você para Realizar Seu Sonho! Se tiver alguma pergunta ou feedback, não hesite em entrar em contato conosco.
