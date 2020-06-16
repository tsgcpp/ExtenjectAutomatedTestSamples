using Zenject;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using NUnit.Framework;

public class RandomScaleTest : ZenjectIntegrationTestFixture
{
    // テスト対象
    [Inject]
    RandomScaler _target;

    const float fixedScale = 0.12345f;

    /// <summary>
    /// テスト毎に共通のInstall処理
    /// </summary>
    void CommonInstall()
    {
        PreInstall();

        // InjectされるRandomizer
        Container
            .BindInterfacesAndSelfTo<FixedRandomizer>()
            .AsSingle()
            .WithArguments<float>(fixedScale);  // Scale値をfloatとしてBindし、FixedRandomizer.FixedValueにInject

        // RandomScalerがアタッチされたGameObjectの生成してBind
        Container
            .Bind<RandomScaler>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();

        // この処理で_targetにInject
        PostInstall();
    }

    /// <summary>
    /// 初期スケールが1であることのテスト
    /// </summary>
    [UnityTest]
    public IEnumerator TestInitScale()
    {
        CommonInstall();

        Vector3 localScale = _target.gameObject.transform.localScale;
        Assert.AreEqual(Vector3.one, localScale);

        yield break;
    }

    /// <summary>
    /// Start()後のスケールがfixedScaleであることのテスト
    /// </summary>
    [UnityTest]
    public IEnumerator TestAfterStartScale()
    {
        CommonInstall();

        yield return null;  // 1frame動かす

        Vector3 localScale = _target.gameObject.transform.localScale;
        Assert.AreEqual(new Vector3(fixedScale, fixedScale, fixedScale), localScale);
    }
}