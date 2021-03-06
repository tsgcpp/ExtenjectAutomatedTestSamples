using Zenject;

public class RandomizerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IRandomizer>()
            .To<Randomizer>()
            .AsSingle()
            .IfNotBound();  // 親のContextで登録されていたら、Bindしない
    }
}