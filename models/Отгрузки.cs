using System;
using System.Collections.Generic;

namespace kyrovaya.models;

public partial class Отгрузки
{
    public int Idотгрузки { get; set; }

    public int? Idкомплектующего { get; set; }

    public int? Idсклада { get; set; }

    public DateOnly? ДатаОтгрузки { get; set; }

    public int Колво { get; set; }

    public virtual Комплектующие? IdкомплектующегоNavigation { get; set; }

    public virtual Склад? IdскладаNavigation { get; set; }
}
