
namespace MonitorDeProcesos
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalProcessorTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHilos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkingSet64 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrioridad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.BtnFinalizar = new DevExpress.XtraEditors.SimpleButton();
            this.colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(984, 426);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNombre,
            this.colTotalProcessorTime,
            this.colHilos,
            this.colStartTime,
            this.colWorkingSet64,
            this.colPrioridad,
            this.colUsuario});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "ProcessName";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            // 
            // colTotalProcessorTime
            // 
            this.colTotalProcessorTime.Caption = "TiempoTotalProcesador";
            this.colTotalProcessorTime.FieldName = "TotalProcessorTime";
            this.colTotalProcessorTime.Name = "colTotalProcessorTime";
            this.colTotalProcessorTime.Visible = true;
            this.colTotalProcessorTime.VisibleIndex = 2;
            // 
            // colHilos
            // 
            this.colHilos.Caption = "Hilos";
            this.colHilos.FieldName = "Hilos";
            this.colHilos.Name = "colHilos";
            this.colHilos.Visible = true;
            this.colHilos.VisibleIndex = 3;
            // 
            // colStartTime
            // 
            this.colStartTime.Caption = "StartTime";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 4;
            // 
            // colWorkingSet64
            // 
            this.colWorkingSet64.Caption = "Uso Memoria (MB)";
            this.colWorkingSet64.FieldName = "WorkingSet64";
            this.colWorkingSet64.Name = "colWorkingSet64";
            this.colWorkingSet64.Visible = true;
            this.colWorkingSet64.VisibleIndex = 5;
            // 
            // colPrioridad
            // 
            this.colPrioridad.Caption = "Prioridad";
            this.colPrioridad.FieldName = "Prioridad";
            this.colPrioridad.Name = "colPrioridad";
            this.colPrioridad.Visible = true;
            this.colPrioridad.VisibleIndex = 6;
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.ImageOptions.Image = global::MonitorDeProcesos.Properties.Resources.cancel_32x32;
            this.BtnFinalizar.Location = new System.Drawing.Point(866, 444);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(130, 39);
            this.BtnFinalizar.TabIndex = 1;
            this.BtnFinalizar.Text = "Terminar Proceso";
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // colUsuario
            // 
            this.colUsuario.Caption = "Usuario";
            this.colUsuario.FieldName = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.Visible = true;
            this.colUsuario.VisibleIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 494);
            this.Controls.Add(this.BtnFinalizar);
            this.Controls.Add(this.gridControl1);
            this.Name = "Main";
            this.Text = "Monitor de procesos";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalProcessorTime;
        private DevExpress.XtraGrid.Columns.GridColumn colHilos;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkingSet64;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SimpleButton BtnFinalizar;
        private DevExpress.XtraGrid.Columns.GridColumn colPrioridad;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
    }
}

