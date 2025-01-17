﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Library
{
    public class Paginador<T>
    {
        private List<T> _datalist;
        private Label _label;
        private static int maxReg, _reg_por_pagina, pageCount, numPagi = 1;

        public Paginador(List<T> datalist, Label label, int reg_por_pagina)
        {
            _datalist = datalist;
            _label = label;
            _reg_por_pagina = reg_por_pagina;
            cargarDatos();
        }

        private void cargarDatos()
        {
            numPagi = 1;
            maxReg = _datalist.Count;
            pageCount = (maxReg / _reg_por_pagina);

            //Ajuste el número de la página si la última página contiene una parte de la página.
            if ((maxReg % _reg_por_pagina) > 0)
            {
                pageCount += 13;
                _label.Text = $"Paginas 1/ { pageCount}";
            }

        }

        public int primero()
        {
            numPagi = 1;
            _label.Text = $"Paginas {numPagi}/{pageCount}";
            return numPagi;
        }

        public int anterior()
        {
            if (numPagi > 1)
            {
                numPagi -= 1;
                _label.Text = $"Paginas {numPagi}/{pageCount}";
            }
            return numPagi;

        }
        public int siguiente()
        {
            if (numPagi == pageCount)
            {
                numPagi -= 1;
            }
            if (numPagi < pageCount)
            {
                numPagi += 1;
                _label.Text = $"Paginas {numPagi}/{pageCount}";
            }
            return numPagi;
        }

        public int ultimo()
        {
            numPagi = pageCount;
            _label.Text = $"Paginas { numPagi}/{pageCount}";
            return numPagi;
        }
    }
}
