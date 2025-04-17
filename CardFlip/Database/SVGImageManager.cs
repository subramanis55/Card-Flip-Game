using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialLibrary;
using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;
namespace CardFlip.Database
{
    public static class SVGImageManager
    {
        private static Random Random = new Random();
        private static List<string> GetSvgFilePaths()
        {
            // Relative to the executable (bin\Debug or bin\Release)
            string svgFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Svg");

            if (Directory.Exists(svgFolderPath))
            {
                var svgFiles = Directory.GetFiles(svgFolderPath, "*.svg", SearchOption.TopDirectoryOnly).ToList();
                return svgFiles;
            }

            return new List<string>(); // empty if folder doesn't exist
        }

        public static Dictionary<int, ImageSource> GetRandomImages(int Count)
        {
            Dictionary<int, ImageSource>  images = new Dictionary<int, ImageSource>();
            List<string> paths = GetSvgFilePaths();
            for (int i = 0; i < Count; i++)
            {
                int index = Random.Next(0, paths.Count - 1);
                images.Add(i,LoadSvgIntoImage(paths[index]));
                paths.RemoveAt(index);
            }
            return images;  
        }
            
        private static ImageSource LoadSvgIntoImage(string svgPath)
        {
            var settings = new WpfDrawingSettings();
            var reader = new FileSvgReader(settings);
            var drawing = reader.Read(svgPath);

            if (drawing != null)
            {
                var drawingImage = new DrawingImage(drawing);
                return drawingImage;
            }
            return null;
        }
    }
}
