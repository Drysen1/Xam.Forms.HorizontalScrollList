using HorizontalScrollList.Models;
using HorizontalScrollList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HorizontalScrollList
{
    public partial class MainPage : ContentPage
    {
        private List<ItemModel> _itemList;
        private MainViewModel _viewModel;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            BindingContext = _viewModel;
            _itemList = new List<ItemModel>();
        }

        /// <summary>
        /// Overriden OnBindingContextChanged
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

        /// <summary>
        /// Overriden OnAppearing.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.VmOnAppearing();
            _itemList = _viewModel.ItemList.ToList();            
            SetGridList();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetGridList()
        {
            gridList.ColumnDefinitions.Clear();
            int row = 0;
            int col = 0;

            foreach (var item in _itemList)
            {
                gridList.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                AddToUI(row, col, item);
                col++;
            }
        }

        /// <summary>
        /// This method creates a Stacklayout to add to the grid in the UI and calls other methods to create labels.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="item"></param>
        private void AddToUI(int row, int col, ItemModel item)
        {

            StackLayout stack = new StackLayout();
            stack.BackgroundColor = Color.OrangeRed;
            stack.Padding = 10;

            var nameLbl = CreateNameLbl(item.ItemName);
            stack.Children.Add(nameLbl);

            var detailLbl = CreateDetailLbl(item.ItemDetail);
            stack.Children.Add(detailLbl);

            var tapGestureRecon = new TapGestureRecognizer();
            tapGestureRecon.SetBinding(TapGestureRecognizer.CommandProperty, "TapCmd");
            tapGestureRecon.CommandParameter = item;

            stack.GestureRecognizers.Add(tapGestureRecon);

            gridList.Children.Add(stack, col, row);
        }

        /// <summary>
        /// Creates a label for the name in the itemmodel
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Label CreateNameLbl(string name)
        {
            Label nameLbl = new Label();
            nameLbl.FontSize = 17;
            nameLbl.TextColor = Color.Black;
            nameLbl.Text = name;
            nameLbl.HorizontalTextAlignment = TextAlignment.Center;
            nameLbl.VerticalTextAlignment = TextAlignment.End;

            return nameLbl;
        }

        /// <summary>
        /// ´Create 
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        private Label CreateDetailLbl(string detail)
        {
            Label detailLbl = new Label();
            detailLbl.FontSize = 14;
            detailLbl.TextColor = Color.Gray;
            detailLbl.Text = detail;
            detailLbl.HorizontalTextAlignment = TextAlignment.Center;
            detailLbl.VerticalTextAlignment = TextAlignment.Start;

            return detailLbl;
        }
    }
}
