using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace EasyStrategy.App.ViewModels
{
    public class MainViewModel
    {
        public PlotModel Temp { get; set; }

        public List<VendaCategoria> Vendas { get; set; } = new List<VendaCategoria>();


        public double Meta { get; set; } = 250000;
        public double Realizado { get; set; }

        public int HoraInicio { get; set; } = 7;
        public int HoraFim { get; set; } = 23;


        public MainViewModel()
        {
            var rnd = new Random();
            foreach (var c in new string[] { "Bebidas", "Mercearia", "Bazar", "Limpeza", "Perfumaria", "Carnes & Aves", "Frios e Laticinios", "Peixaria", "Padaria" })
                for (int l = HoraInicio + 1; l <= 18; l++)
                    Vendas.Add(new VendaCategoria { Categoria = c, Hora = l, Valor = rnd.NextDouble() * 3000 });

            this.Temp = new PlotModel
            {
                PlotAreaBorderColor = OxyColors.Transparent,
                Padding = new OxyThickness(0)
            };

            this.Temp.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                IsPanEnabled = false,
                IsZoomEnabled = false,
                IsAxisVisible = false
            });

            this.Temp.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                IsPanEnabled = false,
                IsZoomEnabled = false,
                IsAxisVisible = false
            });

            var colors = new OxyColor[]
            {
                OxyColors.Green,
                OxyColors.Purple,
                OxyColors.Orange,
                OxyColors.Blue,
                OxyColors.Red,
                OxyColors.Brown,
                OxyColors.Goldenrod,
                OxyColors.DarkCyan,
                OxyColors.DarkSeaGreen
            };

            var i = -1;
            foreach (var vendaCat in Vendas.GroupBy(_ => _.Categoria))
            {
                i++;
                var serie = new AreaSeries();
                serie.Color = colors[i];
                serie.StrokeThickness = 0;
                serie.Points.Add(new DataPoint(this.HoraInicio, 0));
                serie.Points2.Add(new DataPoint(this.HoraInicio, 0));
                var valor = 0D;
                foreach (var venda in vendaCat)
                {
                    valor += venda.Valor;

                    
                    var valorHora = !Temp.Series.Any() ? 0 : Temp.Series.OfType<AreaSeries>().Max(_ => _.Points2.Where(_1 => _1.X == (double)venda.Hora).Max(_1 => _1.Y));
                    serie.Points.Add(new DataPoint(venda.Hora, valorHora));
                    serie.Points2.Add(new DataPoint(venda.Hora, valor + valorHora));
                }

                this.Temp.Series.Add(serie);
                
            }


            var maxHora = !this.Temp.Series.OfType<AreaSeries>().Any() ? this.HoraInicio : this.Temp.Series.OfType<AreaSeries>().Max(_ => _.Points2.Max(_1 => _1.X));
            var maxValor = !this.Temp.Series.OfType<AreaSeries>().Any() ? 0 : this.Temp.Series.OfType<AreaSeries>().Max(_ => _.Points2.Max(_1 => _1.Y));

            var serieSobra = new AreaSeries();
            serieSobra.Color = OxyColors.Gray;
            serieSobra.StrokeThickness = 0;

            serieSobra.Points.Add(new DataPoint(maxHora, 0));
            serieSobra.Points2.Add(new DataPoint(maxHora, maxValor));

            serieSobra.Points.Add(new DataPoint(this.HoraFim, 0));
            serieSobra.Points2.Add(new DataPoint(this.HoraFim, this.Meta));

            this.Temp.Series.Add(serieSobra);

            var metaSerie = new LineSeries
            {
                Color = OxyColor.FromRgb(Convert.ToByte(Color.Gray.R), Convert.ToByte(Color.Gray.G), Convert.ToByte(Color.Gray.B))
            };
            metaSerie.Points.Add(new DataPoint(this.HoraInicio, 0));
            metaSerie.Points.Add(new DataPoint(this.HoraFim, this.Meta));
            metaSerie.LineStyle = LineStyle.Dash;
            metaSerie.Color = OxyColors.Black;
            this.Temp.Series.Add(metaSerie);




            //var serie1 = new AreaSeries();
            //serie1.Color = OxyColors.Green;
            //serie1.StrokeThickness = 0;
            //serie1.Points.Add(new DataPoint(0, 0));
            //serie1.Points.Add(new DataPoint(1, 10));
            //serie1.Points.Add(new DataPoint(2, 13));
            //serie1.Points.Add(new DataPoint(3, 17));
            //serie1.Points.Add(new DataPoint(4, 21));
            //serie1.Points.Add(new DataPoint(5, 34));
            //serie1.Points.Add(new DataPoint(6, 56));
            //serie1.Points.Add(new DataPoint(7, 57));
            //serie1.Points.Add(new DataPoint(8, 68));
            ////serie1.Points.Add(new DataPoint(9, 68));
            ////serie1.Points.Add(new DataPoint(10, 95));
            ////serie1.Points.Add(new DataPoint(11, 95));
            ////serie1.Points.Add(new DataPoint(12, 97));
            //serie1.Points2.Add(new DataPoint(0, 0));
            //serie1.Points2.Add(new DataPoint(1, 8));
            //serie1.Points2.Add(new DataPoint(2, 12));
            //serie1.Points2.Add(new DataPoint(3, 14));
            //serie1.Points2.Add(new DataPoint(4, 15));
            //serie1.Points2.Add(new DataPoint(5, 24));
            //serie1.Points2.Add(new DataPoint(6, 35));
            //serie1.Points2.Add(new DataPoint(7, 40));
            //serie1.Points2.Add(new DataPoint(8, 59));
            ////serie1.Points2.Add(new DataPoint(9, 61));
            ////serie1.Points2.Add(new DataPoint(10, 72));
            ////serie1.Points2.Add(new DataPoint(11, 80));
            ////serie1.Points2.Add(new DataPoint(12, 86));
            //Temp.Series.Add(serie1);

            //var serie2 = new AreaSeries();
            //serie2.Color = OxyColors.Red;
            //serie2.StrokeThickness = 0;
            //serie2.Points.Add(new DataPoint(0, 0));
            //serie2.Points.Add(new DataPoint(1, 8));
            //serie2.Points.Add(new DataPoint(2, 12));
            //serie2.Points.Add(new DataPoint(3, 14));
            //serie2.Points.Add(new DataPoint(4, 15));
            //serie2.Points.Add(new DataPoint(5, 24));
            //serie2.Points.Add(new DataPoint(6, 35));
            //serie2.Points.Add(new DataPoint(7, 40));
            //serie2.Points.Add(new DataPoint(8, 59));
            ////serie2.Points.Add(new DataPoint(9, 61));
            ////serie2.Points.Add(new DataPoint(10, 72));
            ////serie2.Points.Add(new DataPoint(11, 80));
            ////serie2.Points.Add(new DataPoint(12, 86));
            //serie2.Points2.Add(new DataPoint(0, 0));
            //serie2.Points2.Add(new DataPoint(1, 6));
            //serie2.Points2.Add(new DataPoint(2, 8));
            //serie2.Points2.Add(new DataPoint(3, 9));
            //serie2.Points2.Add(new DataPoint(4, 13));
            //serie2.Points2.Add(new DataPoint(5, 21));
            //serie2.Points2.Add(new DataPoint(6, 34));
            //serie2.Points2.Add(new DataPoint(7, 37));
            //serie2.Points2.Add(new DataPoint(8, 50));
            ////serie2.Points2.Add(new DataPoint(9, 55));
            ////serie2.Points2.Add(new DataPoint(10, 67));
            ////serie2.Points2.Add(new DataPoint(11, 71));
            ////serie2.Points2.Add(new DataPoint(12, 80));

            //Temp.Series.Add(serie2);


            //var serie3 = new AreaSeries();
            //serie3.Color = OxyColors.Blue;
            //serie3.StrokeThickness = 0;
            //serie3.Points.Add(new DataPoint(0, 0));
            //serie3.Points.Add(new DataPoint(1, 6));
            //serie3.Points.Add(new DataPoint(2, 8));
            //serie3.Points.Add(new DataPoint(3, 9));
            //serie3.Points.Add(new DataPoint(4, 13));
            //serie3.Points.Add(new DataPoint(5, 21));
            //serie3.Points.Add(new DataPoint(6, 34));
            //serie3.Points.Add(new DataPoint(7, 37));
            //serie3.Points.Add(new DataPoint(8, 50));
            ////serie3.Points.Add(new DataPoint(9, 55));
            ////serie3.Points.Add(new DataPoint(10, 67));
            ////serie3.Points.Add(new DataPoint(11, 71));
            ////serie3.Points.Add(new DataPoint(12, 80));

            //Temp.Series.Add(serie3);



        }
    }

    public class VendaCategoria
    {
        public string Categoria { get; set; }
        public double Valor { get; set; }
        public int Hora { get; set; }
    }

}
