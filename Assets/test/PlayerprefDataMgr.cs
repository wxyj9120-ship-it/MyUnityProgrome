using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
//游戏读取数据：PlayerInfo(自定义玩家类) p = PlayerprefDataMgr.Instance.LoadDate(typeof(PlayerInfo), "player1") as PlayerInfo; 
//游戏存储数据：PlayerprefDataMgr.Instance.SaveDate(p,"player1");
public class PlayerprefDataMgr
{
    private static PlayerprefDataMgr instance = new PlayerprefDataMgr(); 
    public static PlayerprefDataMgr Instance
    {
        get{
            return instance;
        }
    }
    private PlayerprefDataMgr() { }
    public void SaveDate(object date,string KyeName)
    {
        Type dateType = date.GetType();
        FieldInfo[] fieldInfos = dateType.GetFields();
        //定义规则 keyName_数据类型_字段类型_字段名
        //字段类型：fieldInfo.FieldType
        //字段名：fieldInfo.Name
        string savekeyName = "";
        FieldInfo fieldInfo;
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            fieldInfo = fieldInfos[i];
            savekeyName = "keyname" + "_" + dateType.Name + "_" + fieldInfo.FieldType.Name + "_" + fieldInfo.Name;
            SaveValue(fieldInfo.GetValue(date), savekeyName);
        }
    }
    //存储数据并进行数据类型判断
    private void SaveValue(object value, string keyName)
    {
        Type fieldType = value.GetType();
        if(fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if(fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (fieldType == typeof(double))
        {
            double doubleValue = (double)value;
            float floatValue = (float)doubleValue;
            PlayerPrefs.SetFloat(keyName, floatValue);
        }
        else if(fieldType == typeof(string))
        {
            PlayerPrefs.SetString(keyName,value.ToString());
        }
        else if(fieldType == typeof(bool))
        {
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }
        //存储List类型
        else if( typeof(IList).IsAssignableFrom(fieldType) )
        {
            IList list = value as IList;
            PlayerPrefs.SetInt(keyName, list.Count);
            int index = 0;
            foreach (object obj in list)
            {
                SaveValue(obj, keyName + index);
                ++index;
            }
        }
        //存储字典类型
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            IDictionary dictionary = value as IDictionary;
            PlayerPrefs.SetInt(keyName, dictionary.Count);
            int index = 0;
            //因为泛型字典必须写.Keys才能拿到 key
            foreach (object key in dictionary.Keys)
            {
                SaveValue(key, keyName + "_key" + index);
                SaveValue(dictionary[key], keyName + "_value" + index);
                ++index;
            }
        }
        //以上都不是，说明大概是自定义类型了，递归调用
        else
        {
            SaveDate(value, keyName);
        }
        PlayerPrefs.Save();
    }
    //读取数据
    public object LoadDate(Type type,string KyeName)
    {
        object date = Activator.CreateInstance(type);
        FieldInfo[] fieldInfos = type.GetFields();
        string loadkeyName = "";
        FieldInfo fieldInfo;
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            fieldInfo = fieldInfos[i];
            loadkeyName = "keyname" + "_" + type.Name + "_" + fieldInfo.FieldType.Name + "_" + fieldInfo.Name;
            fieldInfo.SetValue(date, LoadValue(fieldInfo.FieldType, loadkeyName));
        }
        return date;
    }
    //判断数据类型进行读取
    private object LoadValue(Type fieldType, string keyName)
    {
        if (fieldType == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName);
        }
        else if (fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName);
        }
        else if (fieldType == typeof(double))
        {
          return (double)PlayerPrefs.GetFloat(keyName);
        }
        else if (fieldType == typeof(string))
        {
            return PlayerPrefs.GetString(keyName);
        }
        else if (fieldType == typeof(bool))
        {
            return PlayerPrefs.GetInt(keyName) == 1 ? true : false;
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            int coute = PlayerPrefs.GetInt(keyName);
            IList list = Activator.CreateInstance(fieldType) as IList;
            for (int i = 0; i < coute; i++)
            {
                list.Add(LoadValue(fieldType.GetGenericArguments()[0],keyName + i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            int coute = PlayerPrefs.GetInt(keyName,0);
            IDictionary dictionary = Activator.CreateInstance(fieldType) as IDictionary;
            Type[] kvType = fieldType.GetGenericArguments();
            for (int i = 0; i < coute; i++)
            {
                dictionary.Add(LoadValue(kvType[0], keyName + "_key" + i),
                               LoadValue(kvType[1], keyName + "_value" + i));
            }
            return dictionary;
        }
        else
        {
           return LoadDate(fieldType, keyName);
        }
       
    }
}
