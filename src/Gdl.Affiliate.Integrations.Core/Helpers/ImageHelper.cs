using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FacebookCommunityAnalytics.Api.Core.Helpers
{
    public static class ImageHelper
    {
        public static byte[] ResizeImage(byte[] imgBytes, int width = 150)
        {
            try
            {
                byte[] resizedImage;

                MemoryStream inputMemoryStream = new MemoryStream(imgBytes);
                using (Image orginalImage = Image.FromStream(inputMemoryStream, false, false))
                {
                    ImageFormat orginalImageFormat = orginalImage.RawFormat;
                    int orginalImageWidth = orginalImage.Width;
                    int orginalImageHeight = orginalImage.Height;
                    int resizedImageWidth = width; // Type here the width you want
                    int resizedImageHeight = Convert.ToInt32(resizedImageWidth * orginalImageHeight / orginalImageWidth);
                    using (Bitmap bitmapResized = new Bitmap(orginalImage, resizedImageWidth, resizedImageHeight))
                    {
                        using (MemoryStream streamResized = new MemoryStream())
                        {
                            bitmapResized.Save(streamResized, orginalImageFormat);
                            resizedImage = streamResized.ToArray();
                        }
                    }
                }
                return resizedImage;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}