using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Controllers
{
    public class PacienteController : Controller
    {
        private static readonly List<Paciente> _pacienteList = new List<Paciente>();
        

        // GET: Paciente
        public ActionResult Index()
        {
            return View(_pacienteList);
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int id)
        {
            Paciente pacienteSelecionado = _pacienteList.FirstOrDefault(x => x.Id == id);

            return View(pacienteSelecionado);
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Paciente novoPaciente = new Paciente();
                novoPaciente.Nome = collection["Nome"];
                novoPaciente.DataNascimento = Convert.ToDateTime(collection["DataNascimento"]);
                novoPaciente.Id = Convert.ToInt32(collection["Id"]);

                _pacienteList.Add(novoPaciente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int id)
        {
            Paciente pacienteSelecionado = _pacienteList.FirstOrDefault(x => x.Id == id);

            return View(pacienteSelecionado);
        }

        // POST: Paciente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Paciente pacienteSelecionado = _pacienteList.FirstOrDefault(x => x.Id == id);
                pacienteSelecionado.Nome = collection["Nome"];
                pacienteSelecionado.DataNascimento = Convert.ToDateTime(collection["DataNascimento"]);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int id)
        {
            Paciente pacienteSelecionado = _pacienteList.FirstOrDefault(x => x.Id == id);

            return View(pacienteSelecionado);
        }

        // POST: Paciente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Paciente pacienteSelecionado = _pacienteList.FirstOrDefault(x => x.Id == id);

                _pacienteList.Remove(pacienteSelecionado);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}