using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlatformerDemo
{
    public class Level : MonoBehaviour
    {
        List<NPC> enemies;
        [HideInInspector]
        public List<Collectable> collectables;
        public GameObject levelDescription;
        public float levelTime { get; set; }
        public Vector2 startLocation;
        //[SerializeField]
        //GameObject nextLevelWarp;

        private void Awake()
        {
            Text levelText = levelDescription.GetComponentInChildren<Text>();
            levelText.text = "Press any key to start";

            enemies = new List<NPC>();
            enemies.AddRange(GetComponentsInChildren<NPC>());

            collectables = new List<Collectable>();
            foreach (Collectable c in GetComponentsInChildren<Collectable>())
            {
                collectables.Add(c);
            }
        }

        private void OnEnable()
        {
            levelDescription.SetActive(true);

            foreach (NPC npc in enemies)
                npc.gameObject.SetActive(false);
            foreach (NPC npc in enemies)
                npc.gameObject.SetActive(true);

            foreach (Collectable c in collectables)
            {
                if (c.resetOnEnable)
                    c.gameObject.SetActive(true);
            }
        }
    }
}