using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
	private float m_fTime;
	public float m_fInterval = 5.0f;
	public GameObject m_prefEnemy;

	private void Start()
	{
		m_fTime = 0.0f;
	}

	private void Update()
	{
		m_fTime += Time.deltaTime;
		if(m_fInterval < m_fTime)
		{
			Instantiate(m_prefEnemy, gameObject.transform.position, gameObject.transform.rotation);
			m_fTime -= m_fInterval;
		}		
	}
}
