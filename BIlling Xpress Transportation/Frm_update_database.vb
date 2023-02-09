Public Class Frm_update_database
    Dim internet_connection As Boolean

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

    Private Sub bttnsave_Click(sender As Object, e As EventArgs) Handles bttnsave.Click
        Dim allcountstore, allcountstore2, allcountstore3, allcountstore4, allcountvendor, allcount, counter As Integer
        Dim area As String

        Call Connection.checkconnection()
        internet_connection = Connection.internet_connection

        If internet_connection = False Then
            MessageBox.Show("System Offline, Can't Connect to Server. Please Check your Internet Connection")
            Exit Sub
        Else
            ProgressBar1.Visible = True
            lblprogress.Visible = True


            ExecuteQueryMySQL("SELECT COUNT(StoreName) as allcountstore FROM tbl_storemaster LEFT JOIN tbl_distributorbranch ON tbl_storemaster.BranchCode=tbl_distributorbranch.BranchCode LEFT JOIN tbl_distributorcpc ON tbl_storemaster.CPCID=tbl_distributorcpc.CPCID LEFT JOIN tbl_employeemaster employeemasterA ON tbl_storemaster.SalesRepCode=employeemasterA.EmpInternalID LEFT JOIN tbl_employeemaster employeemasterB ON tbl_storemaster.SalesRepID=employeemasterB.EmpInternalID WHERE employeemasterA.Comments='PRESELL' OR employeemasterA.Comments='MAM' ORDER BY Branch ASC")
            allcountstore = cmd_mysql.ExecuteScalar
            conn_mysql.Close()

            ExecuteQueryMySQL("SELECT COUNT(StoreName) AS allcountstore2 FROM tbl_storemaster LEFT JOIN tbl_distributorcpc ON tbl_storemaster.CPCID=tbl_distributorcpc.CPCID LEFT JOIN tbl_distributorbranch ON tbl_storemaster.BranchCode=tbl_distributorbranch.BranchCode WHERE Reach>1 AND IsSubDID=1")
            allcountstore2 = cmd_mysql.ExecuteScalar
            conn_mysql.Close()

            ExecuteQueryMySQL("SELECT COUNT(StoreName) AS allcountstore3 FROM tbl_storemaster LEFT JOIN tbl_distributorcpc ON tbl_storemaster.CPCID=tbl_distributorcpc.CPCID LEFT JOIN tbl_distributorbranch ON tbl_storemaster.BranchCode=tbl_distributorbranch.BranchCode WHERE Reach>1 AND tbl_storemaster.BranchCode=537")
            allcountstore3 = cmd_mysql.ExecuteScalar
            conn_mysql.Close()

            ExecuteQueryMySQL("SELECT COUNT(StoreName) AS allcountstore4 FROM tbl_storemaster LEFT JOIN tbl_distributorcpc ON tbl_storemaster.CPCID=tbl_distributorcpc.CPCID LEFT JOIN tbl_distributorbranch ON tbl_storemaster.BranchCode=tbl_distributorbranch.BranchCode WHERE Reach>1 AND tbl_storemaster.BranchCode=2019")
            allcountstore4 = cmd_mysql.ExecuteScalar
            conn_mysql.Close()

            ExecuteQueryMySQL("SELECT COUNT(*) AS allcountvendor FROM tbl_bixvendor")
            allcountvendor = cmd_mysql.ExecuteScalar
            conn_mysql.Close()


            allcount = allcountstore + allcountstore2 + allcountstore3 + allcountstore4 + allcountvendor + 4

            counter = 1


            ExecuteQueryAccess("DELETE FROM tbl_storetransportation")
            datareader_access = cmd_access.ExecuteReader
            conn_access.Close()

            ExecuteQueryMySQL("SELECT CONCAT(StoreID,' ',StoreName) AS StoreNamewithID,StoreName,BranchCode_NI,Branch,CPC,CPCID_NI,IsSubDID FROM tbl_storemaster LEFT JOIN tbl_distributorbranch ON tbl_storemaster.BranchCode=tbl_distributorbranch.BranchCode LEFT JOIN tbl_distributorcpc ON tbl_storemaster.CPCID=tbl_distributorcpc.CPCID LEFT JOIN tbl_employeemaster employeemasterA ON tbl_storemaster.SalesRepCode=employeemasterA.EmpInternalID LEFT JOIN tbl_employeemaster employeemasterB ON tbl_storemaster.SalesRepID=employeemasterB.EmpInternalID WHERE employeemasterA.Comments='PRESELL' OR employeemasterA.Comments='MAM' ORDER BY Branch ASC")
            datareader_mysql = cmd_mysql.ExecuteReader
            If datareader_mysql.HasRows Then
                While (datareader_mysql.Read)

                    If datareader_mysql("IsSubDID") = 0 Then
                        area = datareader_mysql("Branch")
                    Else
                        area = "Iligan"
                    End If

                    ExecuteQueryAccess("INSERT INTO tbl_storetransportation(StoreNamewithID,StoreName,BranchCode_NI,CPC,CPCID_NI,Area) VALUES('" & datareader_mysql("StoreNamewithID").ToString.Replace("'", "''") & "','" & datareader_mysql("StoreName").ToString.Replace("'", "''") & "','" & datareader_mysql("BranchCode_NI") & "','" & datareader_mysql("CPC") & "','" & datareader_mysql("CPCID_NI") & "','" & area & "')")
                    conn_access.Close()
                    lblprogress.Refresh()
                    ProgressBar1.Value = (counter / allcount) * 100
                    lblprogress.Text = "Updating Store..." & CStr(Math.Round((counter / allcount) * 100, 0)) & "%"
                    counter += 1
                End While
            End If
            conn_mysql.Close()

            ExecuteQueryMySQL("SELECT CONCAT(StoreID,' ',StoreName) AS StoreNamewithID,StoreName,CPC,CPCID_NI,BranchCode_NI FROM tbl_storemaster LEFT JOIN tbl_distributorcpc ON tbl_storemaster.CPCID=tbl_distributorcpc.CPCID LEFT JOIN tbl_distributorbranch ON tbl_storemaster.BranchCode=tbl_distributorbranch.BranchCode WHERE Reach>1 AND IsSubDID=1")
            datareader_mysql = cmd_mysql.ExecuteReader
            If datareader_mysql.HasRows Then
                While (datareader_mysql.Read)

                    ExecuteQueryAccess("INSERT INTO tbl_storetransportation(StoreNamewithID,StoreName,BranchCode_NI,CPC,CPCID_NI,Area) VALUES('" & datareader_mysql("StoreNamewithID").ToString.Replace("'", "''") & "','" & datareader_mysql("StoreName").ToString.Replace("'", "''") & "','" & datareader_mysql("BranchCode_NI") & "','" & datareader_mysql("CPC") & "','" & datareader_mysql("CPCID_NI") & "','Iligan')")
                    conn_access.Close()
                    lblprogress.Refresh()
                    ProgressBar1.Value = (counter / allcount) * 100
                    lblprogress.Text = "Updating Store..." & CStr(Math.Round((counter / allcount) * 100, 0)) & "%"
                    counter += 1
                End While
            End If
            conn_mysql.Close()

            ExecuteQueryMySQL("SELECT CONCAT(StoreID,' ',StoreName) AS StoreNamewithID,StoreName,CPC,BranchCode_NI,CPCID_NI FROM tbl_storemaster LEFT JOIN tbl_distributorcpc ON tbl_storemaster.CPCID=tbl_distributorcpc.CPCID LEFT JOIN tbl_distributorbranch ON tbl_storemaster.BranchCode=tbl_distributorbranch.BranchCode WHERE Reach>1 AND tbl_storemaster.BranchCode=537")
            datareader_mysql = cmd_mysql.ExecuteReader
            If datareader_mysql.HasRows Then
                While (datareader_mysql.Read)

                    ExecuteQueryAccess("INSERT INTO tbl_storetransportation(StoreNamewithID,StoreName,BranchCode_NI,CPC,CPCID_NI,Area) VALUES('" & datareader_mysql("StoreNamewithID").ToString.Replace("'", "''") & "','" & datareader_mysql("StoreName").ToString.Replace("'", "''") & "','" & datareader_mysql("BranchCode_NI") & "','" & datareader_mysql("CPC") & "','" & datareader_mysql("CPCID_NI") & "','Butuan')")
                    conn_access.Close()
                    lblprogress.Refresh()
                    ProgressBar1.Value = (counter / allcount) * 100
                    lblprogress.Text = "Updating Store..." & CStr(Math.Round((counter / allcount) * 100, 0)) & "%"
                    counter += 1
                End While
            End If
            conn_mysql.Close()

            ExecuteQueryMySQL("SELECT CONCAT(StoreID,' ',StoreName) AS StoreNamewithID,StoreName,CPC,BranchCode_NI,CPCID_NI FROM tbl_storemaster LEFT JOIN tbl_distributorcpc ON tbl_storemaster.CPCID=tbl_distributorcpc.CPCID LEFT JOIN tbl_distributorbranch ON tbl_storemaster.BranchCode=tbl_distributorbranch.BranchCode WHERE Reach>1 AND tbl_storemaster.BranchCode=2019")
            datareader_mysql = cmd_mysql.ExecuteReader
            If datareader_mysql.HasRows Then
                While (datareader_mysql.Read)

                    ExecuteQueryAccess("INSERT INTO tbl_storetransportation(StoreNamewithID,StoreName,BranchCode_NI,CPC,CPCID_NI,Area) VALUES('" & datareader_mysql("StoreNamewithID").ToString.Replace("'", "''") & "','" & datareader_mysql("StoreName").ToString.Replace("'", "''") & "','" & datareader_mysql("BranchCode_NI") & "','" & datareader_mysql("CPC") & "','" & datareader_mysql("CPCID_NI") & "','Surigao')")
                    conn_access.Close()
                    lblprogress.Refresh()
                    ProgressBar1.Value = (counter / allcount) * 100
                    lblprogress.Text = "Updating Store..." & CStr(Math.Round((counter / allcount) * 100, 0)) & "%"
                    counter += 1
                End While
            End If
            conn_mysql.Close()

            ExecuteQueryAccess("INSERT INTO tbl_storetransportation(StoreNamewithID,StoreName,BranchCode_NI,CPC,CPCID_NI,Area) VALUES('Stock Transfer CDO','Stock Transfer CDO','53','Administration','2','CDO')")
            conn_access.Close()

            ProgressBar1.Value = (counter / allcount) * 100
            lblprogress.Text = "Updating Store..." & CStr(Math.Round((counter / allcount) * 100, 0)) & "%"
            counter += 1

            ExecuteQueryAccess("INSERT INTO tbl_storetransportation(StoreNamewithID,StoreName,BranchCode_NI,CPC,CPCID_NI,Area) VALUES('Stock Transfer Bukidnon','Stock Transfer Bukidnon','56','Administration','2','Bukidnon')")
            conn_access.Close()

            ProgressBar1.Value = (counter / allcount) * 100
            lblprogress.Text = "Updating Store..." & CStr(Math.Round((counter / allcount) * 100, 0)) & "%"
            counter += 1

            ExecuteQueryAccess("INSERT INTO tbl_storetransportation(StoreNamewithID,StoreName,BranchCode_NI,CPC,CPCID_NI,Area) VALUES('Stock Transfer Butuan','Stock Transfer Butuan','54','Administration','2','Butuan')")
            conn_access.Close()

            ProgressBar1.Value = (counter / allcount) * 100
            lblprogress.Text = "Updating Store..." & CStr(Math.Round((counter / allcount) * 100, 0)) & "%"
            counter += 1

            ExecuteQueryAccess("INSERT INTO tbl_storetransportation(StoreNamewithID,StoreName,BranchCode_NI,CPC,CPCID_NI,Area) VALUES('Stock Transfer Surigao','Stock Transfer Surigao','55','Administration','2','Surigao')")
            conn_access.Close()

            ProgressBar1.Value = (counter / allcount) * 100
            lblprogress.Text = "Updating Store..." & CStr(Math.Round((counter / allcount) * 100, 0)) & "%"
            counter += 1





            ExecuteQueryAccess("DELETE FROM tbl_bixvendor")
            datareader_access = cmd_access.ExecuteReader
            conn_access.Close()

            ExecuteQueryMySQL("SELECT vendorID,vendorname,vendornetsuite,status,typeofexpenses,discount FROM tbl_bixvendor")
            datareader_mysql = cmd_mysql.ExecuteReader
            If datareader_mysql.HasRows Then
                While (datareader_mysql.Read)
                    ExecuteQueryAccess("INSERT INTO tbl_bixvendor(vendorID,vendorname,vendornetsuite,status,typeofexpenses,discount) VALUES('" & datareader_mysql("vendorID") & "','" & datareader_mysql("vendorname").ToString.Replace("'", "''") & "','" & datareader_mysql("vendornetsuite").ToString.Replace("'", "''") & "','" & datareader_mysql("status") & "','" & datareader_mysql("typeofexpenses") & "','" & datareader_mysql("discount") & "')")
                    conn_access.Close()
                    lblprogress.Refresh()
                    ProgressBar1.Value = (counter / allcount) * 100
                    lblprogress.Text = "Updating Vendor..." & CStr(Math.Round((counter / allcount) * 100, 0)) & "%"
                    counter += 1
                End While
            End If
            conn_mysql.Close()



            ProgressBar1.Visible = False
            lblprogress.Visible = False
            MessageBox.Show("Successfully Updated")
        End If

    End Sub
End Class