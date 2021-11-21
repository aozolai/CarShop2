﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public interface ICarStorage
    {
        public void SaveCarList(List<Car> carList);
        public List<Car> ReadCarList();
    }
}
