using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject warning;
    [SerializeField] private GameObject effectPrefab; // ¿Ã∆Â∆Æ «¡∏Æ∆’
    [SerializeField] private int maxEffects = 3; // √÷¥Î ª˝º∫ ¿Ã∆Â∆Æ ºˆ

    private GameObject target;
    private Vector3 vec;
    private float length;

    private void Start()
    {
        target = GameObject.Find("target").gameObject;
        vec = (transform.position - target.transform.position).normalized;
        SetRotation();
        StartCoroutine(Warning());
    }

    private void Update()
    {
        if (laser.activeSelf)
        {
            Quaternion quater = transform.rotation;
            Vector2 startPos = transform.position;
            RaycastHit2D[] hit = Physics2D.RaycastAll(this.gameObject.transform.position, quater * Vector2.down * 10, 10.0f);
            Debug.DrawRay(startPos, quater * Vector2.down * 10, Color.green);

            foreach (RaycastHit2D hitinfos in hit)
            {
                if (hitinfos.collider != null)
                {
                    if (hitinfos.collider.gameObject.CompareTag("Player") )
                    {
                        length = (hitinfos.collider.gameObject.transform.position - this.gameObject.transform.position).sqrMagnitude;
                        laser.transform.localScale = new Vector3(0.2f, Mathf.Sqrt(length) * 2, this.gameObject.transform.localScale.y);
                        break;
                    }
                    if (hitinfos.collider.gameObject.CompareTag("target"))
                    {
                        length = (hitinfos.collider.gameObject.transform.position - this.gameObject.transform.position).sqrMagnitude;
                        laser.transform.localScale = new Vector3(0.2f, Mathf.Sqrt(length) * 2, this.gameObject.transform.localScale.y);
                        ShowkillEffect(hitinfos.collider.gameObject);
                        break;
                    }
                }
            }
        }
    }

    private void ShowkillEffect(GameObject obj)
    {
        GameObject effect = Instantiate(effectPrefab, obj.transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
    }

    private void SetRotation()
    {
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        laser.SetActive(false);
        transform.rotation = Quaternion.Euler(0, 0, -90 + angle);
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
