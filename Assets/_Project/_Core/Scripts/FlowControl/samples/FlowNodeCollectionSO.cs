using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A base class for all flow node collections.
/// </summary>
public abstract class FlowNodeCollectionSO : ScriptableObject
{
#if UNITY_EDITOR

    [ContextMenu("CreateSO")]
    protected void CreateSOInEditor() => CreateSO();

    [ContextMenu("DeleteNodeInList")]
    protected void DeleteNodeInListInEditor() => DeleteNodeInList();

    [SerializeField] protected int _indexToDelete = -1;

    protected abstract void CreateSO();
    protected abstract void DeleteNodeInList();

#endif
}

/// <summary>
/// A generic class for all flow node collections.
/// </summary>
public abstract class FlowNodeCollectionSO<T> : FlowNodeCollectionSO where T : FlowNodeSOBase
{
    #region -----Fields-----

    [SerializeField] protected List<T> _nodeList;

    #endregion -----|-----


#if UNITY_EDITOR

    protected override void CreateSO()
    {
        var so = CreateInstance<T>();
        so.name = typeof(T).Name;

        _nodeList.Add(so);

        UnityEditor.AssetDatabase.AddObjectToAsset(so, this);

        UnityEditor.EditorUtility.SetDirty(this);
        UnityEditor.EditorUtility.SetDirty(so);

        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
    }

    protected override void DeleteNodeInList()
    {
        DeleteNodeInList(ref _indexToDelete);
    }

    protected void DeleteNodeInList(ref int index)
    {
        if (index < 0 || index >= _nodeList.Count)
        {
            Debug.LogError("Invalid index");
            return;
        }

        var so = _nodeList[index];

        _nodeList.RemoveAt(index);

        UnityEditor.Undo.DestroyObjectImmediate(so);

        index = -1;

        UnityEditor.EditorUtility.SetDirty(this);

        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
    }

#endif
}