using UnityEngine;

/// <summary>
/// A class that contains a list of FlowNodeSOBase objects and executes them in parallel.
/// </summary>
[CreateAssetMenu(fileName = "FlowNodeGroupSO_Parallel_", menuName = "MySO/FlowControl/Groups/Parallel", order = 0)]
public class FlowNodeGroupSO_Parallel : FlowNodeGroupSO
{
    #region -----Public API-----

    public override void Start()
    {
        if (ListCount == 0)
        { return; }

        for (int i = 0; i < ListCount; i++)
        {
            _nodeList[i].Start();
        }
    }

    public override void Execute(out bool hasFinished)
    {
        hasFinished = true;

        if (ListCount == 0)
        { return; }

        for (int i = 0; i < ListCount; i++)
        {
            _nodeList[i].Execute(out var hasChildFinished);

            hasFinished &= hasChildFinished;
        }

        return;
    }

    #endregion -----|-----
}