using System;
using System.Collections.Generic;

namespace Lb2_4_Up_store.Models;

public partial class Measure
{
    public int Id { get; set; }

    public string MeasureName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
