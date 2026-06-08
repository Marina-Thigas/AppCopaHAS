using AppCopaHAS.Models.DTOs;
using AppCopaHAS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppCopaHAS.ViewModels
{
    public class TabelaViewModel : BaseViewModel
    {
        JogoService _jogoService;
        public ObservableCollection<JogoDTO> Jogos { get; set; }
        public TabelaViewModel()
        {
            _jogoService = new JogoService();
            Jogos = new ObservableCollection<JogoDTO>();

            _ = ObterJogos();
        }

        public async Task ObterJogos()
        {
            try
            {
                Jogos = await _jogoService.GetJogosDTOAsync();
                OnPropertyChanged(nameof(Jogos));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlertAsync("Ops", ex.Message, "Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
