using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoYobuV2.ViewModels;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SelectionChangedEventArgs = Syncfusion.XForms.ComboBox.SelectionChangedEventArgs;

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
            // _viewModel.TestData();
            // _viewModel.TestData();
            // _viewModel.TestData();
            _viewModel.LoadData(0, 25);
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

        private void CbIncludeTagMode_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.IncludeTagMode = CbIncludeTagMode.SelectedItem.ToString();
        }

        private void CbExcludeTagMode_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.ExcludeTagMode = CbExcludeTagMode.SelectedItem.ToString();
        }
    }
}