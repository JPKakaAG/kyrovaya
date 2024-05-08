using System;
using System.Collections.Generic;

namespace kyrovaya.models;

public partial class Приемка
{
    public int Idприемки { get; set; }

    public int? Idкомплектующего { get; set; }

    public int? Idсклада { get; set; }

    public DateOnly? ДатаПоступления { get; set; }

    public int КолвоПоступивших { get; set; }

    public virtual Комплектующие? IdкомплектующегоNavigation { get; set; }

    public virtual Склад? IdскладаNavigation { get; set; }
}
