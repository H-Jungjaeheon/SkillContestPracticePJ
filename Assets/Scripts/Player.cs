using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Unit
{
    #region 이동 관련 변수들
    [SerializeField]
    private Vector2 moveField;

    [SerializeField]
    private Vector2 speedVector;

    float horizontal;

    float vertical;

    Vector3 nowPos;
    #endregion

    #region 체력 관련 모음

    public override float Hp 
    {
        get => base.Hp;
        set
        {
            if (value <= 0)
            {
                hp = 0;
                Dead();
            }
            else
            {
                hp = value;

                hpText.text = $"{value}%";
                hpImage.fillAmount = value / maxHp;
            }
        }
    }

    [SerializeField]
    Image hpImage;

    [SerializeField]
    Text hpText;

    #endregion

    #region 공격(총알 발사 모음)
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float shootDelay;

    private float nowShootDelay;

    Vector3 bulletSpawnPlus;
    #endregion

    #region 폭탄 관련 모음

    List<GameObject> boomRangeInEnemy = new List<GameObject>();

    BoxCollider2D boomRangeCollider;

    #endregion

    #region 스킬 관련 모음
    [SerializeField]
    private Image skillCoolTimeImage;

    const float MAX_DASH_COOLTIME = 1f;

    const float MAX_BOOM_COOLTIME = 5f;

    const float DASH_POWER = 2f;

    float nowSkillCooltime;

    IEnumerator nowCoolTimeCoroutine;
    #endregion

    #region 시점 변경 관련 모음
    [SerializeField]
    private Image viewChangeCoolTimeImage;

    const float MAX_VIEW_CHANGE_COOLTIME = 8f;

    float nowViewChangeCooltime;
    #endregion

    private bool isTopView = true;

    private void Start()
    {
        hp = maxHp;
        bulletSpawnPlus.y = 0.25f;
        nowPos = transform.position;
        StartCoroutine(ViewChangeSkill());
        StartCoroutine(Skill());
    }

    void Update()
    {
        if (isTopView)
        {
            TopViewMove();
        }
        else
        {
            TopViewMove();
            //SideViewMove();
        }

        Shoot();
    }

    public override void Hit(float damage)
    {
        if (isDontHit == false)
        {
            Hp -= damage;
            //StartCoroutine(HitColorEffect());
        }
    }

    private void Shoot()
    {
        if (shootDelay <= nowShootDelay)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                Instantiate(bullet, transform.position + bulletSpawnPlus, bullet.transform.rotation);
                nowShootDelay = 0;
            }
        }
        else
        {
            nowShootDelay += Time.deltaTime;
        }
    }

    IEnumerator ViewChangeSkill()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ViewChange(isTopView);

                StopCoroutine(nowCoolTimeCoroutine);

                isTopView = !isTopView;

                nowCoolTimeCoroutine = SkillCoolTime(isTopView);
                StartCoroutine(nowCoolTimeCoroutine);

                StartCoroutine(ViewChangeCoolTime());
                
                break;
            }

            yield return null;
        }
    }

    IEnumerator ViewChange(bool isNowTopView)
    {
        if (isNowTopView)
        {

        }
        else
        {
            
        }
        
        yield return null;
    }

    IEnumerator ViewChangeCoolTime()
    {
        nowViewChangeCooltime = MAX_VIEW_CHANGE_COOLTIME;

        while (true)
        {
            nowViewChangeCooltime -= Time.deltaTime;

            viewChangeCoolTimeImage.fillAmount = nowViewChangeCooltime / MAX_VIEW_CHANGE_COOLTIME;

            if (nowViewChangeCooltime <= 0)
            {
                break;
            }
            yield return null;
        }

        StartCoroutine(ViewChangeSkill());
    }

    private void TopViewMove()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (transform.position.x + horizontal * speed * Time.deltaTime > -moveField.x && transform.position.x + horizontal * speed * Time.deltaTime < moveField.x)
        {
            speedVector.x = speed;
            nowPos.x += horizontal * Time.deltaTime * speedVector.x;
        }
        else
        {
            speedVector.x = 0;
        }

        if (transform.position.y + vertical * speed * Time.deltaTime > -moveField.y && transform.position.y + vertical * speed * Time.deltaTime < moveField.y)
        {
            speedVector.y = speed;
            nowPos.y += vertical * Time.deltaTime * speedVector.y;
        }
        else
        {
            speedVector.y = 0;
        }

        transform.position = nowPos;
    }

    private void SideViewMove()
    {
        
    }

    IEnumerator Skill()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isTopView)
                {

                }
                else
                {
                    isDontHit = true;
                }

                nowCoolTimeCoroutine = SkillCoolTime(isTopView);
                StartCoroutine(nowCoolTimeCoroutine);

                break;
            }

            yield return null;
        }
    }

    IEnumerator SkillCoolTime(bool isNowTopView) 
    {
        nowSkillCooltime = isNowTopView ? MAX_BOOM_COOLTIME : MAX_DASH_COOLTIME;

        while (true)
        {
            nowSkillCooltime -= Time.deltaTime;

            skillCoolTimeImage.fillAmount = isNowTopView ? nowSkillCooltime / MAX_BOOM_COOLTIME : nowSkillCooltime / MAX_DASH_COOLTIME;

            if (nowSkillCooltime <= 0)
            {
                break;
            }

            yield return null;
        }

        StartCoroutine(Skill());
    }

    protected override void Dead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
