using UnityEngine;

/// <summary>
/// A class that implements a flow node.
/// </summary>
[CreateAssetMenu(fileName = "FlowNodeSO_", menuName = "MySO/FlowControl/FlowNodeSO", order = 0)]
public class FlowNodeSO : FlowNodeSOBase
{
    #region -----Public API-----

    public System.Action OnStart { get; set; }
    public System.Func<bool> OnExecuteAndHasFinished { get; set; }

    public override void Start()
    {
        OnStart?.Invoke();
    }

    public override void Execute(out bool hasFinished)
    {
        hasFinished = true;

        if (OnExecuteAndHasFinished is null)
        { return; }

        hasFinished = OnExecuteAndHasFinished.Invoke();
    }

    #endregion -----|-----
}