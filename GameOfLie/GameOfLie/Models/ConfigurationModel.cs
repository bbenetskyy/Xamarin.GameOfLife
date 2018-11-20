using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLie.Models
{
    public class ConfigurationModel
    {
        public int RowCounts { get; set; }
        public int ColumnCounts { get; set; }
        public SKColor AliveColor { get; set; }
    }
}
