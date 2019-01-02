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
        private Filter filter = null;
        

        public InputOutputAccess io = null;

        public MainForm()
        {
            InitializeComponent();

            comboFilterApplication.Enabled = false;
            comboEdgeDetection.Enabled = false; 

            filter = new Filter();
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            io = new InputOutputAccess();
            originalBitmap = io.openFileDialog();
            picPreview.Image = originalBitmap.resize(picPreview.Width);
            comboFilterApplication.Enabled = true;
        }

        private void btnSaveNewImage_Click(object sender, EventArgs e)
        {
            io = new InputOutputAccess();
            bool saveGoneRight = io.openSaveDialog((Bitmap)picPreview.Image);
        }

        private void comboFilterApplication_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboFilterApplication.SelectedItem.ToString() != "None")
            {
              Bitmap bitmapResult = filter.ApplyFilter(comboFilterApplication.SelectedItem.ToString(), originalBitmap);

                //ApplyImageFilter
                if (bitmapResult != null)
                {
                    picPreview.Image = bitmapResult;
                    
                    comboEdgeDetection.SelectedIndex = 0;
                }
            }

            else
            {
                picPreview.Image = originalBitmap;
            }

            comboEdgeDetection.Enabled = true;
        }
    }
}
