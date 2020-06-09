﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public interface IPieRepository
    {
         IEnumerable<Pie> AllPies { get;}
         IEnumerable<Pie> PiesOfTheWeek { get;}
         Pie GetPieById(Guid PieId);
         void CreatePie(Pie pie);
        void RemovePie(Pie pie);
        void EditPie(Pie the_pie,Pie pie);
        void MakePieOfTheWeek(Pie pie);
    }
}
