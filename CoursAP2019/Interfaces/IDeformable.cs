using CoursAP2019.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Interfaces
{
    public interface IDeformable
    {
        Figure Deformation(double coeffH, double coeffV);
    }
}
