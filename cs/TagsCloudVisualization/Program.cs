﻿using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloudVisualization;

public class Program
{
    public static void Main(string[] args)
    {
        var cloudLayouter = new CircularCloudLayouter(new Point(500, 200));
        var random = new Random();
        for (var i = 0; i < 100; i++)
        {
            cloudLayouter.PutNextRectangle(new Size(random.Next(50, 100), random.Next(10, 50)));
        }
        
        using var bitmap = CloudImageGenerator.Generate(cloudLayouter);
        
        string directory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        var path = Path.Combine(directory, "Images", "tag-cloud-200-first-quarter.bmp");
        bitmap.Save(path, ImageFormat.Bmp);
    }
}