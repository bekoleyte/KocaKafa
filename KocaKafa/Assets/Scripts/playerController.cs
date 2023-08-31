using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    float playerSpeed = 6f;
    float xSpeed;
    float maxXValue = 4.28f;
    bool isPlayerMoving;
    public GameObject headBoxGO;
    private ScaleCalculator scaleCalculator; 
    Renderer headBoxRenderer;
    private Material currentHeadMat;
    public Material warningMat;
    Animator playerAnim;
    public AudioSource playerAudioSource;
    public AudioClip gateClip, colorBoxClip, obstacleClip, successClip;

    // Start is called before the first frame update
    void Start()
    {
        scaleCalculator = new ScaleCalculator();
        headBoxRenderer = headBoxGO.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        currentHeadMat = headBoxRenderer.material;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float touchX = 0;//yrni update
        float newXValue;

        if (isPlayerMoving == false)
        {
            return;
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            xSpeed = 250;
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }

        else if (Input.GetMouseButton(0))
        {
            xSpeed = 500f;
            touchX = Input.GetAxis("Mouse X");
        }

        newXValue = transform.position.x + xSpeed * touchX * Time.deltaTime;
        newXValue = Mathf.Clamp(newXValue, -maxXValue, maxXValue);

        Vector3 playerNewPosition = new Vector3(newXValue, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime); //duz yurume
        transform.position = playerNewPosition;//duz yurume
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FinishLine")
        {
            isPlayerMoving = false;
            StartIdleAnim();
            GameManager.instance.ShowSuccessMenu();
            StopBackgroundMusic();
            PlayAudio(successClip, 1f);
            //karakteri durdur
        }
    }

    public void PassedGate(GateType gateType, int gateValue)
    {
        PlayAudio(gateClip, 1f);
        headBoxGO.transform.localScale = scaleCalculator.CalculatePlayerHeadSize(gateType, gateValue, headBoxGO.transform);
        Debug.Log("kapidan gectin");
    }

    public void TouchedToColorBox(Material boxMat)
    {
        PlayAudio(colorBoxClip, 1f);
        headBoxRenderer.material = boxMat;
        currentHeadMat = boxMat;
        //kafa rengi degistir
    }

    public void TouchedToObstacle()
    {
        PlayAudio(obstacleClip, 1f);
        headBoxGO.transform.localScale = scaleCalculator.DecreasePlayerHeadSize(headBoxGO.transform);
        StartCoroutine(StartRedBlinkEffect());
    }

    private IEnumerator StartRedBlinkEffect()
    {
        headBoxGO.transform.GetChild(0).GetComponent<MeshRenderer>().material = warningMat;
        yield return new WaitForSeconds(0.3f);
        headBoxGO.transform.GetChild(0).GetComponent<MeshRenderer>().material = currentHeadMat;
    }

    public void GameStarted() 
    {
        isPlayerMoving = true;
        StartRunAnim();
    }

    private void StartRunAnim()
    {
        playerAnim.SetBool("IsIdleOn", false);
        playerAnim.SetBool("IsRunningOn", true);
    }
    private void StartIdleAnim()
    {
        playerAnim.SetBool("IsIdleOn", true);
        playerAnim.SetBool("IsRunningOn", false);
    }

    private void PlayAudio(AudioClip audioClip, float volume)
    {
        playerAudioSource.PlayOneShot(audioClip, volume);
    }

    private void StopBackgroundMusic()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
    }
}
