Imports Excel = Microsoft.Office.Interop.Excel
Public Class Frm_transportation
    Dim branch, cpc, storenamewithID, area, cpcid As String
    Public value_transID, value_invoice_date, value_delivery_date As String

    Private Sub lblclose_MouseHover(sender As Object, e As EventArgs) Handles lblclose.MouseHover
        lblclose.Visible = False
        lblclose2.Visible = True
    End Sub

    Private Sub lblclose2_Click(sender As Object, e As EventArgs) Handles lblclose2.Click
        Me.Close()
    End Sub

    Private Sub lblclose2_MouseLeave(sender As Object, e As EventArgs) Handles lblclose2.MouseLeave
        lblclose.Visible = True
        lblclose2.Visible = False
    End Sub

    Private Sub Frm_transportation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call initialize()
    End Sub

    Private Sub initialize()
        lblvendor.Text = ""
        lblstore.Text = ""
        txtdr_no.Text = ""
        invoice_date.Value = Now
        deliverydate.Value = Now
        date_from.Value = Now
        date_to.Value = Now
        lbltotalcase.Text = "0"
        lbltotalamount.Text = "0.00"
        txtcase.Text = ""
        txtamount.Text = ""
        ListView2.Items.Clear()
        txtsearch_vendor.Select()
        cboorigin.SelectedItem = "CDO"
        cbotruck_type.SelectedItem = "CANTER 6W"
        cboremarks.SelectedItem = "Regular"

        ExecuteQueryAccess("DELETE FROM tbl_tempstoretransportation")
        datareader_access = cmd_access.ExecuteReader
        conn_access.Close()
    End Sub

    Private Sub txtsearch_vendor_TextChanged(sender As Object, e As EventArgs) Handles txtsearch_vendor.TextChanged
        If txtsearch_vendor.Text = "" Then
            ListView3.Visible = False
        Else

            ListView3.Visible = True
            ExecuteQueryAccess("SELECT vendorname,vendornetsuite FROM tbl_bixvendor WHERE vendorname LIKE '%" & txtsearch_vendor.Text.Replace("'", "''") & "%' AND status=0 AND typeofexpenses='TRANSPORATION & HANDLING'")
            datareader_access = cmd_access.ExecuteReader

            ListView3.Items.Clear()
            If datareader_access.HasRows Then
                While (datareader_access.Read)
                    ListView3.Items.Add(datareader_access("vendorname"))
                    ListView3.Items(ListView3.Items.Count - 1).SubItems.Add(datareader_access("vendornetsuite"))
                End While
            End If
            conn_access.Close()

        End If

    End Sub
    Private Sub ListView3_DoubleClick(sender As Object, e As EventArgs) Handles ListView3.DoubleClick
        lblvendor.Visible = True
        lblvendor.Text = ListView3.SelectedItems(0).SubItems(1).Text
        ListView3.Visible = False
        txtsearch_vendor.Text = ""
        txtsoa_no.Select()
    End Sub

    Private Sub txtsearch_vendor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch_vendor.KeyDown
        If ListView3.Items.Count = 0 Then
        Else
            If e.KeyCode = Keys.Down Then
                ListView3.Items(0).Selected = True
                ListView3.Select()
            End If

        End If
    End Sub

    Private Sub ListView3_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView3.KeyUp
        If ListView3.Items(0).Selected = True Then
            If e.KeyCode = Keys.Up Then
                txtsearch_vendor.Select()
            End If
        End If
    End Sub

    Private Sub ListView3_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView3.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblvendor.Visible = True
            lblvendor.Text = ListView3.SelectedItems(0).SubItems(1).Text
            ListView3.Visible = False
            txtsearch_vendor.Text = ""
            txtsoa_no.Select()
        End If
    End Sub

    Private Sub txtsearch_store_TextChanged(sender As Object, e As EventArgs) Handles txtsearch_store.TextChanged
        If txtsearch_store.Text = "" Then
            ListView1.Visible = False
        Else
            ListView1.Visible = True
            ExecuteQueryAccess("SELECT * FROM tbl_storetransportation WHERE StoreName LIKE '%" & txtsearch_store.Text.Replace("'", "''") & "%'")
            datareader_access = cmd_access.ExecuteReader

            ListView1.Items.Clear()
            If datareader_access.HasRows Then
                While (datareader_access.Read)
                    ListView1.Items.Add(datareader_access("StoreName"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(datareader_access("StoreNamewithID"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(datareader_access("BranchCode_NI"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(datareader_access("CPC"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(datareader_access("Area"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(datareader_access("CPCID_NI"))
                End While
            End If
            conn_access.Close()
        End If
    End Sub

    Private Sub txtsearch_store_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch_store.KeyDown
        If ListView1.Items.Count = 0 Then
        Else
            If e.KeyCode = Keys.Down Then
                ListView1.Items(0).Selected = True
                ListView1.Select()
            End If

        End If
    End Sub

    Private Sub bttnadd_Click(sender As Object, e As EventArgs) Handles bttnadd.Click
        Dim amount_check As Single
        Dim memo_trans, case_trans, temp_id As String
        Dim case_len, tempo_id, case_check As Integer

        If lblvendor.Text = "" Then
            MessageBox.Show("Please Select Vehicle")
            txtsearch_vendor.Select()
        ElseIf lblstore.Text = "" Then
            MessageBox.Show("Please Select Vendor")
            txtsearch_store.Select()
        ElseIf txtsoa_no.Text = "" Then
            MessageBox.Show("Please Enter SOA No.")
            txtsoa_no.Select()
        ElseIf txtamount.Text = "" Then
            MessageBox.Show("Please Enter Amount")
            txtamount.Select()
        ElseIf txtcase.Text = "" Then
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

            temp_id = ""

            ExecuteQueryAccess("SELECT temp_id FROM tbl_tempstoretransportation ORDER BY temp_id DESC")
            temp_id = cmd_access.ExecuteScalar
            conn_access.Close()

            If temp_id Is Nothing Then
                tempo_id = 1
            Else
                tempo_id = CInt(temp_id) + 1
            End If


            memo_trans = Format(deliverydate.Value, "MM") & Format(deliverydate.Value, "dd") & Format(deliverydate.Value, "yy") & "," & case_trans & "," & lblstore.Text

            ExecuteQueryAccess("INSERT INTO tbl_tempstoretransportation(StoreName,DeliveryDate,TotalCase,Amount,TruckType,Remarks,WOVAT,InputVAT,NetsuiteName,Branch,CPC,Area,Memo1,temp_id,CPCID,InvoiceDate,Origin,DR_No) VALUES('" & lblstore.Text.Replace("'", "''") & "','" & Format(deliverydate.Value, "MM/dd/yyyy") & "','" & txtcase.Text & "','" & txtamount.Text & "','" & cbotruck_type.Text & "','" & cboremarks.Text & "','" & Math.Round(CSng(txtamount.Text) / 1.12, 2) & "','" & Math.Round((CSng(txtamount.Text) / 1.12) * 0.12, 2) & "','" & storenamewithID.Replace("'", "''") & "','" & branch & "','" & cpc & "','" & area & "','" & memo_trans.Replace("'", "''") & "','" & tempo_id & "','" & cpcid & "','" & Format(invoice_date.Value, "MM/dd/yyyy") & "','" & cboorigin.Text & "','" & txtdr_no.Text & "')")
            conn_access.Close()

            Call showtransportation()
            Call totalamount()
            Call totalcase()
            txtamount.Text = ""
            txtcase.Text = ""
            txtsearch_store.Select()
            cboremarks.SelectedItem = "Regular"
            cbotruck_type.SelectedItem = "CANTER 6W"
            cboorigin.SelectedItem = "CDO"
            txtdr_no.Text = ""

        End If
    End Sub

    Public Sub totalamount()
        Dim total As Decimal
        total = 0
        For i = 0 To ListView2.Items.Count - 1
            total = total + Decimal.Parse(ListView2.Items(i).SubItems(6).Text)
        Next
        lbltotalamount.Text = Math.Round(total, 2).ToString("###,##0.00")
    End Sub

    Public Sub totalcase()
        Dim total As Integer
        total = 0
        For i = 0 To ListView2.Items.Count - 1
            total = total + Integer.Parse(ListView2.Items(i).SubItems(5).Text)
        Next
        lbltotalcase.Text = total.ToString("###,##0")
    End Sub

    Public Sub showtransportation()

        ListView2.Items.Clear()
        ExecuteQueryAccess("SELECT * FROM tbl_tempstoretransportation")
        datareader_access = cmd_access.ExecuteReader
        If datareader_access.HasRows Then
            While (datareader_access.Read)
                ListView2.Items.Add(datareader_access("StoreName"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("InvoiceDate"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("DeliveryDate"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("Origin"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("Area"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("TotalCase"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CSng(datareader_access("Amount")).ToString("###,##0.00"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("DR_No"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("TruckType"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("Remarks"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CSng(datareader_access("WOVAT")).ToString("###,##0.00"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(CSng(datareader_access("InputVAT")).ToString("###,##0.00"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("NetsuiteName"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("Branch"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("CPC"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("Memo1"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("temp_id"))
                ListView2.Items(ListView2.Items.Count - 1).SubItems.Add(datareader_access("CPCID"))
            End While
        End If
        conn_access.Close()
    End Sub

    Private Sub bttnnew_Click(sender As Object, e As EventArgs) Handles bttnnew.Click
        Call initialize()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        lblstore.Visible = True
        lblstore.Text = ListView1.SelectedItems.Item(0).Text
        storenamewithID = ListView1.SelectedItems(0).SubItems(1).Text
        branch = ListView1.SelectedItems(0).SubItems(2).Text
        cpc = ListView1.SelectedItems(0).SubItems(3).Text
        area = ListView1.SelectedItems(0).SubItems(4).Text
        cpcid = ListView1.SelectedItems(0).SubItems(5).Text
        ListView1.Visible = False
        txtsearch_store.Text = ""
    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp
        If ListView1.Items(0).Selected = True Then
            If e.KeyCode = Keys.Up Then
                txtsearch_store.Select()
            End If
        End If
    End Sub


    Private Sub bttngenerate_Click(sender As Object, e As EventArgs) Handles bttngenerate.Click

        If ListView2.Items.Count = 0 Then
            MessageBox.Show("Please Add Item")
        Else

            Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application

            Dim xlWorkbook As Excel.Workbook
            Dim xlWorksheet1, xlWorksheet2 As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim xlrange As Excel.Range
            Dim file_exist_counter, counter_column, counter_column_new, counter, total_case, total_caseogdi, total_caseiligan, count_ogdi As Integer
            Dim filePath, file_name, memo_final As String
            Dim net_amount, total_amount, total_inputvat, total_ap, total_ap_vat As Single


            xlWorkbook = xlApp.Workbooks.Add(misValue)
            'xlWorksheet1 = xlWorkbook.Sheets("Sheet1")
            xlWorksheet1 = xlWorkbook.Sheets.Add
            xlWorksheet1.Name = "Transportation"

            xlWorksheet1.Cells(1, 1) = "Oro Grande Distributors, Inc."
            xlWorksheet1.Cells(2, 1) = "Fuel Billing Details"

            xlWorksheet1.Cells(4, 1) = "Vendor:"
            xlWorksheet1.Cells(5, 1) = "Period Covered:"

            xlWorksheet1.Cells(4, 2) = lblvendor.Text

            xlWorksheet1.Cells(5, 2) = "FROM: " & date_from.Text
            xlWorksheet1.Cells(5, 3) = "TO: " & date_to.Text


            xlrange = xlWorksheet1.Range("A7", "K7")
            xlrange.Font.Bold = True
            xlrange.Font.Color = Color.White
            xlrange.Interior.ColorIndex = 49
            xlrange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlrange.ColumnWidth = 20
            xlrange.Value = {"Invoice Date", "Delivery Date", "DR No.", "Store Name", "Truck Type", "Origin", "Area", "# of cases", "Rate/Case", "Amount", "Remarks"}
            xlrange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

            counter_column = 8


            ExecuteQueryAccess("SELECT * FROM tbl_tempstoretransportation")
            datareader_access = cmd_access.ExecuteReader
            If datareader_access.HasRows Then
                While (datareader_access.Read)

                    xlWorksheet1.Cells(counter_column, 1) = datareader_access("InvoiceDate")
                    xlWorksheet1.Cells(counter_column, 2) = datareader_access("DeliveryDate")
                    xlWorksheet1.Cells(counter_column, 3) = datareader_access("DR_No")
                    xlWorksheet1.Cells(counter_column, 4) = datareader_access("StoreName")
                    xlWorksheet1.Cells(counter_column, 5) = datareader_access("TruckType")
                    xlWorksheet1.Cells(counter_column, 6) = datareader_access("Origin")
                    xlWorksheet1.Cells(counter_column, 7) = datareader_access("Area")

                    ' xlWorksheet1.Cells(counter_column, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                    xlWorksheet1.Cells(counter_column, 8) = datareader_access("TotalCase")

                    If CInt(datareader_access("TotalCase")) = 0 Then
                        xlWorksheet1.Cells(counter_column, 9) = 0
                    Else
                        xlWorksheet1.Cells(counter_column, 9) = Math.Round(CSng(datareader_access("Amount")) / CSng(datareader_access("TotalCase")), 2)
                    End If

                    xlWorksheet1.Cells(counter_column, 10) = datareader_access("Amount")

                    xlWorksheet1.Cells(counter_column, 11) = datareader_access("Remarks")

                    counter_column += 1
                End While
            End If
            conn_access.Close()


            ExecuteQueryAccess("SELECT SUM(TotalCase) AS total_case FROM tbl_tempstoretransportation")
            total_case = cmd_access.ExecuteScalar
            conn_access.Close()

            xlWorksheet1.Cells(counter_column, 8) = total_case
            xlWorksheet1.Cells(counter_column, 8).NumberFormat = "#,##0"
            xlWorksheet1.Cells(counter_column, 8).font.bold = True
            xlWorksheet1.Cells(counter_column, 8).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlWorksheet1.Cells(counter_column, 8).Font.Color = Color.Red

            ExecuteQueryAccess("SELECT SUM(Amount) AS net_amount FROM tbl_tempstoretransportation")
            net_amount = cmd_access.ExecuteScalar
            conn_access.Close()

            xlWorksheet1.Cells(counter_column, 10) = Math.Round(net_amount, 2)
            xlWorksheet1.Cells(counter_column, 10).NumberFormat = "#,##0.00"
            xlWorksheet1.Cells(counter_column, 10).font.bold = True
            xlWorksheet1.Cells(counter_column, 10).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlWorksheet1.Cells(counter_column, 10).Font.Color = Color.Red

            counter_column = counter_column + 2

            xlWorksheet1.Cells(counter_column, 1) = "Area"
            xlWorksheet1.Cells(counter_column, 2) = "Total Case"
            xlWorksheet1.Cells(counter_column, 3) = "Total Amount"

            For i As Integer = 1 To 3
                xlWorksheet1.Cells(counter_column, i).Font.Bold = True
                xlWorksheet1.Cells(counter_column, i).Font.Color = Color.White
                xlWorksheet1.Cells(counter_column, i).Interior.ColorIndex = 49
                xlWorksheet1.Cells(counter_column, i).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                xlWorksheet1.Cells(counter_column, i).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Next


            counter_column_new = counter_column + 1

            Dim list_for_area As New List(Of String)
            ExecuteQueryAccess("SELECT DISTINCT(Area) as new_area FROM tbl_tempstoretransportation")
            datareader_access = cmd_access.ExecuteReader
            If datareader_access.HasRows Then
                While (datareader_access.Read)
                    list_for_area.Add(datareader_access("new_area"))
                    xlWorksheet1.Cells(counter_column_new, 1) = datareader_access("new_area")
                    counter_column_new += 1
                End While
            End If
            conn_access.Close()


            counter_column_new = counter_column + 1

            For i As Integer = 0 To list_for_area.Count - 1

                ExecuteQueryAccess("SELECT SUM(TotalCase) as total_case FROM tbl_tempstoretransportation WHERE Area='" & list_for_area(i) & "'")
                datareader_access = cmd_access.ExecuteReader
                If datareader_access.HasRows Then
                    While (datareader_access.Read)
                        xlWorksheet1.Cells(counter_column_new, 2) = datareader_access("total_case")
                        xlWorksheet1.Cells(counter_column_new, 2).NumberFormat = "#,##0"
                        counter_column_new += 1
                    End While
                End If
                conn_access.Close()
            Next


            counter_column_new = counter_column + 1

            For i As Integer = 0 To list_for_area.Count - 1

                ExecuteQueryAccess("SELECT SUM(Amount) as total_amount FROM tbl_tempstoretransportation WHERE Area='" & list_for_area(i) & "'")
                datareader_access = cmd_access.ExecuteReader
                If datareader_access.HasRows Then
                    While (datareader_access.Read)
                        xlWorksheet1.Cells(counter_column_new, 3) = datareader_access("total_amount")
                        xlWorksheet1.Cells(counter_column_new, 3).NumberFormat = "#,##0.00"
                        counter_column_new += 1
                    End While
                End If
                conn_access.Close()
            Next



            xlWorksheet2 = xlWorkbook.Sheets.Add
            xlWorksheet2.Name = "Finance"

            xlrange = xlWorksheet2.Range("A1", "K1")
            xlrange.Value = {"Account", "Amount (Debit)", "Amount (Credit)", "Posting", "Memo", "Name", "Distributor", "Cost / Profit Center", "CPC_ID", "Class", "Branch"}

            xlWorksheet2.Cells(2, 1) = "21120 Accounts Payable - Others"

            ExecuteQueryAccess("SELECT sum(Amount) as total_amount FROM tbl_tempstoretransportation")
            total_amount = cmd_access.ExecuteScalar
            conn_access.Close()


            total_ap = 0
            total_ap_vat = 0


            xlWorksheet2.Cells(3, 1) = "21330 Expanded Withholding Tax"
            xlWorksheet2.Cells(3, 3) = Math.Round((total_amount / 1.12) * 0.02, 2)


            xlWorksheet2.Cells(2, 3) = Math.Round(total_amount - ((total_amount / 1.12) * 0.02), 2)


            xlWorksheet2.Cells(4, 1) = "11660 Input VAT"

            ExecuteQueryAccess("SELECT sum(InputVAT) as total_inputvat FROM tbl_tempstoretransportation")
            total_inputvat = cmd_access.ExecuteScalar
            conn_access.Close()

            xlWorksheet2.Cells(4, 2) = Math.Round(total_inputvat, 2)


            ExecuteQueryAccess("SELECT sum(TotalCase) as total_caseogdi FROM tbl_tempstoretransportation WHERE Area<>'Iligan'")
            datareader_access = cmd_access.ExecuteReader
            If datareader_access.HasRows Then
                While (datareader_access.Read)

                    If IsDBNull(datareader_access("total_caseogdi")) Then
                        total_caseogdi = 0
                    Else
                        total_caseogdi = datareader_access("total_caseogdi")
                    End If
                End While
            End If
            conn_access.Close()

            ExecuteQueryAccess("SELECT sum(TotalCase) as total_caseiligan FROM tbl_tempstoretransportation WHERE Area='Iligan'")
            datareader_access = cmd_access.ExecuteReader
            If datareader_access.HasRows Then
                While (datareader_access.Read)
                    If IsDBNull(datareader_access("total_caseiligan")) Then
                        total_caseiligan = 0
                    Else
                        total_caseiligan = datareader_access("total_caseiligan")
                    End If
                End While
            End If
            conn_access.Close()

            memo_final = ""
            If total_caseogdi <> 0 And total_caseiligan <> 0 Then
                memo_final = "OGDI " & CStr(total_caseogdi) & "," & "GPDI " & CStr(total_caseiligan)
            ElseIf total_caseogdi <> 0 And total_caseiligan = 0 Then
                memo_final = "OGDI " & CStr(total_caseogdi)
            ElseIf total_caseogdi = 0 And total_caseiligan <> 0 Then
                memo_final = "GPDI " & CStr(total_caseiligan)
            End If

            xlWorksheet2.Cells(2, 5) = Format(date_from.Value, "MM") & Format(date_from.Value, "dd") & Format(date_from.Value, "yy") & "-" & Format(date_to.Value, "MM") & Format(date_to.Value, "dd") & Format(date_to.Value, "yy") & "," & memo_final
            xlWorksheet2.Cells(3, 5) = Format(date_from.Value, "MM") & Format(date_from.Value, "dd") & Format(date_from.Value, "yy") & "-" & Format(date_to.Value, "MM") & Format(date_to.Value, "dd") & Format(date_to.Value, "yy") & "," & memo_final
            xlWorksheet2.Cells(4, 5) = Format(date_from.Value, "MM") & Format(date_from.Value, "dd") & Format(date_from.Value, "yy") & "-" & Format(date_to.Value, "MM") & Format(date_to.Value, "dd") & Format(date_to.Value, "yy") & "," & memo_final

            xlWorksheet2.Cells(2, 6) = lblvendor.Text
            xlWorksheet2.Cells(3, 6) = lblvendor.Text
            xlWorksheet2.Cells(4, 6) = "VE_888 BUREAU OF INTERNAL REVENUE"

            xlWorksheet2.Cells(2, 7) = "DERP : OGDI"
            xlWorksheet2.Cells(3, 7) = "DERP : OGDI"
            xlWorksheet2.Cells(4, 7) = "DERP : OGDI"

            xlWorksheet2.Cells(2, 8) = "Administration"
            xlWorksheet2.Cells(3, 8) = "Administration"
            xlWorksheet2.Cells(4, 8) = "Administration"

            xlWorksheet2.Cells(2, 9) = "2"
            xlWorksheet2.Cells(3, 9) = "2"
            xlWorksheet2.Cells(4, 9) = "2"

            xlWorksheet2.Cells(2, 11) = "53"
            xlWorksheet2.Cells(3, 11) = "53"
            xlWorksheet2.Cells(4, 11) = "53"

            counter = 5

            ExecuteQueryAccess("SELECT COUNT(*) AS count_ogdi FROM tbl_tempstoretransportation WHERE Area<>'Iligan'")
            datareader_access = cmd_access.ExecuteReader
            If datareader_access.HasRows Then
                While (datareader_access.Read)
                    If IsDBNull(datareader_access("count_ogdi")) Then
                        count_ogdi = 0
                    Else
                        count_ogdi = datareader_access("count_ogdi")
                    End If
                End While
            End If
            conn_access.Close()

            ExecuteQueryAccess("SELECT * FROM tbl_tempstoretransportation")
            datareader_access = cmd_access.ExecuteReader
            If datareader_access.HasRows Then
                While (datareader_access.Read)

                    If count_ogdi = 0 Then
                        xlWorksheet2.Cells(counter, 1) = "44400 Transportation & Handling Fee"
                    Else
                        If datareader_access("StoreName") = "GAISANO ILIGAN" Or datareader_access("StoreName") = "GAISANO ILIGAN MALL" Then
                            xlWorksheet2.Cells(counter, 1) = "11580 Advances to Home Office"
                        ElseIf datareader_access("Area") = "Iligan" Then
                            xlWorksheet2.Cells(counter, 1) = "11580 Advances to Home Office"
                        Else
                            xlWorksheet2.Cells(counter, 1) = "44400 Transportation & Handling Fee"
                        End If
                    End If

                    xlWorksheet2.Cells(counter, 2) = datareader_access("WOVAT")
                    xlWorksheet2.Cells(counter, 5) = datareader_access("memo1")
                    xlWorksheet2.Cells(counter, 7) = "DERP : OGDI"
                    xlWorksheet2.Cells(counter, 8) = datareader_access("CPC")
                    xlWorksheet2.Cells(counter, 9) = datareader_access("CPCID")
                    xlWorksheet2.Cells(counter, 11) = datareader_access("Branch")
                    counter = counter + 1
                End While
            End If
            conn_access.Close()

            xlWorksheet1.Protect("bixfinance")
            xlWorksheet2.Protect("bixfinance")
            xlWorksheet2.Visible = False


            file_name = "BIX_Transportation_" & lblvendor.Text & "_" & Format(date_to.Value, "MM") & Format(date_to.Value, "dd") & Format(date_to.Value, "yy")
            xlWorkbook.Application.Visible = False


            Dim AppPath = Application.StartupPath
            filePath = AppPath & "/Reports/" & file_name & ".csv"

            If System.IO.File.Exists(filePath) Then

                Do
                    file_exist_counter += 1
                    filePath = AppPath & "/Reports/" & file_name & "(" & CStr(file_exist_counter) & ")" & ".csv"
                Loop Until Not System.IO.File.Exists(filePath)

                xlWorkbook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
                xlWorkbook.Close(True, misValue, misValue)
                xlApp.Quit()

            Else
                xlWorkbook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
                xlWorkbook.Close(True, misValue, misValue)
                xlApp.Quit()
            End If


            MessageBox.Show("Download Successful")
            xlrange = Nothing
            xlWorksheet1 = Nothing
            xlWorkbook = Nothing
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblstore.Visible = True
            lblstore.Text = ListView1.SelectedItems.Item(0).Text
            storenamewithID = ListView1.SelectedItems(0).SubItems(1).Text
            branch = ListView1.SelectedItems(0).SubItems(2).Text
            cpc = ListView1.SelectedItems(0).SubItems(3).Text
            area = ListView1.SelectedItems(0).SubItems(4).Text
            cpcid = ListView1.SelectedItems(0).SubItems(5).Text
            ListView1.Visible = False
            txtsearch_store.Text = ""
            invoice_date.Select()
        End If
    End Sub

    Private Sub ListView2_MouseUp(sender As Object, e As MouseEventArgs) Handles ListView2.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(ListView2, e.Location)
        End If
    End Sub

    Private Sub DELETEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DELETEToolStripMenuItem.Click
        If ListView2.SelectedItems.Count < 1 Then
            MessageBox.Show("Please Select an Item to Delete")
        Else

            Dim n As String = MsgBox("Delete Item?", MsgBoxStyle.YesNo, "")
            If n = vbYes Then

                ExecuteQueryAccess("DELETE FROM tbl_tempstoretransportation WHERE temp_id=" & ListView2.SelectedItems(0).SubItems(16).Text & "")
                datareader_access = cmd_access.ExecuteReader
                conn_access.Close()
                Call showtransportation()
                Call totalamount()
                Call totalcase()
                MessageBox.Show("Successfuly Deleted")
            End If
        End If

    End Sub

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick
        If ListView2.Items.Count = 0 Then
            MessageBox.Show("Please Add Item")
        Else
            value_transID = ListView2.SelectedItems(0).SubItems(16).Text
            value_invoice_date = ListView2.SelectedItems(0).SubItems(1).Text
            value_delivery_date = ListView2.SelectedItems(0).SubItems(2).Text
            Frm_transportation_update.StartPosition = FormStartPosition.CenterScreen
            Frm_transportation_update.ShowDialog()
        End If

    End Sub
End Class
