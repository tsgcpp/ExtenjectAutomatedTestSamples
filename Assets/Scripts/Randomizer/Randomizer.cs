using UnityEngine;

/// <summary>
/// 通常の乱数生成器
/// </summary>
public class Randomizer : IRandomizer
{
    public float value => Random.Range(0.0f, 1.0f);
}
