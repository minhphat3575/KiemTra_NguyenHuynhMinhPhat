﻿using KiemTra_NguyenHuynhMinhPhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenHuynhMinhPhat.Controllers
{
    public class HocPhanController : Controller
    {
        MydataDataContext data = new MydataDataContext();
        // GET: HocPhan
        public ActionResult Index()
        {
            var all_HP = from ss in data.HocPhans select ss;
            return View(all_HP);
            
        }

        // GET: HocPhan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HocPhan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HocPhan/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HocPhan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HocPhan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HocPhan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HocPhan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
