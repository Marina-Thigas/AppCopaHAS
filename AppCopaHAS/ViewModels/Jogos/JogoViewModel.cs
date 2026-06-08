using AppCopaHAS.Models;
using AppCopaHAS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace AppCopaHAS.ViewModels.Jogos
{
    public class JogoViewModel : BaseViewModel
    {
        private EstadioService _estadioService;
        private SelecaoService _selecaoService;
        private JogoService _jogoService;

        public ObservableCollection<Estadio> Estadios { get; set; }
        public ObservableCollection<Selecao> Selecoes { get; set; }
        public ObservableCollection<Jogo> Jogos { get; set; }
        public ICommand SalvarCommand { get; set; }
        public JogoViewModel()
        {
            _estadioService = new EstadioService();
            _selecaoService = new SelecaoService();
            _jogoService = new JogoService();

            Estadios = new ObservableCollection<Estadio>();
            Selecoes = new ObservableCollection<Selecao>();
            Jogos = new ObservableCollection<Jogo>();

            _ = ObterEstadios();
            _ = ObterSelecoes();

            SalvarCommand = new Command(async () => { await SalvarResultado(); });
        }   

        private Estadio estadioSelecionado;
        public Estadio EstadioSelecionado
        {
            get => estadioSelecionado;
            set
            {
                if (value != null)
                {
                    estadioSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }


        private DateTime _dataSelecionada = DateTime.Today;
        public DateTime DataSelecionada { 
            get => _dataSelecionada;
            set
            {
                if (_dataSelecionada != value)
                {
                    _dataSelecionada = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DataHora));
                }
            }
        }

        private TimeSpan _horaSelecionada = DateTime.Now.TimeOfDay;
        public TimeSpan HoraSelecionada { 
            get => _horaSelecionada;
            set
            {
                if (_horaSelecionada != value)
                {
                    _horaSelecionada = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DataHora));
                }
            }
        }

        private DateTime DataHora
        {
            get => DataSelecionada.Date + HoraSelecionada;
        }

        private Selecao selecao1;
        public Selecao Selecao1 { get => selecao1;
            set
            {
                if (value != null)
                {
                    selecao1 = value;
                    OnPropertyChanged();
                }
            }
        }
        

        private Selecao selecao2;
        public Selecao Selecao2 { 
            get => selecao2;
            set
            {
                if (value != null)
                {
                   selecao2 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int golsSelecao1 = 0;
        public int GolsSelecao1
        {
            get => golsSelecao1;
            set
            {
                if (value != 0)
                {
                    golsSelecao1 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int golsSelecao2 = 0;
        public int GolsSelecao2 { 
            get => golsSelecao2; 
            set 
            {
                if (value != 0)
                {
                    golsSelecao2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task ObterEstadios()
        {
            try
            {
                Estadios = await _estadioService.GetEstadiosAsync();
                OnPropertyChanged(nameof(Estadios));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlertAsync("Ops", ex.Message, "Detalhes" + ex.InnerException, "Ok");     
            }
        }
        public async Task ObterSelecoes()
        {
            try
            {
                Selecoes = await _selecaoService.GetSelecoesAsync();
                OnPropertyChanged(nameof(Selecoes));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlertAsync("Ops", ex.Message, "Detalhes" + ex.InnerException, "Ok");
            }
        }

        public async Task SalvarResultado()
        {
            try
            {
                Jogo j = new Jogo();
                j.EstadioId = estadioSelecionado.Id;
                j.DataHora = DataHora;

                JogoSelecao mandante = new JogoSelecao();
                mandante.SelecaoId = selecao1.Id;
                mandante.Gols = golsSelecao1;

                JogoSelecao visitante = new JogoSelecao();
                visitante.SelecaoId= selecao2.Id;
                visitante.Gols = golsSelecao2;

                j.JogoSelecoes.Add(mandante);
                j.JogoSelecoes.Add(visitante);

                if (j.Id == 0)
                {
                    Jogo jogoRetorno = await _jogoService.PostJogoAsync(j);

                    await Application.Current.MainPage.DisplayAlertAsync("Mensagem", "Dados salvos com sucesso!", "Ok");
                }
                await Shell.Current.GoToAsync("//tabela");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlertAsync("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
