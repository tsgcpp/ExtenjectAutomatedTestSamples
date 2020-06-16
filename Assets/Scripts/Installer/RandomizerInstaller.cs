using Zenject;

public class RandomizerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IRandomizer>()
            .To<Randomizer>()
            .AsSingle()
            .IfNotBound();  // e‚ÌContext‚Å“o˜^‚³‚ê‚Ä‚¢‚½‚çABind‚µ‚È‚¢
    }
}