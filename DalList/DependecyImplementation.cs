﻿

namespace Dal;
using DO;
using DalApi;
using System.Collections.Generic;

public class DependecyImplementation : IDependency
{
    /// <summary>
    /// create a new item in the Dependency list
    /// </summary>
    /// <param name="item">the item to add</param>
    /// <returns>the id of the item we addad</returns>
    public int Create(Dependency item)
    {
        int newId = DataSource.Config.NextIdDepency;
        Dependency newDenendency = new Dependency(newId,item.DependentTask,item.DependenceOnTask);
        DataSource.Dependencies.Add(newDenendency);
        return newDenendency.Id;
    }
    
    /// <summary>
    /// delete a item from the Dependency list
    /// </summary>
    /// <param name="id">the id of the item to delete</param>
    /// <exception cref="Exception">this id is not exist</exception>
    public void Delete(int id)

    {
        Dependency? foundDependency = DataSource.Dependencies.Find(x => x.Id == id);
        if (foundDependency != null)
        {
            DataSource.Dependencies.Remove(foundDependency);
        }
        else
        {
            throw new Exception($"Dependency with ID={id} does Not exist");
        }
    }

    /// <summary>
    /// read an item from the Dependency list
    /// </summary>
    /// <param name="id">the id of the item to delete</param>
    /// <returns>return a reference to the item</returns>
    public Dependency? Read(int id)
    {
        Dependency? foundDependency = DataSource.Dependencies.Find(x => x.Id == id);
        if (foundDependency == null)
        {
            return foundDependency;
        }
        return null;
    }

    /// <summary>
    /// read all of the Dependency list
    /// </summary>
    /// <returns>a list that copied from the Dependency list</returns>
    public List<Dependency> ReadAll()
    {
        return new List<Dependency>(DataSource.Dependencies);
    }

    /// <summary>
    /// update one item in the Dependency list
    /// </summary>
    /// <param name="item">the item to update</param>
    public void Update(Dependency item)
    {
        Delete(item.Id);
        Create(item);
    }

    /// <summary>
    /// delete all items in the Dependency list
    /// </summary>
    public void Reset()
    {
        DataSource.Dependencies.Clear();
    }
}
