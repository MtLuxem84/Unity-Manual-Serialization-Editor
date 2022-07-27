using System;

/// <summary>
/// To Create arrays for classes that need to be serialized
/// </summary>
public class MNAttributes : Attribute
{

  /*  public MNAttributes(int id)
    {
        this.ID = id;
    }
    public int ID { get; set; }*/

}

public class MNSerializeClass : Attribute
{

}

/// <summary>
/// Receive the serialization of classes marked MNCombine. Add number later
/// </summary>
public class MNReceive : Attribute
{

}

/// <summary>
/// Combine the serialization of other classes
/// </summary>
public class MNCombine : Attribute
{

}

public class MNIgnore : Attribute
{

}
/// <summary>
/// Direct calls to serializer
/// </summary>
public class MNDirect : Attribute { }
