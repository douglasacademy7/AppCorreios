using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppCorreios.Servico.Modelo;
using AppCorreios.Servico;
namespace AppCorreios
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {

                        RESULTADO.Text = string.Format("Endereço: {2} de {3}, {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        string infCEP = string.Format("O endereço não foi encontrado pelo CEP informado: {0}", cep);

                        DisplayAlert("ERRO", infCEP, "OK");

                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");

                }
            }

        }

        private bool isValidCEP(string cep)
        {

            bool valido = true;
            if (cep.Length != 8)
            {
                //erro
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 carecteres.", "OK");

                valido = false;
            }
            int NovoCEp = 0;
            if (!int.TryParse(cep, out NovoCEp))
            {
                //erro
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve ser composto apenas por números.", "OK");

                valido = false;
            }
            return valido;
        }
    }
}
