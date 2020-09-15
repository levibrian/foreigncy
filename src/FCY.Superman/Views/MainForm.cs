using FCY.Cyborg.DTOs;
using FCY.Superman.Interfaces.Main;
using FCY.Superman.Presenter;
using FCY.Superman.Views.Shared;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCY.Superman.Views
{
    public partial class MainForm : BaseForm, IMainView
    {
        private readonly MainPresenter _presenter;

        // Constructor
        public MainForm()
        {
            InitializeComponent();

            _presenter = new MainPresenter(this);
            this.BorderStyle = MetroFormBorderStyle.FixedSingle;
            this.ShadowType = MetroFormShadowType.AeroShadow;
        }

        // Events
        private async void AllTabPanelOnGotFocus(object sender, EventArgs e)
        {
            var allCurrenciesValues = await _presenter.GetCurrencies();

            SetAllCurrenciesPanels(allCurrenciesValues);
        }

        private void AllTabPanelOnLostFocus(object sender, EventArgs e)
        {
            lblDolarOficialCompra.Visible = false;
            lblDolarOficialVenta.Visible = false;
            psDolarOficialCompra.Visible = true;
            psDolarOficialVenta.Visible = true;

            lblEuroCompra.Visible = false;
            lblEuroVenta.Visible = false;
            psEuroCompra.Visible = true;
            psEuroVenta.Visible = true;

            lblRealCompra.Visible = false;
            lblRealVenta.Visible = false;
            psRealCompra.Visible = true;
            psRealVenta.Visible = true;

            lblLibraCompra.Visible = false;
            lblLibraVenta.Visible = false;
            psLibraCompra.Visible = true;
            psLibraVenta.Visible = true;

            lblBitcoinCompra.Visible = false;
            lblBitcoinVenta.Visible = false;
            psBitcoinCompra.Visible = true;
            psBitcoinVenta.Visible = true;

            lblPesoUruguayoCompra.Visible = false;
            lblPesoUruguayoVenta.Visible = false;
            psPesoUruguayoCompra.Visible = true;
            psPesoUruguayoVenta.Visible = true;

            lblPesoChilenoCompra.Visible = false;
            lblPesoChilenoVenta.Visible = false;
            psPesoChilenoCompra.Visible = true;
            psPesoChilenoVenta.Visible = true;

            lblGuaraniCompra.Visible = false;
            lblGuaraniVenta.Visible = false;
            psGuaraniCompra.Visible = true;
            psGuaraniVenta.Visible = true;
        }

        private void DolarCardOnClick(object sender, EventArgs e)
        {
            metroTabControl1.SelectedIndex = 1;
        }

        // Methods
        private void SetAllCurrenciesPanels(List<CurrencyDTO> currencies)
        {
            var dolarOficial = currencies.FirstOrDefault(x => x.Nombre.Equals("Dolar"));
            var euro = currencies.FirstOrDefault(x => x.Nombre.Equals("Euro"));
            var real = currencies.FirstOrDefault(x => x.Nombre.Equals("Real"));
            var libra = currencies.FirstOrDefault(x => x.Nombre.Equals("Libra Esterlina"));
            var bitcoin = currencies.FirstOrDefault(x => x.Nombre.Equals("Bitcoin"));
            var pesoUruguayo = currencies.FirstOrDefault(x => x.Nombre.Equals("Peso Uruguayo"));
            var pesoChileno = currencies.FirstOrDefault(x => x.Nombre.Equals("Peso Chileno"));
            var guarani = currencies.FirstOrDefault(x => x.Nombre.Equals("Guaraní"));


            lblDolarOficialCompra.Text = dolarOficial.Compra;
            lblDolarOficialVenta.Text = dolarOficial.Venta;
            lblDolarOficialCompra.Visible = true;
            lblDolarOficialVenta.Visible = true;
            psDolarOficialCompra.Visible = false;
            psDolarOficialVenta.Visible = false;


            lblEuroCompra.Text = euro.Compra;
            lblEuroVenta.Text = euro.Venta;
            lblEuroCompra.Visible = true;
            lblEuroVenta.Visible = true;
            psEuroCompra.Visible = false;
            psEuroVenta.Visible = false;


            lblRealCompra.Text = real.Compra;
            lblRealVenta.Text = real.Venta;
            lblRealCompra.Visible = true;
            lblRealVenta.Visible = true;
            psRealCompra.Visible = false;
            psRealVenta.Visible = false;


            lblLibraCompra.Text = libra.Compra;
            lblLibraVenta.Text = libra.Venta;
            lblLibraCompra.Visible = true;
            lblLibraVenta.Visible = true;
            psLibraCompra.Visible = false;
            psLibraVenta.Visible = false;

            lblBitcoinCompra.Text = bitcoin.Compra;
            lblBitcoinVenta.Text = bitcoin.Venta;
            lblBitcoinCompra.Visible = true;
            lblBitcoinVenta.Visible = true;
            psBitcoinCompra.Visible = false;
            psBitcoinVenta.Visible = false;


            lblPesoUruguayoCompra.Text = pesoUruguayo.Compra;
            lblPesoUruguayoVenta.Text = pesoUruguayo.Venta;
            lblPesoUruguayoCompra.Visible = true;
            lblPesoUruguayoVenta.Visible = true;
            psPesoUruguayoCompra.Visible = false;
            psPesoUruguayoVenta.Visible = false;

            lblPesoChilenoCompra.Text = pesoChileno.Compra;
            lblPesoChilenoVenta.Text = pesoChileno.Venta;
            lblPesoChilenoCompra.Visible = true;
            lblPesoChilenoVenta.Visible = true;
            psPesoChilenoCompra.Visible = false;
            psPesoChilenoVenta.Visible = false;

            lblGuaraniCompra.Text = guarani.Compra;
            lblGuaraniVenta.Text = guarani.Venta;
            lblGuaraniCompra.Visible = true;
            lblGuaraniVenta.Visible = true;
            psGuaraniCompra.Visible = false;
            psGuaraniVenta.Visible = false;
        }
    }
}
