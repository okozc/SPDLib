Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class MyPrintEngine

#Region "Unmanaged"
    Private iDocument As MyDocument
    Private iExternalSQLConnection As SqlConnection
    Private iExternalODBCConnection As OdbcConnection
    'Private iExternalDataTable() As DataTable
#End Region

#Region "Managed"
    Private iDrawEngine As MyDrawEngine2
    Private WithEvents iPrintDialog As MyPrintDialog
    Private WithEvents iPrintDocument As PrintDocument
    Private iPageSettings As PageSettings
    Private iPrinterDialog As PrintDialog
    Private iPrintScale As Double

    Private PTotalPages As Integer
    Private PActualPage As Integer
    Private PPageMaxHeight As Integer
    Private ActualPageHeight As Integer

    'Private iDataTable() As DataTable
    'Private iSQLQuery() As String
    'Private iODBCQuery() As String
    Private DataAcquired As Boolean
#End Region

    Public Property PrintScale As Double
        Get
            Return iPrintScale
        End Get
        Set(value As Double)
            iPrintScale = value
        End Set
    End Property
    Public WriteOnly Property ExternalSQLConnection As SqlConnection
        Set(value As SqlConnection)
            iExternalSQLConnection = value
        End Set
    End Property
    Public WriteOnly Property ExternalODBCConnection As OdbcConnection
        Set(value As OdbcConnection)
            iExternalODBCConnection = value
        End Set
    End Property

    Sub New()
        Dim PrSe As New PrinterSettings
        iPrintDialog = New MyPrintDialog
        iPageSettings = New PageSettings With {
            .PaperSize = PrSe.DefaultPageSettings.PaperSize,
            .Margins = New Margins(0, 0, 0, 0)}

        iPrintDocument = New PrintDocument With {
            .DocumentName = "Test Document",
            .DefaultPageSettings = iPageSettings,
            .OriginAtMargins = False}

        iPrinterDialog = New PrintDialog With {
            .Document = iPrintDocument,
            .AllowCurrentPage = False
        }
        AddHandler iPrintDocument.BeginPrint, AddressOf BeginDraw
        AddHandler iPrintDocument.PrintPage, AddressOf Draw
        AddHandler iPrintDocument.EndPrint, AddressOf EndDraw
        iPrintScale = 1.04 '0.835
        DataAcquired = False
    End Sub

    Public Sub PrintDocument(Document As MyDocument)
        iDocument = Document
        iPrintDialog.PrintDocument = iPrintDocument
        iPrintDialog.ShowDialog()
    End Sub

    Private Sub BeginDraw()
        iDrawEngine = New MyDrawEngine2()
        PTotalPages = 0
        PActualPage = 0
        PPageMaxHeight = iDocument.PageHeight
        Dim AllAreasDone As Boolean = False
        Dim BodyAreas As List(Of MyDocumentArea) = iDocument.GetAreaByType(DocumentAreaType.Body)
        Dim AreaIndex As Integer = 0
        'Get data for all DataTables
        If Not DataAcquired Then
            For Each Area In iDocument.DocumentAreas
                Select Case Area.DataSourceType
                    'Case MyDocumentArea.MyDataSourceType.DataTable
                    '    If Not IsNothing(Area.ExternalDataTable) And Area.ExternalDataTable.Rows.Count > 0 Then
                    '        For Each Item In Area.AreaItems
                    '            Select Case Item.Type
                    '                Case ItemType.Data
                    '                    Dim cItem As MyDataItem = CType(Item, MyDataItem)
                    '                    cItem.Assign(Area.ExternalDataTable.Rows(0))
                    '                Case ItemType.Barcode
                    '                    Dim cItem As MyBarcodeItem = CType(Item, MyBarcodeItem)
                    '                    'cItem.Assign(Area.ExternalDataTable.Rows(0))
                    '            End Select
                    '        Next
                    '    End If
                    Case MyDocumentArea.MyDataSourceType.SQLQuery
                        If Not IsNothing(iExternalSQLConnection) Then
                            Try
                                Area.InternalDataTable.Clear()
                                Dim C As SqlConnection = iExternalSQLConnection
                                Dim Q As String = Area.DataSourceSQLQuery
                                Dim DA As New SqlDataAdapter(Q, C)
                                DA.Fill(Area.InternalDataTable)
                            Catch ex As Exception
                                Area.InternalDataTable.Clear()
                            End Try
                        End If
                    Case MyDocumentArea.MyDataSourceType.ODBCQuery
                        If Not IsNothing(iExternalODBCConnection) Then
                            Try
                                Area.InternalDataTable.Clear()
                                Dim C As OdbcConnection = iExternalODBCConnection
                                Dim Q As String = Area.DataSourceODBCQuery
                                Dim DA As New OdbcDataAdapter(Q, C)
                                DA.Fill(Area.InternalDataTable)
                            Catch ex As Exception
                                Area.InternalDataTable.Clear()
                            End Try
                        End If
                End Select
            Next
        End If
        DataAcquired = True
        NewPage()

        Do Until AllAreasDone
            If ActualPageHeight + BodyAreas(AreaIndex).Height > PPageMaxHeight Then
                NewPage()
            Else
                ActualPageHeight += BodyAreas(AreaIndex).Height
            End If
            AreaIndex += 1
            If AreaIndex = BodyAreas.Count Then AllAreasDone = True
        Loop
        PActualPage = 1
        iPrintDialog.TotalPages = PTotalPages
    End Sub
    Private Sub Draw(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim PageRectangle As New Rectangle(ev.PageBounds.Location, ev.PageBounds.Size)
        Dim g As Graphics = ev.Graphics
        Dim AllAreasDone As Boolean = False
        g.ScaleTransform(iPrintScale, iPrintScale)
        Dim BaseOffset As New Point(0, 0)
        Dim BodyOffset As New Point(0, 0)
        Dim AvailableBodyHeight As Integer = 0
        'PActualPage = iPrintDialog
        Do Until AllAreasDone
            BaseOffset.X = 0
            AvailableBodyHeight = PPageMaxHeight
            If PActualPage = 1 Then
                If iDocument.AreaExists(DocumentAreaType.Header1stPage) Then
                    Dim HFArea As MyDocumentArea = iDocument.GetAreaByType(DocumentAreaType.Header1stPage)(0)
                    BaseOffset.Y = 0
                    iDrawEngine.DrawArea(BaseOffset, HFArea, g)
                    AvailableBodyHeight -= HFArea.Height
                    BodyOffset.Y = HFArea.Height
                ElseIf iDocument.AreaExists(DocumentAreaType.HeaderAllPages) Then
                    Dim HFArea As MyDocumentArea = iDocument.GetAreaByType(DocumentAreaType.HeaderAllPages)(0)
                    BaseOffset.Y = 0
                    iDrawEngine.DrawArea(BaseOffset, HFArea, g)
                    AvailableBodyHeight -= HFArea.Height
                    BodyOffset.Y = HFArea.Height
                End If
                If iDocument.AreaExists(DocumentAreaType.Footer1stPage) Then
                    Dim HFArea As MyDocumentArea = iDocument.GetAreaByType(DocumentAreaType.Footer1stPage)(0)
                    BaseOffset.Y = iDocument.PageHeight - HFArea.Height - 1
                    iDrawEngine.DrawArea(BaseOffset, HFArea, g)
                    AvailableBodyHeight -= HFArea.Height
                ElseIf iDocument.AreaExists(DocumentAreaType.FooterAllPages) Then
                    Dim HFArea As MyDocumentArea = iDocument.GetAreaByType(DocumentAreaType.FooterAllPages)(0)
                    BaseOffset.Y = iDocument.PageHeight - HFArea.Height - 1
                    iDrawEngine.DrawArea(BaseOffset, HFArea, g)
                    AvailableBodyHeight -= HFArea.Height
                End If
            End If
            If PActualPage > 1 Then
                If iDocument.AreaExists(DocumentAreaType.HeaderAllPages) Then
                    Dim HFArea As MyDocumentArea = iDocument.GetAreaByType(DocumentAreaType.HeaderAllPages)(0)
                    BaseOffset.Y = 0
                    iDrawEngine.DrawArea(BaseOffset, HFArea, g)
                    AvailableBodyHeight -= HFArea.Height
                    BodyOffset.Y = HFArea.Height
                End If
                If iDocument.AreaExists(DocumentAreaType.FooterAllPages) Then
                    Dim HFArea As MyDocumentArea = iDocument.GetAreaByType(DocumentAreaType.FooterAllPages)(0)
                    BaseOffset.Y = iDocument.PageHeight - HFArea.Height - 1
                    iDrawEngine.DrawArea(BaseOffset, HFArea, g)
                    AvailableBodyHeight -= HFArea.Height
                    BodyOffset.Y = HFArea.Height
                End If
            End If


            AllAreasDone = True
        Loop
        If PActualPage < PTotalPages Then
            PActualPage += 1
            ev.HasMorePages = True
        End If

    End Sub
    Private Sub EndDraw()
        iDrawEngine.Dispose()
    End Sub

    Private Sub NewPage(Optional AddTotal As Boolean = True)
        PActualPage += 1
        If AddTotal Then PTotalPages += 1
        ActualPageHeight = 0
        If PActualPage = 1 Then
            If iDocument.AreaExists(DocumentAreaType.Header1stPage) Then
                ActualPageHeight += iDocument.GetAreaByType(DocumentAreaType.Header1stPage)(0).Height
            ElseIf iDocument.AreaExists(DocumentAreaType.HeaderAllPages) Then
                ActualPageHeight += iDocument.GetAreaByType(DocumentAreaType.HeaderAllPages)(0).Height
            End If
            If iDocument.AreaExists(DocumentAreaType.Footer1stPage) Then
                ActualPageHeight += iDocument.GetAreaByType(DocumentAreaType.Footer1stPage)(0).Height
            ElseIf iDocument.AreaExists(DocumentAreaType.FooterAllPages) Then
                ActualPageHeight += iDocument.GetAreaByType(DocumentAreaType.FooterAllPages)(0).Height
            End If
        End If
        If PActualPage > 1 Then
            If iDocument.AreaExists(DocumentAreaType.HeaderAllPages) Then
                ActualPageHeight += iDocument.GetAreaByType(DocumentAreaType.HeaderAllPages)(0).Height
            End If
            If iDocument.AreaExists(DocumentAreaType.FooterAllPages) Then
                ActualPageHeight += iDocument.GetAreaByType(DocumentAreaType.FooterAllPages)(0).Height
            End If
        End If
    End Sub

    Private Sub PrintSetup() Handles iPrintDialog.PrinterSetupClicked
        iPrinterDialog.ShowDialog()
    End Sub
End Class
