using AppCopaHAS.ViewModels;

namespace AppCopaHAS.Views.Jogos;

public partial class TabelaView : ContentPage
{
	TabelaViewModel viewModel;
	public TabelaView()
	{
		InitializeComponent();

		viewModel = new TabelaViewModel();
		BindingContext = viewModel;
		Title = "Tabela";
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		_ = viewModel.ObterJogos();
    }
}