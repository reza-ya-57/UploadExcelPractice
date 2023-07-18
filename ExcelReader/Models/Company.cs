using System;
using System.Collections.Generic;

namespace ExcelReader.Models;

public partial class Company
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public byte CompanyType { get; set; }

    public virtual ICollection<Agency> Agencies { get; set; } = new List<Agency>();
}
