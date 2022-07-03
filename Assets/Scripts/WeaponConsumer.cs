using UnityEngine;
using Zenject;

public class WeaponConsumer : MonoBehaviour
{
    /// Field Injection Pattern
    /// Can be private or public
    /// Field injection occurs immediately after the constructor is called
    /// Cons: not easy to read
    /* [Inject] */ private IWeapon weapon, secondaryWeapon;
    private SuperPowerSource superpower;

    /// Property Injection Pattern
    /// AS above +
    /// the setter can be private or public in this case.
    /// Cons:
    /// it might be public therefore visible outside the class
    /* [Inject] */ public IWeapon Weapon
    {
        private set => weapon = value;
        get => weapon;
    }

    /// Constructor Injection Pattern;
    /// Considered the best practice while using non-MonoBehaviour 
    /// Cons: 
    /// Is not usable with MonoBehaviour since MonoBehaviours cannot have constructors.
    /// Pros:
    /// Easy to understand all the dependencies of a class when another programmer is reading the code
    /// More obvious when a class has too many dependencies and should therefore be split up 
    public WeaponConsumer(IWeapon weapon)
    {
        this.weapon = weapon ?? throw new System.ArgumentNullException(nameof(weapon));
    }
    
    /// Method Injection Pattern;
    /// Considered THE BEST PRACTICE while using MonoBehaviours
    /// AS above +
    /// There can be any number of inject methods
    /// Inject methods are called after all other injection types
    [Inject] public void InjectDependencies(IWeapon weapon, IWeapon secondaryWeapon, SuperPowerSource superpower)
    {
        this.weapon = weapon ?? throw new System.ArgumentNullException(nameof(weapon));
        this.secondaryWeapon = secondaryWeapon ?? throw new System.ArgumentNullException(nameof(secondaryWeapon));
        this.superpower = superpower ?? throw new System.ArgumentNullException(nameof(superpower));
    }
    
    private void Awake()
    {
        weapon.Hit();
        secondaryWeapon.Hit("You lost 100 HP");
        superpower.Hit("You used 100 mana from common pool.");
    }

    public void SignalReceived(PlayerHitSignal signal)
    {
        Debug.Log($"Oh no I'm {name} and hit with {signal.weapon}, {signal.hp} hp lost. Argh!");
    }
}