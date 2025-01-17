using UnityEngine;

public class DefaultAsteroid : EnemyBaseClass
{
    private float lifeTime = 0f;
    [Range(1, 100)]
    [SerializeField] private int points = 1;

    private void Start()
    {
        this.m_lives = Mathf.Max(1, this.m_lives);
        this.lifeTime = 0f;
    }

    internal override void TakeDamage(int m_damagePoints)
    {
        base.TakeDamage(m_damagePoints);
        if (m_lives <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ShipController>().IncreaseScore(this.points);
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (this.m_lives <= 0)
        {
            return;
        }
        // d�sactiv� apr�s 5s
        this.lifeTime += Time.deltaTime;
        if (this.lifeTime > 20f)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ResetLifetime()
    {
        this.lifeTime = 0f;
    }
}
