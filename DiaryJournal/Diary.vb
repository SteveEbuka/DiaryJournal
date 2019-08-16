Public Class Diary
  Dim myDatabase As New Database()     'creating an instance of Database

  'the ReadTime() utillity method prompts the user to enter date and time and returns DateTime instance set to the entered value. 
  'There might be a problem of validating users input cos DateTime format depends on OS regional setting
  Public Function ReadDateTime() As DateTime
    Console.WriteLine("Enter date and time as e.g. [01/13/2019 14:00]:")
    Dim dateTime As DateTime
    While Not DateTime.TryParse(Console.ReadLine(), dateTime)
      Console.WriteLine("Error. Please try again")
    End While
    Return dateTime
  End Function

  Public Sub PrintEntries(day As DateTime)    'the method finds entries for d given day and prints them
    Dim entries As List(Of Entry) = myDatabase.FindEntries(day, False) 'byTime is false since we are printing only by date
    For Each entry As Entry In entries
      Console.WriteLine(entry)
    Next
  End Sub

  Public Sub AddEntry()
    Dim dateTime As DateTime = ReadDateTime()
    Console.WriteLine("Enter the entry text:")
    Dim text As String = Console.ReadLine()
    myDatabase.AddEntry(dateTime, text)
  End Sub

  Public Sub SearchEntries()
    'Entering the date
    Dim dateTime As DateTime = ReadDateTime()
    Dim found As List(Of Entry) = myDatabase.FindEntries(dateTime, False)   '"False" enables search by date andAlso time orelse date only
    'Printing searched entries
    If found.Count() > 0 Then
      Console.WriteLine("Entries found:")
      For Each entry As Entry In found
        Console.WriteLine(entry)
      Next
    Else
      'Nothing found
      Console.WriteLine("No entries were found")
    End If
  End Sub

  Public Sub DeleteEntries()
    Console.WriteLine("Entries that match exact date and time will be deleted")
    Dim dateTime As DateTime = ReadDateTime()
    myDatabase.DeleteEntries(dateTime)
  End Sub

  Public Sub PrintHomeScreen()    'method for printing home screen; allows user to only keep today and tomorrows journal; showing the current date and time and entries for today and tomorrow
    Console.Clear()
    Console.WriteLine("Welcome to your virtual diary")
    Console.WriteLine("Today is: {0}", DateTime.Now)
    Console.WriteLine()
    'Printing the home screen
    Console.WriteLine("Today is: {0}------", vbCrLf)
    PrintEntries(DateTime.Today)
    Console.WriteLine("Tomorrow is: {0}------", vbCrLf)
    PrintEntries(DateTime.Now.AddDays(1))
    Console.WriteLine()
  End Sub
End Class
