﻿namespace CentralLog.Listener
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
      this.SuspendLayout();
      // 
      // tbx_output
      // 
      this.tbx_output.Location = new System.Drawing.Point(12, 12);
      this.tbx_output.Multiline = true;
      this.tbx_output.Name = "tbx_output";
      this.tbx_output.Size = new System.Drawing.Size(910, 238);
      this.tbx_output.TabIndex = 0;
      // 
      // frm_Listener
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(934, 262);
      this.Controls.Add(this.tbx_output);
      this.Name = "frm_Listener";
      this.Text = "Log Listener";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbx_output;
  }
}

