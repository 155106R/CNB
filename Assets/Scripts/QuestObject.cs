using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestObject : MonoBehaviour
{
    protected bool m_activated = false;
    public bool m_activateOnce = true;

    public QuestManager m_questManager;
    public bool isActivated() { return m_activated; }

    void Awake()
    {
        if (!m_questManager) m_questManager = QuestManager.Instance;

        m_questManager.QuestList.Add(this);
    }

    protected bool HasBeenActivated()
    {
        if (m_activated && m_activateOnce) return true;
        else return false;
    }

    //Only called once
    public virtual void Activate()
    {
        if (HasBeenActivated())
            return;

        m_activated = true;
        m_questManager.CheckForQuestDone();
        Debug.Log("Parent QuestObject -> ACTIVATED");
    }
}
