using UnityEngine;

/// <summary>
/// A concrete implementation of FlowNodeSOBase that adds a delay before next node.
/// </summary>
public class FlowNodeSO_Delay : FlowNodeSOBase
{
    #region -----Fields-----

    [Header("Settings")]

    [SerializeField] private float _delayDuration = -1f;

    [System.NonSerialized] private float _delayTimer;

    #endregion -----|-----


    #region -----Lifecycle-----

#if UNITY_EDITOR
    // Editor
    private void OnValidate()
    {
        if (_delayDuration < 0f)
        { return; }

        this.name = $"Delay_{_delayDuration}s";

        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif

    #endregion -----|-----


    #region -----Public API-----

    public override void Start()
    {
        if (_delayDuration < 0f)
        { return; }

        _delayTimer = _delayDuration;
    }

    public override void Execute(out bool hasFinished)
    {
        hasFinished = true;

        if (_delayDuration < 0f)
        { return; }

        _delayTimer -= Time.deltaTime;

        hasFinished = _delayTimer < 0f;
    }

    #endregion -----|-----
}