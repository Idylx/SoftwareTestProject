using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace InputOutput
{
    public class InputOutputAccess : IInputOutput
    {

        public Bitmap openFileDialog()
        {

            Bitmap loadedImage = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";

            //Accepted file type
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp";
            //Ok button listener
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                loadedImage = readImage(ofd.FileName);
            }
            return loadedImage;
        }
        //Load image method
        public Bitmap readImage(string filename)
        {

            Bitmap loadedImage = null;

            try
            {
                //Load the file
                StreamReader streamReader = new StreamReader(filename);
            loadedImage = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
            streamReader.Close(); }
            catch (IOException e)
            {
                Console.WriteLine(e);              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);             
            }

            return loadedImage;
        }

        public bool openSaveDialog(Bitmap bitmap)
        {
            bool result = false;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Select an image file.";

            //Accepted file type
            sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp";

            //Ok button listener
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                result = writeImage(bitmap, sfd.FileName);
            }
            return result;
        }
        //write image method
        public bool writeImage(Bitmap bitmap, string filename)
        {
            bool result = false;

            string fileExtension = Path.GetExtension(filename).ToUpper();
            ImageFormat imgFormat = ImageFormat.Png;

            //chose format logic
            switch (fileExtension)
            {
                case ".BMP":
                    imgFormat = ImageFormat.Bmp;
                    break;
                case ".PNG":
                    imgFormat = ImageFormat.Png;
                    break;
                case ".JPG":
                    imgFormat = ImageFormat.Jpeg;
                    break;
                default:
                    return false;
            }

            //writting image
            StreamWriter streamWriter = new StreamWriter(filename);
            try
            {
                bitmap.Save(streamWriter.BaseStream, imgFormat);
                streamWriter.Flush();
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    result = true;
                    bitmap = null;
                }
            }


            return result;
        }

    }
}
