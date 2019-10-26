Imports System.Data.SqlClient

Public Class BindRepeater
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindData()
        End If
    End Sub

    'bind subject details to repeater control
    Private Sub BindData()
        Try
            'specify your connection string here..
            Dim con As String = "Data Source=datasource;Integrated Security=true;Initial Catalog=TestPractical"
            Using sqlConn As New SqlConnection(con)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * FROM SubjectDetails"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    rptCustomRepeater.DataSource = objDataReader
                    rptCustomRepeater.DataBind()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

End Class