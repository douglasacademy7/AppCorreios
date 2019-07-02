using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AppCorreios.Servico.Modelo;
using Newtonsoft.Json;

namespace AppCorreios.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURl, cep);

            WebClient wc = new WebClient();

            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;

        }
    }
}
