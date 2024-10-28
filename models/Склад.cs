using System;
using System.Collections.Generic;

namespace kyrovaya.models;

public partial class Склад
{
    public int Idсклада { get; set; }

    public string Location { get; set; } = null!;

    public virtual ICollection<Заказы> Заказыs { get; set; } = new List<Заказы>();

    public virtual ICollection<Комплектующие> Комплектующиеs { get; set; } = new List<Комплектующие>();

    public virtual ICollection<Отгрузки> Отгрузкиs { get; set; } = new List<Отгрузки>();

    public virtual ICollection<Приемка> Приемкаs { get; set; } = new List<Приемка>();
}
