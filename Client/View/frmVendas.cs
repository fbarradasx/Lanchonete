using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Http;
using Client.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Client
{
    public partial class frmVendas : Form
    {
		private readonly string URI = "";

		private int timeLeft;

		private int idPedido = 0;

		private List<Promocao> promocao;

		public frmVendas()
        {
            InitializeComponent();

			URI = ConfigurationManager.AppSettings.Get("enderecoUri");

			InicializarPedido();
        }

        private void InicializarPedido()
        {
			BuscarLanche();

			BuscarIdUltimoPedido();

			BuscarPromocao();

			timer1.Start();
		}


        private async void BuscarIdUltimoPedido()
		{
			using (var client = new HttpClient())
			{
				HttpResponseMessage response = await client.PostAsync(URI + "/Pedido/PegarId/", (HttpContent)null);
				if (response.IsSuccessStatusCode)
				{
					new BindingSource();
					idPedido = int.Parse(await response.Content.ReadAsStringAsync());
				}
				else
				{
					MessageBox.Show("Resultado não encontrado: " + response.StatusCode);
				}
			}
		}

		private async void BuscarLanche()
		{
			using (var client = new HttpClient())
			{
				HttpResponseMessage response = await client.PostAsync(URI + "/Lanche/Listar", (HttpContent)null);
				if (response.IsSuccessStatusCode)
				{
					string LancheJsonString = await response.Content.ReadAsStringAsync();
					dbGridLanche.DataSource = JsonConvert.DeserializeObject<Lanche[]>(LancheJsonString).ToList();
					dbGridLanche.Columns[0].Visible = false;
					dbGridLanche.Columns[1].HeaderText = "Nome do Lanche";
					dbGridLanche.Columns[1].Width = 180;
					dbGridLanche.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
					DataGridViewButtonColumn addColumn = new DataGridViewButtonColumn
					{
						HeaderText = "",
						UseColumnTextForButtonValue = true,
						Text = "+",
						Width = 30
					};
					dbGridLanche.Columns.Add(addColumn);
					DataGridViewButtonColumn subColumn = new DataGridViewButtonColumn
					{
						HeaderText = "",
						UseColumnTextForButtonValue = true,
						Text = "-",
						Width = 30
					};
					dbGridLanche.Columns.Add(subColumn);
				}
				else
				{
					MessageBox.Show("Resultado não encontrado: " + response.StatusCode);
				}
			}
		}

		private async void BuscarPedido()
		{
			using (var client = new HttpClient())
			{
				HttpResponseMessage response = await client.PostAsync(URI + "/Pedido/Listar/" + idPedido.ToString(), (HttpContent)null);
				if (response.IsSuccessStatusCode)
				{
					string ListaPedidoJsonString = await response.Content.ReadAsStringAsync();
					dbGridPedido.DataSource = JsonConvert.DeserializeObject<ListaPedido[]>(ListaPedidoJsonString).ToList();

					dbGridPedido.Columns[0].Visible = false;
					dbGridPedido.Columns[1].Visible = false;
					dbGridPedido.Columns[2].HeaderText = "Nome do Lanche";
					dbGridPedido.Columns[2].Width = 180;
					dbGridPedido.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
					dbGridPedido.Columns[3].HeaderText = "QTD";
					dbGridPedido.Columns[3].Width = 50;
					dbGridPedido.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dbGridPedido.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
					dbGridPedido.Columns[4].HeaderText = "Valor";
					dbGridPedido.Columns[4].Width = 100;
					dbGridPedido.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dbGridPedido.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
					dbGridPedido.Columns[4].DefaultCellStyle.Format = "0.00##";

					decimal valor = 0;
					for (int i = 0; i < dbGridPedido.Rows.Count; ++i)
					{
						valor += Convert.ToDecimal(dbGridPedido.Rows[i].Cells[4].Value);
					}
					txtValorTotal.Text = valor.ToString("C");
				}
				else
				{
					MessageBox.Show("Resultado não encontrado: " + response.StatusCode);
				}
			}
		}
				

		private async void AdicionarLanche(int id, int qtd, decimal valor)
		{
			Pedido pedido = new Pedido
			{
				Id = idPedido,
				IdLanche = id,
				Quantidade = qtd,
				Valor = valor
			};

			using (var client = new HttpClient())
            {
				string serializedProduto = JsonConvert.SerializeObject(pedido);

				StringContent content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");

				await client.PostAsync(URI + "/Pedido/Incluir", (HttpContent)(object)content);
			}

			BuscarPedido();
		}

		private async void SubtrairLanche(int id, int qtd, decimal valor)
		{
			Pedido pedido = new Pedido
			{
				Id = idPedido,
				IdLanche = id,
				Quantidade = qtd,
				Valor = valor
			};
			using (var client = new HttpClient())
			{
				string serializedProduto = JsonConvert.SerializeObject(pedido);
				StringContent content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
				await client.PostAsync(URI + "/Pedido/Excluir", (HttpContent)(object)content);
			}

			BuscarPedido();

		}


		private async void BuscarIngredientes(int idLanche)
		{
			using (var client = new HttpClient())
			{
				HttpResponseMessage response = await client.PostAsync(URI + "/Lanche/BuscarIngredientes/" + idLanche, (HttpContent)null);

				if (response.IsSuccessStatusCode)
				{
					dbGridIngredientes.DataSource = null;
					dbGridIngredientes.Rows.Clear();
					dbGridIngredientes.Refresh();
					string LancheIngredienteJsonString = await response.Content.ReadAsStringAsync();
					dbGridIngredientes.AutoGenerateColumns = true;
					dbGridIngredientes.DataSource = JsonConvert.DeserializeObject<LancheIngrediente[]>(LancheIngredienteJsonString).ToList();
					dbGridIngredientes.Columns[0].Visible = false;
					dbGridIngredientes.Columns[1].Visible = false;
					dbGridIngredientes.Columns[2].HeaderText = "Nome do Lanche";
					dbGridIngredientes.Columns[2].Width = 180;
					dbGridIngredientes.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
					dbGridIngredientes.Columns[3].HeaderText = "Porção";
					dbGridIngredientes.Columns[3].Width = 70;
					dbGridIngredientes.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
					dbGridIngredientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dbGridIngredientes.Columns[4].HeaderText = "Valor";
					dbGridIngredientes.Columns[4].Width = 100;
					dbGridIngredientes.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
					dbGridIngredientes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				}
				else
				{
					MessageBox.Show("Resultado não encontrado: " + response.StatusCode);
				}
			}
		}

		private void dbGridLanche_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.RowIndex >= 0)
			{
				int idLanche = (int)dbGridLanche.SelectedCells[0].Value;

				switch (e.ColumnIndex)
				{
					case 1:
						{
							BuscarIngredientes(idLanche);
							break;
						}

					case 2:
						{
							if (dbGridIngredientes.DataSource != null)
							{
								int qtdIngredientes = (int)dbGridIngredientes.SelectedCells[3].Value;

								decimal valorIngrediente = 0;

								decimal valorLanche = 0;

								decimal desconto = 1;


								for (int i = 0; i < dbGridIngredientes.Rows.Count; ++i)
								{
									valorIngrediente = Convert.ToDecimal(dbGridIngredientes.Rows[i].Cells[4].Value);
									int idIngrediente = (int)dbGridIngredientes.Rows[i].Cells[1].Value;
									int qtdPorcao = (int)dbGridIngredientes.Rows[i].Cells[3].Value;

									if (qtdPorcao > 0)
									{
										valorLanche += valorIngrediente * qtdPorcao;

										foreach(Promocao item in promocao)
                                        {
											if ((idIngrediente == item.IdIngrediente) &&
											 (qtdPorcao >= item.Quantidade) &&
											 (item.Quantidade > 0) && item.IdIngredienteSem == 0)
											{

												valorLanche -= ((valorLanche / qtdPorcao) * item.PorcaoDesconto);
												break;
											}
											
											if (item.Quantidade == 0 && item.PorcentagemDesconto > 0 && idIngrediente == item.IdIngrediente)
											{
												desconto = item.PorcentagemDesconto;
												break;
											}
										}
									}
								}

								if (valorLanche != 0)
                                {
									if (desconto != 1 )
                                    {
										valorLanche = valorLanche - (valorLanche * desconto);
									}

									AdicionarLanche(idLanche, 1, valorLanche);
								}
								else
									MessageBox.Show("Escolher no mínimo 1 ingrediente");
							}
							break;
						}

					case 3:
						{
							if (dbGridIngredientes.DataSource != null)
							{
								int qtdSu = (int)dbGridIngredientes.SelectedCells[3].Value;
								decimal valorSu = 0;
								for (int i = 0; i < dbGridIngredientes.Rows.Count; ++i)
								{
									if (Convert.ToInt32(dbGridIngredientes.Rows[i].Cells[3].Value) > 0)
										valorSu += Convert.ToDecimal(dbGridIngredientes.Rows[i].Cells[4].Value);
								}
								if (valorSu != 0 || idLanche == 0)
									SubtrairLanche(idLanche, qtdSu, valorSu);
							}
							break;
						}
				}
			}
		}

		private void timer1_Tick_1(object sender, EventArgs e)
		{
			timeLeft++;
			textTempo.Text = timeLeft.ToString();
		}

		private void btnFechar_Click(object sender, EventArgs e)
        {
			timer1.Stop();

			TimeSpan time = TimeSpan.FromSeconds(timeLeft);

			MessageBox.Show(string.Format("Pedido Fechado em {0} segundos, no valor total de {1}", time.ToString(@"mm\:ss"), txtValorTotal.Text));

			Application.Restart();
		}

        private void dbGridIngredientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.RowIndex >= 0 && dbGridIngredientes.Rows[e.RowIndex].Cells[0].Value.ToString() == "0")
			{
				string Item = dbGridIngredientes.Rows[e.RowIndex].Cells[3].Value.ToString();
				int quantidade = int.Parse(Item);
				dbGridIngredientes.Rows[e.RowIndex].Cells[3].Value = (quantidade + 1).ToString();
			}
		}

		private void dbGridIngredientes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (e.RowIndex >= 0 && dbGridIngredientes.Rows[e.RowIndex].Cells[0].Value.ToString() == "0")
				{
					string Item = dbGridIngredientes.Rows[e.RowIndex].Cells[3].Value.ToString();
					int quantidade = int.Parse(Item);
					if (quantidade >0)
                    {
						dbGridIngredientes.Rows[e.RowIndex].Cells[3].Value = (quantidade - 1).ToString();
					}
				}
			}
		}


		private async void BuscarPromocao()
		{
			using (var client = new HttpClient())
			{
				HttpResponseMessage response = await client.PostAsync(URI + "/Promocao/Listar/", (HttpContent)null);
				if (response.IsSuccessStatusCode)
				{
					string ListaPedidoJsonString = await response.Content.ReadAsStringAsync();
					promocao = JsonConvert.DeserializeObject<List<Promocao>>(ListaPedidoJsonString);
				}
				else
				{
					MessageBox.Show("Resultado não encontrado: " + response.StatusCode);
				}
			}

		}
	}
}
