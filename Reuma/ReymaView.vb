Module ReymaView
    Dim Reyma As New Electricity
    Sub Main()
        Do
            Reyma.LoadData()
            Console.Clear()
            Console.WriteLine("-------- Ρευμα ----------")
            Console.WriteLine("Κωδικός πελάτη:" & Reyma.KwdikosPelath)
            Console.WriteLine("Αριθμός παροχής:" & Reyma.ArithmosParoxhs)
            Console.WriteLine("-------------------------")
            Console.WriteLine("1) Προσθήκη Λγαριασμου.")
            Console.WriteLine("2) Αναλυτικά.")
            Console.WriteLine("3) Exit.")
            Console.WriteLine()
            Console.WriteLine("Επέλεξε ενα απο το μενου:")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    Add()
                Case 2
                    Analytika()
                Case 3
                    Exit Sub
            End Select
        Loop
    End Sub
    Sub Analytika()
        Do
            Reyma.LoadData()
            Console.Clear()
            Console.WriteLine("--------------- Αναλυτικά ρευμα ---------")
            Console.WriteLine()

            For i = 0 To Reyma.Items.Count - 1
                Console.WriteLine("--------- Επιλογή: " & i + 1 & " --------------")
                Console.WriteLine("Εκδοσή: " & Reyma.Items(i).Ekdosh)
                Console.WriteLine("Περιοδός κατανάλωσης:" & Reyma.Items(i).PeriodosKatanalwshs(0) & " - " & Reyma.Items(i).PeriodosKatanalwshs(1))
                Console.WriteLine("Ποσό:" & Reyma.Items(i).Poso)
                Console.WriteLine("Πληρώθηκε:" & Reyma.Items(i).Payed)
                Console.WriteLine("-----------------------------------------------")
            Next

            Console.WriteLine()
            Console.WriteLine("--------------- Menu --------------------")
            Console.WriteLine(1 & " - " & Reyma.Items.Count & ") Επιλογή.")
            Console.WriteLine(Reyma.Items.Count + 1 & ") Προσθήκη Νεου.")
            Console.WriteLine(Reyma.Items.Count + 2 & ") Exit.")
            Dim Choice As String = Console.ReadLine - 1
            Select Case Choice
                Case 0 To Reyma.Items.Count - 1
                    ChoiceShow(Reyma.Items(Choice))
                Case Reyma.Items.Count
                    Add()
                Case Reyma.Items.Count + 1
                    Exit Do
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
    Sub Add()
        Do


            Console.Clear()
            Console.WriteLine("------------- Add Electricity Bill ------------")
            Dim Base As New ElectricityEntity

            With Base

                Console.WriteLine("Δώσε αριθμό εγράφου:")
                .ArithmosEgrafoy = Console.ReadLine
                Console.Clear()
                Show(Base)

                Console.WriteLine("Δώσε ημμερομηνήνία έκδοσης:")
                .Ekdosh = Console.ReadLine
                Console.Clear()
                Show(Base)

                Console.WriteLine("Δώσε Ημμερομηνία εναρξης Κατανάλωσης:")
                .PeriodosKatanalwshs(0) = Console.ReadLine

                Console.WriteLine("Δώσε ημμερομηνία Τελικής κατανάλωσης:")
                .PeriodosKatanalwshs(1) = Console.ReadLine
                Console.Clear()
                Show(Base)

                Console.WriteLine("Δώσε αναφορα:")
                .Anafora = Console.ReadLine
                Console.Clear()
                Show(Base)

                Console.WriteLine("Πληρωμή έως:")
                .PlhrwmhEws = Console.ReadLine
                Console.Clear()
                Show(Base)

                Console.WriteLine("Το ποσό είναι:")
                .Poso = Console.ReadLine
                Console.Clear()
                Show(Base)

again1:
                Console.WriteLine("Πληρώθηκε:")
                Console.WriteLine("Y) NAI")
                Console.WriteLine("N) OXI")
                Dim Choiceer As String = Console.ReadLine
                Select Case Choiceer
                    Case "Y"
                        .Payed = True
                    Case "N"
                        .Payed = False
                    Case Else
                        GoTo again1
                End Select
                Console.Clear()
                Show(Base)

                Console.WriteLine("Κατανάλωση:")
                .Katanalwsh = Console.ReadLine
                Console.Clear()
                Show(Base)

                Console.WriteLine("Αρχείο:")
                .Arxeio = Console.ReadLine
                Console.Clear()
                Show(Base)

                .TypeBill = 0
            End With

Again:
            Console.Clear()
            Console.WriteLine("------------- Επισκοπήση προσπαθειας εγραφής ------------")
            Show(Base)
            Console.WriteLine("Θέλεις να συνεχήσεις με την Εγραφή?")
            Console.WriteLine("Y) NAI.")
            Console.WriteLine("N) OXI.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case "Y"
                    Reyma.Add(Base)
                    Exit Do
                Case "N"
                    Continue Do
                Case Else
                    GoTo Again
            End Select
        Loop

    End Sub

    Sub Show(ElectricityLink As ElectricityEntity)
        With ElectricityLink
            If .ID <> Nothing Then Console.WriteLine("ID: " & .ID)
            If .ArithmosEgrafoy <> Nothing Then Console.WriteLine("Αριθμός εγραφού: " & .ArithmosEgrafoy)
            If .Ekdosh <> Nothing Then Console.WriteLine("έκδοση: " & .Ekdosh)
            If .PeriodosKatanalwshs(0) <> Nothing And .PeriodosKatanalwshs(1) <> Nothing Then Console.WriteLine("Περιοδος κατανάλωσης: " & .PeriodosKatanalwshs(0) & " - " & .PeriodosKatanalwshs(1))
            If .Anafora <> Nothing Then Console.WriteLine("Αναφορά: " & .Anafora)
            If .PlhrwmhEws <> Nothing Then Console.WriteLine("Πληρωμη Εώς: " & .PlhrwmhEws)
            If .Poso <> Nothing Then Console.WriteLine("Ποσό: " & .Poso)
            If .Payed <> Nothing Then Console.WriteLine("Πληρώθηκε: " & .Payed)
            If .Katanalwsh <> Nothing Then Console.WriteLine("Κατανάλωση: " & .Katanalwsh)
            If .Arxeio <> Nothing Then Console.WriteLine("Αρχείο: " & .Arxeio)
        End With
    End Sub

    Sub ChoiceShow(ElectricityLink As ElectricityEntity)
        Do
            Console.Clear()
            Console.WriteLine("------------ Λογαριασμός ρευματος -----------")
            Show(ElectricityLink)
            Console.WriteLine("----------------- Menu ---------------------")
            Console.WriteLine("1) Επεξεργασία.")
            Console.WriteLine("2) Διαγραφή.")
            Console.WriteLine("3) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    Update(ElectricityLink)
                Case 2

                Case 3
                    Exit Sub
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
    Sub Update(ByRef Electric As ElectricityEntity)
        Do
            Dim NewElectric As New ElectricityEntity
            Console.Clear()
            Console.WriteLine("-------------- Επεξεργασία Λογαριασμου ρευματος --------------")
            Show(Electric)
            Console.WriteLine("--------------------------------------------------------------")
            With NewElectric

                Console.WriteLine("Δώσε αριθμό εγράφου:")
                .ArithmosEgrafoy = Console.ReadLine
                Console.Clear()
                Console.WriteLine("-------------- Επεξεργασία Λογαριασμου ρευματος --------------")
                Show(Electric)
                Console.WriteLine("--------------------------------------------------------------")
                Show(NewElectric)

                Console.WriteLine("Δώσε ημμερομηνήνία έκδοσης:")
                .Ekdosh = Console.ReadLine
                Console.Clear()
                Console.WriteLine("-------------- Επεξεργασία Λογαριασμου ρευματος --------------")
                Show(Electric)
                Console.WriteLine("--------------------------------------------------------------")
                Show(NewElectric)

                Console.WriteLine("Δώσε Ημμερομηνία εναρξης Κατανάλωσης:")
                .PeriodosKatanalwshs(0) = Console.ReadLine

                Console.WriteLine("Δώσε ημμερομηνία Τελικής κατανάλωσης:")
                .PeriodosKatanalwshs(1) = Console.ReadLine
                Console.Clear()
                Console.WriteLine("-------------- Επεξεργασία Λογαριασμου ρευματος --------------")
                Show(Electric)
                Console.WriteLine("--------------------------------------------------------------")
                Show(NewElectric)

                Console.WriteLine("Δώσε αναφορα:")
                .Anafora = Console.ReadLine
                Console.Clear()
                Console.WriteLine("-------------- Επεξεργασία Λογαριασμου ρευματος --------------")
                Show(Electric)
                Console.WriteLine("--------------------------------------------------------------")
                Show(NewElectric)

                Console.WriteLine("Πληρωμή έως:")
                .PlhrwmhEws = Console.ReadLine
                Console.Clear()
                Console.WriteLine("-------------- Επεξεργασία Λογαριασμου ρευματος --------------")
                Show(Electric)
                Console.WriteLine("--------------------------------------------------------------")
                Show(NewElectric)

                Console.WriteLine("Το ποσό είναι:")
                .Poso = Console.ReadLine
                Console.Clear()
                Console.WriteLine("-------------- Επεξεργασία Λογαριασμου ρευματος --------------")
                Show(Electric)
                Console.WriteLine("--------------------------------------------------------------")
                Show(NewElectric)

again1:
                Console.WriteLine("Πληρώθηκε:")
                Console.WriteLine("Y) NAI")
                Console.WriteLine("N) OXI")
                Dim Choiceer As String = Console.ReadLine
                Select Case Choiceer
                    Case "Y"
                        .Payed = True
                    Case "N"
                        .Payed = False
                    Case Else
                        GoTo again1
                End Select
                Console.Clear()
                Console.WriteLine("-------------- Επεξεργασία Λογαριασμου ρευματος --------------")
                Show(Electric)
                Console.WriteLine("--------------------------------------------------------------")
                Show(NewElectric)

                Console.WriteLine("Κατανάλωση:")
                .Katanalwsh = Console.ReadLine
                Console.Clear()
                Console.WriteLine("-------------- Επεξεργασία Λογαριασμου ρευματος --------------")
                Show(Electric)
                Console.WriteLine("--------------------------------------------------------------")
                Show(NewElectric)

                Console.WriteLine("Αρχείο:")
                .Arxeio = Console.ReadLine
                Console.Clear()
                Console.WriteLine("-------------- Επεξεργασία Λογαριασμου ρευματος --------------")
                Show(Electric)
                Console.WriteLine("--------------------------------------------------------------")
                Show(NewElectric)

                .TypeBill = 0
            End With

            Do
                Console.Clear()
                Console.WriteLine("------------ Παλίος Λογαριασμός ρευματος --------------------")
                Show(Electric)
                Console.WriteLine()
                Console.WriteLine("------------ Καινουργιοσ Λογαριασμός Ρευματος ---------------")
                Show(NewElectric)
                Console.WriteLine("-------------------------------------------------------------")
                Console.WriteLine("Θέλεις να συνεχήσεις με την αλλαγή?")
                Console.WriteLine("Y) NAI")
                Console.WriteLine("N) OXI")
                Console.WriteLine("Δώσε την απάντηση:")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case "Y"
                        Reyma.Update(Electric, NewElectric)
                        NewElectric.ID = Electric.ID
                        Electric = NewElectric
                        Exit Sub
                    Case "N"
                        Exit Do
                    Case Else
                        Continue Do
                End Select
            Loop

        Loop
    End Sub

End Module
