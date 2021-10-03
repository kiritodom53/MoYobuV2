using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoYobuV2.ViewModels;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoYobuV2.TabbedPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : SfTabItem
    {
        private readonly SearchPageViewModel _viewModel;
        public SearchPage()
        {
            InitializeComponent();
            _viewModel = new SearchPageViewModel();
            BindingContext = _viewModel;
            _viewModel.TestData();
            _viewModel.TestData();
            _viewModel.TestData();
        }

        private void BtnSearch_OnClicked(object sender, EventArgs e)
        {
            _viewModel.IsBtnSearchVisible = false;
            _viewModel.IsLabelVisible = false;
            _viewModel.IsBtnBackVisible = true;
            _viewModel.IsSearchBarVisible = true;
        }

        private void BtnBack_OnClicked(object sender, EventArgs e)
        {
            _viewModel.IsBtnSearchVisible = true;
            _viewModel.IsLabelVisible = true;
            _viewModel.IsBtnBackVisible = false;
            _viewModel.IsSearchBarVisible = false;
        }
    }
}