using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Navigation
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
            var vm = new MasterPageViewModel(); // zamiast robic BindingContext = new MasterPageViewModel()
            vm.Navigation = Navigation;         // robie zmienna typu MasterPageViewModel, do ktorej przypisuje wartosc Navigation
            BindingContext = vm;                // dzieki czemu moge nawigowac miedzy widokami we ViewModelu
        }                                       // zmienna typu var sama definiuje typ podczas kompilacji, dzieki czemu
    }                                           // nie musimy sie martwic tym podczas pisania kodu
}                                               // jesli najedziemy na vm pokaze nam, jakiego typu jest ta zmienna
