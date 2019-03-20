using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Midterm.Models;

using Entry = Microcharts.Entry;
using System.Collections.ObjectModel;

namespace Midterm
{
    public partial class Chart : ContentPage
    {
        List<string> colors = new List<string>();

        public Chart()
        {
            InitializeComponent();
            CreateColorList();
        }

        private void CreateColorList()
        {
            colors.Add("#00006e"); colors.Add("#000075"); colors.Add("#00007d"); colors.Add("#000085");
            colors.Add("#00008c"); colors.Add("#000094"); colors.Add("#00009c"); colors.Add("#0000a3");
            colors.Add("#0000ab"); colors.Add("#0000b2"); colors.Add("#0000ba"); colors.Add("#0000c2");
            colors.Add("#0000c9"); colors.Add("#0000d1"); colors.Add("#0000d9"); colors.Add("#0000e0");
            colors.Add("#0000e8"); colors.Add("#0000f0"); colors.Add("#0000f7"); colors.Add("#0000ff");
            colors.Add("#0000ff"); colors.Add("#000dfc"); colors.Add("#001afa"); colors.Add("#0026f7");
            colors.Add("#0033f5"); colors.Add("#0040f2"); colors.Add("#004cf0"); colors.Add("#0059ed");
            colors.Add("#0066eb"); colors.Add("#0073e8"); colors.Add("#0080e6"); colors.Add("#008ce3");
            colors.Add("#0099e0"); colors.Add("#00a6de"); colors.Add("#00b2db"); colors.Add("#00bfd9");
            colors.Add("#00ccd6"); colors.Add("#00d9d4"); colors.Add("#00e6d1"); colors.Add("#00f2cf");
            colors.Add("#00ffcc"); colors.Add("#00ffcc"); colors.Add("#0df2cf"); colors.Add("#1ae6d1");
            colors.Add("#26d9d4"); colors.Add("#33ccd6"); colors.Add("#40bfd9"); colors.Add("#4cb2db");
            colors.Add("#59a6de"); colors.Add("#6699e0"); colors.Add("#738ce3"); colors.Add("#8080e6");
            colors.Add("#8c73e8"); colors.Add("#9966eb"); colors.Add("#a659ed"); colors.Add("#b24df0");
            colors.Add("#bf40f2"); colors.Add("#cc33f5"); colors.Add("#d926f7"); colors.Add("#e619fa");
            colors.Add("#f20dfc"); colors.Add("#ff00ff"); colors.Add("#ff00ff"); colors.Add("#ff00f2");
            colors.Add("#ff00e6"); colors.Add("#ff00d9"); colors.Add("#ff00cc"); colors.Add("#ff00bf");
            colors.Add("#ff00b2"); colors.Add("#ff00a6"); colors.Add("#ff0099"); colors.Add("#ff008c");
            colors.Add("#ff0080"); colors.Add("#ff0073"); colors.Add("#ff0066"); colors.Add("#ff0059");
            colors.Add("#ff004d"); colors.Add("#ff0040"); colors.Add("#ff0033"); colors.Add("#ff0026");
            colors.Add("#ff0019"); colors.Add("#ff000d"); colors.Add("#ff0000"); colors.Add("#ff0000");
            colors.Add("#ff0800"); colors.Add("#ff0f00"); colors.Add("#ff1700"); colors.Add("#ff1f00");
            colors.Add("#ff2600"); colors.Add("#ff2e00"); colors.Add("#ff3600"); colors.Add("#ff3d00");
            colors.Add("#ff4500"); colors.Add("#ff4c00"); colors.Add("#ff5400"); colors.Add("#ff5c00");
            colors.Add("#ff6300"); colors.Add("#ff6b00"); colors.Add("#ff7300"); colors.Add("#ff7a00"); 
            colors.Add("#ff8200"); colors.Add("#ff8a00"); colors.Add("#ff9100"); colors.Add("#ff9900");
        }

       async void Handle_Appearing(object sender, System.EventArgs e)
        {
            if (!Search.IsEntryNull)
            {
                var Entry = new List<Entry>();
                var Entry2 = new List<Entry>();


                for (int i = 0; i < 30; i++)
                {
                    //for labels
                    string label;
                    if (i % 9 == 0)
                    {
                        label = Search.dailyList[i].TheHigh;
                    }
                    else
                    {
                        label = null;
                    }

                    //makes new entry for list items
                    var newEntry = new Entry(float.Parse(Search.dailyList[i].TheHigh))
                    {
                        ValueLabel= label,
                        TextColor = SKColor.Parse(colors[i % colors.Count()]),
                        Color = SKColor.Parse(colors[i%colors.Count()])
                    };

                    //adds to entry ist
                    Entry2.Add(newEntry);
                    Entry.Add(newEntry);
                }
                //for 100 day list
                for(int i = 29; i < 100; i++)
                {
                    //for labels
                    string label;
                    if(i % 9 == 0)
                    {
                        label = Search.dailyList[i].TheHigh;
                    }
                    else
                    {
                        label = null;
                    }

                    //makes new entry for list items
                    var newEntry = new Entry(float.Parse(Search.dailyList[i].TheHigh))
                    {
                        ValueLabel = label,
                        TextColor = SKColor.Parse(colors[i % colors.Count()]),
                        Color = SKColor.Parse(colors[i % colors.Count()])
                    };
                    //adds to entry ist
                    Entry2.Add(newEntry);
                }

                //create chart for 100 day chart
                var LineChart2 = new LineChart()
                {
                    Entries = Entry2,
                    LineSize = 20,
                    LabelTextSize = 30,
                    LineMode = LineMode.Spline

                };

                //create chart for 30 day chart
                var LineChart = new LineChart() { 
                Entries = Entry,
                LineSize = 20,
                LabelTextSize=30,
                LineMode=LineMode.Spline
                
                };

                //add chart to view
                Chart2.Chart = LineChart2;
                Chart2.Chart.LabelTextSize = 40;
                Chart1.Chart = LineChart;
                Chart1.Chart.LabelTextSize = 40;

                //for chart animation
                await Frame2.TranslateTo(0, 1000, 0);
                await Frame1.TranslateTo(0, -1000, 0);

                Frame1.IsVisible = true;
                Frame2.IsVisible = true;

                await Frame1.TranslateTo(0, 0, 1000, Easing.BounceIn);
                await Frame2.TranslateTo(0, 0, 1000, Easing.BounceIn);
            }
            else
            {
                Frame1.IsVisible = false;
                Frame2.IsVisible = false;

            }

        }
    }

}
