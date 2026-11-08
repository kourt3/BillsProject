Module Module1

    Sub Main()
        Do
            Console.WriteLine("-------- Bills -----------")
            Console.WriteLine("1) Ρεύμα.")
            Console.WriteLine("2) Αέριο.")
            Console.WriteLine("3) Κοινόχριστα")
            Console.WriteLine("4) Νερο.")
            Console.WriteLine("5) Exit.")
            Console.WriteLine("--------------------------")
            Console.WriteLine("Παρακαλω επέλεξε ενα απο το Menu:")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    ReymaView.Main()
                Case 2
                    AerioView.Main()
                Case 3
                    KoinoxristaView.Main()
                Case 4
                    NeroView.Main()
                Case 5
                    Exit Sub
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub

End Module
