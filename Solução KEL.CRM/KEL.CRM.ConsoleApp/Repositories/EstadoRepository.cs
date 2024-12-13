using KEL.CRM.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KEL.CRM.ConsoleApp.Repositories
{
    public class EstadoRepository
    {
        //****** Inicializa ID único para os estados ******
        private static int _id = 0;

        //****** Nome do arquivo para armazenar os estados ******
        private string _nomeArquivo = "listaEstados.txt";

        //****** Construtor para carregar dados do arquivo e inicializar o ID ******
        public EstadoRepository()
        {
            if (File.Exists(_nomeArquivo))
            {
                InicializarId(); //****** Inicializa o ID se o arquivo já existe ******
            }
        }

        //****** Inicializa o ID baseado no maior ID presente no arquivo ******
        private void InicializarId()
        {
            using (StreamReader streamReader = new StreamReader(_nomeArquivo))
            {
                string linha;
                while ((linha = streamReader.ReadLine()) != null)
                {
                    string[] dados = linha.Split(";");
                    int id = Convert.ToInt32(dados[0]);
                    _id = Math.Max(_id, id); //****** Atualiza o ID para o maior ID encontrado ******
                }
            }
        }

        //****** CREATE: Salva um novo estado no arquivo ******
        public string Create(Estado model)
        {
            _id++; //****** Incrementa o ID para garantir um novo ID único ******
            model.Id = _id;

            using (StreamWriter sw = new StreamWriter(_nomeArquivo, append: true))
            {
                //****** Salva o estado no arquivo com os dados separados por ponto e vírgula ******
                sw.WriteLine(model.ToString());
            }

            return $"Estado: {model.Nome} cadastrado com sucesso!";
        }

        //****** READ ALL: Retorna todos os estados do arquivo ******
        public List<Estado> ReadAll()
        {
            List<Estado> listaEstados = new List<Estado>();

            if (File.Exists(_nomeArquivo))
            {
                using (StreamReader streamReader = new StreamReader(_nomeArquivo))
                {
                    string linha;
                    while ((linha = streamReader.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(";");
                        Estado estado = new Estado
                        {
                            Id = Convert.ToInt32(dados[0]),
                            Nome = dados[1],
                            Sigla = dados[2],
                            Populacao = Convert.ToInt32(dados[3]),
                            Pais = new Pais { Id = Convert.ToInt32(dados[4]) } //****** Salva apenas o ID do País ******
                        };
                        listaEstados.Add(estado); //****** Adiciona o estado à lista ******
                    }
                }
            }

            return listaEstados;
        }

        //****** READ BY ID: Busca um estado pelo ID ******
        public Estado ReadById(int id)
        {
            //****** CRIADO OBJETO PARA INICIAR EM NULL ******
            Estado estado = null;

            if (File.Exists(_nomeArquivo))
            {
                using (StreamReader streamReader = new StreamReader(_nomeArquivo))
                {
                    string linha;
                    while ((linha = streamReader.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(";");
                        if (Convert.ToInt32(dados[0]) == id)
                        {
                            //****** VAI ATRIBUIR dados AO OBJETO estado ******
                            estado = new Estado
                            {
                                Id = id,
                                Nome = dados[1],
                                Sigla = dados[2],
                                Populacao = Convert.ToInt32(dados[3]),
                                Pais = new Pais { Id = Convert.ToInt32(dados[4]) } //****** Salva o ID do País ******
                            };
                            return estado;
                        }
                    }
                }
            }

            return estado; //****** Retorna OBJETO estado CASO NULL ******
        }

        //****** UPDATE: Atualiza um estado existente ******
        public string Update(Estado model)
        {
            List<Estado> estados = ReadAll(); //****** Lê todos os estados ******
            var estadoExistente = estados.FirstOrDefault(e => e.Id == model.Id); //****** Encontra o estado pelo ID ******

            if (estadoExistente != null)
            {
                //****** Atualiza os dados do estado existente ******
                estadoExistente.Nome = model.Nome;
                estadoExistente.Sigla = model.Sigla;
                estadoExistente.Populacao = model.Populacao;
                estadoExistente.Pais = model.Pais;

                SalvarLista(estados); //****** Salva a lista atualizada no arquivo ******
                return $"Estado {model.Nome} atualizado com sucesso!";
            }

            return "Estado não encontrado!";
        }

        //****** DELETE: Remove um estado pelo ID ******
        public string Delete(int id)
        {
            List<Estado> estados = ReadAll(); //****** Lê todos os estados ******
            var estado = estados.FirstOrDefault(e => e.Id == id); //****** Encontra o estado pelo ID ******

            if (estado != null)
            {
                estados.Remove(estado); //****** Remove o estado da lista ******
                SalvarLista(estados); //****** Salva a lista atualizada no arquivo ******
                return $"Estado {estado.Nome} removido com sucesso!";
            }

            return "Estado não encontrado!";
        }

        //****** READ BY PAIS: Busca estados por ID do país ******
        public List<Estado> ReadByPais(int paisId)
        {
            return ReadAll().Where(e => e.Pais.Id == paisId).ToList(); //****** Filtra os estados pelo ID do país ******
        }

        //****** Método auxiliar para salvar a lista de estados no arquivo ******
        private void SalvarLista(List<Estado> estados)
        {
            using (StreamWriter sw = new StreamWriter(_nomeArquivo, append: false))
            {
                //****** Escreve cada estado no arquivo ******
                foreach (var estado in estados)
                {
                    sw.WriteLine($"{estado.Id};{estado.Nome};{estado.Sigla};{estado.Populacao};{estado.Pais.Id}");
                }
            }
        }
    }
}
