﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Photo_Rainbow
{
    /// <summary>
    /// Interaction logic for SortedImagesByRainbowDisplay.xaml
    /// </summary>
    class DataGridItemsForRainbow
    {
        public float vPercent { get; set; }
        public float IPercent { get; set; }
        public float BPercent { get; set; }
        public float GPercent { get; set; }
        public float YPercent { get; set; }
        public float OPercent { get; set; }
        public float RPercent { get; set; }
        public Uri ImageUrl { get; set; }
    }
    public partial class SortedImagesByRainbowDisplay : Window
    {
        private ImageDataStore imgDataObj;
        //private ImageColorData iCDObj = new ImageColorData();
        public SortedImagesByRainbowDisplay()
        {
            InitializeComponent();
        }

        public SortedImagesByRainbowDisplay(ImageDataStore imgs)
        {
            this.imgDataObj = imgs;
            InitializeComponent();
            LoadImages();
        }
        
        private void LoadImages()
        {
            Dictionary<Image, Dictionary<String, float>> img7ColorsPercentage = imgDataObj.imgObjColorData.getSortedImagesByRainbow();
            RainbowSortedImages.Items.Clear();

            foreach (Image img in img7ColorsPercentage.Keys)
            { 
                Dictionary<String, float> colors7Value = img7ColorsPercentage[img];
                RainbowSortedImages.Items.Add(new DataGridItemsForRainbow()
                {
                    ImageUrl = new Uri(img.Url),
                    vPercent = colors7Value["Violet"],
                    IPercent = colors7Value["Indigo"],
                    BPercent = colors7Value["Blue"],
                    GPercent = colors7Value["Green"],
                    YPercent = colors7Value["Yellow"],
                    OPercent = colors7Value["Orange"],
                    RPercent = colors7Value["Red"]
                });

            }
        }
    }
}
