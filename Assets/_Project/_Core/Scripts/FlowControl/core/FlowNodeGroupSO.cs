using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A base class for all flow node groups.
/// </summary>
public abstract class FlowNodeGroupSO : FlowNodeSOBase
{
    #region -----Fields-----

    [SerializeField] protected List<FlowNodeSOBase> _nodeList;

    [System.NonSerialized] protected int _currentIndex;

    #endregion -----|-----


    #region -----Public API-----

    public int ListCount
    {
        get
        {
            if (_nodeList == null)
            { return 0; }

            return _nodeList.Count;
        }
    }

    public int CurrentIndex
    {
        get
        {
            if (ListCount == 0)
            { return -1; }

            return _currentIndex;
        }
    }

    public override void SetManager(FlowControlManager value)
    {
        base.SetManager(value);

        for (int i = 0; i < ListCount; i++)
        {
            _nodeList[i].SetManager(value);
        }
    }

    #endregion -----|-----


#if UNITY_EDITOR

    [ContextMenu("CreateAnOrderedNodeGroup")]
    private void CreateAnOrderedNodeGroup() => CreateNodeGroup<FlowNodeGroupSO_Ordered>("");

    [ContextMenu("CreateAParallelNodeGroup")]
    private void CreateAParallelNodeGroup() => CreateNodeGroup<FlowNodeGroupSO_Parallel>("para");

    private void CreateNodeGroup<T>(string postfix) where T : FlowNodeGroupSO
    {
        var asset = CreateInstance<T>();

        var path = UnityEditor.AssetDatabase.GetAssetPath(this);
        var folder = path.Substring(0, path.LastIndexOf('/'));

        UnityEditor.AssetDatabase.CreateAsset(asset, Path.Combine(folder,
            string.IsNullOrEmpty(postfix) ?
                $"{name}_{_nodeList.Count + 1}.asset" :
                $"{name}_{_nodeList.Count + 1}_{postfix}.asset"));

        _nodeList.Add(asset);

        UnityEditor.EditorUtility.SetDirty(this);
        UnityEditor.EditorUtility.SetDirty(asset);
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
    }

#endif
}