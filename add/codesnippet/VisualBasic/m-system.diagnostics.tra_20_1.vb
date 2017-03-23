    ' Class-level declaration.
    ' Create a TraceSwitch.
    Private Shared generalSwitch As New TraceSwitch("General", "Entire Application")
    
    Public Shared Sub MyErrorMethod(myObject As Object, category As String)
        ' Write the message if the TraceSwitch level is set to Error or higher.
        If generalSwitch.TraceError Then
            Trace.Write("Invalid object for category. ")
        End If 
        ' Write a second message if the TraceSwitch level is set to Verbose.
        If generalSwitch.TraceVerbose Then
            Trace.WriteLine(myObject, category)
        End If
    End Sub