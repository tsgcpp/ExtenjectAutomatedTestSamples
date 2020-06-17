using Zenject;

public class RandomizerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IRandomizer>()
            .To<Randomizer>()
            .AsSingle()
            .IfNotBound();  // �e��Context�œo�^����Ă�����ABind���Ȃ�
    }
}