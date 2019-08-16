Public Class Database
  Private entries As List(Of Entry)

  Public Sub New()
    entries = New List(Of Entry)
  End Sub
  ' Or we can initialize the object in one fell swoop:     'Private entries As New List(Of Entry)

  Public Sub AddEntry(occurs As DateTime, text As String)
    entries.Add(New Entry(occurs, text))        'Creates a new instance of Entry with its parameters and stores it
  End Sub

  Public Function FindEntries(dateTime As DateTime, byTime As Boolean) As List(Of Entry)
    Dim found As New List(Of Entry)         'Also creating an instance of Entry object
    For Each entry As Entry In entries
      'fiter search by time and date [if boolean paramter is true] or date only [if boolean parameter is false]
      If ((byTime) AndAlso (entry.Occurs = dateTime)) OrElse ((Not byTime) AndAlso entry.Occurs.Date = dateTime.Date) Then
        found.Add(entry)
      End If
    Next
    Return found
  End Function
  'The following method deletes entries base on given time. It is performed using the findEntries() method. since we'll be 
  'deleting entries of specific date and time the boolean parameter of FindEntries() will be true
  Public Sub DeleteEntries(dateTime As DateTime)
    Dim found As List(Of Entry) = FindEntries(dateTime, True)
    For Each entry As Entry In found
      entries.Remove(entry)
    Next
  End Sub
End Class
'Next step is to create a diary class that allows user interaction and stores entries input in the diary in the the database
