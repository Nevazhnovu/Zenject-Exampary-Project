using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Zenject;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private IWeapon weapon;

    private void Awake()
    {
        print($"My name is {gameObject.name}, I have awakened from prefab with {weapon.ToString()} and I am here to kiss I mean kill you!");
    }
    
    [Inject(Id = "EnemyWeapon")] public void InjectDependencies(IWeapon weapon)
    {
        this.weapon = weapon ?? throw new System.ArgumentNullException(nameof(weapon));
    }
}