namespace CentralLog.EventGeneratorDemo
{
  partial class frm_EventGeneratorDemo
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
      this.btn_LogEvent = new System.Windows.Forms.Button();
      this.tbx_EventMessage = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btn_LogEvent
      // 
      this.btn_LogEvent.Location = new System.Drawing.Point(352, 10);
      this.btn_LogEvent.Name = "btn_LogEvent";
      this.btn_LogEvent.Size = new System.Drawing.Size(75, 23);
      this.btn_LogEvent.TabIndex = 0;
      this.btn_LogEvent.Text = "Create Log Event";
      this.btn_LogEvent.UseVisualStyleBackColor = true;
      this.btn_LogEvent.Click += new System.EventHandler(this.btn_LogEvent_Click);
      // 
      // tbx_EventMessage
      // 
      this.tbx_EventMessage.Location = new System.Drawing.Point(32, 12);
      this.tbx_EventMessage.Name = "tbx_EventMessage";
      this.tbx_EventMessage.Size = new System.Drawing.Size(300, 20);
      this.tbx_EventMessage.TabIndex = 1;
      this.tbx_EventMessage.Text = "this is a test event";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(653, 207);
      this.Controls.Add(this.tbx_EventMessage);
      this.Controls.Add(this.btn_LogEvent);
      this.Name = "Form1";
      this.Text = "Log Generator Demo";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btn_LogEvent;
    private System.Windows.Forms.TextBox tbx_EventMessage;
  }
}

