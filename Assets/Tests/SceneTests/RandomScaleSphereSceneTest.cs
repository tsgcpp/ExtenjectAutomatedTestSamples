using Zenject;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using NUnit.Framework;

public class RandomScaleSphereSceneTest : SceneTestFixture
{
    const string sceneName = "RandomScaleSphereScene";

    [UnityTest]
    [Timeout(5000)]  // タイムアウトは5秒(5000ms)
    public IEnumerator TestSceneStartup()
    {
        // シーンの読み込みが問題ないことの確認
        yield return LoadScene(sceneName);

        // シーンが問題なく開始していることの確認
        yield return new WaitForSeconds(1.0f);
    }


    [UnityTest]
    [Timeout(5000)]  // タイムアウトは5秒(5000ms)
    public IEnumerator TestSphereScaleWithFixedRandomizer()
    {
        float targetScale = 0.45678f;

        // InjectされるRandomizer
        StaticContext.Container
            .BindInterfacesAndSelfTo<FixedRandomizer>()
            .AsSingle()
            .WithArguments<float>(targetScale);

        // シーンの読み込み
        yield return LoadScene(sceneName);

        var resolved = SceneContainer.Resolve<IRandomizer>();
        Assert.IsInstanceOf<FixedRandomizer>(resolved);

        // テスト対象のGeameObjectを取得
        var targetObject = GameObject.Find("RandomScaleSphere");

        yield return null;  // 1frame動かす

        // Start()後のスケールを確認
        Vector3 localScale = targetObject.transform.localScale;
        Assert.AreEqual(new Vector3(targetScale, targetScale, targetScale), localScale);
    }
}