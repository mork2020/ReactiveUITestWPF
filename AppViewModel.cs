using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace ReactiveUITestWPF
{
    public class AppViewModel : ReactiveObject
    {      
        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set => this.RaiseAndSetIfChanged(ref _searchTerm, value);
        }
       
        public AppViewModel()
        {                                 
            this
                .WhenAnyValue(x => x.SearchTerm)
                .Skip(1) // ignore the initial NullOrEmpty value of SearchTerm     
                //.Delay(TimeSpan.FromSeconds(0.1)) actually needed only in avalonia 0.10.0
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(val =>
                {                   
                    if (val.Equals("aaa"))
                    {
                        SearchTerm = "bbb";
                    }                  
                    Console.WriteLine("WhenAnyValue Subscribe() -> " + $"SearchTerm value changed to: \"{SearchTerm}\"\n");                    
                });            
        }     
    }
}
