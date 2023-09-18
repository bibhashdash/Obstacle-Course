using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject BoostPickupPrefab;
  public GameObject DamageHazardPrefab;
  public GameObject DasherPrefab;

  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating(nameof(CreateNewBoostPickup), 0f, 1.5f);
  }
  private void CreateNewBoostPickup()
  {
    Vector3 newPosition = new(DasherPrefab.transform.position.x, 0.63f, DasherPrefab.transform.position.z + 20);
    float randomNumber = Random.Range(0f, 1f);
    if (randomNumber < 0.5f)
    {
      Instantiate(BoostPickupPrefab, newPosition, Quaternion.identity);
    }
    else
    {
      Instantiate(DamageHazardPrefab, newPosition, Quaternion.identity);
    }
  }
}
