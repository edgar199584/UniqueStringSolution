using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace UniqueString.DesktopApp.ViewModel
{
    public class UniqueStringViewModel : ViewModelBase
    {
        static HttpClient client = new HttpClient();
        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                if (value == _text) return;
                _text = value;
                RaisePropertyChanged();
            }
        }


        #region commands;
        private RelayCommand _buttonClickCommand;

        public RelayCommand ButtonClickCommand
        {
            get { return _buttonClickCommand ?? (_buttonClickCommand = new RelayCommand(ButtonClickExecute)); }
        }

        private async void ButtonClickExecute()
        {
            HttpResponseMessage response = await client.PostAsync(
               "http://localhost:18794/api/isUnique", new StringContent(JsonConvert.SerializeObject(new {Text=Text }),Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();
            MessageBox.Show(result);
        }

        
        #endregion
    }
}
