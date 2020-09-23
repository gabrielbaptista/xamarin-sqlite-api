using System.ComponentModel;
using Xamarin.Forms;
using AppSample.ViewModels;

namespace AppSample.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}