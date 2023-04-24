using UnityEngine;

// This class contains general information describing an actor (player or enemies).
// 这个类是用来给角色的模板类(包括Player和敌人)
// It is mostly used for AI detection logic and determining if an actor is friend or foe
//它主要用于AI检测逻辑和确定一个行动者是友军还是敌
public class Actor : MonoBehaviour
{
    [Tooltip("表示Actor所属的团队或派系。同一派系的Actor彼此友好。")]
    public int affiliation;
    [Tooltip("表示其他Actor在攻击该Actor时瞄准的位置。")]
    public Transform aimPoint;

    ActorsManager m_ActorsManager;

    private void Start()
    {
        //FindObjectOfType它需要遍历整个场景来查找符合条件的对象,不建议使用。
        m_ActorsManager = GameObject.FindObjectOfType<ActorsManager>();
        //DebugUtility.HandleErrorIfNullFindObject<ActorsManager, Actor>(m_ActorsManager, this);

        // 注册一个Actor
        if (!m_ActorsManager.actors.Contains(this))
        {
            m_ActorsManager.actors.Add(this); 
        }
    }

    private void OnDestroy()
    {
        // 移除一个Actor
        if (m_ActorsManager)
        {
            m_ActorsManager.actors.Remove(this);
        }
    }
}
