using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace InputOutput
{
    public class InputOutput
    {
        //Load image method
        public Bitmap readImage()
        {
             
            Bitmap loadedImage = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";

            //Accepted file type
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp";

            //Ok button listener
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Load the file
                StreamReader streamReader = new StreamReader(ofd.FileName);
                loadedImage = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();
            }
            return loadedImage;
        }

        //write image method
        public bool writeImage(Bitmap bitmap)
        {
                    
            bool result = false;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Select an image file.";

            //Accepted file type
            sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp";

            //Ok button listener
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                ImageFormat imgFormat = ImageFormat.Png;

                //chose format logic
                switch (fileExtension)
                {
                    case "BMP":
                        imgFormat = ImageFormat.Bmp;
                        break;
                    case "PNG":
                        imgFormat = ImageFormat.Png;
                        break;
                    case "JPG":
                        imgFormat = ImageFormat.Jpeg;
                        break;
                }

                //writting image
                StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                try { 
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
                
            }
            return result;
        }

    }
}
