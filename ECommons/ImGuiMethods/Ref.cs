﻿using ECommons.LazyDataHelpers;
using ECommons.Logging;
using ECommons.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.ImGuiMethods;
public static class Ref<T>
{
    static Ref()
    {
        Purgatory.Add(typeof(Ref<T>));
    }

    private static Dictionary<string, Box<T>> Storage = [];
    public static ref T? Get(string s, T? defaultValue = default)
    {
        if (Storage.TryGetValue(s, out var ret))
        {
            return ref ret.Value;
        }
        else
        {
            Storage[s] = new(defaultValue);
            if (defaultValue == null && typeof(T) == typeof(string))
            {
                Storage[s].SetFoP("Value", string.Empty);
            }
            return ref Storage[s].Value;
        }
    }
}
