using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.GameManager
{
    public class LevelController : MonoBehaviour
    {
        public static int StartEnemysOnLevel = 0;
        public static bool isLevelComplete;

        private void Start()
        {
            Time.timeScale = 1;
            isLevelComplete = false;
            StartEnemysOnLevel = FindObjectsOfType<EnemyHealth>().Length;
            

        }

        private void Update()
        {
            WinChecker();
        }

        private static void WinChecker()
        {
            if (StartEnemysOnLevel == EnemyHealth.DeadEnemys)
            {
                isLevelComplete = true;
                Time.timeScale = 0;
            }
        }
    }
}