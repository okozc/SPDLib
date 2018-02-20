Imports System.ComponentModel

Public Enum DocumentAreaType
    Header1stPage
    HeaderAllPages
    Footer1stPage
    FooterAllPages
    Body
    MultiLabelBody
    PageBackground
End Enum


Public Class MyDocumentArea
    Implements IDisposable

    Public Enum MyDataSourceType
        None
        DataTable
        SQLQuery
        ODBCQuery
    End Enum
#Region "Unmanaged"
    Private iExternalDataTable As DataTable
#End Region

#Region "Managed"
    Private iAreaItems As List(Of MyItem)
    Private iAreaID As String
    Private iAreaName As String
    Private iAreaWidth As Integer
    Private iAreaHeight As Integer
    Private iDynamicHeight As Boolean
    Private iAreaType As DocumentAreaType
    Private iDataSourceType As MyDataSourceType
    Private iDataTable As DataTable
    Private iSQLQuery As String
    Private iODBCQuery As String
    Private iAreaFields As List(Of MyField)
#End Region

    <Browsable(False)> Public ReadOnly Property Items As List(Of MyItem)
        Get
            Return iAreaItems
        End Get
    End Property
    Public ReadOnly Property ID As String
        Get
            Return iAreaID
        End Get
    End Property
    Public Property Name As String
        Get
            Return iAreaName
        End Get
        Set(value As String)
            iAreaName = value
        End Set
    End Property
    Public Property Width As Integer
        Get
            Return iAreaWidth
        End Get
        Set(value As Integer)
            iAreaWidth = value
        End Set
    End Property
    Public Property Height As Integer
        Get
            Return iAreaHeight
        End Get
        Set(value As Integer)
            iAreaHeight = value
        End Set
    End Property
    Public Property DynamicHeight As Boolean
        Get
            Return iDynamicHeight
        End Get
        Set(value As Boolean)
            iDynamicHeight = value
        End Set
    End Property
    Public ReadOnly Property Type As DocumentAreaType
        Get
            Return iAreaType
        End Get
    End Property
    Protected Friend WriteOnly Property SetType As DocumentAreaType
        Set(value As DocumentAreaType)
            iAreaType = value
        End Set
    End Property
    <Browsable(False)> Public ReadOnly Property DataSourceType As MyDataSourceType
        Get
            Return iDataSourceType
        End Get
    End Property
    <Browsable(False)> Public Property ExternalDataTable As DataTable
        Get
            Return iExternalDataTable
        End Get
        Set(value As DataTable)
            iDataSourceType = MyDataSourceType.DataTable
            iExternalDataTable = value
        End Set
    End Property
    <Browsable(False)> Public Property DataSourceSQLQuery As String
        Get
            Return iSQLQuery
        End Get
        Set(value As String)
            iDataSourceType = MyDataSourceType.SQLQuery
            iSQLQuery = value
        End Set
    End Property
    <Browsable(False)> Public Property DataSourceODBCQuery As String
        Get
            Return iODBCQuery
        End Get
        Set(value As String)
            iDataSourceType = MyDataSourceType.ODBCQuery
            iODBCQuery = value
        End Set
    End Property
    <Browsable(False)> Public ReadOnly Property InternalDataTable As DataTable
        Get
            Return iDataTable
        End Get
    End Property
    <Browsable(False)> Public ReadOnly Property Fields As List(Of MyField)
        Get
            Return iAreaFields
        End Get
    End Property
    <Browsable(False)> Protected Friend WriteOnly Property SetDatasourceType As MyDataSourceType
        Set(value As MyDataSourceType)
            iDataSourceType = value
        End Set
    End Property

    Sub New(AreaID As String, AreaName As String, AreaWidth_px As Integer, AreaHeight_px As Integer, DynamicHeight As Boolean, AreaType As DocumentAreaType)
        If IsNothing(AreaID) Then AreaID = Guid.NewGuid().ToString("N")
        iAreaItems = New List(Of MyItem)
        iAreaID = AreaID
        iAreaName = AreaName
        iAreaWidth = AreaWidth_px
        iAreaHeight = AreaHeight_px
        iDynamicHeight = DynamicHeight
        iAreaType = AreaType
        iDataSourceType = MyDataSourceType.None
        iAreaFields = New List(Of MyField)
        iDataTable = New DataTable
    End Sub
    Sub New()
        Me.New(Nothing, "New Area", 0, 10, False, DocumentAreaType.Body)
    End Sub

    Public Function GetItemByID(ItemID As String) As MyItem
        For Each Item In iAreaItems
            If Item.ID = ItemID Then Return Item
        Next
        Return Nothing
    End Function
    Public Function GetItemsByType(ItemType As ItemType) As List(Of MyItem)
        Dim ReturnList As New List(Of MyItem)
        For Each Item In iAreaItems
            If Item.Type = ItemType Then
                ReturnList.Add(Item)
            End If
        Next
        Return ReturnList
    End Function

    Public Function GetFieldByName(FieldName As String) As MyField
        For Each Fld In iAreaFields
            If Fld.Name = FieldName Then Return Fld
        Next
        Return Nothing
    End Function
    Public Function GetFieldsByType(FieldType As MyField.FieldType) As List(Of MyField)
        Dim RetList As New List(Of MyField)
        For Each Field In iAreaFields
            If Field.Type = FieldType Then RetList.Add(Field)
        Next
        Return RetList
    End Function

    Public Function GetLabelSize() As Size
        Return New Size(Width, Height)
    End Function
    Public Function GetRectangle() As Rectangle
        Return New Rectangle(0, 0, Width, Height)
    End Function

    Public Shared Operator =(a1 As MyDocumentArea, a2 As MyDocumentArea)
        If IsNothing(a1) And IsNothing(a2) Then Return True
        If IsNothing(a1) And Not IsNothing(a2) Then Return False
        If Not IsNothing(a1) And IsNothing(a2) Then Return False
        If a1.ID = a2.ID And a1.Name = a2.Name And a1.Type = a2.Type Then Return True Else Return False
    End Operator
    Public Shared Operator <>(a1 As MyDocumentArea, a2 As MyDocumentArea)
        If IsNothing(a1) And IsNothing(a2) Then Return False
        If IsNothing(a1) And Not IsNothing(a2) Then Return True
        If Not IsNothing(a1) And IsNothing(a2) Then Return True
        If a1.ID <> a2.ID Or a1.Name <> a2.Name Or a1.Type <> a2.Type Then Return True Else Return False
    End Operator
    Public Overrides Function ToString() As String
        Return iAreaType.ToString & "(" & iAreaName & ")"
    End Function

    Private disposedValue As Boolean ' To detect redundant calls
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                For Each Item In iAreaItems
                    Item.Dispose()
                Next
                iAreaItems.Clear()
                iAreaItems = Nothing
                iAreaID = Nothing
                iAreaName = Nothing
                iAreaWidth = Nothing
                iAreaHeight = Nothing
                iDynamicHeight = Nothing
                iAreaType = Nothing
                iDataSourceType = Nothing
                iSQLQuery = Nothing
                iODBCQuery = Nothing
                For Each Field In iAreaFields
                    Field.Dispose()
                Next
                iAreaFields.Clear()
                iAreaFields = Nothing
                iDataTable.Clear()
                iDataTable.Dispose()
                iDataTable = Nothing
            End If
        End If
        disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
End Class
