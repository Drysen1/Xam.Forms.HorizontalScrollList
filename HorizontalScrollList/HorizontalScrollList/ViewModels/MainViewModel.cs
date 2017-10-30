using HorizontalScrollList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorizontalScrollList.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ItemModel> _itemList = new ObservableCollection<ItemModel>();
        public ObservableCollection<ItemModel> ItemList { get { return _itemList; } set { _itemList = value; OnPropertyChanged(); } }

        private ItemModel _item;
        public ItemModel Item { get { return _item; } set { _item = value; OnPropertyChanged(); } }

        public ICommand TapCmd { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            TapCmd = new Command(ExecuteTapCmd);
        }
    
        /// <summary>
        /// Lets pretend we dowload data from an api or something.
        /// </summary>
        /// <returns></returns>
        public async Task VmOnAppearing()
        {
            await Task.Run(() => SimulateDownload());
            SetList();
        }

        /// <summary>
        /// Do something when user clicks in UI.
        /// </summary>
        /// <param name="s"></param>
        private void ExecuteTapCmd(object s)
        {
            Item = s as ItemModel;
            System.Diagnostics.Debug.WriteLine(string.Format("ID : {0} , Name : {1} , Detail : {2}", Item.ID, Item.ItemName, Item.ItemDetail)); //Lets write to debug to see all of our values.
        }

        #region Simulate download and add mock data
        private void SetList()
        {
            ItemList.Add(new ItemModel()
            {
                ID = 0,
                ItemName = "Item 1",
                ItemDetail = "Detail one"
            });
            ItemList.Add(new ItemModel()
            {
                ID = 1,
                ItemName = "Item 2",
                ItemDetail = "Two detail"
            });
            ItemList.Add(new ItemModel()
            {
                ID = 2,
                ItemName = "Item 3",
                ItemDetail = "Three details"
            });
            ItemList.Add(new ItemModel()
            {
                ID = 3,
                ItemName = "Item 4",
                ItemDetail = "Another detail"
            });
            ItemList.Add(new ItemModel()
            {
                ID = 4,
                ItemName = "Item 5",
                ItemDetail = "This is detail"
            });
            ItemList.Add(new ItemModel()
            {
                ID = 5,
                ItemName = "Item 6",
                ItemDetail = "Detailian Raptor"
            });
            ItemList.Add(new ItemModel()
            {
                ID = 6,
                ItemName = "Item 7",
                ItemDetail = "Dets detail"
            });
        }

        private void SimulateDownload()
        {
            var endTime = DateTime.Now.AddSeconds(2);
            while (true)
            {
                if(DateTime.Now >= endTime)
                {
                    break;
                }
            }
        }
        #endregion

        #region Implemnattion of interface
        //Implementaion of interface
        public event PropertyChangedEventHandler PropertyChanged;
        //Implementaion of interface
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
