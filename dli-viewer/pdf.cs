using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace dli_viewer
{
    class pdf
    {
        static List<string> GetSortedImagesFromDirectory(string directory)
        {
            string[] filenameArray = Directory.GetFiles(directory, "*.tif", SearchOption.TopDirectoryOnly);
            List<string> filenameList = new List<string>(filenameArray);
            filenameList.Sort(StringComparer.InvariantCultureIgnoreCase);
            return filenameList;
        }

        static void OpenFile(string fileName)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Verb = "Open";
            process.Start();
        }
        static System.Drawing.Image Resize(System.Drawing.Image img, float percentage)
        {
            float originalW = img.Width;
            float originalH = img.Height;

            int resizedW = (int)(originalW * percentage);
            int resizedH = (int)(originalH * percentage);

            Bitmap bmp = new Bitmap(resizedW, resizedH);
            Graphics graphic = Graphics.FromImage((System.Drawing.Image)bmp);
            graphic.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphic.DrawImage(img, 0, 0, resizedW, resizedH);
            graphic.Dispose();
            return (System.Drawing.Image)bmp;
        }
        static ImageCodecInfo imageEncoder = GetEncoder(ImageFormat.Tiff);
        static Byte[] ConvertImage(string filename)
        {
            MemoryStream ms = new MemoryStream();
            Bitmap bitmap = new Bitmap(filename);

            float scaleFactor = 1f;

            System.Drawing.Image resizedImage = Resize(bitmap, scaleFactor);
            EncoderParameters encoderParameters = new EncoderParameters(2);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
            encoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long).7);
            resizedImage.Save(ms, imageEncoder, encoderParameters);

            if (ms.Length > new FileInfo(filename).Length)
            {
                return File.ReadAllBytes(filename);
            }
            else
            {
                return ms.GetBuffer();
            }
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        static void CreatePDF(List<string> inputFilenames, string outputFilename)
        {
            try
            {
                FileStream outputStream = new FileStream(outputFilename, FileMode.Create);

                int totalNmberOfFiles = inputFilenames.Count;
                int numberOfFilesProcessed = 0;

                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, outputStream);
                writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_5);
                writer.CompressionLevel = PdfStream.BEST_COMPRESSION;

                document.Open();
                PdfContentByte content = writer.DirectContent;

                Console.Write("Progress (pages): ");

                foreach (string file in inputFilenames)
                {
                    Console.WriteLine(file);
                    iTextSharp.text.Image image;
                    try
                    {
                        //image = iTextSharp.text.Image.GetInstance(file);
                        image = iTextSharp.text.Image.GetInstance(ConvertImage(file));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error reading image " + file + ". " + e);
                        continue;
                    }

                    // scale image to fit either the 8.5 or 11 inch margins
                    // default dpi is 72

                    float scaleFactor = 1f;
                    if (image.Height > 11 * 72f)
                    {
                        scaleFactor = 11f / (image.Height / 72f);
                    }
                    if (image.Width > 8.5 * 72f)
                    {
                        float widthScaleFactor = 8.5f / (image.Width / 72f);
                        if (widthScaleFactor > scaleFactor)
                        {
                            scaleFactor = widthScaleFactor;
                        }
                    }

                    if (scaleFactor != 1f)
                    {
                        image.ScalePercent(scaleFactor * (float)100.0);
                    }

                    document.SetPageSize(new iTextSharp.text.Rectangle(image.Width * scaleFactor, image.Height * scaleFactor));
                    document.NewPage();

                    image.SetAbsolutePosition(0, 0);
                    content.AddImage(image);

                    if (++numberOfFilesProcessed % 10 == 0)
                    {
                        Console.Write(string.Format("{0}.", numberOfFilesProcessed));
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Done.");
                document.Close();
                OpenFile(outputFilename);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }    
    }
}
