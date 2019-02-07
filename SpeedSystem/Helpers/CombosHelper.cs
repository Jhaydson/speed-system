﻿using SpeedSystem.Data;
using SpeedSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedSystem.Helpers
{
    public class CombosHelper : IDisposable
    {

        private static SpeedContext db = new SpeedContext();



        /**
         * Reordena meu combo list
         * 
         * */
        public static List<Measure> GetMeasures()
        {

            //Ordenando lista do banco de dados
            var mea = db.Measures.ToList();
            mea.Add(new Measure
            {
                MeasureId = 0,
                Name = " Selecione uma opção"
            });

            return mea = mea.OrderBy(m => m.Name).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}