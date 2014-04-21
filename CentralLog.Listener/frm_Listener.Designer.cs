namespace CentralLog.Listener
{
  partial class frm_Listener
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.tbx_output = new System.Windows.Forms.TextBox();
      this.btn_ConnectHub = new System.Windows.Forms.Button();
      this.tbx_SignalrHost = new System.Windows.Forms.TextBox();
      this.btn_TestSend = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // tbx_output
      // 
      this.tbx_output.Location = new System.Drawing.Point(12, 12);
      this.tbx_output.Multiline = true;
      this.tbx_output.Name = "tbx_output";
      this.tbx_output.Size = new System.Drawing.Size(600, 238);
      this.tbx_output.TabIndex = 0;
      // 
      // btn_ConnectHub
      // 
      this.btn_ConnectHub.Location = new System.Drawing.Point(618, 39);
      this.btn_ConnectHub.Name = "btn_ConnectHub";
      this.btn_ConnectHub.Size = new System.Drawing.Size(134, 23);
      this.btn_ConnectHub.TabIndex = 1;
      this.btn_ConnectHub.Text = "Connect to Hub";
      this.btn_ConnectHub.UseVisualStyleBackColor = true;
      this.btn_ConnectHub.Click += new System.EventHandler(this.btn_ConnectHub_Click);
      // 
      // tbx_SignalrHost
      // 
      this.tbx_SignalrHost.Location = new System.Drawing.Point(618, 13);
      this.tbx_SignalrHost.Name = "tbx_SignalrHost";
      this.tbx_SignalrHost.Size = new System.Drawing.Size(134, 20);
      this.tbx_SignalrHost.TabIndex = 2;
      // 
      // btn_TestSend
      // 
      this.btn_TestSend.Location = new System.Drawing.Point(618, 68);
      this.btn_TestSend.Name = "btn_TestSend";
      this.btn_TestSend.Size = new System.Drawing.Size(134, 23);
      this.btn_TestSend.TabIndex = 3;
      this.btn_TestSend.Text = "Test Send";
      this.btn_TestSend.UseVisualStyleBackColor = true;
      this.btn_TestSend.Click += new System.EventHandler(this.btn_TestSend_Click);
      // 
      // frm_Listener
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(934, 262);
      this.Controls.Add(this.btn_TestSend);
      this.Controls.Add(this.tbx_SignalrHost);
      this.Controls.Add(this.btn_ConnectHub);
      this.Controls.Add(this.tbx_output);
      this.Name = "frm_Listener";
      this.Text = "Log Listener";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbx_output;
    private System.Windows.Forms.Button btn_ConnectHub;
    private System.Windows.Forms.TextBox tbx_SignalrHost;
    private System.Windows.Forms.Button btn_TestSend;
  }
}

