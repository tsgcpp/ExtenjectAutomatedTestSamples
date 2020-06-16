using Zenject;
using NUnit.Framework;

[TestFixture]
public class FixedRandomizerTest : ZenjectUnitTestFixture
{
    // テスト対象
    [Inject]
    IRandomizer _target;

    const float injectedValue = 0.75f;

    [SetUp]
    public void CommonInstall()
    {
        // Bindの実施
        Container
            .Bind<IRandomizer>()
            .To<FixedRandomizer>()
            .AsSingle()
            .WithArguments<float>(injectedValue);  // FixedRandomizer.FixedValueにInjectするfloat値

        // DIの実施
        Container.Inject(this);
    }

    /// <summary>
    /// Inject結果の検証
    /// </summary>
    [Test]
    public void TestInjectType()
    {
        Assert.IsInstanceOf<FixedRandomizer>(_target);
    }

    /// <summary>
    /// Injectされた固定値を返すことの検証
    /// </summary>
    [Test]
    public void TestInjectedValue()
    {
        Assert.AreEqual(injectedValue, _target.value, 0.0f);
    }

    /// <summary>
    /// 指定した固定値を返すことの検証
    /// </summary>
    [Test]
    public void TestFixedValue()
    {
        (_target as FixedRandomizer).FixedValue = 0.25f;
        Assert.AreEqual(0.25f, _target.value, 0.0f);
    }
}