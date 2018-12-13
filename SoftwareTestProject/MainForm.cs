using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using InputOutput;

namespace SoftwareTestProject
{
    public partial class MainForm : Form
    {

        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
        private Bitmap bitmapResultFilter ;
        private Bitmap bitmapResultEdge = null;

        public InputOutputAccess io = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            io = new InputOutputAccess();
            originalBitmap= io.readImage();
            picPreview.Image = originalBitmap.CopyToSquareCanvas(picPreview.Width);
        }
    }
}
