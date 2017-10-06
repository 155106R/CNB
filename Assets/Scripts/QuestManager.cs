using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestManager : SingletonTemplate<QuestManager>
{
    protected QuestManager() { } // guarantee this will be always a singleton only - can't use the constructor!
    public UnityEvent OnAllQuestsDone;
    public List<QuestObject> QuestList;

    public bool activateOnce = true;
    private bool m_activated = false;

    public void DEBUG_DONEDED_TESTY()
    {
        Debug.Log("ALL DONE LUL");
    }

    public bool CheckForQuestDone()
    {
        foreach (QuestObject qo in QuestList)
            if (!qo.isActivated())
                return false;

        if (activateOnce && !m_activated)
            OnAllQuestsDone.Invoke();

        return true;
    }
}
