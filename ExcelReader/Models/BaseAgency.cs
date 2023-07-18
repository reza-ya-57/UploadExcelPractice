using System;
using System.Collections.Generic;

namespace ExcelReader.Models;

public partial class BaseAgency
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long CompanyId { get; set; }

    public string CityId { get; set; } = null!;

    public string CityName { get; set; } = null!;
}
