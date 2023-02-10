using UnityEngine;
using UnityEngine.UI;

public class CatPlayer : MonoBehaviour
{
    [SerializeField] private GameObject fishbonePrefab;
    [SerializeField] private Transform fishboneParent;
    [SerializeField] private Image forceBar;
    [SerializeField] private GameObject forceBarObject;
    private float holdDownStartTime;
    private Animator _animator;
    private Fishbone _fishbone;
    private GameManager _gameManager;
    private Wind _wind;
    private GameObject currentFishbone { get; set; }
    private bool canThrow { get; set; }
    private bool mouseDown;
    private float holdTimeNormalized;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _gameManager = FindObjectOfType<GameManager>();
        _wind = FindObjectOfType<Wind>();
    }

    private void Start()
    {
        forceBar =forceBar.GetComponent<Image>();
        forceBar.fillAmount = 0;
        CreateFishbone();
    }

    private void Update()
    {
        if (_gameManager.isGameOver || !GameManager.isGameStarted) return;

        if (Input.GetMouseButtonDown(0) && canThrow && !_gameManager.isPlayerDog)
        {
            holdDownStartTime = Time.time;
            forceBarObject.SetActive(true);
            mouseDown = true;
        } 
        
        if (Input.GetMouseButton(0))
        {
            if (mouseDown)
            {
                forceBar.fillAmount += 0.002f;
            }
        }
        
        if (Input.GetMouseButtonUp(0) && canThrow && !_gameManager.isPlayerDog && mouseDown)
        {
            forceBar.fillAmount = 0;
            _animator.Play("Jump");

            float holdDownTime = Time.time - this.holdDownStartTime;
            float calculatedForce = CalculateForce(holdDownTime);
            float fixedHight = Mathf.Clamp(calculatedForce, .5f, 7.5f);
            float fixedPosX = Mathf.Clamp(calculatedForce, 3, 10);
            _fishbone.ThrowFishbone(fixedHight, (fixedPosX * 2) - DogPlayer.catWindForceValue);
            
            forceBarObject.SetActive(false);
            canThrow = false;
            mouseDown = false;
        }
        
        if(Fishbone.canRespawnFishbone && (!_gameManager.isPlayerDog))
        {
            CreateFishbone();
        }
    }
    
    
    private void CreateFishbone()
    {
        currentFishbone = Instantiate(fishbonePrefab, fishboneParent.transform.position,Quaternion.identity, fishboneParent.transform);
        _fishbone = currentFishbone.GetComponent<Fishbone>();
        canThrow = true;
        forceBar.fillAmount = 0;
    }
    
    private float CalculateForce(float holdTime)
    {
        float maxForceHoldTime = 2f;
        holdTimeNormalized = Mathf.Clamp(holdTime, 0.1f, maxForceHoldTime);
        float throwForce = holdTimeNormalized * 10;
        return throwForce;
    }
}
