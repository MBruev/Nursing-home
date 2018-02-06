using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public enum UnitType
    {
        NeutralNoAggresive,
        NeutralAggresive,
        Warden, // надзиратель
        Waterboy, // подхалим
    };
    public string Name; // Имя персонажа на карте
    public string Description; // Описание персонажа
    public float BaseHealth; // Базовое здоровье
    public float CurrentHealth; // Текущее здоровье
    public UnitType Type; // Тип персонажа

    public UnitType NeutralAggresive { get; private set; }

    public Unit()
    {
        Description = "";
        Name = "<Unknown>";
        CurrentHealth = BaseHealth = 100.0f;
        Type = NeutralAggresive;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }
}
