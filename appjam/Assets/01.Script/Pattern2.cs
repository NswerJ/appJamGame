using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pattern2 : MonoBehaviour
{
    [SerializeField]
    GameObject laser;
    [SerializeField]
    GameObject warning;
    GameObject target;
    public GameObject Effect;

    Vector3 vec;

    float length;

    private void Start()
    {
        target = GameObject.Find("target");

        vec = (transform.position - target.transform.position).normalized;

        set();

        StartCoroutine(Warning());
    }
    private void Update()
    {
        if(laser.activeSelf)
        {
            Quaternion quater = transform.rotation;
            Vector2 startPos = transform.position;
            RaycastHit2D[] hit = Physics2D.RaycastAll(this.gameObject.transform.position, quater * Vector2.down * 10, 10.0f);
            Debug.DrawRay(startPos, quater * Vector2.down * 10, Color.green);

            foreach (RaycastHit2D hitinfos in hit)
            {
                if (hitinfos.collider != null)
                {
                    if (hitinfos.collider.gameObject.CompareTag("Player"))
                    {
                        length = (hitinfos.collider.gameObject.transform.position - this.gameObject.transform.position).sqrMagnitude;
                        laser.transform.localScale = new Vector3(0.2f, Mathf.Sqrt(length) * 2, this.gameObject.transform.localScale.y);
                        dieEffectShow(hitinfos.collider.gameObject);
                        break;
                    }
                    else if (hitinfos.collider.gameObject.CompareTag("target"))
                    {
                        length = (hitinfos.collider.gameObject.transform.position - this.gameObject.transform.position).sqrMagnitude;
                        laser.transform.localScale = new Vector3(0.2f, Mathf.Sqrt(length) * 2, this.gameObject.transform.localScale.y);
                        dieEffectShow(hitinfos.collider.gameObject);
                        break;
                    }
                }
            }
        }
    }
    public void dieEffectShow(GameObject obj)
    {
        GameObject effct = Instantiate(Effect, obj.transform.position, Quaternion.identity);
        Destroy(effct, 1.5f);
    }


    private void set()
    {
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;

        laser.SetActive(false);

        transform.rotation = Quaternion.Euler(0, 0,-90 + angle);

        this.gameObject.transform.SetParent(target.transform);
    }
    private IEnumerator Warning()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Laser());
    }
    private IEnumerator Laser()
    {
        warning.SetActive(false);
        laser.SetActive(true);
        yield return new WaitForSeconds(5f);
        laser.SetActive(false);
        Destroy(this.gameObject);
    }
}
