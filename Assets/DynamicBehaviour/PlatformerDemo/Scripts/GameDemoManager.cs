using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlatformerDemo
{
    public class GameDemoManager : MonoBehaviour
    {
        [Header("Debug Options")]
        public bool isDebug;
        public int debugLevel;

        public List<Level> levels;
        [HideInInspector]
        public Player player;
        int currentLevel;
        float totalTime;
        public GameObject instructions;
        public Text lives;
        public Text score;
        public Text levelTime;
        public Text resultsText;
        float bestTime = 360;
        public Text bestTimeText;

        public int startLives = 3;

        [HideInInspector]
        public static GameDemoManager Instance;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            if (player == null)
                player = FindObjectOfType<Player>();
            player.gameObject.SetActive(false);
        }

        private void Start()
        {
            ResetGame();

            if (isDebug)
            {
                instructions.SetActive(false);
                currentLevel = debugLevel;
                ResetLevel();
                return;
            }
        }

        void Update()
        {
            if (instructions.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    instructions.SetActive(false);
                    levels[currentLevel].gameObject.SetActive(true);
                }
                return;
            }

            if (levels[currentLevel].levelDescription.activeSelf)
            {
                if (Input.anyKeyDown)
                {
                    levels[currentLevel].levelDescription.SetActive(false);
                    player.gameObject.SetActive(true);
                    player.transform.position = levels[currentLevel].startLocation;
                }
                return;
            }

            //Lose con
            if (!player.isAlive)
            {
                player.lives--;
                //Debug.Log("You Lose!");
                if (player.lives > 0)
                {
                    ResetLevel();
                    return;
                }
                else
                {
                    resultsText.text = "You Lose!";
                    ResetGame();
                    return;
                }
            }

            levels[currentLevel].levelTime += Time.deltaTime;
            UpdateUI();
        }

        public void UpdateUI()
        {
            lives.text = "lives: " + player.lives;
            score.text = "score: " + player.score;
            levelTime.text = "time: " + levels[currentLevel].levelTime;
        }

        public void ResetLevel()
        {
            levels[currentLevel].gameObject.SetActive(false);
            levels[currentLevel].gameObject.SetActive(true);
            UpdateUI();
        }

        public void ResetGame()
        {
            instructions.SetActive(true);
            foreach (Level level in levels)
            {
                foreach (Collectable c in level.collectables)
                    c.gameObject.SetActive(true);
                level.gameObject.SetActive(false);

            }
            currentLevel = 0;
            player.lives = startLives;
            player.score = 0;
            totalTime = 0;
            player.ResetPlatformerActor();
            UpdateUI();
        }

        public void LoadNextLevel()
        {
            player.gameObject.SetActive(false);
            totalTime += levels[currentLevel].levelTime;
            levels[currentLevel].levelTime = 0;
            levels[currentLevel].gameObject.SetActive(false);
            currentLevel++;
            if (currentLevel < levels.Count)
            {
                levels[currentLevel].gameObject.SetActive(true);
            }
            else
            {
                //print(totalTime);
                resultsText.text = "You Win! Total Time: " + totalTime;
                if (totalTime < bestTime)
                {
                    bestTime = totalTime;
                    bestTimeText.text = "Best Time: " + bestTime;
                }
                ResetGame();
            }
            UpdateUI();
        }

        public Transform GetCurrentLevelTransform()
        {
            return levels[currentLevel].transform;
        }
    }
}