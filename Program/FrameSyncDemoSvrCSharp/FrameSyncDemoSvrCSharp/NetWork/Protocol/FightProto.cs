//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Proto/FightProto.proto
namespace Proto.FightProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FightLoginReq")]
  public partial class FightLoginReq : global::ProtoBuf.IExtensible
  {
    public FightLoginReq() {}
    
    private uint _roomid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"roomid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint roomid
    {
      get { return _roomid; }
      set { _roomid = value; }
    }
    private uint _ticket;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"ticket", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint ticket
    {
      get { return _ticket; }
      set { _ticket = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}