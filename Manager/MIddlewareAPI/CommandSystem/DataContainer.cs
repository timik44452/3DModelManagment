using System;
using System.Collections.Generic;

namespace MiddlewareAPI.CommandSystem
{
    public class DataContainer
    {
        private Dictionary<string, object> data = new Dictionary<string, object>();


        /// <summary>
        /// Интегрирует данные в контейнер, данные с одинаковыми именами заменяются
        /// </summary>
        public void Integrate(DataContainer commandData)
        {
            foreach (string key in commandData.data.Keys)
                SetObject(key, commandData.data[key]);
        }

        /// <summary>
        /// Добавляет обьект с именем name в контейнер, в случае если
        /// объект с таким именем уже существует заменяет его
        /// </summary>
        public void SetObject(string name, object value)
        {
            if (data.ContainsKey(name))
            {
                data[name] = value;
            }
            else
            {
                data.Add(name, value);
            }
        }

        /// <summary>
        /// Возвращает обьект типа T с именем name
        /// </summary>
        public T GetObject<T>(string name)
        {
            if (data.ContainsKey(name))
            {
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)data[name].ToString();
                }
                else if (typeof(T) == data[name].GetType())
                {
                    return (T)data[name];
                }
            }

            return default;
        }
    }
}
