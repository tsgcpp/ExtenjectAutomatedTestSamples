using Zenject;

/// <summary>
/// 毎回固定値を返すRandomizer
/// </summary>
public class FixedRandomizer : IRandomizer
{
    [InjectOptional]  // Injectにより数値の変更可能
    public float FixedValue { get; set; } = 0.0f;

    /// <summary>
    /// 乱数ではなく固定値を返す
    /// </summary>
    public float value => FixedValue;
}
