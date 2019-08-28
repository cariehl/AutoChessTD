using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Interfaces.Interactables;
using AutoChessTD.Interfaces;


namespace AutoChessTD.Units.HomeBases
{
    public class HomeBaseUnit : Unit, ICanBeSuicided
    {
        [Header("Stats")]
        [SerializeField] private float health = 10;

        public void SuicideDamage(float damage)
        {
            this.TakeDamage(damage);
        }
    }
}