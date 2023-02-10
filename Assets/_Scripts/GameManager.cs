using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject dogPlayerObject, catPlayerObject;
    [SerializeField] private GameObject dogIndicator, catIndicator;
    [SerializeField] private GameObject gameOverUI, inGameUI, startUI;
    [SerializeField] private GameObject catWinImage, dogWinImage;
    private DogPlayer _dogPlayer;
    private CatPlayer _catPlayer;
    public bool isPlayerDog { get; set; }
    public bool isWinnerDog { get; set; }
    public bool isGameOver { get; set; }
    public static bool isGameStarted;

    private void Awake()
    {
        _dogPlayer = dogPlayerObject.GetComponent<DogPlayer>();
        _catPlayer = catPlayerObject.GetComponent<CatPlayer>();
        isPlayerDog = true;
        isGameOver = false;
    }

    private void Start()
    {
        isGameStarted = false;
        inGameUI.SetActive(false);
        startUI.SetActive(true);
    }

    void Update()
    {
        if (isPlayerDog)
        {
            _dogPlayer.enabled = true;
            _catPlayer.enabled = false;
            dogIndicator.SetActive(true);
            catIndicator.SetActive(false);
        }
        else
        {
            _catPlayer.enabled = true;
            _dogPlayer.enabled = false;
            dogIndicator.SetActive(false);
            catIndicator.SetActive(true);
        }
    }

    public void StartGame()
    {
        startUI.SetActive(false);
        inGameUI.SetActive(true);
        isGameStarted = true;
    }
    public void ChangePlayer()
    {
        isPlayerDog = !isPlayerDog;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);

        if (isWinnerDog)
        {
            catWinImage.SetActive(false);
            dogWinImage.SetActive(true);
        }
        else
        {
            catWinImage.SetActive(true);
            dogWinImage.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        isGameOver = false;
    }
}