Imports System.Globalization
Imports System.IO
Imports System.Runtime.CompilerServices
Imports CsvHelper

Module Module1

    Sub Main()
        WriteClassObj()
        Console.ReadKey()
    End Sub

    Sub WriteClassObj()
        Dim records As New List(Of Foo)({
                                        New Foo() With {.Id = 1, .Name = "One"},
                                        New Foo() With {.Id = 2, .Name = "One"},
                                        New Foo() With {.Id = 3, .Name = "One"},
                                        New Foo() With {.Id = 4, .Name = "One"}
                                        })
        records.WriteCSV("D:\\CSV\\fileVB2.csv")
    End Sub

    Public Class Foo
        Public Property Id As Integer
        Public Property Name As String
    End Class

End Module

Module MyExtensions
    <Extension>
    Public Sub WriteCSV(Of T)(list As IList(Of T), filePath As String)
        Using writer As New StreamWriter(filePath)
            Using csv As New CsvWriter(writer, CultureInfo.InvariantCulture)
                csv.WriteRecords(list)
            End Using
        End Using
    End Sub
End Module
