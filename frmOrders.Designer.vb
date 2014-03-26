<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrders
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnPrinterConfig = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.grpBox = New System.Windows.Forms.GroupBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.dgvImages = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPrintLabel = New System.Windows.Forms.Button()
        Me.dgvOrders = New System.Windows.Forms.DataGridView()
        Me.lblSelectedOrder = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.tmrUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.lblPrinterConfig = New System.Windows.Forms.Label()
        Me.grpBox.SuspendLayout()
        CType(Me.dgvImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrinterConfig
        '
        Me.btnPrinterConfig.Location = New System.Drawing.Point(17, 437)
        Me.btnPrinterConfig.Name = "btnPrinterConfig"
        Me.btnPrinterConfig.Size = New System.Drawing.Size(124, 23)
        Me.btnPrinterConfig.TabIndex = 22
        Me.btnPrinterConfig.Text = "Printers Configuration"
        Me.ToolTip1.SetToolTip(Me.btnPrinterConfig, "Opens the printers configuration.")
        Me.btnPrinterConfig.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(378, 437)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 21
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(459, 437)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(74, 23)
        Me.btnBack.TabIndex = 18
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'grpBox
        '
        Me.grpBox.Controls.Add(Me.btnPreview)
        Me.grpBox.Controls.Add(Me.dgvImages)
        Me.grpBox.Controls.Add(Me.Label2)
        Me.grpBox.Controls.Add(Me.Label1)
        Me.grpBox.Controls.Add(Me.btnPrintLabel)
        Me.grpBox.Controls.Add(Me.dgvOrders)
        Me.grpBox.Controls.Add(Me.lblSelectedOrder)
        Me.grpBox.Controls.Add(Me.btnPrint)
        Me.grpBox.Location = New System.Drawing.Point(6, 7)
        Me.grpBox.Name = "grpBox"
        Me.grpBox.Size = New System.Drawing.Size(538, 424)
        Me.grpBox.TabIndex = 19
        Me.grpBox.TabStop = False
        Me.grpBox.Text = "GroupBox1"
        '
        'btnPreview
        '
        Me.btnPreview.Enabled = False
        Me.btnPreview.Location = New System.Drawing.Point(453, 389)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnPreview.TabIndex = 18
        Me.btnPreview.Text = "Preview"
        Me.ToolTip1.SetToolTip(Me.btnPreview, "Opens a window to preview the selected image.")
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'dgvImages
        '
        Me.dgvImages.AllowUserToAddRows = False
        Me.dgvImages.AllowUserToDeleteRows = False
        Me.dgvImages.AllowUserToOrderColumns = True
        Me.dgvImages.AllowUserToResizeRows = False
        Me.dgvImages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvImages.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImages.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgvImages.Location = New System.Drawing.Point(10, 283)
        Me.dgvImages.MultiSelect = False
        Me.dgvImages.Name = "dgvImages"
        Me.dgvImages.ReadOnly = True
        Me.dgvImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvImages.Size = New System.Drawing.Size(518, 95)
        Me.dgvImages.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.dgvImages, "Click on the left arrow of the desired row to select an image to print or preview" & _
                ".")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 263)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Images List:"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(10, 254)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(517, 3)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "      "
        '
        'btnPrintLabel
        '
        Me.btnPrintLabel.Enabled = False
        Me.btnPrintLabel.Location = New System.Drawing.Point(141, 389)
        Me.btnPrintLabel.Name = "btnPrintLabel"
        Me.btnPrintLabel.Size = New System.Drawing.Size(91, 23)
        Me.btnPrintLabel.TabIndex = 12
        Me.btnPrintLabel.Text = "Get Label"
        Me.ToolTip1.SetToolTip(Me.btnPrintLabel, "Opens a pop-up dialog with delivery and order information to print.")
        Me.btnPrintLabel.UseVisualStyleBackColor = True
        '
        'dgvOrders
        '
        Me.dgvOrders.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolTip
        Me.dgvOrders.AllowUserToAddRows = False
        Me.dgvOrders.AllowUserToDeleteRows = False
        Me.dgvOrders.AllowUserToOrderColumns = True
        Me.dgvOrders.AllowUserToResizeRows = False
        Me.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrders.Location = New System.Drawing.Point(10, 19)
        Me.dgvOrders.MultiSelect = False
        Me.dgvOrders.Name = "dgvOrders"
        Me.dgvOrders.ReadOnly = True
        Me.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrders.Size = New System.Drawing.Size(518, 207)
        Me.dgvOrders.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.dgvOrders, "Click on the left arrow of the desired row to select an order to work with.")
        '
        'lblSelectedOrder
        '
        Me.lblSelectedOrder.AutoSize = True
        Me.lblSelectedOrder.Location = New System.Drawing.Point(8, 233)
        Me.lblSelectedOrder.Name = "lblSelectedOrder"
        Me.lblSelectedOrder.Size = New System.Drawing.Size(84, 13)
        Me.lblSelectedOrder.TabIndex = 7
        Me.lblSelectedOrder.Text = "Selected Order: "
        '
        'btnPrint
        '
        Me.btnPrint.Enabled = False
        Me.btnPrint.Location = New System.Drawing.Point(10, 389)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(125, 23)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print Selected Image"
        Me.ToolTip1.SetToolTip(Me.btnPrint, "Prints the selected image.")
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'tmrUpdate
        '
        Me.tmrUpdate.Interval = 60000
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'lblPrinterConfig
        '
        Me.lblPrinterConfig.AutoSize = True
        Me.lblPrinterConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrinterConfig.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPrinterConfig.Location = New System.Drawing.Point(147, 435)
        Me.lblPrinterConfig.Name = "lblPrinterConfig"
        Me.lblPrinterConfig.Size = New System.Drawing.Size(211, 26)
        Me.lblPrinterConfig.TabIndex = 23
        Me.lblPrinterConfig.Text = "The printers configuration is empty. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This is required to continue."
        Me.lblPrinterConfig.Visible = False
        '
        'frmOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 467)
        Me.Controls.Add(Me.lblPrinterConfig)
        Me.Controls.Add(Me.btnPrinterConfig)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.grpBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmOrders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOrders"
        Me.grpBox.ResumeLayout(False)
        Me.grpBox.PerformLayout()
        CType(Me.dgvImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrinterConfig As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents grpBox As System.Windows.Forms.GroupBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents dgvImages As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPrintLabel As System.Windows.Forms.Button
    Friend WithEvents dgvOrders As System.Windows.Forms.DataGridView
    Friend WithEvents lblSelectedOrder As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents tmrUpdate As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents lblPrinterConfig As System.Windows.Forms.Label
End Class
