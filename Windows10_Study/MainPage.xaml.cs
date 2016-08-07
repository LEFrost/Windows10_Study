﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Windows10_Study
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string url = "http://apis.baidu.com/showapi_open_bus/oil_price/find";
        public MainPage()
        {
            this.InitializeComponent();
        }
        List< KeyValuePair<string,string>> Params;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content="";

            HttpClient httpClient = new HttpClient();
            
            Params.Add(new KeyValuePair<string, string>("prov",input.Text));
            httpClient.DefaultRequestHeaders.Add("apikey", "6e4b2f5b59fc77691942c8ba6f3bf7e3");
            HttpResponseMessage response= httpClient.GetAsync(new Uri(url)).Result;
            
            if(response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                content = response.Content.ReadAsStringAsync().Result;
            }
            show.Text = content.ToString();
        }
    }
}
