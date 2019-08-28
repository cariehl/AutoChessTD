using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface that dictates this can be suicided on
public interface ICanBeSuicided
{
    void SuicideDamage(float damage);
}
