﻿using System.Xml.Serialization;

namespace ChummerDataViewer.Backend.Enums;

public enum WeaponMountSlots
{
    [XmlEnum("Stock")]
    Stock,
    
    [XmlEnum("Side")]
    Side,
    
    [XmlEnum("Top")]
    Top,
    
    [XmlEnum("Under")]
    Under,
    
    [XmlEnum("Barrel")]
    Barrel,
    
    Internal
}