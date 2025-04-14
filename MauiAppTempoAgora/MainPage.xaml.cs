using System.Diagnostics;
using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void Button_Clicked_Previsao(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);
                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latitude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"NAscer do Sol: {t.sunrise} \n" +
                                         $"Por do Sol: {t.temp_sunset} \n" +
                                         $"Temp Máx: {t.temp_max} \n" +
                                         $"Temp Min: {t.temp_min} \n";

                        lbl_res.Text = dados_previsao;

                        string mapa = $"https://embed_windy.com/embed.html?" +
                                      $"type=map&location=coordinates&metricRin=mm&metricTemp=°C" +
                                      $"&metricWind=km/h&zoom=&overlay=wind&product=ecmwf&level=surface" +
                                      $"&lat={try.lat.ToString().Replace(",", ".")}&lon=" +
                                      $"{try.lon.ToString().Replace(",", ".")}";

                        wv_mapa.Source = mapa;

                        Debug.WriteLine(mapa);
                    } else
                    {
                        lbl_res.Text = "Sem dados de Previsão";
                    }
                } else
                {
                    lbl_res.Text = "Preencha a cidade";
                }
            } catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            } 
        }

        private async void
      

     }

}
