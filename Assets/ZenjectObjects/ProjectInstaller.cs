using System;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller<ProjectInstaller>
{
    ///ProjectContext calls it's installers, before every other installers, only once at the project startup
    public override void InstallBindings()
    {
        NotMonoInstaller.Install(Container);
    }
}

public class NotMonoInstaller : Installer<NotMonoInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<WannabeMonoBehaviour>().AsSingle();

        //signals
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<PlayerHitSignal>();
        Container.BindSignal<PlayerHitSignal>().
            ToMethod(s => Debug.Log($"PlayerHitSignal fired! {s.weapon} used, {s.hp} affected"));
        Container.BindSignal<PlayerHitSignal>()
            .ToMethod<WeaponConsumer>(wc => wc.SignalReceived)
            .FromNew(); //the handler classes is not accessed anywhere else in the container
    }
}

public class WannabeMonoBehaviour : IInitializable, ITickable, IFixedTickable, ILateTickable, IDisposable //Zenject Interfaces
{
    public void Initialize()
    {
        Debug.Log("Initialize (as Start): prepare battlefield  for entire project...");
    }

    public void Tick()
    {
        Debug.Log("Tick (as Update): to broom battlefield for entire project...");
    }

    public void FixedTick()
    {        
        Debug.Log("FixedTick (as FixedUpdate): wash battlefield for entire project...");
    }

    public void LateTick()
    {
        Debug.Log("LateTick (as LateUpdate): smoke break after cleaning for entire project...");
    }

    public void Dispose()
    {
        Debug.Log("Dispose (as OnDestroy): janitor goes home for entire project...");
    }
}