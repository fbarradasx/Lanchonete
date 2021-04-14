
namespace Client
{
    partial class frmVendas
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxLanches = new System.Windows.Forms.GroupBox();
            this.dbGridLanche = new System.Windows.Forms.DataGridView();
            this.groupBoxMontar = new System.Windows.Forms.GroupBox();
            this.dbGridIngredientes = new System.Windows.Forms.DataGridView();
            this.groupBoxPedido = new System.Windows.Forms.GroupBox();
            this.dbGridPedido = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textTempo = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblTotalPedido = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.groupBoxLanches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridLanche)).BeginInit();
            this.groupBoxMontar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridIngredientes)).BeginInit();
            this.groupBoxPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // groupBoxLanches
            // 
            this.groupBoxLanches.Controls.Add(this.dbGridLanche);
            this.groupBoxLanches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLanches.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLanches.Name = "groupBoxLanches";
            this.groupBoxLanches.Size = new System.Drawing.Size(335, 216);
            this.groupBoxLanches.TabIndex = 0;
            this.groupBoxLanches.TabStop = false;
            this.groupBoxLanches.Text = "Lanches";
            // 
            // dbGridLanche
            // 
            this.dbGridLanche.AllowUserToAddRows = false;
            this.dbGridLanche.AllowUserToDeleteRows = false;
            this.dbGridLanche.AllowUserToResizeColumns = false;
            this.dbGridLanche.AllowUserToResizeRows = false;
            this.dbGridLanche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridLanche.Location = new System.Drawing.Point(6, 19);
            this.dbGridLanche.Name = "dbGridLanche";
            this.dbGridLanche.ReadOnly = true;
            this.dbGridLanche.RowHeadersVisible = false;
            this.dbGridLanche.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridLanche.Size = new System.Drawing.Size(316, 191);
            this.dbGridLanche.TabIndex = 0;
            this.dbGridLanche.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbGridLanche_CellClick);
            // 
            // groupBoxMontar
            // 
            this.groupBoxMontar.Controls.Add(this.dbGridIngredientes);
            this.groupBoxMontar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMontar.Location = new System.Drawing.Point(353, 12);
            this.groupBoxMontar.Name = "groupBoxMontar";
            this.groupBoxMontar.Size = new System.Drawing.Size(454, 216);
            this.groupBoxMontar.TabIndex = 1;
            this.groupBoxMontar.TabStop = false;
            this.groupBoxMontar.Text = "Ingredientes";
            // 
            // dbGridIngredientes
            // 
            this.dbGridIngredientes.AllowUserToAddRows = false;
            this.dbGridIngredientes.AllowUserToDeleteRows = false;
            this.dbGridIngredientes.AllowUserToResizeColumns = false;
            this.dbGridIngredientes.AllowUserToResizeRows = false;
            this.dbGridIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridIngredientes.Location = new System.Drawing.Point(6, 19);
            this.dbGridIngredientes.Name = "dbGridIngredientes";
            this.dbGridIngredientes.ReadOnly = true;
            this.dbGridIngredientes.RowHeadersVisible = false;
            this.dbGridIngredientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridIngredientes.Size = new System.Drawing.Size(442, 191);
            this.dbGridIngredientes.TabIndex = 1;
            this.dbGridIngredientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbGridIngredientes_CellClick);
            this.dbGridIngredientes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dbGridIngredientes_CellMouseDown);
            // 
            // groupBoxPedido
            // 
            this.groupBoxPedido.Controls.Add(this.dbGridPedido);
            this.groupBoxPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPedido.Location = new System.Drawing.Point(12, 234);
            this.groupBoxPedido.Name = "groupBoxPedido";
            this.groupBoxPedido.Size = new System.Drawing.Size(452, 187);
            this.groupBoxPedido.TabIndex = 2;
            this.groupBoxPedido.TabStop = false;
            this.groupBoxPedido.Text = "Pedido";
            // 
            // dbGridPedido
            // 
            this.dbGridPedido.AllowUserToAddRows = false;
            this.dbGridPedido.AllowUserToDeleteRows = false;
            this.dbGridPedido.AllowUserToResizeColumns = false;
            this.dbGridPedido.AllowUserToResizeRows = false;
            this.dbGridPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridPedido.Location = new System.Drawing.Point(6, 17);
            this.dbGridPedido.Name = "dbGridPedido";
            this.dbGridPedido.ReadOnly = true;
            this.dbGridPedido.RowHeadersVisible = false;
            this.dbGridPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridPedido.Size = new System.Drawing.Size(440, 164);
            this.dbGridPedido.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 444);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tempo";
            // 
            // textTempo
            // 
            this.textTempo.Enabled = false;
            this.textTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTempo.Location = new System.Drawing.Point(76, 441);
            this.textTempo.Margin = new System.Windows.Forms.Padding(2);
            this.textTempo.Name = "textTempo";
            this.textTempo.Size = new System.Drawing.Size(63, 26);
            this.textTempo.TabIndex = 34;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Lime;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFechar.Location = new System.Drawing.Point(676, 432);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 50);
            this.btnFechar.TabIndex = 33;
            this.btnFechar.Text = "Fechar Pedido";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // lblTotalPedido
            // 
            this.lblTotalPedido.AutoSize = true;
            this.lblTotalPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPedido.Location = new System.Drawing.Point(636, 337);
            this.lblTotalPedido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPedido.Name = "lblTotalPedido";
            this.lblTotalPedido.Size = new System.Drawing.Size(160, 20);
            this.lblTotalPedido.TabIndex = 32;
            this.lblTotalPedido.Text = "Valor Total do Pedido";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.Location = new System.Drawing.Point(634, 359);
            this.txtValorTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(162, 26);
            this.txtValorTotal.TabIndex = 31;
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 490);
            this.Controls.Add(this.textTempo);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblTotalPedido);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxPedido);
            this.Controls.Add(this.groupBoxMontar);
            this.Controls.Add(this.groupBoxLanches);
            this.Name = "frmVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lanchonete";
            this.groupBoxLanches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridLanche)).EndInit();
            this.groupBoxMontar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridIngredientes)).EndInit();
            this.groupBoxPedido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridPedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBoxLanches;
        private System.Windows.Forms.DataGridView dbGridLanche;
        private System.Windows.Forms.GroupBox groupBoxMontar;
        private System.Windows.Forms.DataGridView dbGridIngredientes;
        private System.Windows.Forms.GroupBox groupBoxPedido;
        private System.Windows.Forms.DataGridView dbGridPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTempo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblTotalPedido;
        private System.Windows.Forms.TextBox txtValorTotal;
    }
}

