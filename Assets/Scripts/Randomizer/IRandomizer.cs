/// <summary>
/// 乱数生成器のインターフェース
/// 乱数を[0.0f, 1.0f]で返す
/// </summary>
public interface IRandomizer
{
    /// <summary>
    /// 乱数を[0.0f, 1.0f]で返す
    /// </summary>
    float value { get; }
}
