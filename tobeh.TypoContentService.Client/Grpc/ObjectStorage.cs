// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: objectStorage.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace tobeh.TypoContentService {

  /// <summary>Holder for reflection information generated from objectStorage.proto</summary>
  public static partial class ObjectStorageReflection {

    #region Descriptor
    /// <summary>File descriptor for objectStorage.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ObjectStorageReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNvYmplY3RTdG9yYWdlLnByb3RvEg1vYmplY3RTdG9yYWdlGg1jb250ZW50",
            "LnByb3RvGhtnb29nbGUvcHJvdG9idWYvZW1wdHkucHJvdG8iRgofQ2xvdWRJ",
            "bWFnZUlkZW50aWZpY2F0aW9uTWVzc2FnZRIPCgdpbWFnZUlkGAEgASgDEhIK",
            "CnVzZXJGb2xkZXIYAiABKAkikQIKF1NhdmVJbWFnZVRvQ2xvdWRNZXNzYWdl",
            "EjMKDmltYWdlRmlsZUNodW5rGAEgASgLMhkuY29udGVudC5GaWxlQ2h1bmtN",
            "ZXNzYWdlSAASNgoRY29tbWFuZHNGaWxlQ2h1bmsYAiABKAsyGS5jb250ZW50",
            "LkZpbGVDaHVua01lc3NhZ2VIABIyCg1tZXRhRmlsZUNodW5rGAMgASgLMhku",
            "Y29udGVudC5GaWxlQ2h1bmtNZXNzYWdlSAASTQoTaW1hZ2VJZGVudGlmaWNh",
            "dGlvbhgEIAEoCzIuLm9iamVjdFN0b3JhZ2UuQ2xvdWRJbWFnZUlkZW50aWZp",
            "Y2F0aW9uTWVzc2FnZUgAQgYKBGRhdGEibAocRGVsZXRlSW1hZ2VzRnJvbUNs",
            "b3VkTWVzc2FnZRJMChRpbWFnZUlkZW50aWZpY2F0aW9ucxgBIAMoCzIuLm9i",
            "amVjdFN0b3JhZ2UuQ2xvdWRJbWFnZUlkZW50aWZpY2F0aW9uTWVzc2FnZTLF",
            "AQoNT2JqZWN0U3RvcmFnZRJUChBTYXZlSW1hZ2VUb0Nsb3VkEiYub2JqZWN0",
            "U3RvcmFnZS5TYXZlSW1hZ2VUb0Nsb3VkTWVzc2FnZRoWLmdvb2dsZS5wcm90",
            "b2J1Zi5FbXB0eSgBEl4KFERlbGV0ZUltYWdlRnJvbUNsb3VkEi4ub2JqZWN0",
            "U3RvcmFnZS5DbG91ZEltYWdlSWRlbnRpZmljYXRpb25NZXNzYWdlGhYuZ29v",
            "Z2xlLnByb3RvYnVmLkVtcHR5QhuqAhh0b2JlaC5UeXBvQ29udGVudFNlcnZp",
            "Y2ViBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::tobeh.TypoContentService.ContentReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::tobeh.TypoContentService.CloudImageIdentificationMessage), global::tobeh.TypoContentService.CloudImageIdentificationMessage.Parser, new[]{ "ImageId", "UserFolder" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::tobeh.TypoContentService.SaveImageToCloudMessage), global::tobeh.TypoContentService.SaveImageToCloudMessage.Parser, new[]{ "ImageFileChunk", "CommandsFileChunk", "MetaFileChunk", "ImageIdentification" }, new[]{ "Data" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::tobeh.TypoContentService.DeleteImagesFromCloudMessage), global::tobeh.TypoContentService.DeleteImagesFromCloudMessage.Parser, new[]{ "ImageIdentifications" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class CloudImageIdentificationMessage : pb::IMessage<CloudImageIdentificationMessage>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CloudImageIdentificationMessage> _parser = new pb::MessageParser<CloudImageIdentificationMessage>(() => new CloudImageIdentificationMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CloudImageIdentificationMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::tobeh.TypoContentService.ObjectStorageReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CloudImageIdentificationMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CloudImageIdentificationMessage(CloudImageIdentificationMessage other) : this() {
      imageId_ = other.imageId_;
      userFolder_ = other.userFolder_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CloudImageIdentificationMessage Clone() {
      return new CloudImageIdentificationMessage(this);
    }

    /// <summary>Field number for the "imageId" field.</summary>
    public const int ImageIdFieldNumber = 1;
    private long imageId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long ImageId {
      get { return imageId_; }
      set {
        imageId_ = value;
      }
    }

    /// <summary>Field number for the "userFolder" field.</summary>
    public const int UserFolderFieldNumber = 2;
    private string userFolder_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string UserFolder {
      get { return userFolder_; }
      set {
        userFolder_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CloudImageIdentificationMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CloudImageIdentificationMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ImageId != other.ImageId) return false;
      if (UserFolder != other.UserFolder) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ImageId != 0L) hash ^= ImageId.GetHashCode();
      if (UserFolder.Length != 0) hash ^= UserFolder.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ImageId != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(ImageId);
      }
      if (UserFolder.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(UserFolder);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ImageId != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(ImageId);
      }
      if (UserFolder.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(UserFolder);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (ImageId != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(ImageId);
      }
      if (UserFolder.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UserFolder);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CloudImageIdentificationMessage other) {
      if (other == null) {
        return;
      }
      if (other.ImageId != 0L) {
        ImageId = other.ImageId;
      }
      if (other.UserFolder.Length != 0) {
        UserFolder = other.UserFolder;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            ImageId = input.ReadInt64();
            break;
          }
          case 18: {
            UserFolder = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            ImageId = input.ReadInt64();
            break;
          }
          case 18: {
            UserFolder = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class SaveImageToCloudMessage : pb::IMessage<SaveImageToCloudMessage>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<SaveImageToCloudMessage> _parser = new pb::MessageParser<SaveImageToCloudMessage>(() => new SaveImageToCloudMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<SaveImageToCloudMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::tobeh.TypoContentService.ObjectStorageReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SaveImageToCloudMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SaveImageToCloudMessage(SaveImageToCloudMessage other) : this() {
      switch (other.DataCase) {
        case DataOneofCase.ImageFileChunk:
          ImageFileChunk = other.ImageFileChunk.Clone();
          break;
        case DataOneofCase.CommandsFileChunk:
          CommandsFileChunk = other.CommandsFileChunk.Clone();
          break;
        case DataOneofCase.MetaFileChunk:
          MetaFileChunk = other.MetaFileChunk.Clone();
          break;
        case DataOneofCase.ImageIdentification:
          ImageIdentification = other.ImageIdentification.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SaveImageToCloudMessage Clone() {
      return new SaveImageToCloudMessage(this);
    }

    /// <summary>Field number for the "imageFileChunk" field.</summary>
    public const int ImageFileChunkFieldNumber = 1;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::tobeh.TypoContentService.FileChunkMessage ImageFileChunk {
      get { return dataCase_ == DataOneofCase.ImageFileChunk ? (global::tobeh.TypoContentService.FileChunkMessage) data_ : null; }
      set {
        data_ = value;
        dataCase_ = value == null ? DataOneofCase.None : DataOneofCase.ImageFileChunk;
      }
    }

    /// <summary>Field number for the "commandsFileChunk" field.</summary>
    public const int CommandsFileChunkFieldNumber = 2;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::tobeh.TypoContentService.FileChunkMessage CommandsFileChunk {
      get { return dataCase_ == DataOneofCase.CommandsFileChunk ? (global::tobeh.TypoContentService.FileChunkMessage) data_ : null; }
      set {
        data_ = value;
        dataCase_ = value == null ? DataOneofCase.None : DataOneofCase.CommandsFileChunk;
      }
    }

    /// <summary>Field number for the "metaFileChunk" field.</summary>
    public const int MetaFileChunkFieldNumber = 3;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::tobeh.TypoContentService.FileChunkMessage MetaFileChunk {
      get { return dataCase_ == DataOneofCase.MetaFileChunk ? (global::tobeh.TypoContentService.FileChunkMessage) data_ : null; }
      set {
        data_ = value;
        dataCase_ = value == null ? DataOneofCase.None : DataOneofCase.MetaFileChunk;
      }
    }

    /// <summary>Field number for the "imageIdentification" field.</summary>
    public const int ImageIdentificationFieldNumber = 4;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::tobeh.TypoContentService.CloudImageIdentificationMessage ImageIdentification {
      get { return dataCase_ == DataOneofCase.ImageIdentification ? (global::tobeh.TypoContentService.CloudImageIdentificationMessage) data_ : null; }
      set {
        data_ = value;
        dataCase_ = value == null ? DataOneofCase.None : DataOneofCase.ImageIdentification;
      }
    }

    private object data_;
    /// <summary>Enum of possible cases for the "data" oneof.</summary>
    public enum DataOneofCase {
      None = 0,
      ImageFileChunk = 1,
      CommandsFileChunk = 2,
      MetaFileChunk = 3,
      ImageIdentification = 4,
    }
    private DataOneofCase dataCase_ = DataOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public DataOneofCase DataCase {
      get { return dataCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearData() {
      dataCase_ = DataOneofCase.None;
      data_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as SaveImageToCloudMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(SaveImageToCloudMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(ImageFileChunk, other.ImageFileChunk)) return false;
      if (!object.Equals(CommandsFileChunk, other.CommandsFileChunk)) return false;
      if (!object.Equals(MetaFileChunk, other.MetaFileChunk)) return false;
      if (!object.Equals(ImageIdentification, other.ImageIdentification)) return false;
      if (DataCase != other.DataCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (dataCase_ == DataOneofCase.ImageFileChunk) hash ^= ImageFileChunk.GetHashCode();
      if (dataCase_ == DataOneofCase.CommandsFileChunk) hash ^= CommandsFileChunk.GetHashCode();
      if (dataCase_ == DataOneofCase.MetaFileChunk) hash ^= MetaFileChunk.GetHashCode();
      if (dataCase_ == DataOneofCase.ImageIdentification) hash ^= ImageIdentification.GetHashCode();
      hash ^= (int) dataCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (dataCase_ == DataOneofCase.ImageFileChunk) {
        output.WriteRawTag(10);
        output.WriteMessage(ImageFileChunk);
      }
      if (dataCase_ == DataOneofCase.CommandsFileChunk) {
        output.WriteRawTag(18);
        output.WriteMessage(CommandsFileChunk);
      }
      if (dataCase_ == DataOneofCase.MetaFileChunk) {
        output.WriteRawTag(26);
        output.WriteMessage(MetaFileChunk);
      }
      if (dataCase_ == DataOneofCase.ImageIdentification) {
        output.WriteRawTag(34);
        output.WriteMessage(ImageIdentification);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (dataCase_ == DataOneofCase.ImageFileChunk) {
        output.WriteRawTag(10);
        output.WriteMessage(ImageFileChunk);
      }
      if (dataCase_ == DataOneofCase.CommandsFileChunk) {
        output.WriteRawTag(18);
        output.WriteMessage(CommandsFileChunk);
      }
      if (dataCase_ == DataOneofCase.MetaFileChunk) {
        output.WriteRawTag(26);
        output.WriteMessage(MetaFileChunk);
      }
      if (dataCase_ == DataOneofCase.ImageIdentification) {
        output.WriteRawTag(34);
        output.WriteMessage(ImageIdentification);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (dataCase_ == DataOneofCase.ImageFileChunk) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ImageFileChunk);
      }
      if (dataCase_ == DataOneofCase.CommandsFileChunk) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CommandsFileChunk);
      }
      if (dataCase_ == DataOneofCase.MetaFileChunk) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MetaFileChunk);
      }
      if (dataCase_ == DataOneofCase.ImageIdentification) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ImageIdentification);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(SaveImageToCloudMessage other) {
      if (other == null) {
        return;
      }
      switch (other.DataCase) {
        case DataOneofCase.ImageFileChunk:
          if (ImageFileChunk == null) {
            ImageFileChunk = new global::tobeh.TypoContentService.FileChunkMessage();
          }
          ImageFileChunk.MergeFrom(other.ImageFileChunk);
          break;
        case DataOneofCase.CommandsFileChunk:
          if (CommandsFileChunk == null) {
            CommandsFileChunk = new global::tobeh.TypoContentService.FileChunkMessage();
          }
          CommandsFileChunk.MergeFrom(other.CommandsFileChunk);
          break;
        case DataOneofCase.MetaFileChunk:
          if (MetaFileChunk == null) {
            MetaFileChunk = new global::tobeh.TypoContentService.FileChunkMessage();
          }
          MetaFileChunk.MergeFrom(other.MetaFileChunk);
          break;
        case DataOneofCase.ImageIdentification:
          if (ImageIdentification == null) {
            ImageIdentification = new global::tobeh.TypoContentService.CloudImageIdentificationMessage();
          }
          ImageIdentification.MergeFrom(other.ImageIdentification);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            global::tobeh.TypoContentService.FileChunkMessage subBuilder = new global::tobeh.TypoContentService.FileChunkMessage();
            if (dataCase_ == DataOneofCase.ImageFileChunk) {
              subBuilder.MergeFrom(ImageFileChunk);
            }
            input.ReadMessage(subBuilder);
            ImageFileChunk = subBuilder;
            break;
          }
          case 18: {
            global::tobeh.TypoContentService.FileChunkMessage subBuilder = new global::tobeh.TypoContentService.FileChunkMessage();
            if (dataCase_ == DataOneofCase.CommandsFileChunk) {
              subBuilder.MergeFrom(CommandsFileChunk);
            }
            input.ReadMessage(subBuilder);
            CommandsFileChunk = subBuilder;
            break;
          }
          case 26: {
            global::tobeh.TypoContentService.FileChunkMessage subBuilder = new global::tobeh.TypoContentService.FileChunkMessage();
            if (dataCase_ == DataOneofCase.MetaFileChunk) {
              subBuilder.MergeFrom(MetaFileChunk);
            }
            input.ReadMessage(subBuilder);
            MetaFileChunk = subBuilder;
            break;
          }
          case 34: {
            global::tobeh.TypoContentService.CloudImageIdentificationMessage subBuilder = new global::tobeh.TypoContentService.CloudImageIdentificationMessage();
            if (dataCase_ == DataOneofCase.ImageIdentification) {
              subBuilder.MergeFrom(ImageIdentification);
            }
            input.ReadMessage(subBuilder);
            ImageIdentification = subBuilder;
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            global::tobeh.TypoContentService.FileChunkMessage subBuilder = new global::tobeh.TypoContentService.FileChunkMessage();
            if (dataCase_ == DataOneofCase.ImageFileChunk) {
              subBuilder.MergeFrom(ImageFileChunk);
            }
            input.ReadMessage(subBuilder);
            ImageFileChunk = subBuilder;
            break;
          }
          case 18: {
            global::tobeh.TypoContentService.FileChunkMessage subBuilder = new global::tobeh.TypoContentService.FileChunkMessage();
            if (dataCase_ == DataOneofCase.CommandsFileChunk) {
              subBuilder.MergeFrom(CommandsFileChunk);
            }
            input.ReadMessage(subBuilder);
            CommandsFileChunk = subBuilder;
            break;
          }
          case 26: {
            global::tobeh.TypoContentService.FileChunkMessage subBuilder = new global::tobeh.TypoContentService.FileChunkMessage();
            if (dataCase_ == DataOneofCase.MetaFileChunk) {
              subBuilder.MergeFrom(MetaFileChunk);
            }
            input.ReadMessage(subBuilder);
            MetaFileChunk = subBuilder;
            break;
          }
          case 34: {
            global::tobeh.TypoContentService.CloudImageIdentificationMessage subBuilder = new global::tobeh.TypoContentService.CloudImageIdentificationMessage();
            if (dataCase_ == DataOneofCase.ImageIdentification) {
              subBuilder.MergeFrom(ImageIdentification);
            }
            input.ReadMessage(subBuilder);
            ImageIdentification = subBuilder;
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class DeleteImagesFromCloudMessage : pb::IMessage<DeleteImagesFromCloudMessage>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<DeleteImagesFromCloudMessage> _parser = new pb::MessageParser<DeleteImagesFromCloudMessage>(() => new DeleteImagesFromCloudMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<DeleteImagesFromCloudMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::tobeh.TypoContentService.ObjectStorageReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public DeleteImagesFromCloudMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public DeleteImagesFromCloudMessage(DeleteImagesFromCloudMessage other) : this() {
      imageIdentifications_ = other.imageIdentifications_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public DeleteImagesFromCloudMessage Clone() {
      return new DeleteImagesFromCloudMessage(this);
    }

    /// <summary>Field number for the "imageIdentifications" field.</summary>
    public const int ImageIdentificationsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::tobeh.TypoContentService.CloudImageIdentificationMessage> _repeated_imageIdentifications_codec
        = pb::FieldCodec.ForMessage(10, global::tobeh.TypoContentService.CloudImageIdentificationMessage.Parser);
    private readonly pbc::RepeatedField<global::tobeh.TypoContentService.CloudImageIdentificationMessage> imageIdentifications_ = new pbc::RepeatedField<global::tobeh.TypoContentService.CloudImageIdentificationMessage>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::tobeh.TypoContentService.CloudImageIdentificationMessage> ImageIdentifications {
      get { return imageIdentifications_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as DeleteImagesFromCloudMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(DeleteImagesFromCloudMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!imageIdentifications_.Equals(other.imageIdentifications_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= imageIdentifications_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      imageIdentifications_.WriteTo(output, _repeated_imageIdentifications_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      imageIdentifications_.WriteTo(ref output, _repeated_imageIdentifications_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += imageIdentifications_.CalculateSize(_repeated_imageIdentifications_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(DeleteImagesFromCloudMessage other) {
      if (other == null) {
        return;
      }
      imageIdentifications_.Add(other.imageIdentifications_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            imageIdentifications_.AddEntriesFrom(input, _repeated_imageIdentifications_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            imageIdentifications_.AddEntriesFrom(ref input, _repeated_imageIdentifications_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
