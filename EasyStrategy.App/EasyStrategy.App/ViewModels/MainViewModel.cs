using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Collections;

namespace EasyStrategy.App.ViewModels
{
    public class MainViewModel
    {
        public PlotModel Temp { get; set; }

        public PlotModel Temp2 { get; set; }

        public List<VendaCategoria> Vendas { get; set; } = new List<VendaCategoria>();

        public IList VendaCategorias { get; set; } = new List<object>();


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
                Padding = new OxyThickness(0,5,0,0)
            };

            this.Temp2 = new PlotModel
            {
                PlotAreaBorderColor = OxyColors.Transparent,
                Padding = new OxyThickness(0,10,0,5)
            };

            this.Temp.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                IsPanEnabled = false,
                IsZoomEnabled = false,
                //IsAxisVisible = false,
                MajorGridlineStyle = LineStyle.Dot,
                MajorStep = 50000,
                LabelFormatter = (d) => (d / 1000).ToString("0M")
            });

            this.Temp.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                IsPanEnabled = false,
                IsZoomEnabled = false,
                Selectable = true,
                MajorStep = 2,
                LabelFormatter = (d) => d.ToString("00H")
                //IsAxisVisible = false
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

            var seriePie = new PieSeries()
            {
                
            };

            var i = -1;
            foreach (var vendaCat in Vendas.GroupBy(_ => _.Categoria))
            {
                i++;
                var serie = new AreaSeries();
                serie.Color = colors[i];
                serie.Fill = colors[i];
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

                seriePie.Slices.Add(new PieSlice("", vendaCat.Sum(_ => _.Valor))
                {
                    Fill = colors[i],
                });

                this.VendaCategorias.Add(new
                {
                    Categoria = vendaCat.Key,
                    Valor = vendaCat.Sum(_ => _.Valor),
                    Color = Color.FromRgb(colors[i].R, colors[i].G, colors[i].B)
                });
            }

            this.Temp2.Series.Add(seriePie);


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
            metaSerie.Color = OxyColors.LightGray;
            this.Temp.Series.Add(metaSerie);

            this.Realizado = Vendas.Sum(_ => _.Valor);


        }
        
    }

    public class VendaCategoria
    {
        public string Categoria { get; set; }
        public double Valor { get; set; }
        public int Hora { get; set; }
    }

}
