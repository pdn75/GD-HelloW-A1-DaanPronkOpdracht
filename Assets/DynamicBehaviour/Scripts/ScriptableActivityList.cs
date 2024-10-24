using System.Collections.Generic;
using UnityEngine;

namespace DynamicBehaviour
{
    [CreateAssetMenu(fileName = "activity list", menuName = "ScriptableObjects/Acts/ActivityList")]
    public class ScriptableActivityList : ScriptableObject
    {
        public List<Act> list;

        private void OnValidate()
        {
            SortActivities();
        }

        public void SortActivities()
        {
            //sort actions based on number of conditions
            list.Sort(SortByMostConditions);
        }

        static int SortByMostConditions(Act p_activity1, Act p_activity2)
        {
            //puts all the null objects at the bottom of the list
            if (p_activity1 != null && p_activity2 == null)
                return -1;
            if (p_activity1 == null && p_activity2 != null)
                return 1;
            if (p_activity1 == null && p_activity2 == null)
                return 0;

            return p_activity2.conditions.Length.CompareTo(p_activity1.conditions.Length);
        }
    }
}