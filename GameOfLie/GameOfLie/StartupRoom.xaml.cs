using GameOfLie.Converters;
using GameOfLie.ViewModels;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
    
namespace GameOfLie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartupRoom : ContentPage
    {
        private StartupRoomViewModel viewModel;
        public StartupRoom()
        {
            InitializeComponent();
            viewModel = new StartupRoomViewModel(this);
            viewModel.AliveColor = App.AlivePaint.Color;
            BindingContext = viewModel;
        }

        private void Handle_ItemTapped(object sender, Syncfusion.SfRadialMenu.XForms.ItemTappedEventArgs e)
        {
            Syncfusion.SfRadialMenu.XForms.SfRadialMenuItem item1 = sender as Syncfusion.SfRadialMenu.XForms.SfRadialMenuItem;
            viewModel.AliveColor = SKColor.Parse(ColorConverter.ConvertToHex(item1.BackgroundColor));
            canvasView.InvalidateSurface();
            teamUSARadialMenu.Close();
        }

        private void CanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var state = new bool[,]
            {
                {true,true },
                {true,true }
            };
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear(SKColors.Black);

            var height = e.Info.Height;
            var width = e.Info.Width;

            var rows = state.GetLength(0);
            var columns = state.GetLength(1);

            var rectHeight = height / rows;
            var rectWidth = width / columns;

            var padding = 15;
            var activeColor = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = viewModel.AliveColor
            };

            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    canvas.DrawCircle(rectWidth * j + padding, rectHeight * i + padding, rectHeight / 5, activeColor);
                }
            }

        }
    }
}