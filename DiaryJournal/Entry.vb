''' <summary>
''' We create this Entry class to just store date/time and texts so the only methods used are the constructor and ToString().
''' The user will input a text and date and time the action occurred. Then we'll create a separte Database object that stores
''' our entries aand allows for data manipulation using different list methods
''' </summary>
Public Class Entry
  Public Property Occurs As DateTime
  Public Property Text As String

  Public Sub New(occurs As DateTime, text As String)
    Me.Occurs = occurs
    Me.Text = text
  End Sub

  Public Overrides Function ToString() As String
    Return Occurs & " " & Text
  End Function
End Class
