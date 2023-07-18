using System;
using System.Collections.Generic;

namespace ExcelReader.Models;

public partial class City
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long ProvinceId { get; set; }

    public virtual ICollection<Agency> Agencies { get; set; } = new List<Agency>();

    public virtual Province Province { get; set; } = null!;
}
