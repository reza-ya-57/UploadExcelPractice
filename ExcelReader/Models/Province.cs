﻿using System;
using System.Collections.Generic;

namespace ExcelReader.Models;

public partial class Province
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
