using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Mover : MonoBehaviour
{
  // use serialize field to make it available in the unity inspector
  [SerializeField] float moveSpeed = 10f;

  float countDown;

  public TMPro.TMP_Text countdown_UI;

  // Start is called before the first frame update
  void Start()
  {
    countDown = 15f;
  }

  // Update is called once per frame
  void Update()
  {    
    float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
    float zValue = Time.deltaTime * moveSpeed;
    transform.Translate(xValue, 0, zValue);

    countDown -= Time.deltaTime;
    countdown_UI.text = ((int)countDown).ToString();

    if (countDown <= 0)
    {
      Debug.LogError("Outta time!");

    }
  }

  IEnumerator IncreaseSpeedCoroutine()
  {
    moveSpeed += 10f;
    yield return new WaitForSeconds(3);
    moveSpeed -= 10f;
  }

  IEnumerator DecreaseSpeedCoroutine()
  {
    StopAllCoroutines();
    moveSpeed = 2f;
    yield return new WaitForSeconds(3);
    moveSpeed = 10f;
  }

  private void OnTriggerEnter(Collider other)
  {
    Debug.Log(gameObject.name + " hit " + other.gameObject.tag);

    if (other.gameObject.CompareTag("Damage"))
    {
      StartCoroutine(DecreaseSpeedCoroutine());
    }

    if (other.gameObject.CompareTag("Boost"))
    {
      StartCoroutine(IncreaseSpeedCoroutine());
    }
  }
}
// Temple run
// subway surfers
// jetpack joyride
// endless-runner type games
// what is the skill you want player to learn
// continuous playing - or quick respawn
