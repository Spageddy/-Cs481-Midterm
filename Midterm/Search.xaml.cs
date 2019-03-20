using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Midterm.Models;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace Midterm
{
    public partial class Search : ContentPage
    {
        public static ObservableCollection<TimeSeriesDaily> dailyList;
        public static bool IsEntryNull = true;

        public Search()
        {
            InitializeComponent();
        }

      async void Search_Clicked(object sender, System.EventArgs e)
        {
            //entry isnt empty or null
            if (!string.IsNullOrEmpty(searchEntry.Text))
            {
                IsEntryNull = false;
                var client = new HttpClient();

                //url for entry
                var ApiUrl = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol="
                + searchEntry.Text.ToUpper() + "&outputsize=compact&apikey=RS3YV1SFILW2SNFY";

                //make api request
                var uri = new Uri(ApiUrl);
                StockData stockdata = new StockData();
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    //get data from json 
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    stockdata = JsonConvert.DeserializeObject<StockData>(jsonContent);

                    //symbol was not found
                    if (stockdata.MetaData == null)
                    {
                        ShowNothing();
                        await DisplayAlert("Error", "Sorry, stock symbol not found.", "Try again!");

                    }
                    //symbol was found
                    else
                    {
                        //convert data into list
                        dailyList = new ObservableCollection<TimeSeriesDaily>(stockdata.TimeSeriesDaily.Values);
                     
                        int i = 0;
                        var temp = dailyList[0].TheHigh;
                        double highest = double.Parse(dailyList[0].TheHigh);
                        double lowest = double.Parse(dailyList[0].TheLow);

                        //add the dates and get highest and lowest
                        foreach (var item in stockdata.TimeSeriesDaily)
                        {
                            dailyList[i].TheDate = DateTime.Parse(item.Key);
                            if (double.Parse(dailyList[i].TheHigh) > highest)
                            {
                                highest = double.Parse(dailyList[i].TheHigh);
                            }

                            if (double.Parse(dailyList[i].TheLow) < lowest)
                            {
                                lowest = double.Parse(dailyList[i].TheLow);
                            }

                            i++;
                        }

                        ShowNothing();

                        highestLabel.Text = "Highest $" + highest;
                        lowestLabel.Text = "Lowest $" + lowest;

                        await frame.TranslateTo(0,1000,0);
                        await frame2.TranslateTo(1000,0, 0);

                        frame.IsVisible = true;
                        frame2.IsVisible = true;
                        stockDataListView.ItemsSource = dailyList;
                        stockDataListView.IsVisible = true;

                        await frame.TranslateTo(0, 0, 1000, Easing.BounceIn);
                        await frame2.TranslateTo(0, 0, 1000, Easing.BounceIn);

                        stockDataListView.ItemsSource = dailyList;
                        stockDataListView.IsVisible = true;

                    }
                } 
            }
            //entry is empty or null
            else 
            {
                ShowNothing();
                await DisplayAlert("Error", "Sorry, must enter a stock symbol.", "Try again!");
            }
        }

        private void ShowNothing()
        {
            IsEntryNull = true;
            frame2.IsVisible = false;
            frame.IsVisible = false;
            stockDataListView.IsVisible = false;
        }
    }
}   
