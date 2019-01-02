using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IFilter
    {
        Bitmap BlackWhite(Bitmap Bmp);
        Bitmap RainbowFilter(Bitmap bmp);
        Bitmap ApplyFilter(String selection, Bitmap originalBitmap);

    }
}
