using System.Linq;
using UnityEngine;

public interface IWeapon
{
    public void Hit(params object[] args);
}

public class SwordWeapon : IWeapon
{
    internal int counter = 0;
    
    public virtual void Hit(params object[] args)
    {
        counter++;
        Debug.Log("Stab! Stab! Stab! by Sword which was reused " + counter + " times;");
    }
}

public class KatanaWeapon : SwordWeapon
{
    public override void Hit(params object[] args)
    {
        counter++;
        string argsStr = "";
        args.ToList().ForEach(x => argsStr += x.ToString() + "  ");
        Debug.Log("Stab! Stab! Stab! by Katana which were reused " + counter + " times + " + argsStr);
    }
}

public class SuperPowerSource : IWeapon
{
    public void Hit(params object[] args)
    {
        string argsStr = "";
        args.ToList().ForEach(x => argsStr += x.ToString() + "  ");
        Debug.Log("Boom! This superpower source is publicly available for all heroes (like Singleton); + " + argsStr);
    }
}