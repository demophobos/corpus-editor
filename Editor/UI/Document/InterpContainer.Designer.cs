
namespace Document
{
    partial class InterpContainer
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterpContainer));
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "Добавить перевод";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(663, 343);
            this.dockPanel1.TabIndex = 12;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(663, 25);
            this.toolStrip2.TabIndex = 13;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // InterpContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 368);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.toolStrip2);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.HideOnClose = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterpContainer";
            this.Text = "Переводы";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnAdd;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
    }
}
