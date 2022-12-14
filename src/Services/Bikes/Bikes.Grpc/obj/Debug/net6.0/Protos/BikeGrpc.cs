// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/bike.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Bikes.Grpc.Protos {
  public static partial class BikeProtoService
  {
    static readonly string __ServiceName = "BikeProtoService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Bikes.Grpc.Protos.GetRequest> __Marshaller_GetRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Bikes.Grpc.Protos.GetRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Bikes.Grpc.Protos.BikeModel> __Marshaller_BikeModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Bikes.Grpc.Protos.BikeModel.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Bikes.Grpc.Protos.CreateRequest> __Marshaller_CreateRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Bikes.Grpc.Protos.CreateRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Bikes.Grpc.Protos.UpdateRequest> __Marshaller_UpdateRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Bikes.Grpc.Protos.UpdateRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Bikes.Grpc.Protos.DeleteRequest> __Marshaller_DeleteRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Bikes.Grpc.Protos.DeleteRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Bikes.Grpc.Protos.DeleteResponse> __Marshaller_DeleteResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Bikes.Grpc.Protos.DeleteResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Bikes.Grpc.Protos.GetRequest, global::Bikes.Grpc.Protos.BikeModel> __Method_Get = new grpc::Method<global::Bikes.Grpc.Protos.GetRequest, global::Bikes.Grpc.Protos.BikeModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Get",
        __Marshaller_GetRequest,
        __Marshaller_BikeModel);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Bikes.Grpc.Protos.CreateRequest, global::Bikes.Grpc.Protos.BikeModel> __Method_CreateBike = new grpc::Method<global::Bikes.Grpc.Protos.CreateRequest, global::Bikes.Grpc.Protos.BikeModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateBike",
        __Marshaller_CreateRequest,
        __Marshaller_BikeModel);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Bikes.Grpc.Protos.BikeModel, global::Bikes.Grpc.Protos.BikeModel> __Method_AllocateBike = new grpc::Method<global::Bikes.Grpc.Protos.BikeModel, global::Bikes.Grpc.Protos.BikeModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AllocateBike",
        __Marshaller_BikeModel,
        __Marshaller_BikeModel);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Bikes.Grpc.Protos.UpdateRequest, global::Bikes.Grpc.Protos.BikeModel> __Method_Update = new grpc::Method<global::Bikes.Grpc.Protos.UpdateRequest, global::Bikes.Grpc.Protos.BikeModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Update",
        __Marshaller_UpdateRequest,
        __Marshaller_BikeModel);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Bikes.Grpc.Protos.DeleteRequest, global::Bikes.Grpc.Protos.DeleteResponse> __Method_Delete = new grpc::Method<global::Bikes.Grpc.Protos.DeleteRequest, global::Bikes.Grpc.Protos.DeleteResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Delete",
        __Marshaller_DeleteRequest,
        __Marshaller_DeleteResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Bikes.Grpc.Protos.BikeReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of BikeProtoService</summary>
    [grpc::BindServiceMethod(typeof(BikeProtoService), "BindService")]
    public abstract partial class BikeProtoServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Bikes.Grpc.Protos.BikeModel> Get(global::Bikes.Grpc.Protos.GetRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Bikes.Grpc.Protos.BikeModel> CreateBike(global::Bikes.Grpc.Protos.CreateRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Bikes.Grpc.Protos.BikeModel> AllocateBike(global::Bikes.Grpc.Protos.BikeModel request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Bikes.Grpc.Protos.BikeModel> Update(global::Bikes.Grpc.Protos.UpdateRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Bikes.Grpc.Protos.DeleteResponse> Delete(global::Bikes.Grpc.Protos.DeleteRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(BikeProtoServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Get, serviceImpl.Get)
          .AddMethod(__Method_CreateBike, serviceImpl.CreateBike)
          .AddMethod(__Method_AllocateBike, serviceImpl.AllocateBike)
          .AddMethod(__Method_Update, serviceImpl.Update)
          .AddMethod(__Method_Delete, serviceImpl.Delete).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, BikeProtoServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Get, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Bikes.Grpc.Protos.GetRequest, global::Bikes.Grpc.Protos.BikeModel>(serviceImpl.Get));
      serviceBinder.AddMethod(__Method_CreateBike, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Bikes.Grpc.Protos.CreateRequest, global::Bikes.Grpc.Protos.BikeModel>(serviceImpl.CreateBike));
      serviceBinder.AddMethod(__Method_AllocateBike, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Bikes.Grpc.Protos.BikeModel, global::Bikes.Grpc.Protos.BikeModel>(serviceImpl.AllocateBike));
      serviceBinder.AddMethod(__Method_Update, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Bikes.Grpc.Protos.UpdateRequest, global::Bikes.Grpc.Protos.BikeModel>(serviceImpl.Update));
      serviceBinder.AddMethod(__Method_Delete, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Bikes.Grpc.Protos.DeleteRequest, global::Bikes.Grpc.Protos.DeleteResponse>(serviceImpl.Delete));
    }

  }
}
#endregion
