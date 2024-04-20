using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pattern2 : MonoBehaviour
{
    [SerializeField]
    GameObject laser;
    GameObject target;
    GameObject player;

    Vector3 vec;

    float length;

    private void Start()
    {
        target = GameObject.Find("target");
        player = GameObject.Find("player");

        vec = (transform.position - target.transform.position).normalized;

        StartCoroutine(Laser());
    }
    private void Update()
    {
        Quaternion quater = transform.rotation;
        Vector2 startPos = transform.position;
        RaycastHit2D[] hit = Physics2D.RaycastAll(this.gameObject.transform.position, quater * Vector2.down * 10, 10.0f);
        Debug.DrawRay(startPos, quater * Vector2.down * 10, Color.green);

        foreach(RaycastHit2D hitinfos in hit)
        {
            if (hitinfos.collider != null)
            {
                if (hitinfos.collider.gameObject.CompareTag("Player"))
                {
                    length = (hitinfos.collider.gameObject.transform.position - this.gameObject.transform.position).sqrMagnitude;
                    laser.transform.localScale = new Vector3(0.2f, Mathf.Sqrt(length) * 2, this.gameObject.transform.localScale.y);
                    break;
                }
                else if (hitinfos.collider.gameObject.CompareTag("target"))
                {
                    length = (hitinfos.collider.gameObject.transform.position - this.gameObject.transform.position).sqrMagnitude;
                    laser.transform.localScale = new Vector3(0.2f, Mathf.Sqrt(length) * 2, this.gameObject.transform.localScale.y);
                    break;
                }
            }
        }
    }
    private void set()
    {
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0,-90 + angle);

        this.gameObject.transform.SetParent(target.transform);
    }
    private IEnumerator Laser()
    {
        set();
        yield return new WaitForSeconds(1);
        laser.SetActive(true);
        yield return new WaitForSeconds(5f);
        laser.SetActive(false);
        Destroy(this.gameObject);
    }
}
