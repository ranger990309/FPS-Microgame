using UnityEngine;

public static class DebugUtility
{

    /// <summary>
    /// 定位到哪个物哪个组件代码中需要什么组件没有
    /// </summary>
    /// <typeparam name="TO"></typeparam>
    /// <typeparam name="TS"></typeparam>
    /// <param name="component"></param>
    /// <param name="source"></param>
    /// <param name="onObject"></param>
    public static void HandleErrorIfNullGetComponent<TO, TS>(Component component, Component source, GameObject onObject)
    {
#if UNITY_EDITOR
        if (component == null)
        {
            Debug.LogError("Error: 定位到哪个物哪个组件代码中需要什么组件没有,Component of type " + typeof(TS) + " on GameObject " + source.gameObject.name +
                " expected to find a component of type " + typeof(TO) + " on GameObject " + onObject.name + ", but none were found.");
        }
#endif
    }

    /// <summary>
    /// 定位到哪个物哪个组件代码中需要什么组件没有
    /// </summary>
    /// <typeparam name="TO"></typeparam>
    /// <typeparam name="TS"></typeparam>
    /// <param name="obj"></param>
    /// <param name="source"></param>
    public static void HandleErrorIfNullFindObject<TO, TS>(UnityEngine.Object obj, Component source)
    {
#if UNITY_EDITOR
        if (obj == null)
        {
            Debug.LogError("Error: 定位到哪个物哪个组件代码中需要什么组件没有.Component of type " + typeof(TS) + " on GameObject " + source.gameObject.name +
                " expected(期待) to find an object of type " + typeof(TO) + " in the scene, but none were found.");
        }
#endif
    }

    public static void HandleErrorIfNoComponentFound<TO, TS>(int count, Component source, GameObject onObject)
    {
#if UNITY_EDITOR
        if (count == 0)
        {
            Debug.LogError("Error: Component of type " + typeof(TS) + " on GameObject " + source.gameObject.name +
                " expected to find at least one component of type " + typeof(TO) + " on GameObject " + onObject.name + ", but none were found.");
        }
#endif
    }

    public static void HandleWarningIfDuplicateObjects<TO, TS>(int count, Component source, GameObject onObject)
    {
#if UNITY_EDITOR
        if (count > 1)
        {
            Debug.LogWarning("Warning: Component of type " + typeof(TS) + " on GameObject " + source.gameObject.name +
                " expected to find only one component of type " + typeof(TO) + " on GameObject " + onObject.name + ", but several were found. First one found will be selected.");
        }
#endif
    }
}
