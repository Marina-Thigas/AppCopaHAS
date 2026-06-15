using AppCopaHAS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppCopaHAS.Services
{
    public class JogadorService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://copaapi3ai.azurewebsites.net/Jogadores";

        public JogadorService()
        {
            _request = new Request();
        }

        public async Task<ObservableCollection<Jogador>> GetJogadoresAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");

            ObservableCollection<Jogador> lista =
                await _request.GetAsync<ObservableCollection<Jogador>>(_apiUrlBase + urlComplementar, string.Empty);

            return lista;
        }

        public async Task<Jogador> GetJogadorAsync(int id) 
        {
            string urlComplementar = $"/{id}";

            Jogador jogador = await _request.GetAsync<Jogador>(_apiUrlBase + urlComplementar, string.Empty);

            return jogador;
        }
    }
}
