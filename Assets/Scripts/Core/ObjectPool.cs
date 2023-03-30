using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPool<T> where T : class
{
    [SerializeField]
    private int m_Amount;
    [SerializeField]
    private GameObject m_PoolObject;
    [SerializeField]
    private List<Tuple<GameObject, T>> m_Elements;

    public int Amount { get => m_Amount; set => m_Amount = value; }
    public GameObject PoolObject { get => m_PoolObject; set => m_PoolObject = value; }
    public List<Tuple<GameObject, T>> Elements { get => m_Elements; set => m_Elements = value; }

    public void Init(Action<Tuple<GameObject, T>> callback){
        for (int i = 0; i < m_Amount; i++)
        {
            GameObject go = GameObject.Instantiate(m_PoolObject);
            go.SetActive(false);
            Tuple<GameObject, T> element = new Tuple<GameObject, T>(go, go.GetComponent<T>());
            m_Elements.Add(element);
            callback(element);
        }
    }

    public void Init(GameObject obj, int amount, Action<Tuple<GameObject, T>> callback){
        m_PoolObject = obj;
        m_Amount = amount;
        for (int i = 0; i < m_Amount; i++)
        {
            GameObject go = GameObject.Instantiate(m_PoolObject);
            go.SetActive(false);
            Tuple<GameObject, T> element = new Tuple<GameObject, T>(go, go.GetComponent<T>());
            m_Elements.Add(element);
            callback(element);
        }
    }

    public Tuple<GameObject, T> Get(Action<Tuple<GameObject, T>> callback1, bool addNew = false, Action<Tuple<GameObject, T>> callback2 = null){
        for (int i = 0; i < m_Amount; i++)
        {
            if(!m_Elements[i].Item1.activeInHierarchy){
                callback1(m_Elements[i]);
                return m_Elements[i];
            }
        }

        if(addNew){
            m_Amount++;
            GameObject go = GameObject.Instantiate(m_PoolObject);
            go.SetActive(false);
            Tuple<GameObject, T> newElement = new Tuple<GameObject, T>(go, go.GetComponent<T>());
            m_Elements.Add(newElement);
            if(callback2 != null){
                callback2(newElement);
            }            
        }

        return null;
    }
}
