using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExcelReader.Models;

public partial class ReportCompanyScore
{
    [Key]
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? Name { get; set; }

    public string? Weight { get; set; }

    public double? Asisystem { get; set; }

    public double? AgenciesScore { get; set; }

    public double? CustomerSatisfaction { get; set; }

    public double? PerformanceResult { get; set; }

    public double? Dsiscore { get; set; }

    public double? FinalScore { get; set; }

    public byte? Rank { get; set; }

    public int? AgencyCount { get; set; }

    public short? PeriodDate { get; set; }
}
