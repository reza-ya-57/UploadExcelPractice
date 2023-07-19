using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExcelReader.Models;

public partial class BaseAgency
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long CompanyId { get; set; }

    public string CityId { get; set; } = null!;

    public string CityName { get; set; } = null!;
}
