using Zenject;
using NUnit.Framework;

[TestFixture]
public class FixedRandomizerTest : ZenjectUnitTestFixture
{
    // �e�X�g�Ώ�
    [Inject]
    IRandomizer _target;

    const float injectedValue = 0.75f;

    [SetUp]
    public void CommonInstall()
    {
        // Bind�̎��{
        Container
            .Bind<IRandomizer>()
            .To<FixedRandomizer>()
            .AsSingle()
            .WithArguments<float>(injectedValue);  // FixedRandomizer.FixedValue��Inject����float�l

        // DI�̎��{
        Container.Inject(this);
    }

    /// <summary>
    /// Inject���ʂ̌���
    /// </summary>
    [Test]
    public void TestInjectType()
    {
        Assert.IsInstanceOf<FixedRandomizer>(_target);
    }

    /// <summary>
    /// Inject���ꂽ�Œ�l��Ԃ����Ƃ̌���
    /// </summary>
    [Test]
    public void TestInjectedValue()
    {
        Assert.AreEqual(injectedValue, _target.value, 0.0f);
    }

    /// <summary>
    /// �w�肵���Œ�l��Ԃ����Ƃ̌���
    /// </summary>
    [Test]
    public void TestFixedValue()
    {
        (_target as FixedRandomizer).FixedValue = 0.25f;
        Assert.AreEqual(0.25f, _target.value, 0.0f);
    }
}