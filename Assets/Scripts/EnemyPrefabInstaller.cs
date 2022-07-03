using Zenject;

public class EnemyPrefabInstaller : MonoInstaller<EnemyPrefabInstaller>
{
    public override void InstallBindings()
    {
        // TODO:
        // List<Type> weaponList = new List<Type>() { typeof(SwordWeapon), typeof(KatanaWeapon), typeof(SuperPowerSource) };
        // int random = Random.Range(0, weaponList.Count - 1);
        // Type type = weaponList[random].GetElementType();
        // Container.
        //     Bind<IWeapon>().
        //     To<type>().
        //     AsTransient()
        //     ;
        
        Container.
            Bind<IWeapon>()
            .To<SwordWeapon>()
            .AsTransient()
            // .WithConcreteId("EnemyWeapon")
            ;
    }
}