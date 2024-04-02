using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters
{
    public class PosterizationParameters : IParameters
    {
        public double GradationsNumber { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Число градаций",
                    MinValue = 2,
                    MaxValue = 8,
                    DefaultValue = 4,
                    Increment = 1
                }
            };
        }

        public void SetValues(double[] values)
        {
            GradationsNumber = values[0];
        }
    }
}
