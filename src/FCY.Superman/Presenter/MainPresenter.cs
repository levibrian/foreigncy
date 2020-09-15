using FCY.Cyborg.APIResultObjects;
using FCY.Cyborg.DTOs;
using FCY.Superman.Interfaces.Main;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCY.Superman.Presenter
{
    public class MainPresenter : Presenter
    {
        private readonly IMainView mainView;
        private string allCurrenciesApi = System.Configuration.ConfigurationManager.AppSettings["allCurrenciesApi"];
        private string dolarOficialApi = System.Configuration.ConfigurationManager.AppSettings["dolarOficialApi"];

        public MainPresenter(IMainView mainView)
        {
            this.mainView = mainView;
        }

        public async Task<List<CurrencyDTO>> GetCurrencies()
        {
            var apiResults = await base.Get<RootObject>(allCurrenciesApi);
            apiResults.AddRange(await base.Get<RootObject>(dolarOficialApi));

            try
            {
                var currencyList = new List<CurrencyDTO>();

                foreach (var root in apiResults)
                {
                    currencyList.Add(new CurrencyDTO()
                    {
                        Compra = root.casa.compra,
                        Venta = root.casa.venta,
                        Nombre = root.casa.nombre,
                        Variacion = root.casa.variacion
                    });
                }

                return currencyList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
