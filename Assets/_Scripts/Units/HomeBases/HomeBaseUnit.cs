using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Interfaces.Interactables;
using AutoChessTD.Interfaces;


namespace AutoChessTD.Units.HomeBases
{
    public class HomeBaseUnit : Unit
    {
        [Header("Stats")]
        [SerializeField] private float health = 10;

        public override void Awake()
        {
            base.Awake();
            base.OnUnitDetected += UnitDetected;
        }


        private void UnitDetected(Unit unit)
        {
            TakeDamage(unit.Damage);
            Destroy(unit.gameObject);
        }

        
    }
}
