using Zenject;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using NUnit.Framework;

public class RandomScaleTest : ZenjectIntegrationTestFixture
{
    // �e�X�g�Ώ�
    [Inject]
    RandomScaler _target;

    const float fixedScale = 0.12345f;

    /// <summary>
    /// �e�X�g���ɋ��ʂ�Install����
    /// </summary>
    void CommonInstall()
    {
        PreInstall();

        // Inject�����Randomizer
        Container
            .BindInterfacesAndSelfTo<FixedRandomizer>()
            .AsSingle()
            .WithArguments<float>(fixedScale);  // Scale�l��float�Ƃ���Bind���AFixedRandomizer.FixedValue��Inject

        // RandomScaler���A�^�b�`���ꂽGameObject�̐�������Bind
        Container
            .Bind<RandomScaler>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();

        // ���̏�����_target��Inject
        PostInstall();
    }

    /// <summary>
    /// �����X�P�[����1�ł��邱�Ƃ̃e�X�g
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
    /// Start()��̃X�P�[����fixedScale�ł��邱�Ƃ̃e�X�g
    /// </summary>
    [UnityTest]
    public IEnumerator TestAfterStartScale()
    {
        CommonInstall();

        yield return null;  // 1frame������

        Vector3 localScale = _target.gameObject.transform.localScale;
        Assert.AreEqual(new Vector3(fixedScale, fixedScale, fixedScale), localScale);
    }
}