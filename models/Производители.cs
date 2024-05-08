using System;
using System.Collections.Generic;

namespace kyrovaya.models;

public partial class Производители
{
    public int Idпроизводителя { get; set; }

    public string НазваниеПроизводителя { get; set; } = null!;

    public virtual ICollection<Комплектующие> Комплектующиеs { get; set; } = new List<Комплектующие>();
}
