using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExcelReader.Models;

public partial class Company
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public byte CompanyType { get; set; }

    public virtual ICollection<Agency> Agencies { get; set; } = new List<Agency>();
}
