using AppCopaHAS.ViewModels.Jogos;

namespace AppCopaHAS.Views.Jogos;

public partial class CadastroJogoView : ContentPage
{
	JogoViewModel viewModel;
	public CadastroJogoView()
	{
        InitializeComponent();
		viewModel = new JogoViewModel();
		BindingContext = viewModel;
		Title = "Jogos";
	}
}