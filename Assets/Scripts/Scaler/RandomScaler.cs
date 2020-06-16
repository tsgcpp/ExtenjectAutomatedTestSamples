using UnityEngine;
using Zenject;

public class RandomScaler : MonoBehaviour
{
    [Inject]
    private IRandomizer Randomizer { get; set; }

    void Start()
    {
        // 乱数によってスケールを変更
        float scale = Randomizer.value;
        this.transform.localScale = new Vector3(scale, scale, scale);
    }
}
