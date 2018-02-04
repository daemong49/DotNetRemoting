using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyProduct;

namespace PointBiz
{
    [Serializable]
    public class PointBuilder : IAddPointBuild
    {
        public int CalculateAddPoint(decimal realPayAmt, decimal addPointRate, decimal plusPointRate)
        {
            return (int) Math.Round(realPayAmt * (addPointRate + plusPointRate  )  / 100, 0);
        }
    }
}
