using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Runtime;

using IT_YARD.Models;
using IT_YARD.Common;

namespace IT_YARD.Repositories
{
    class JsonRepository 
    {
        DataContractJsonSerializer serializer;

        public List<EntityBase> list;
        private string file;       
        //private Array temp;
        //public Array updated;
        //private Logger logger = new Logger();
        private FileLogger logger = new FileLogger();

        /// <summary>
        /// JsonRepository constructor
        /// </summary>
        /// <param name="repoType"></param>
        public JsonRepository(Type repoType)
        {
            //list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(repoType));
            //this.temp = Array.CreateInstance(repoType, 0);
            //this.updated = Array.CreateInstance(repoType, 1);
            //list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(repoType));
            this.serializer = new DataContractJsonSerializer(typeof(List<>).MakeGenericType(repoType));
            this.file = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\ApplicationData\\" + repoType.FullName + ".json";
            //this.type = repoType;
            //Convert.ChangeType(updated, type);
        }

        /// <summary>
        /// Gat collection from json
        /// </summary>
        /// <returns>repository collection</returns>
        public IList All()
        {
            using (FileStream stream = new FileStream(this.file, FileMode.OpenOrCreate))
            {
                list = (List<EntityBase>)serializer.ReadObject(stream);
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DisplayItemInfo(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Insert(object item)
        {
            var newItem = item as EntityBase;
            if (newItem.Validate())
            {
                using (FileStream stream = new FileStream(this.file, FileMode.OpenOrCreate))
                {
                    if (stream.Length == 0)
                    {
                        list.Add(newItem);
                    }
                    else
                    {
                        list = (List<EntityBase>)serializer.ReadObject(stream);
                        list.Add(newItem);                                               
                    }
                    serializer.WriteObject(stream, list);
                }
                this.logger.LogInfo($"Add item with id - {newItem.Id} to repository");
                return true;
            }
            this.logger.LogError($"Item not added, validation error");
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(Guid id, object item)
        {
            throw new NotImplementedException();
        }
    }
}
