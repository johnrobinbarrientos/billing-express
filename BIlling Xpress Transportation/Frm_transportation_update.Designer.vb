<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_transportation_update
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.deliverydate = New System.Windows.Forms.DateTimePicker()
        Me.txtcase = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtamount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbotruck_type = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboremarks = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.bttnclose = New System.Windows.Forms.Button()
        Me.bttnupdate = New System.Windows.Forms.Button()
        Me.lblstore = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.invoice_date = New System.Windows.Forms.DateTimePicker()
        Me.txtdr_no = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboorigin = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(15, 96)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 17)
        Me.Label18.TabIndex = 158
        Me.Label18.Text = "Delivery Date:"
        '
        'deliverydate
        '
        Me.deliverydate.CustomFormat = "yyyy-MM-dd"
        Me.deliverydate.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deliverydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.deliverydate.Location = New System.Drawing.Point(135, 91)
        Me.deliverydate.Name = "deliverydate"
        Me.deliverydate.Size = New System.Drawing.Size(193, 25)
        Me.deliverydate.TabIndex = 157
        Me.deliverydate.Value = New Date(2018, 8, 19, 0, 0, 0, 0)
        '
        'txtcase
        '
        Me.txtcase.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcase.Location = New System.Drawing.Point(457, 51)
        Me.txtcase.Name = "txtcase"
        Me.txtcase.Size = New System.Drawing.Size(193, 25)
        Me.txtcase.TabIndex = 159
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(350, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 17)
        Me.Label5.TabIndex = 160
        Me.Label5.Text = "Total Case:"
        '
        'txtamount
        '
        Me.txtamount.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtamount.Location = New System.Drawing.Point(457, 85)
        Me.txtamount.Name = "txtamount"
        Me.txtamount.Size = New System.Drawing.Size(193, 25)
        Me.txtamount.TabIndex = 161
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(350, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 162
        Me.Label3.Text = "Total Amount:"
        '
        'cbotruck_type
        '
        Me.cbotruck_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotruck_type.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotruck_type.FormattingEnabled = True
        Me.cbotruck_type.Items.AddRange(New Object() {"CANTER 6W", "FORWARD", "ELF"})
        Me.cbotruck_type.Location = New System.Drawing.Point(457, 127)
        Me.cbotruck_type.Name = "cbotruck_type"
        Me.cbotruck_type.Size = New System.Drawing.Size(193, 25)
        Me.cbotruck_type.TabIndex = 163
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(350, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 17)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "Truck Type:"
        '
        'cboremarks
        '
        Me.cboremarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboremarks.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboremarks.FormattingEnabled = True
        Me.cboremarks.Items.AddRange(New Object() {"Regular", "Extended", "Backload", "Special Trip"})
        Me.cboremarks.Location = New System.Drawing.Point(457, 167)
        Me.cboremarks.Name = "cboremarks"
        Me.cboremarks.Size = New System.Drawing.Size(193, 25)
        Me.cboremarks.TabIndex = 165
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(350, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 17)
        Me.Label6.TabIndex = 166
        Me.Label6.Text = "Remarks:"
        '
        'bttnclose
        '
        Me.bttnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bttnclose.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnclose.Image = Global.BIlling_Xpress_Transportation.My.Resources.Resources.icons8_cancel_30
        Me.bttnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bttnclose.Location = New System.Drawing.Point(532, 218)
        Me.bttnclose.Name = "bttnclose"
        Me.bttnclose.Size = New System.Drawing.Size(118, 42)
        Me.bttnclose.TabIndex = 168
        Me.bttnclose.Text = "    CANCEL"
        Me.bttnclose.UseVisualStyleBackColor = True
        '
        'bttnupdate
        '
        Me.bttnupdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bttnupdate.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnupdate.Image = Global.BIlling_Xpress_Transportation.My.Resources.Resources.icons8_restart_30
        Me.bttnupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bttnupdate.Location = New System.Drawing.Point(399, 218)
        Me.bttnupdate.Name = "bttnupdate"
        Me.bttnupdate.Size = New System.Drawing.Size(118, 42)
        Me.bttnupdate.TabIndex = 167
        Me.bttnupdate.Text = "     UPDATE"
        Me.bttnupdate.UseVisualStyleBackColor = True
        '
        'lblstore
        '
        Me.lblstore.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstore.ForeColor = System.Drawing.Color.Black
        Me.lblstore.Location = New System.Drawing.Point(131, 12)
        Me.lblstore.Name = "lblstore"
        Me.lblstore.Size = New System.Drawing.Size(286, 42)
        Me.lblstore.TabIndex = 170
        Me.lblstore.Text = "Store:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(14, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 19)
        Me.Label11.TabIndex = 169
        Me.Label11.Text = "Store Name:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 17)
        Me.Label13.TabIndex = 174
        Me.Label13.Text = "Invoice Date:"
        '
        'invoice_date
        '
        Me.invoice_date.CustomFormat = "yyyy-MM-dd"
        Me.invoice_date.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invoice_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.invoice_date.Location = New System.Drawing.Point(135, 54)
        Me.invoice_date.Name = "invoice_date"
        Me.invoice_date.Size = New System.Drawing.Size(193, 25)
        Me.invoice_date.TabIndex = 173
        Me.invoice_date.Value = New Date(2018, 8, 19, 0, 0, 0, 0)
        '
        'txtdr_no
        '
        Me.txtdr_no.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdr_no.Location = New System.Drawing.Point(135, 132)
        Me.txtdr_no.Name = "txtdr_no"
        Me.txtdr_no.Size = New System.Drawing.Size(193, 25)
        Me.txtdr_no.TabIndex = 177
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(15, 135)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 17)
        Me.Label16.TabIndex = 178
        Me.Label16.Text = "DR No.:"
        '
        'cboorigin
        '
        Me.cboorigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboorigin.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboorigin.FormattingEnabled = True
        Me.cboorigin.Items.AddRange(New Object() {"CDO", "BKD", "SUR", "BXU"})
        Me.cboorigin.Location = New System.Drawing.Point(135, 172)
        Me.cboorigin.Name = "cboorigin"
        Me.cboorigin.Size = New System.Drawing.Size(193, 25)
        Me.cboorigin.TabIndex = 179
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(15, 180)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 17)
        Me.Label14.TabIndex = 180
        Me.Label14.Text = "Origin:"
        '
        'Frm_transportation_update
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(667, 272)
        Me.Controls.Add(Me.cboorigin)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtdr_no)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.invoice_date)
        Me.Controls.Add(Me.lblstore)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.bttnclose)
        Me.Controls.Add(Me.bttnupdate)
        Me.Controls.Add(Me.cboremarks)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbotruck_type)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtamount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcase)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.deliverydate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Frm_transportation_update"
        Me.Text = "Frm_transportation_update"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label18 As Label
    Friend WithEvents deliverydate As DateTimePicker
    Friend WithEvents txtcase As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtamount As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbotruck_type As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboremarks As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents bttnupdate As Button
    Friend WithEvents bttnclose As Button
    Friend WithEvents lblstore As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents invoice_date As DateTimePicker
    Friend WithEvents txtdr_no As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cboorigin As ComboBox
    Friend WithEvents Label14 As Label
End Class
