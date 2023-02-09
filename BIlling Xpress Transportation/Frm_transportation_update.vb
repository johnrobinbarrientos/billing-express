Public Class Frm_transportation_update
    Dim value_transID, value_departure_date As String

    Private Sub bttnclose_Click(sender As Object, e As EventArgs) Handles bttnclose.Click
        Me.Close()
    End Sub

    Private Sub Frm_transportation_update_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim delivery_date, invoice_date_value As Date
        value_transID = Frm_transportation.value_transID

        ExecuteQueryAccess("SELECT * FROM tbl_tempstoretransportation WHERE temp_id=" & value_transID & "")
        datareader_access = cmd_access.ExecuteReader

        If datareader_access.HasRows Then
            While (datareader_access.Read)
                txtcase.Text = datareader_access("TotalCase")
                txtamount.Text = datareader_access("Amount")
                cbotruck_type.SelectedItem = datareader_access("TruckType")
                cboremarks.SelectedItem = datareader_access("Remarks")
                lblstore.Text = datareader_access("StoreName")

                cboorigin.SelectedItem = datareader_access("Origin")
                txtdr_no.Text = datareader_access("DR_No")
            End While
        End If
        conn_access.Close()
        delivery_date = DateTime.Parse(Frm_transportation.value_delivery_date, System.Globalization.CultureInfo.InvariantCulture)
        invoice_date_value = DateTime.Parse(Frm_transportation.value_invoice_date, System.Globalization.CultureInfo.InvariantCulture)

        deliverydate.Value = delivery_date
        invoice_date.Value = invoice_date_value
    End Sub

    Private Sub bttnupdate_Click(sender As Object, e As EventArgs) Handles bttnupdate.Click
        Dim amount_check As Single
        Dim case_len, case_check As Integer
        Dim memo_trans, case_trans As String

        If txtcase.Text = "" Then
            MessageBox.Show("Please Enter Total Case")
            txtcase.Select()
        ElseIf txtdr_no.Text = "" Then
            MessageBox.Show("Please Enter DR No.")
            txtdr_no.Select()
        ElseIf Not Single.TryParse(txtamount.Text, amount_check) Then
            MessageBox.Show("Amount should be number")
            txtamount.Select()
        ElseIf Not Integer.TryParse(txtcase.Text, case_check) Then
            MessageBox.Show("Invalid Case")
            txtcase.Select()
        Else

            Dim n As String = MsgBox("Update Item?", MsgBoxStyle.YesNo, "")
            If n = vbYes Then

                case_len = txtcase.Text.Length

                If case_len = 1 Then
                    case_trans = txtcase.Text & "XXX"
                ElseIf case_len = 2 Then
                    case_trans = txtcase.Text & "XX"
                ElseIf case_len = 3 Then
                    case_trans = txtcase.Text & "X"
                Else
                    case_trans = txtcase.Text
                End If

                memo_trans = Format(deliverydate.Value, "MM") & Format(deliverydate.Value, "dd") & Format(deliverydate.Value, "yy") & "," & case_trans & "," & lblstore.Text


                ExecuteQueryAccess("UPDATE tbl_tempstoretransportation SET InvoiceDate='" & Format(invoice_date.Value, "MM/dd/yyyy") & "', DeliveryDate='" & Format(deliverydate.Value, "MM/dd/yyyy") & "', DR_No='" & txtdr_no.Text & "', Origin='" & cboorigin.Text & "', TotalCase='" & txtcase.Text & "', Amount='" & txtamount.Text & "', TruckType='" & cbotruck_type.Text & "', Remarks='" & cboremarks.Text & "', WOVAT='" & Math.Round(CSng(txtamount.Text) / 1.12, 2) & "', InputVAT='" & Math.Round((CSng(txtamount.Text) / 1.12) * 0.12, 2) & "', Memo1='" & memo_trans.Replace("'", "''") & "' WHERE Temp_id=" & value_transID & "")
                MessageBox.Show("Successfuly Updated")
                conn_access.Close()
                Call Frm_transportation.showtransportation()
                Call Frm_transportation.totalamount()
                Call Frm_transportation.totalcase()
                Me.Close()
            End If
        End If


    End Sub
End Class