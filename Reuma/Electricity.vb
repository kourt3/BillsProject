Imports MyDatabase = FoundationLibrary.Database
Imports FoundationLibrary.Database.Queries
Public Class Electricity
    Private MyDB As New MyDatabase.MSAccessOLEDB(MyDatabase.Tools.Providers.TypeProviders.ACE16, "Bills.accdb")
    Private _Electricity As New List(Of ElectricityEntity)
    Public KwdikosPelath As String
    Public ArithmosParoxhs As String
    ReadOnly Property Items As IReadOnlyList(Of ElectricityEntity)
        Get
            Return _Electricity
        End Get
    End Property

    Sub LoadData()
        _Electricity.Clear()
        Dim DT As New DataTable
        Dim Cmd As New MyDatabase.Tools.Command("BillBase")
        MyDB.Command(Cmd.QSelect, DT)
        For i = 0 To DT.Rows.Count - 1
            Dim Electric As New ElectricityEntity
            With Electric
                .ID = DT(i)(0)
                .ArithmosEgrafoy = DT(i)(1)
                .Ekdosh = DT(i)(2)
                .PeriodosKatanalwshs(0) = DT(i)(3)
                .PeriodosKatanalwshs(1) = DT(i)(4)
                .Anafora = DT(i)(5)
                .PlhrwmhEws = DT(i)(6)
                .Poso = DT(i)(7)
                .Payed = DT(i)(8)
                .Katanalwsh = DT(i)(9)
                .Arxeio = DT(i)(10)
                .TypeBill = DT(i)(11)
            End With
            _Electricity.Add(Electric)
        Next
    End Sub
    Sub Add(ElectricityLink As ElectricityEntity)
        Dim Cmd As New MyDatabase.Tools.Command("BillBase")
        Cmd.AddComand("ArithmosEgrafoy", ElectricityLink.ArithmosEgrafoy)
        Cmd.AddComand("Ekdosh", ElectricityLink.Ekdosh.ToString("yyyy/MM/dd"))
        Cmd.AddComand("PeriodosStart", ElectricityLink.PeriodosKatanalwshs(0).ToString("yyyy/MM/dd"))
        Cmd.AddComand("PeriodosEnd", ElectricityLink.PeriodosKatanalwshs(1).ToString("yyyy/MM/dd"))
        Cmd.AddComand("Anafora", ElectricityLink.Anafora)
        Cmd.AddComand("PlhrwmhEws", ElectricityLink.PlhrwmhEws.ToString("yyyy/MM/dd"))
        Cmd.AddComand("Poso", ElectricityLink.Poso)
        If ElectricityLink.Payed = True Then
            Cmd.AddComand("Payed", 1)
        Else
            Cmd.AddComand("Payed", 0)
        End If
        Cmd.AddComand("Katanalwsh", ElectricityLink.Katanalwsh)
        Cmd.AddComand("Arxeio", ElectricityLink.Arxeio)
        Cmd.AddComand("TypeBill", 0)
        MyDB.Command(MyDatabase.Queries.QInsert(Cmd))
    End Sub
    Sub Update(OldElectricity As ElectricityEntity, NewElectricity As ElectricityEntity)
        Dim Cmd As New MyDatabase.Tools.Command("BillBase", "[ID]=" & OldElectricity.ID)
        Cmd.AddComand("ArithmosEgrafoy", NewElectricity.ArithmosEgrafoy)
        Cmd.AddComand("Ekdosh", NewElectricity.Ekdosh.ToString("yyyy/MM/dd"))
        Cmd.AddComand("PeriodosStart", NewElectricity.PeriodosKatanalwshs(0).ToString("yyyy/MM/dd"))
        Cmd.AddComand("PeriodosEnd", NewElectricity.PeriodosKatanalwshs(1).ToString("yyyy/MM/dd"))
        Cmd.AddComand("Anafora", NewElectricity.Anafora)
        Cmd.AddComand("PlhrwmhEws", NewElectricity.PlhrwmhEws.ToString("yyyy/MM/dd"))
        Cmd.AddComand("Poso", NewElectricity.Poso)
        If NewElectricity.Payed = True Then
            Cmd.AddComand("Payed", 1)
        Else
            Cmd.AddComand("Payed", 0)
        End If
        Cmd.AddComand("Katanalwsh", NewElectricity.Katanalwsh)
        Cmd.AddComand("Arxeio", NewElectricity.Arxeio)
        Cmd.AddComand("TypeBill", 0)
        MsgBox(MyDatabase.Queries.QUpdate(Cmd))
        MyDB.Command(MyDatabase.Queries.QUpdate(Cmd))
    End Sub

End Class
