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
    private SignalBus signalBus;

    private void Awake()
    {
        print($"My name is {gameObject.name}, I have awakened from prefab with {weapon.ToString()} and I am here to kiss I mean kill you!");
        StartCoroutine(Hit());
    }
    
    [Inject(Id = "EnemyWeapon")] public void InjectDependencies(IWeapon weapon, SignalBus signalBus)
    {
        this.weapon = weapon ?? throw new System.ArgumentNullException(nameof(weapon));
        this.signalBus = signalBus;
    }

    private IEnumerator Hit()
    {
        yield return new WaitForSeconds(3f);
        signalBus.Fire(new PlayerHitSignal() { weapon = this.weapon, hp = -10 });
    }
}