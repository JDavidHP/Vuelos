using ServicioWeb.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VervicioWeb.Datos.Model.ViewStations;

namespace Vuelos.Controllers
{
    public class StationsController : Controller
    {
        // GET: Stations
        public ActionResult Index()
        {

            List<TablaStation> lst = null;
            using (VuelosConnection db = new VuelosConnection())
            {
                lst = (from S in db.Station
                       select new TablaStation
                       {
                           Iata = S.Iata,
                           Name = S.Name,
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(S =>
            {
                return new SelectListItem()
                {
                    Text = S.Name.ToString(),
                    Value = S.Iata.ToString(),
                    Selected = false
                };
            });

            ViewBag.Items = items;

            ViewData["Fecha"] = DateTime.Now.ToString("yyyy-mm-dd");

            return View();
        }
    }
}