using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject gm;
    public Button 底部按钮;
    public Button 土豆按钮;
    public Button 鸡蛋按钮;
    public Button 顶部按钮;
    public Button 牛排按钮;
    public Button 番茄按钮;

    public GameObject 底部;
    public GameObject 土豆;
    public GameObject 鸡蛋;
    public GameObject 顶部;
    public GameObject 番茄;
    public GameObject 牛排;

    public Button 提交;
    public GameObject 叉叉;
    void Start()
    {
        底部按钮.onClick.AddListener(底部Function);
        土豆按钮.onClick.AddListener(土豆Function);
        鸡蛋按钮.onClick.AddListener(鸡蛋Function);
        番茄按钮.onClick.AddListener(番茄Function);
        顶部按钮.onClick.AddListener(顶部Function);
        牛排按钮.onClick.AddListener(牛排Function);
        //提交.onClick.AddListener(提交Function);
    }

    private Stack<item> _items = new Stack<item>();
    private float 高度=0;
    private void AddFood(食物 type)
    {
        GameObject g=null;
        switch (type)
        {
            case 食物.土豆:
                g = 土豆;
                break;
            case 食物.鸡蛋:
                g = 鸡蛋;
                break;
            case 食物.底部:
                g = 底部;
                break;
            case 食物.顶部:                
                g = 顶部;
                break;
            case 食物.牛排:                
                g = 牛排;
                break;
            case 食物.番茄:               
                g = 番茄;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        var tt=Instantiate(g, gm.transform).GetComponent<item>();
        if (_items.Count==0)
        {
            _items.Push(tt);
            高度 += tt.厚度 / 2;
        }
        else
        {
            _items.Push(tt);
            tt.GetComponent<RectTransform>().anchoredPosition = tt.GetComponent<RectTransform>().anchoredPosition+new Vector2(0,高度);
            高度 += tt.厚度;
        }
    }

    private void 提交Function()
    {
        
    }

    void 底部Function()
    {
        if (_items.Count==0)
        {
            AddFood(食物.底部);
           return;
        }
        var xx=Instantiate(叉叉,底部按钮.transform);
        StartCoroutine(sdad(xx));
    }

    void 土豆Function()
    {
        if (_items.Count != 0)
        {
            var item = _items.Peek();
            if (item.type == 食物.番茄)
            {
                AddFood(食物.土豆);
                return;
            }
        }

        var xx=Instantiate(叉叉,土豆按钮.transform);
        StartCoroutine(sdad(xx));
    }

    private IEnumerator sdad(GameObject xx)
    {
        yield return new WaitForSeconds(1);
        Destroy(xx);
    }

    void 鸡蛋Function()
    {
        if (_items.Count != 0)
        {
            var item = _items.Peek();
            if (item.type == 食物.土豆)
            {
                AddFood(食物.鸡蛋);
                return;
            }
        }
        var xx=Instantiate(叉叉,鸡蛋按钮.transform);
        StartCoroutine(sdad(xx));
    }
    void 顶部Function()
    {
        if (_items.Count != 0)
        {
            var item = _items.Peek();
            if (item.type == 食物.鸡蛋)
            {        AddFood(食物.顶部);
                Succeed();
return;
            }
        }
        var xx=Instantiate(叉叉,顶部按钮.transform);
        StartCoroutine(sdad(xx));

    }void 牛排Function()
    {
        if (_items.Count != 0)
        {
            var item = _items.Peek();
            if (item.type == 食物.底部)
            {        
                AddFood(食物.牛排);
            }
        }
        var xx=Instantiate(叉叉,牛排按钮.transform);
        StartCoroutine(sdad(xx));

    }
    void 番茄Function()
    {
        if (_items.Count!=0)
        {
            var item = _items.Peek();
            if ( item.type== 食物.牛排)
            {
                AddFood(食物.番茄);
            }
        }
        var xx=Instantiate(叉叉,番茄按钮.transform);
        StartCoroutine(sdad(xx));
    }

    private void Succeed()
    {
        
    }
}

public enum 食物
{
    土豆,
    鸡蛋,
    底部,
    顶部,
    牛排,
    番茄
}
