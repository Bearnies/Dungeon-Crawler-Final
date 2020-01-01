using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    List<BaseStats> Stats { get; set; }
    CharactersStats charactersStats { get; set; }
    void PerformAttack();
    void PerformSpecialAttack();
}
