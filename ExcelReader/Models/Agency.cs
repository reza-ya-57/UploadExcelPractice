using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExcelReader.Models;

public partial class Agency
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long CityId { get; set; }

    public long CompanyId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;
}
