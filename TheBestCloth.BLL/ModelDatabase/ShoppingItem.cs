﻿using System.Collections.Generic;

namespace TheBestCloth.BLL.ModelDatabase
{
    public class ShoppingItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public int Price { get; set; }
    }
}
