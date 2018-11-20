using GameOfLie.Logic;
using GameOfLie.Models;
using SkiaSharp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameOfLie
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameRoom : ContentPage
    {
        private readonly ConfigurationModel _configurationModel;
        private bool[,] _state;
        //private bool[,] _state = new bool[,]
        //{
        //    {false,false, false, false,false },
        //    {false,false, true, false,false },
        //    {false,false, true, false,false },
        //    {false,false, true, false,false },
        //    {false,false, false, false,false },
        //};

        private Matrix _matrix;

        public GameRoom()
            : this(new ConfigurationModel
            {
                AliveColor = App.AlivePaint.Color,
                ColumnCounts = 125,
                RowCounts = 75
            })
        {

        }
        public GameRoom (ConfigurationModel configurationModel)
		{
			InitializeComponent();

            _configurationModel = configurationModel;

            _state = Matrix.GenerateInitialState(_configurationModel.RowCounts, _configurationModel.ColumnCounts);
            _matrix = new Matrix(_state);
            Device.StartTimer(TimeSpan.FromSeconds(10f/60), () =>
            {
                _state = _matrix.Next();
                canvasView.InvalidateSurface();
                return true; // True = Repeat again, False = Stop the timer
            });
        }

        private void CanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear(SKColors.Black);

            var height = e.Info.Height;
            var width = e.Info.Width;

            var rows = _state.GetLength(0);
            var columns = _state.GetLength(1);


            var rectHeight = height/ rows;
            var rectWidth = width / columns;

            var alivePaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = _configurationModel.AliveColor
            };

            for (int i = 0; i < _state.GetLength(0); i++)
            {
                for (int j = 0; j < _state.GetLength(1); j++)
                {
                    if(_state[i, j])
                    {
                        //alive
                        canvas.DrawCircle(rectWidth * j, rectHeight * i, rectHeight / 5, alivePaint);
                    }
                    else
                    {
                        //dead 
                        canvas.DrawRect(rectWidth * j, rectHeight * i, rectWidth, rectHeight, App.DeadPaint);
                    }
                }
            }

        }
    }
}