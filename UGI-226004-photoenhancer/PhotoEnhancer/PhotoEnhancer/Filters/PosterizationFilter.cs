using PhotoEnhancer.Filters;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    public class PosterizationFilter : PixelFilter<PosterizationParameters>
    {

        private static List<List<double[]>> listOfPalletes = new List<List<double[]>>();

        public PosterizationFilter()
        {
            for (int k = 2; k <= 8; k++)
            {
                List<double> channel_intensities = new List<double>();

                for (int t = 2; t <= k+1; t++)
                {
                    channel_intensities.Add((t-2.0)/(k-1));
                }

                List<double[]> ChannelsList = new List<double[]>();

                for (int r = 0; r < channel_intensities.Count; r++)
                {
                    for (int g = 0; g < channel_intensities.Count; g++)
                    {
                        for (int b = 0; b < channel_intensities.Count; b++)
                        {
                            double[] array = new double[] { channel_intensities[r], channel_intensities[g], channel_intensities[b] };
                            ChannelsList.Add(array);
                        }
                    }
                }

                listOfPalletes.Add(ChannelsList);
            }
        }

        private double ColorGradient(Pixel p, Pixel k)
        {
            return (3 * Math.Pow(k.R - p.R, 2) + 6 * Math.Pow(k.G - p.G, 2) + Math.Pow(k.B - p.B, 2));
        }


        public override Pixel ProcessPixel(Pixel p, PosterizationParameters parameters)
        {
            double min_function = 1000;
 
            List<double[]> ChannelsList = new List<double[]>();

            ChannelsList = listOfPalletes[(int)parameters.GradationsNumber - 2];

            Pixel result_pixel = new Pixel();
            for (int a = 0; a < ChannelsList.Count; a++)
            {
                Pixel k = new Pixel();
                k.R = ChannelsList[a][0]; k.G = ChannelsList[a][1]; k.B = ChannelsList[a][2];
                double new_function = ColorGradient(p, k);
                if (new_function < min_function)
                {
                    min_function = new_function;
                    result_pixel = k;
                }
            }
            return result_pixel;
        }

        public override string ToString()
        {
            return "Постеризация";
        }

    }
}
