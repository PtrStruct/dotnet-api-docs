using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Services;


// Intercept marshal, unmarshal, and disconnect events for an object.
public class TrackingHandler : ITrackingHandler
{
    // Called when the tracked object is marshaled.

    [System.Security.Permissions.SecurityPermissionAttribute(
     System.Security.Permissions.SecurityAction.LinkDemand,
     Flags=System.Security.Permissions.SecurityPermissionFlag.Infrastructure)]
    public void MarshaledObject(Object obj, ObjRef objRef)
    {
        // Notify the user of the marshal event.
        Console.WriteLine("Tracking: An instance of {0} was marshaled.", 
            obj.ToString());

        // Print the channel information.
        if (objRef.ChannelInfo != null)
        {
            // Iterate over ChannelData.
            foreach(object data in objRef.ChannelInfo.ChannelData)
            {
                if (data is ChannelDataStore)
                {
                    // Print the URIs from the ChannelDataStore objects.
                    string[] uris = ((ChannelDataStore)data).ChannelUris;
                    foreach(string uri in uris)
                        Console.WriteLine("ChannelUri: " + uri);
                }
            }
        }

        // Print the envoy information.
        if (objRef.EnvoyInfo != null)
            Console.WriteLine("EnvoyInfo: " + objRef.EnvoyInfo.ToString());

        // Print the type information.
        if (objRef.TypeInfo != null)
        {
            Console.WriteLine("TypeInfo: " + objRef.TypeInfo.ToString());
            Console.WriteLine("TypeName: " + objRef.TypeInfo.TypeName);
        }

        // Print the URI.
        if (objRef.URI != null)
            Console.WriteLine("URI: " + objRef.URI.ToString());
    }

    // Called when the tracked object is unmarshaled.
    [System.Security.Permissions.SecurityPermissionAttribute(
     System.Security.Permissions.SecurityAction.LinkDemand,
     Flags=System.Security.Permissions.SecurityPermissionFlag.Infrastructure)]
    public void UnmarshaledObject(Object obj, ObjRef objRef)
    {
        Console.WriteLine("Tracking: An instance of {0} was unmarshaled.", 
            obj.ToString());
    }

    // Called when the tracked object is disconnected.
    [System.Security.Permissions.SecurityPermissionAttribute(
     System.Security.Permissions.SecurityAction.LinkDemand,
     Flags=System.Security.Permissions.SecurityPermissionFlag.Infrastructure)]
    public void DisconnectedObject(Object obj)
    {
        Console.WriteLine("Tracking: An instance of {0} was disconnected.", 
            obj.ToString());
    }
}