using ReactiveUI;
using System.Reactive.Disposables;

namespace ReactiveUITestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<AppViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new AppViewModel();
           
            this.WhenActivated(disposableRegistration =>
            {               
                this.Bind(ViewModel,
                    viewModel => viewModel.SearchTerm,
                    view => view.searchTextBox.Text)
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}
