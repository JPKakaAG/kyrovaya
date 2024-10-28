using System;
using System.Collections.Generic;

namespace kyrovaya.models;

public partial class Комплектующие
{
    public int Idкомплектующего { get; set; }

    public string НазваниеКомплектующего { get; set; } = null!;

    public int? Idпроизводителя { get; set; }

    public int? IdтипаКомплектующего { get; set; }

    public decimal Цена { get; set; }

    public int? Idсклада { get; set; }

    public int КолвоНаСкладе { get; set; }

    public virtual Производители? IdпроизводителяNavigation { get; set; }

    public virtual Склад? IdскладаNavigation { get; set; }

    public virtual ТипыКомплектующего? IdтипаКомплектующегоNavigation { get; set; }

    public virtual ICollection<Заказы> Заказыs { get; set; } = new List<Заказы>();

    public virtual ICollection<Отгрузки> Отгрузкиs { get; set; } = new List<Отгрузки>();

    public virtual ICollection<Приемка> Приемкаs { get; set; } = new List<Приемка>();
}
