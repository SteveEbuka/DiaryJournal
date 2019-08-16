Module Module1

  Sub Main()
    Dim myDiary As New Diary()
    Dim choice As Char = "0"c
    'main loop
    While choice <> "4"c
      myDiary.PrintHomeScreen()
      Console.WriteLine("Choose an action")
      Console.WriteLine()
      Console.WriteLine("1 - Add new entry")
      Console.WriteLine("2 - Search for entries")
      Console.WriteLine("3 - Delete entries")
      Console.WriteLine("4 - End")
      choice = Console.ReadKey().KeyChar
      Console.WriteLine()
      'Reaction to choice
      Select Case choice
        Case "1"
          myDiary.AddEntry()
        Case "2"
          myDiary.SearchEntries()
        Case "3"
          myDiary.DeleteEntries()
        Case "4"
          Console.WriteLine("Press any key to quit the program...")
        Case Else
          Console.WriteLine("Error.Press any key to choose another action...")
      End Select
      Console.ReadKey()
    End While

  End Sub

End Module
