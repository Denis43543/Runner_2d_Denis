using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCollector : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public MoveCharacter playerController;
    public int coins = 0;

    private bool isJumpBoosted = false;
    private float jumpBoostTimeLeft = 0f;

    public GameObject respawnObject;
    public int sceneName;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("coin"))
        {
            coins++;
            coinText.text = coins.ToString();
            Destroy(collider.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && coins >= 15)
        {
            coins -= 15;
            playerController.moveSpeed = 20;
            isJumpBoosted = true;
            jumpBoostTimeLeft = 2f;
        }

        if (isJumpBoosted)
        {
            jumpBoostTimeLeft -= Time.deltaTime;
            if (jumpBoostTimeLeft <= 0f)
            {
                playerController.moveSpeed = 10;
                isJumpBoosted = false;
            }
        }
    }

    public void OnButtonClick()
    {
        if (coins >= 15)
        {
            coins -= 15;
            // Телепортировать игрока на координаты объекта Respawn
            Transform respawnTransform = respawnObject.transform;
            Vector3 respawnPosition = respawnTransform.position;
            // Применяем позицию и вращение к игроку
            transform.position = respawnPosition;
            gameObject.GetComponent<PlayerController>().isDeath = false;
            gameObject.GetComponent<PlayerController>().OnDeath();
            coinText.text = coins.ToString();
        }
        else
        {
            // Загрузить сцену
            SceneManager.LoadScene(sceneName);
        }
    }
}
