using AppCopaHAS.Models;
using AppCopaHAS.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppCopaHAS.Services
{
    public class JogoService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://copaapi3ai.azurewebsites.net/Jogos";
        public JogoService()
        {
            _request = new Request();
        }
        public async Task<ObservableCollection<Jogo>> GetJogosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Jogo> lista =
                await _request.GetAsync<ObservableCollection<Jogo>>(_apiUrlBase + urlComplementar, string.Empty);
            return lista;
        }
        public async Task<Jogo> PostJogoAsync(Jogo j)
        {
            Jogo jogoInserido = await _request.PostAsync<Jogo>(_apiUrlBase, j, string.Empty);
            return jogoInserido;
        }

        public async Task<ObservableCollection<JogoDTO>> GetJogosDTOAsync()
        {
            string urlComplementar = string.Format("{0}", "/ObterTabela");

            ObservableCollection<JogoDTO> lista =
                await _request.GetAsync<ObservableCollection<JogoDTO>>(_apiUrlBase + urlComplementar, string.Empty);

            return lista;
        }
    }
}
