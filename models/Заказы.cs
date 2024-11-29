using System;
using System.Collections.Generic;

namespace kyrovaya.models;

public partial class Заказы
{
    public int Idзаказа { get; set; }

    public int Idкомплектующего { get; set; }

    public int Idсклада { get; set; }

    public int Iduser { get; set; }

    public DateTime ДатаЗаказа { get; set; }

    public int Количество { get; set; }

    public virtual User IduserNavigation { get; set; } = null!;

    public virtual Комплектующие IdкомплектующегоNavigation { get; set; } = null!;

    public virtual Склад IdскладаNavigation { get; set; } = null!;

}
