using UnityEngine;

/// <summary>
/// A class that contains a list of FlowNodeSOBase objects and executes them in order.
/// </summary>
[CreateAssetMenu(fileName = "FlowNodeGroupSO_", menuName = "MySO/FlowControl/Groups/Ordered", order = 0)]
public class FlowNodeGroupSO_Ordered : FlowNodeGroupSO
{
    public override void Start()
    {
        if (CurrentIndex == -1)
        { return; }

        _currentIndex = 0;
        _nodeList[_currentIndex].Start();
    }

    public override void Execute(out bool hasFinished)
    {
        hasFinished = true;

        if (CurrentIndex == -1)
        { return; }

        while (_currentIndex < ListCount && hasFinished)
        {
            _nodeList[CurrentIndex].Execute(out hasFinished);

            if (!hasFinished)
            { return; }

            _currentIndex++;
            if (_currentIndex < ListCount)
            { _nodeList[_currentIndex].Start(); }
        }

        hasFinished = true;
    }
}