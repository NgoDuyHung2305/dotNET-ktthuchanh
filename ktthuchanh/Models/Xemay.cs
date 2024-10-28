using System;
using System.Collections.Generic;

namespace ktthuchanh.Models;

public partial class Xemay
{
    public string Idxe { get; set; } = null!;

    public string? Tenxe { get; set; }

    public double? Giaxe { get; set; }

    public string? Mausac { get; set; }

    public string? Mota { get; set; }

    public string? Loai { get; set; }

    public int? Soluong { get; set; }

    public string? Anh { get; set; }
}
