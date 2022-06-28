using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    public override void InstallBindings()
    {
        // AsTransient() - creates separate instance of object each time it's injected
        // AsSingle() - Singleton; almost the same as AsCached, except that it will sometimes throw exceptions if there already exists a binding for ResultType.
        // AsCached() - creates instance of object for every unique Contract Type then re-using it each time it's injected
        
        Container.
            Bind<IWeapon>().
            To<SwordWeapon>().
            AsTransient().
            OnInstantiated(LogCallback)
            //OnInstantiated<SwordWeapon>(LogCallback) // causes bug: ZenjectException: Assert hit! Invalid generic argument to OnInstantiated! ValidationMarker must be type SwordWeapon
            //                                         // but works fine in Play mode. I consider it's a Zenject's fault 
            ;
        
        Container.
            Bind<IWeapon>().
            To<KatanaWeapon>().
            AsCached().
            OnInstantiated(LogCallback).
            When(x => 
                    x.MemberName == "secondaryWeapon"
                )
            ;
        
        Container.
            Bind<SuperPowerSource>().
            To<SuperPowerSource>().
            AsSingle().
            OnInstantiated(LogCallback)
            // TODO:
            //.WithArguments()
            //.WhenInjectedInto<>()
            // Construction methods: FromNew (default), FromInstance, FromFactory
            ;
    }

    private void LogCallback(InjectContext arg1, object arg2)
    {
        Debug.Log($"CallBack invoked with generic object arg2= { arg2.ToString() }");
    }

    private void LogCallback(InjectContext arg1, IWeapon weapon)
    {
        Debug.Log("CallBack invoked with IWeapon");
    }
    
    private void LogCallback(InjectContext arg1, SwordWeapon weapon)
    {
        Debug.Log("CallBack invoked with SwordWeapon");
    }
}