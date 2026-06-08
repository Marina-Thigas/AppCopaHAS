using AppCopaHAS.Views.Jogos;

namespace AppCopaHAS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("tabela", typeof(TabelaView));
        }
    }
}
