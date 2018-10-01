Imports System.IO
Module Module1
    Sub Main()
        Console.Title = "Deck generator"
        Console.WriteLine("Enter a deck name: ")
        Dim DeckName As String = Console.ReadLine()
        Dim DeckWriter As StreamWriter = New StreamWriter("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\temp.txt")
        DeckWriter.WriteLine("#created by ...")
        DeckWriter.WriteLine("#main")
        AddCard(DeckWriter, "main", DeckName)
        DeckWriter.WriteLine("#extra")
        AddCard(DeckWriter, "extra", DeckName)
        DeckWriter.WriteLine("!side")
        DeckWriter.Close()
        File.Copy("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\temp.txt", "C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\" & DeckName & ".ydk")
        File.Delete("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\temp.txt")
    End Sub
    Private Function GetRandomFile(ByVal F As String) As String
        Dim R As Random = New Random
        Dim Files As String() = Directory.GetFiles(F)
        Return Files(R.Next(0, Files.Count))
    End Function
    Private Sub AddCard(ByRef DeckWriter As StreamWriter, ByVal Deck As String, ByVal DeckName As String)
        Dim CardLimit, DeckLimit As Integer
        If Deck = "main" Then
            CardLimit = 60
            DeckLimit = 62
        ElseIf Deck = "extra" Then
            CardLimit = 15
            DeckLimit = 78
        End If
        For x = 1 To CardLimit
            DeckWriter.WriteLine(Path.GetFileNameWithoutExtension(GetRandomFile("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\pics")))
        Next
        DeckWriter.Close()
        Dim DeckSize As Integer = File.ReadAllLines("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\temp.txt").Length
        DeckWriter = New StreamWriter("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\temp.txt", True)
        Do Until DeckSize = DeckLimit
            DeckSize = 0
            DeckWriter.WriteLine(Path.GetFileNameWithoutExtension(GetRandomFile("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\pics")))
            DeckWriter.Close()
            File.Copy("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\temp.txt", "C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\" & DeckName & ".ydk")
            Dim YGO As Process = Process.Start("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\ygopro_vs.exe")
            YGO.Kill()
            File.Replace("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\" & DeckName & ".ydk", "C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\temp.txt", Nothing)
            DeckSize = File.ReadAllLines("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\temp.txt").Length
            DeckWriter = New StreamWriter("C:\Users\Ajay\Documents\ygopro-1.033.7-v2-Percy\deck\temp.txt", True)
        Loop
    End Sub
End Module
