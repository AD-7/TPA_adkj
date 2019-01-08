﻿using AutoMapper;
using Data.Metadata_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.SerializableData
{
    [DataContract(IsReference = true)]
    public class SerializableReflector 
    {
      

        [DataMember(Name = "Assembly_Model")]
        public SerializableAssembly SerializableAssembly { get; private set; }
        //[DataMember(Name = "Assembly_Model2")]
        //public AssemblyMetadata assembly { get; set; }

        public SerializableReflector(Reflector refl)
        {    
            SerializableAssembly = new SerializableAssembly(refl.AssemblyModel);
            //assembly = refl.AssemblyModel;
        }


        //public Reflector CreateBase()
        //{
           
        //    return reflBase;
        //}
    }
}
