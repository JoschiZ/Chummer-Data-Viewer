﻿using System.Xml.Serialization;
using ChummerDataViewer.Backend.Interfaces;

namespace ChummerDataViewer.Backend.Classes.XmlRoots;

[XmlRoot("chummer")]
public class RangesXmlRoot: ICreatable
{
    [XmlArray("ranges")]
    [XmlArrayItem("range")]
    public List<WeaponRange> Ranges { get; set; } = new();

    public async Task CreateAsync(ILogger logger, ICreatable? baseObject)
    {
        var taskList = new List<Task>();

        foreach (var range in Ranges)
        {
            taskList.Add(Task.Run(() => range.CreateAsync(logger)));
        }

        await Task.WhenAll(taskList);
        XmlLoader.CreatedXml.Add(GetType());
        
        logger.LogInformation("Created {Type}", GetType().Name);
    }
}