using Zenject;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using NUnit.Framework;

public class RandomScaleSphereSceneTest : SceneTestFixture
{
    const string sceneName = "RandomScaleSphereScene";

    [UnityTest]
    [Timeout(5000)]  // �^�C���A�E�g��5�b(5000ms)
    public IEnumerator TestSceneStartup()
    {
        // �V�[���̓ǂݍ��݂����Ȃ����Ƃ̊m�F
        yield return LoadScene(sceneName);

        // �V�[�������Ȃ��J�n���Ă��邱�Ƃ̊m�F
        yield return new WaitForSeconds(1.0f);
    }


    [UnityTest]
    [Timeout(5000)]  // �^�C���A�E�g��5�b(5000ms)
    public IEnumerator TestSphereScaleWithFixedRandomizer()
    {
        float targetScale = 0.45678f;

        // Inject�����Randomizer
        StaticContext.Container
            .BindInterfacesAndSelfTo<FixedRandomizer>()
            .AsSingle()
            .WithArguments<float>(targetScale);

        // �V�[���̓ǂݍ���
        yield return LoadScene(sceneName);

        var resolved = SceneContainer.Resolve<IRandomizer>();
        Assert.IsInstanceOf<FixedRandomizer>(resolved);

        // �e�X�g�Ώۂ�GeameObject���擾
        var targetObject = GameObject.Find("RandomScaleSphere");

        yield return null;  // 1frame������

        // Start()��̃X�P�[�����m�F
        Vector3 localScale = targetObject.transform.localScale;
        Assert.AreEqual(new Vector3(targetScale, targetScale, targetScale), localScale);
    }
}