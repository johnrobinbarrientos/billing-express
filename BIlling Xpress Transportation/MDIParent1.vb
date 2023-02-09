Imports System.Windows.Forms

Public Class MDIParent1
    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub TransportationHandlingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransportationHandlingToolStripMenuItem.Click
        For Each aform As Form In Me.MdiChildren
            aform.Close()
        Next
        Frm_transportation.MdiParent = Me
        Frm_transportation.StartPosition = FormStartPosition.CenterScreen
        Frm_transportation.Show()
    End Sub

    Private Sub SyncToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SyncToolStripMenuItem.Click
        'For Each aform As Form In Me.MdiChildren
        '    aform.Close()
        'Next
        'Frm_update_database.MdiParent = Me
        Frm_update_database.StartPosition = FormStartPosition.CenterScreen
        Frm_update_database.ShowDialog()
    End Sub
End Class
