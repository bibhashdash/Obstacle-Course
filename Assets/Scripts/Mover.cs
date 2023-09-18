using Assets.Models;
using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
  // use serialize field to make it available in the unity inspector
  [SerializeField] float moveSpeed = 10f;
  GameState gameState = GameState.GameFinished;
  float elapsedTime;
  string pickupAlert;
  float boostNewZPosition;
  float boostNewXPosition;
  float hazardNewZPosition;
  float hazardNewXPosition;

  public TMPro.TMP_Text countdown_UI;
  public TMPro.TMP_Text alert_UI;

  // Start is called before the first frame update
  void Start()
  {
    gameState = GameState.GameStarted;
    elapsedTime = 0f;
    
  }

  // Update is called once per frame
  void Update()
  { 
    if (gameState == GameState.GameFinished) 
      {
      alert_UI.color = Color.white;
      alert_UI.text = "You finished, well done!!";
      moveSpeed = 0f;
      countdown_UI.text = $"Your Final Time: {(int)elapsedTime} seconds";
      }
    else {
      float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
      float zValue = Time.deltaTime * moveSpeed;
      transform.Translate(xValue, 0, zValue);

      elapsedTime += Time.deltaTime;
      countdown_UI.text = $"Elapsed Time: {(int)elapsedTime}";
    }
  }

  IEnumerator IncreaseSpeedCoroutine()
  {
    StopCoroutine(DecreaseSpeedCoroutine());
    alert_UI.color = Color.green;
    alert_UI.text = "Speed Boost!!";
    moveSpeed = 20f;
    yield return new WaitForSeconds(3);
    moveSpeed = 10f;
    alert_UI.text = string.Empty;
  }

  IEnumerator DecreaseSpeedCoroutine()
  {
    StopCoroutine(IncreaseSpeedCoroutine());
    alert_UI.color = Color.red;
    alert_UI.text = "Taken Damage!!";
    moveSpeed = 2f;
    yield return new WaitForSeconds(3);
    moveSpeed = 10f;
    alert_UI.text = string.Empty;

  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Damage"))
    {
      StartCoroutine(DecreaseSpeedCoroutine());
    }

    if (other.gameObject.CompareTag("Boost"))
    {
      StartCoroutine(IncreaseSpeedCoroutine());
    }
    if (other.gameObject.CompareTag("Finish"))
    {
      gameState = GameState.GameFinished;
    }
  }
}
// Temple run
// subway surfers
// jetpack joyride
// endless-runner type games
// what is the skill you want player to learn
// continuous playing - or quick respawn
