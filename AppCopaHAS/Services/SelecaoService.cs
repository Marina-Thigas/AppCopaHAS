using AppCopaHAS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppCopaHAS.Services
{
    public class SelecaoService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://copaapi3ai.azurewebsites.net/Selecoes";
        public SelecaoService()
        {
            _request = new Request();
        }
        public async Task<ObservableCollection<Selecao>> GetSelecoesAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Selecao> lista =
                await _request.GetAsync<ObservableCollection<Selecao>>(_apiUrlBase + urlComplementar, string.Empty);
            return lista;
        }
    }
}