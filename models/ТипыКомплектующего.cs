using System;
using System.Collections.Generic;

namespace kyrovaya.models;

public partial class ТипыКомплектующего
{
    public int IdтипаКомплектующего { get; set; }

    public string НазваниеТипаКомплектующего { get; set; } = null!;

    public virtual ICollection<Комплектующие> Комплектующиеs { get; set; } = new List<Комплектующие>();
}
