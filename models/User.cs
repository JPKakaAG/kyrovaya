﻿using System;
using System.Collections.Generic;

namespace kyrovaya.models;

public partial class User
{
    public int Iduser { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int Idrole { get; set; }

    public string Password { get; set; } = null!;

    public string Login { get; set; } = null!;

    public virtual Role IdroleNavigation { get; set; } = null!;

    public virtual ICollection<Заказы> Заказыs { get; set; } = new List<Заказы>();
}
